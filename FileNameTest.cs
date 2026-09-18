using System.Text.RegularExpressions;

namespace Test
{
    public static class FileNameTest
    {
        public static string[] SplitFileName(string fileName)
        {
            // 定义正则表达式匹配格式：{DateTime}_{staff_id}_{user AD account}_{location code}
            string pattern = @"^(?<DateTime>.+)_(?<staff_id>.+)_(?<user_ad>.+)_(?<location_code>.+)$";
            Match match = Regex.Match(fileName, pattern);

            if (match.Success)
            {
                return new[]
                {
                match.Groups["DateTime"].Value,
                match.Groups["staff_id"].Value,
                match.Groups["user_ad"].Value,
                match.Groups["location_code"].Value
            };
            }
            else
            {
                return null; // 格式不符合时返回null
            }
        }
        #region 清理非法字符
        // 定义所有系统中非法的文件名字符
        private static readonly char[] InvalidFileNameChars = Path.GetInvalidFileNameChars();

        // 清理文件名中的非法字符（替换为下划线）
        private static string SanitizeFileName(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return string.Empty;

            // 替换所有非法字符为下划线
            return string.Join("_", fileName.Split(InvalidFileNameChars, StringSplitOptions.RemoveEmptyEntries));
        }

        public static void ChangeImageName()
        {
            string ImageName = "Batch_21/1 UR\\O_202601211215481" + "_" + "203567";

            ImageName = SanitizeFileName(ImageName);
            string fileName = ImageName + ".jpg";
            string tempFolderPath = "C:\\Users\\liusi\\Desktop\\signature";
            Directory.CreateDirectory(tempFolderPath);

            var tempFilePath = Path.Combine(tempFolderPath, fileName);

            Console.WriteLine(tempFilePath);
        }

        #endregion

