using Renci.SshNet;
using SMBLibrary.Client;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Test
{
    class Program
    {
        static async Task Main(string[] args)
        {
            #region Test
            // See https://aka.ms/new-console-template for more information
            //Console.WriteLine("Hello, World!");

            //MMMS[Progress Sheet]订单号生成测试
            //MMMSCreateOrderNo();


            //MMMS[Progress Sheet]枚举测试
            //MMMSEnum();


            //// 读取JSON测试文件
            //string jsonPath = @"D:\p2.txt";
            //var jsonResponse = ReadTextFile(jsonPath);

            ////将/r/n还是一样保留
            ////sonResponse=EscapeLineEndingsForDisplay(jsonResponse);

            //Console.WriteLine("----------------------------------------------------------------");
            //Console.WriteLine(jsonResponse);

            //// 示例：Ollama返回的内容（包含标签）
            //string structuredQuestionsJson = jsonResponse;

            //// 1. 删除所有标签包裹的内容
            //structuredQuestionsJson = RemoveAllTags(structuredQuestionsJson);

            //// 2. 确保只保留JSON数据部分
            //structuredQuestionsJson = ExtractJsonContent(structuredQuestionsJson);

            //var options = new JsonSerializerOptions
            //{
            //    PropertyNameCaseInsensitive = true
            //};

            //try
            //{
            //    var structuredQuestions = JsonSerializer.Deserialize<List<StructuredQuestion>>(structuredQuestionsJson, options);
            //    Console.WriteLine($"成功反序列化，共 {structuredQuestions?.Count ?? 0} 个问题");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"处理失败: {ex.Message}");
            //    Console.WriteLine($"处理后的JSON: {structuredQuestionsJson}");
            //}


            //// 读取JSON测试文件
            //string jsonPath = @"C:\Users\liusi\Desktop\ELearning\識別后的Json數據.json";
            //var jsonResponse = ReadTextFile(jsonPath);


            //var options = new JsonSerializerOptions
            //{
            //    PropertyNameCaseInsensitive = true
            //};
            //List<ProcessedQuestionResult> processedQuestions = JsonSerializer.Deserialize<List<ProcessedQuestionResult>>(jsonResponse, options);



            //var treeObjectIds = JsonConvert.DeserializeObject<List<int>>(treeObjectIdsFromQuery);

            //string treeObjectIdsFromQuery = "[532]";
            //var treeObjectIds = JsonSerializer.Deserialize<List<int>>(treeObjectIdsFromQuery);




            //var chatbotType = "multimodal";


            //if (chatbotType == "multimodal" && treeObjectIds != null && treeObjectIds.Count > 0)
            //{
            //    Console.WriteLine("进来了");

            //}
            #endregion

            //// 符合格式的文件名
            //string test1 = "20251120_1001_john_doe_001";
            //string[] result1 = SplitFileName(test1);
            //Console.WriteLine(result1 != null
            //    ? $"拆分结果1: {string.Join(", ", result1)}"
            //    : "格式不符合");

            //// 不符合格式的文件名（缺少部分）
            //string test2 = "20251120_1001_john_doe";
            //string[] result2 = SplitFileName(test2);
            //Console.WriteLine(result2 != null
            //    ? $"拆分结果2: {string.Join(", ", result2)}"
            //    : "格式不符合");

            //// 不符合格式的文件名（多余部分）
            //string test3 = "20251120_1001_john_doe_001_extra";
            //string[] result3 = SplitFileName(test3);
            //Console.WriteLine(result3 != null
            //    ? $"拆分结果3: {string.Join(", ", result3)}"
            //    : "格式不符合");

            //Test("20251027T164030");

            //Test("20251027T164030_1_admin_Scam");

            //Test("20251027_164030_1_admin_Scam");


            //TestSftpWrite();

            string filePath = "E:\\Work\\Nexify\\Program/NexToreV4_AI_Application/FileStore/20251127/de55fd42-a350-4b95-bd2a-47e26e9a2d1c.data";

            filePath=Path.GetFullPath(filePath);

            // 解析路径各部分
            string directory = Path.GetDirectoryName(filePath); // 获取目录路径
            string fileName = Path.GetFileName(filePath); // 获取完整文件名
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(filePath); // 无后缀文件名
            string extension = Path.GetExtension(filePath); // 文件后缀

            // 输出解析结果
            Console.WriteLine("完整路径：" + filePath);
            Console.WriteLine("所在目录：" + directory);
            Console.WriteLine("完整文件名：" + fileName);
            Console.WriteLine("文件名（无后缀）：" + fileNameWithoutExt);
            Console.WriteLine("文件后缀：" + extension);

            // 拆分目录层级
            string[] directoryLevels = directory.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine("\n目录层级：");
            for (int i = 0; i < directoryLevels.Length; i++)
            {
                Console.WriteLine($"第{i + 1}级目录：{directoryLevels[i]}");
            }


            filePath = Path.Combine(directory, fileNameWithoutExt + ".jpg");
            Console.WriteLine(filePath);



            Console.ReadKey();
            return;


            // 测试用例1：完全符合（DateTime=20251120，staff_id=1001）
            string test1 = "20251120_1001_john_doe_001";
            var result1 = SplitAndValidateFileName(test1);
            Console.WriteLine(result1.HasValue
                ? $"成功：DateTime={result1.Value.dateTime:yyyy-MM-dd}, staffId={result1.Value.staffId}, userAd={result1.Value.userAd}, locationCode={result1.Value.locationCode}"
                : "失败：格式/类型不符合");

            // 测试用例2：DateTime格式错误（2025-13-01 不存在）
            string test2 = "2025-13-01_1001_john_doe_001";
            var result2 = SplitAndValidateFileName(test2);
            Console.WriteLine(result2.HasValue ? $"成功：{result2}" : "失败：格式/类型不符合");

            // 测试用例3：staff_id非数字（abc）
            string test3 = "20251120_abc_john_doe_001";
            var result3 = SplitAndValidateFileName(test3);
            Console.WriteLine(result3.HasValue ? $"成功：{result3}" : "失败：格式/类型不符合");

            // 测试用例4：基础格式错误（少一部分）
            string test4 = "20251120_1001_john_doe";
            var result4 = SplitAndValidateFileName(test4);
            Console.WriteLine(result4.HasValue ? $"成功：{result4}" : "失败：格式/类型不符合");


            Test("20251027T164030");

            Test("20251027T164030_1_admin_Scam");

            Test("20251027_164030_1_admin_Scam");

            Test("20251027164030_2_admin_Scam");

            Test("20251027164002_2_admin_Scam");

            Console.ReadKey();
            return;

            #region SMB
            Console.WriteLine("SMB");
            var value = "hello Smb";
            using var ms = new MemoryStream(Encoding.UTF8.GetBytes(value));

            using SmbClient client = new SmbClient("192.168.1.38", "smb")
            {
                User = "liu.siyang@outlook.com",
                Domain = "",
                Password = "Liu95Si08Yang26",
                NetBiosOverTCP = false,
                Port = 445
                //NetBiosOverTCP = true,
                //Port = 139
            };
            Console.WriteLine("SMB开始链接账号");
            //开始连接
            client.Connect();
            Console.WriteLine("SMB链接账号成功");
            //设置工作目录
            if (!client.DirectoryIsExist("RootPath"))
            {
                client.CreateDirectory("RootPath", true);
            }
            Console.WriteLine("SMB创建文件夹成功");
            client.SetWorkingDirectory("RootPath");

            //string filePath = "ProcessedFiles";
            //string fileName = Path.Combine(filePath, "test$a#2.txt");

            //目录是否存在
            var result = client.DirectoryIsExist(filePath);
            if (!result)
            {
                //创建目录
                client.CreateDirectory(filePath, true);
            }

            //获取当前目录下的文件
            var files = client.GetFiles("");

            foreach (var file in files)
            {

                string FileExtension = GetFileExtension(file);
                string FileExtensionWithDot = GetFileExtensionWithDot(file);
                Console.WriteLine(FileExtension);
                Console.WriteLine(FileExtensionWithDot);
                if (string.IsNullOrEmpty(FileExtensionWithDot) || FileExtensionWithDot != ".dll")
                {
                    Console.WriteLine("不是dll文件");
                    continue;
                }

                Console.WriteLine($"正在下载: {file}");

                // 修复：为每个文件指定不同的完整路径
                string localFilePath = Path.Combine("D:\\1", Path.GetFileName(file));

                // 修复：使用using确保文件流正确释放
                using (var fs = File.Create(localFilePath))
                {
                    // 修复：Download方法会自动处理工作目录，不需要Path.Combine
                    client.Download(file, fs);
                }
                Console.WriteLine($"文件已保存到: {localFilePath}");
                // client.Download(Path.Combine(client.WorkingDirectory, file), fs);
            }

            //文件是否存在
            result = client.FileIsExist(fileName);
            if (result)
            {
                //删除文件
                client.Delete(fileName);
            }

            //上传文件
            client.Upload(fileName, ms);





            if (!client.DirectoryIsExist("/RootPath2"))
            {
                client.CreateDirectory("/RootPath2", true);
            }

            //设置当前工作目录
            client.SetWorkingDirectory("/RootPath2");


            //filePath = "ProcessedFiles";
            fileName = Path.Combine(filePath, "test$a#4.txt");

            //目录是否存在
            result = client.DirectoryIsExist(filePath);
            if (!result)
            {
                //创建目录
                client.CreateDirectory(filePath, true);
            }

            //获取当前目录下的文件
            files = client.GetFiles("");

            foreach (var file in files)
            {
                Console.WriteLine($"正在下载: {file}");

                // 修复：为每个文件指定不同的完整路径
                string localFilePath = Path.Combine("D:\\2", Path.GetFileName(file));

                // 修复：使用using确保文件流正确释放
                using (var fs = File.Create(localFilePath))
                {
                    // 修复：Download方法会自动处理工作目录，不需要Path.Combine
                    client.Download(file, fs);
                }
                Console.WriteLine($"文件已保存到: {localFilePath}");
                // client.Download(Path.Combine(client.WorkingDirectory, file), fs);
            }

            //文件是否存在
            result = client.FileIsExist(fileName);
            if (result)
            {
                //删除文件
                client.Delete(fileName);
            }

            //上传文件
            client.Upload(fileName, ms);

            client.Move(fileName, "1");

            ////获取指定目录下的文件
            //var files = client.GetFiles(filePath);
            ////获取指定目录下的子目录
            //var directories = client.GetDirectories("");
            ////获取指定目录下的文件及子目录
            //var list = client.GetList(filePath);

            ////下载文件
            //var fs = new MemoryStream();
            //client.Download(fileName, fs);

            ////删除目录及它下面的所有文件
            //client.RemoveDirectory(filePath);

            #endregion
        }

        #region SMB
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
        #endregion


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


        public static void Test(string name)
        {
            var result = SplitAndValidateFileName(name);

            Console.WriteLine(result.HasValue
                ? $"成功：DateTime={result.Value.dateTime:yyyy-MM-dd}, staffId={result.Value.staffId}, userAd={result.Value.userAd}, locationCode={result.Value.locationCode}"
                : "失败：格式/类型不符合");
        }


        // 返回值：Tuple<DateTime, int, string, string> 或 null（格式/类型不符）
        public static (DateTime dateTime, int staffId, string userAd, string locationCode)? SplitAndValidateFileName(string fileName)
        {
            // 正则匹配基础格式
            string pattern = @"^(?<DateTime>.+)_(?<staff_id>.+)_(?<user_ad>.+)_(?<location_code>.+)$";
            Match match = Regex.Match(fileName, pattern);

            if (!match.Success)
                return null;

            // 提取各部分字符串
            string dateTimeStr = match.Groups["DateTime"].Value;
            string staffIdStr = match.Groups["staff_id"].Value;
            string userAd = match.Groups["user_ad"].Value;
            string locationCode = match.Groups["location_code"].Value;

            //    // 支持的所有时间格式（含 20251027164030）
            //    string[] allowedFormats = new[]
            //    {
            //    "yyyyMMdd",                  // 仅日期：20251027
            //    "yyyyMMddHHmmss",            // 无分隔符日期时间：20251027164030
            //    "yyyyMMddTHHmmss",           // T分隔日期时间：20251027T164030
            //    "yyyy-MM-dd",                // 横线日期：2025-10-27
            //    "yyyy-MM-ddTHH:mm:ss"        // T分隔带符号日期时间：2025-10-27T16:40:30
            //};

            // 支持的所有时间格式（含 20251027164030）
            string[] allowedFormats = new[]
            {
                "yyyyMMddTHHmmss"
            };

            // 转换 DateTime（支持常见格式，如 yyyyMMdd、yyyy-MM-dd 等）
            if (!DateTime.TryParseExact(dateTimeStr,
                allowedFormats,
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out DateTime dateTime))
            {
                return null; // DateTime 转换失败
            }

            // 转换 staff_id 为 int
            if (!int.TryParse(staffIdStr, out int staffId))
                return null; // staff_id 转换失败

            // 所有校验通过，返回强类型结果
            return (dateTime, staffId, userAd, locationCode);
        }

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

        public class ProcessedQuestionResult
        {
            public string Content { get; set; }
            public string Source { get; set; }
            public string Analysis { get; set; }
            public string KnowledgePoints { get; set; }
            public List<QuestionSimilarity> SimilarQuestions { get; set; } = new List<QuestionSimilarity>();
            public Dictionary<string, string> Images { get; set; } = new Dictionary<string, string>();
        }


        public class QuestionSimilarity
        {
            public string Id { get; set; }
            public string Content { get; set; }
            public float SimilarityScore { get; set; }
        }

        /// <summary>
        /// MMMS[Progress Sheet]订单号生成测试
        /// </summary>
        public static void MMMSCreateOrderNo()
        {
            #region MMMS[Progress Sheet]订单号生成测试
            //订单号模板，第一个订单按这个来
            string initialNumber = "PS2024061800000";

            //获取数据库中最大的订单号
            //兼容旧订单号码
            string maxCaseNo = "PS00001";
            //新订单
            maxCaseNo = "PS2024061800009";

            if (maxCaseNo != null)
            {
                initialNumber = maxCaseNo;
            }

            string numberPart = "";
            if (initialNumber.Length == 7)
            {
                //去掉前两位
                numberPart = initialNumber[2..];
            }
            else
            {
                //去掉前十位
                numberPart = initialNumber[10..];
            }

            //转换为int类型
            int number = int.Parse(numberPart);
            //把订单号加1
            number++;

            //补齐前面的空缺0,位数补齐
            string incrementedNumber = string.Concat(initialNumber.AsSpan(0, 2), DateTime.Now.ToString("yyyyMMdd"), number.ToString("D5"));

            //得到最新的订单号
            string caseNo = incrementedNumber;

            //输出订单号
            Console.WriteLine(caseNo);
            Console.WriteLine(numberPart);
            #endregion
        }

        /// <summary>
        /// MMMS[Progress Sheet]枚举测试
        /// </summary>
        public static void MMMSEnum()
        {
            ProgressSheetStatusEnum progressSheetStatusEnum = new ProgressSheetStatusEnum();
            //按枚举获取string值
            //根據枚舉成員獲取自定義屬性EnumDisplayNameAttribute的屬性DisplayName
            string EnumValue = EnumExtension.GetEnumCustomDescription(progressSheetStatusEnum);
            Console.WriteLine(EnumValue);

            //獲取枚舉項描述信息 
            string EnumDesc = EnumExtension.GetEnumDesc(ProgressSheetStatusEnum.Completed);
            Console.WriteLine(EnumValue);


            //獲取枚舉項描述信息
            EnumDesc = EnumExtension.GetEnumDesc(ProgressSheetStatusEnum.Completed, "");
            Console.WriteLine(EnumValue);

            //獲取枚舉的描述文本
            string EnumDescription = EnumExtension.GetDescription(ProgressSheetStatusEnum.Completed);
            Console.WriteLine(EnumDescription);


            EnumDescription = EnumExtension.GetDescription(typeof(ProgressSheetStatusEnum), 10);
            Console.WriteLine(EnumDescription);

            string description = EnumExtension.GetEnumDesc(typeof(ProgressSheetStatusEnum), 10);
            Console.WriteLine(description);  // 输出: Second Value
        }

        public class StructuredQuestion
        {
            public string Content { get; set; }
        }

        // 将字符串中的\r\n转换为字面显示的"\\r\\n"
        public static string EscapeLineEndingsForDisplay(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            // 将\r替换为\\r，将\n替换为\\n
            return input.Replace("\r", "\\r").Replace("\n", "\\n");
        }

        /// <summary>
        /// 读取本地TXT文件内容到string
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="encoding">文件编码，默认为UTF-8</param>
        /// <returns>文件内容字符串</returns>
        /// <exception cref="FileNotFoundException">文件未找到时抛出</exception>
        /// <exception cref="IOException">IO操作异常时抛出</exception>
        public static string ReadTextFile(string filePath, Encoding encoding = null)
        {
            // 如果未指定编码，默认使用UTF-8
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }

            try
            {
                // 检查文件是否存在
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException("指定的文件未找到", filePath);
                }

                // 读取文件内容
                string content = File.ReadAllText(filePath, encoding);

                // 可选：去除BOM（Byte Order Mark）
                if (content.StartsWith("\ufeff"))
                {
                    content = content.TrimStart('\ufeff');
                }

                return content;
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new IOException("没有权限访问文件", ex);
            }
            catch (PathTooLongException ex)
            {
                throw new IOException("文件路径过长", ex);
            }
            catch (IOException ex)
            {
                throw new IOException("读取文件时发生IO错误", ex);
            }
        }

        /// <summary>
        /// 读取本地TXT文件内容到string（简化版本，不抛出异常）
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="content">输出的文件内容</param>
        /// <returns>是否读取成功</returns>
        public static bool TryReadTextFile(string filePath, out string content)
        {
            try
            {
                content = ReadTextFile(filePath);
                return true;
            }
            catch
            {
                content = null;
                return false;
            }
        }


        /// <summary>
        /// 删除所有标签包裹的内容
        /// 删除所有用三个反引号包裹的内容，无论内容有多少行，包含什么字符。
        /// 这在处理 Markdown 格式的文本时非常有用，可以快速移除所有代码块，只保留纯文本内容。
        /// </summary>
        private static string RemoveAllTags(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            // 正则表达式：匹配所有标签及其内部内容
            string pattern = @"```[\s\S]*?```";
            return Regex.Replace(input, pattern, string.Empty, RegexOptions.Multiline);
        }

        /// <summary>
        /// 提取从[{"content": 开始的JSON内容
        /// </summary>
        private static string ExtractJsonContent(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return "[]";

            // 找到JSON数组的开始位置
            int startIndex = input.IndexOf("[{\"content\":", StringComparison.OrdinalIgnoreCase);

            if (startIndex >= 0)
            {
                // 从找到的位置开始提取
                string jsonPart = input.Substring(startIndex);

                // 找到JSON数组的结束位置
                int endIndex = FindJsonArrayEnd(jsonPart);

                if (endIndex >= 0)
                {
                    return jsonPart.Substring(0, endIndex + 1);
                }
            }

            // 如果找不到标准格式，尝试找到第一个[和最后一个]
            int firstBracket = input.IndexOf('[');
            int lastBracket = input.LastIndexOf(']');

            if (firstBracket >= 0 && lastBracket > firstBracket)
            {
                return input.Substring(firstBracket, lastBracket - firstBracket + 1);
            }

            return "[]";
        }

        /// <summary>
        /// 找到JSON数组的结束位置（处理嵌套结构）
        /// </summary>
        private static int FindJsonArrayEnd(string json)
        {
            int bracketCount = 0;

            for (int i = 0; i < json.Length; i++)
            {
                if (json[i] == '[')
                    bracketCount++;
                else if (json[i] == ']')
                {
                    bracketCount--;
                    if (bracketCount == 0)
                        return i;
                }
            }

            return -1;
        }

    }
}


