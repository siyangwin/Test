using Renci.SshNet;
using System.Net;
using System.Text;
using SMBLibrary;
using SMBLibrary.Client;

namespace Test
{
    public static class SmbTest
    {
        // ===== SFTP =====
        #region sftp
        /// <summary>
        /// 将文本内容通过流写入SFTP服务器
        /// </summary>
        /// <param name="host">SFTP服务器地址</param>
        /// <param name="port">端口号（默认22）</param>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="remoteFilePath">远程文件路径（包含文件名）</param>
        /// <param name="content">要写入的文本内容</param>
        public static void WriteTextToSftp(string host, int port, string username, string password,
                                   string remoteFilePath, string content)
        {
            // 创建SFTP连接信息
            var connectionInfo = new ConnectionInfo(host, port, username,
                new PasswordAuthenticationMethod(username, password));

            // 使用using语句确保资源释放
            using (var sftpClient = new SftpClient(connectionInfo))
            {
                try
                {
                    // 连接SFTP服务器
                    sftpClient.Connect();

                    if (sftpClient.IsConnected)
                    {
                        Console.WriteLine("成功连接到SFTP服务器");

                        // 将文本转换为内存流
                        using (var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(content)))
                        {
                            // 上传流到SFTP服务器
                            sftpClient.UploadFile(memoryStream, remoteFilePath, true);
                            Console.WriteLine($"文件已成功上传到: {remoteFilePath}");
                        }

                        // 断开连接
                        sftpClient.Disconnect();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"操作失败: {ex.Message}");
                    throw;
                }
            }
        }

        /// <summary>
        /// 测试方法 - 生成测试内容并写入SFTP
        /// </summary>
        public static void TestSftpWrite()
        {
            // 测试配置（请根据实际情况修改）
            var config = new
            {
                Host = "yk.changemall.cn",
                Port = 28,
                Username = "sftptest",
                Password = "sftptest@@",
                RemotePath = "/test/uploaded_file.txt"
            };

            // 生成测试内容
            var testContent = $"测试文件内容 - {DateTime.Now:yyyy-MM-dd HH:mm:ss}\r\n" +
                              "这是通过.NET Core程序上传的测试文件\r\n" +
                              "使用内存流直接写入SFTP服务器";

            // 执行写入操作
            WriteTextToSftp(config.Host, config.Port, config.Username,
                           config.Password, config.RemotePath, testContent);
        }
        #endregion

        // ===== SMB =====
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
    }
}