        #region SMB讀取文件處理
        public static void ReadSmbFile()
        {
            string SmbHost = "Barry";
            string SmbPort = "445";
            string SmbShareName = "smb";
            string SmbUser = "liu.siyang@outlook.com";
            string SmbPassword = "Liu95Si08Yang26";
            string FolderRootPath = "/MRO";
            string SuccessFolderPath = "/MRO/Success"; // 成功文件夹路径
            Console.WriteLine("Read Smb File Start");

            using SmbClient client = new SmbClient(SmbHost, SmbShareName)
            {
                User = SmbUser,
                Domain = "",
                Password = SmbPassword,
                NetBiosOverTCP = false,
                Port = Convert.ToInt32(SmbPort)
            };

            //開始鏈接
            //开始连接
            client.Connect();

            //判断文件夹是否存在，不存在就创建
            if (!client.DirectoryIsExist(FolderRootPath))
            {
                client.CreateDirectory(FolderRootPath, true);
            }

            //判断Success文件夹是否存在，不存在就创建
            if (!client.DirectoryIsExist(SuccessFolderPath))
            {
                client.CreateDirectory(SuccessFolderPath, true);
            }

            //设置当前工作目录
            client.SetWorkingDirectory(FolderRootPath);

            //获取当前目录下的文件
            var files = client.GetFiles("")
                .Where(f => !f.EndsWith(".locking"))  // 過濾掉鎖文件
                .ToArray();

            // 同步休眠
            //Thread.Sleep(2000); // 休眠10秒

            foreach (var file in files)
            {

                // 初始化文件流列表
                List<MemoryStream> fileStreams = new List<MemoryStream>();
                string lockPath = $"{file}.locking"; // 锁文件路径
                bool lockAcquired = false;


                try
                {
                    //获取文件信息做信息验证
                    //获取文件的后缀
                    string FileExtensionWithDot = GetFileExtensionWithDot(file);

                    // 过滤文件类型（如果需要）
                    //if (string.IsNullOrEmpty(FileExtensionWithDot) || FileExtensionWithDot != ".pdf")
                    //{
                    //    Console.WriteLine("Smb Folder Monitor Service ReadSmbFile: Not PDF File");
                    //    continue;
                    //}

                    Console.WriteLine($"正在处理文件: {file}");

                    // ===== 步骤1：原子重命名抢锁（分布式锁核心）=====
                    // 只有一台服务器能重命名成功，其他服务器会抛异常
                    try
                    {
                        client.Rename(file, lockPath, replaceIfExists: false);
                        lockAcquired = true;
                        Console.WriteLine($"成功抢到文件锁: {file} -> {lockPath}");
                    }
                    catch (Exception ex)
                    {
                        // 如果重命名失败，说明其他服务器已经抢到锁
                        Console.WriteLine($"文件已被其他服务器锁定，跳过处理: {file}, 错误: {ex.Message}");
                        continue;
                    }

                    // ===== 步骤2：处理文件内容 =====
                    using (var memoryStream = new MemoryStream())
                    {
                        // 下载锁文件内容（此时原文件已被重命名为锁文件）
                        client.Download(lockPath, memoryStream);

                        if (memoryStream.Length > 0)
                        {
                            memoryStream.Position = 0; // 重置流位置
                            fileStreams.Add(memoryStream);
                            Console.WriteLine($"成功读取文件内容，大小: {memoryStream.Length} bytes");
                        }
                        else
                        {
                            Console.WriteLine($"文件内容为空: {lockPath}");
                            continue;
                        }
                        // 同步休眠
                        Thread.Sleep(10000); // 休眠10秒
                    }

                    // // ===== 步骤3：处理完成后删除锁文件 =====
                    // if (client.FileIsExist(lockPath))
                    // {
                    //     client.Delete(lockPath);
                    //     Console.WriteLine($"处理完成，删除锁文件: {lockPath}");
                    // }

                    // ===== 步骤4：处理文件流数据 =====
                    // if (fileStreams.Count > 0)
                    // {
                    //     // 这里可以添加你的业务逻辑处理
                    //     Console.WriteLine($"成功处理文件: {file}, 共 {fileStreams.Count} 个流");

                    //     // 示例：保存到本地（根据实际需求调整）
                    //     // string localPath = Path.Combine("D:\\ProcessedFiles", file);
                    //     // using (var fileStream = File.Create(localPath))
                    //     // {
                    //     //     fileStreams[0].CopyTo(fileStream);
                    //     // }
                    // }
                    // else
                    // {
                    //     Console.WriteLine($"文件处理失败: {file}");
                    // }


                    // ===== 步骤3：处理文件流数据 =====
                    if (fileStreams.Count > 0)
                    {
                        // 这里可以添加你的业务逻辑处理
                        Console.WriteLine($"成功处理文件: {file}, 共 {fileStreams.Count} 个流");

                        // 示例业务逻辑处理（根据实际需求调整）
                        // 这里可以添加PDF转换、数据解析等处理逻辑

                        // ===== 步骤4：处理完成后移动到Success文件夹 =====
                        string successFilePath = Path.Combine(SuccessFolderPath, file);

                        // 确保Success文件夹中不存在同名文件
                        if (client.FileIsExist(successFilePath))
                        {
                            // 如果存在同名文件，添加时间戳后缀
                            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(file);
                            string extension = Path.GetExtension(file);
                            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                            successFilePath = Path.Combine(SuccessFolderPath, $"{fileNameWithoutExt}_{timestamp}{extension}");
                        }

                        // 移动文件到Success文件夹
                        //client.Move(lockPath, SuccessFolderPath, file);
                        client.Move(lockPath, SuccessFolderPath, Path.GetFileName(successFilePath));
                        Console.WriteLine($"处理完成，文件已移动到Success文件夹: {successFilePath}");
                    }
                    else
                    {
                        Console.WriteLine($"文件处理失败: {file}");
                        // 如果处理失败，恢复原文件名
                        if (client.FileIsExist(lockPath))
                        {
                            client.Rename(lockPath, file, replaceIfExists: true);
                            Console.WriteLine($"处理失败，恢复原文件名: {file}");
                        }
                    }




                    //List<MemoryStream> Stream = null;
                    ////获取文件流
                    //using (var ms = new MemoryStream())
                    //{
                    //    client.Download(file, ms);

                    //    Stream.Add(ms);
                    //}

                    //if (Stream == null || Stream.Count() <= 0)
                    //{
                    //    //Log4Net.AddInfo($"Smb Folder Monitor Service ReadSmbFile: PDF To Imager Error");
                    //    Console.WriteLine($"Smb Folder Monitor Service ReadSmbFile: PDF To Imager Error");
                    //    continue;
                    //}
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"处理文件时发生错误: {file}, 错误: {ex.Message}");

                    // ===== 异常处理：确保锁文件被清理 =====
                    if (lockAcquired)
                    {
                        try
                        {
                            // 尝试恢复原文件名或删除锁文件
                            if (client.FileIsExist(lockPath))
                            {
                                // 如果处理失败，可以选择恢复原文件名或直接删除
                                client.Rename(lockPath, file, replaceIfExists: true); // 恢复原文件名
                                Console.WriteLine($"异常处理：恢复原文件名: {file}");
                                //client.Delete(lockPath); // 或者直接删除锁文件
                                //Console.WriteLine($"异常处理：清理锁文件: {lockPath}");
                            }
                        }
                        catch (Exception cleanupEx)
                        {
                            Console.WriteLine($"恢复原文件名失败: {cleanupEx.Message}");
                            //Console.WriteLine($"清理锁文件失败: {cleanupEx.Message}");
                        }
                    }
                }
                finally
                {
                    // ===== 确保所有流被正确释放 =====
                    foreach (var stream in fileStreams)
                    {
                        stream?.Dispose();
                    }
                    fileStreams.Clear();
                }
            }

            Console.WriteLine("所有文件处理完成");
        }

        /// <summary>
        /// 获取文件后缀（包含点号）
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>文件后缀，如果文件没有后缀则返回空字符串</returns>
        public static string GetFileExtensionWithDot(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                return string.Empty;

            try
            {
                return Path.GetExtension(filePath).ToLower();
            }
            catch (ArgumentException)
            {
                return string.Empty;
            }
        }


        /// <summary>
        /// 获取文件后缀（不包含点号）
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>文件后缀，如果文件没有后缀则返回空字符串</returns>
        public static string GetFileExtension(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                return string.Empty;

            try
            {
                string extension = Path.GetExtension(filePath);
                return string.IsNullOrEmpty(extension) ? string.Empty : extension.TrimStart('.').ToLower();
            }
            catch (ArgumentException)
            {
                return string.Empty;
            }
        }
        #endregion

        #region 文件名校验
        public static void CheckFileName()
        {
            // 測試用例
            string[] testFiles = {
               "20260121T133700_14161_xx_SMBb.pdf",           // 舊格式
               "20260121T133700_14161_xx_SMBb_1.pdf",         // 新格式 _1
               "20260121T133700_14161_xx_SMBb_0.pdf"          // 新格式 _0
            };

            foreach (string FileName in testFiles)
            {

                //string FileName = "20260121T133700_14161_xx_SMBb.pdf";

                var result = SplitAndValidateFileName(FileName);

                // Console.WriteLine(result.HasValue
                //     ? $"成功：DateTime={result.Value.dateTime:yyyy-MM-dd}, staffId={result.Value.staffId}, userAd={result.Value.userAd}, locationCode={result.Value.locationCode}"
                //     : "失败：格式/类型不符合");

                if (result.HasValue)
                {
                    Console.WriteLine($" {FileName} - 格式正確");
                    Console.WriteLine($"   日期時間: {result.Value.dateTime}");
                    Console.WriteLine($"   員工ID: {result.Value.staffId}");
                    Console.WriteLine($"   用戶賬號: {result.Value.userAd}");
                    Console.WriteLine($"   位置代碼: {result.Value.locationCode}");
                    Console.WriteLine($"   Is Combine: {result.Value.iscombine}");

                    // 狀態檢測
                    var status = GetFileNameStatus(FileName);
                    Console.WriteLine($"   狀態標記: {(status.HasValue ? status.Value.ToString() : "無")}");
                }
                else
                {
                    Console.WriteLine($" {FileName} - 格式錯誤");
                }
            }
        }

        /// <summary>
        /// 拆分並驗證檔案名稱
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>返回值：Tuple<DateTime, int, string, string> 或 null（格式/类型不符）</returns>
        public static (DateTime dateTime, int staffId, string userAd, string locationCode, string iscombine)? SplitAndValidateFileName(string fileName)
        {
            // // 正则匹配基础格式
            // string pattern = @"^(?<DateTime>.+)_(?<staff_id>.+)_(?<user_ad>.+)_(?<location_code>.+)$";
            // Match match = Regex.Match(fileName, pattern);
            // 移除文件扩展名
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(fileName);

            // 正则匹配两种格式：
            // 格式1: {DateTime}_{staff_id}_{user_ad}_{location_code}
            // 格式2: {DateTime}_{staff_id}_{user_ad}_{location_code}_{status}
            string pattern1 = @"^(?<DateTime>.+)_(?<staff_id>.+)_(?<user_ad>.+)_(?<location_code>.+)$";
            string pattern2 = @"^(?<DateTime>.+)_(?<staff_id>.+)_(?<user_ad>.+)_(?<location_code>.+)_(?<iscombine>[01])$";

            Match match1 = Regex.Match(fileNameWithoutExt, pattern1);
            Match match2 = Regex.Match(fileNameWithoutExt, pattern2);

            Match match = match2.Success ? match2 : match1;

            if (!match.Success)
                return null;

            string dateTimeStr = match.Groups["DateTime"].Value;
            string staffIdStr = match.Groups["staff_id"].Value;
            string userAd = match.Groups["user_ad"].Value;
            string locationCode = match.Groups["location_code"].Value;
            string iscombine = "false";
            if (match2.Success)
            {
                if (match.Groups["iscombine"].Value == "1")
                {
                    iscombine = "true";
                }
            }

            // 支持的所有时间格式（含 20251027164030）
            string[] allowedFormats = new[]
            {
                "yyyyMMdd",                  // 仅日期：20251027
                "yyyyMMddHHmmss",            // 无分隔符日期时间：20251027164030
                "yyyyMMddTHHmmss",           // T分隔日期时间：20251027T164030
                "yyyy-MM-dd",                // 横线日期：2025-10-27
                "yyyy-MM-ddTHH:mm:ss"        // T分隔带符号日期时间：2025-10-27T16:40:30
            };

            if (!DateTime.TryParseExact(dateTimeStr,
                allowedFormats,
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out DateTime dateTime))
            {
                return null;
            }

            if (!int.TryParse(staffIdStr, out int staffId))
                return null;


            if (string.IsNullOrEmpty(locationCode))
            {
                return null;
            }

            return (dateTime, staffId, userAd, locationCode, iscombine);
        }


        /// <summary>
        /// 检测文件名是否包含状态标记（_1 或 _0）
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns>返回状态值：1、0 或 null（无状态标记）</returns>
        public static int? GetFileNameStatus(string fileName)
        {
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(fileName);

            // 匹配格式：{DateTime}_{staff_id}_{user_ad}_{location_code}_{status}
            string pattern = @"^(?<DateTime>.+)_(?<staff_id>.+)_(?<user_ad>.+)_(?<location_code>.+)_(?<iscombine>[01])$";
            Match match = Regex.Match(fileNameWithoutExt, pattern);

            if (match.Success && int.TryParse(match.Groups["iscombine"].Value, out int status))
            {
                return status;
            }

            return null;
        }
        #endregion
    }
}
