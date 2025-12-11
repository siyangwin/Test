using Org.BouncyCastle.Crypto.Agreement;
using Renci.SshNet;
using SkiaSharp;
using SMBLibrary.Client;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using ZXing;
using ZXing.Common;
using ZXing.SkiaSharp;

namespace Test
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Zxing();
            Console.WriteLine();
            Console.ReadKey();

            #region Other
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

            //string filePath = "E:\\Work\\Nexify\\Program/NexToreV4_AI_Application/FileStore/20251127/de55fd42-a350-4b95-bd2a-47e26e9a2d1c.data";

            //filePath=Path.GetFullPath(filePath);

            //// 解析路径各部分
            //string directory = Path.GetDirectoryName(filePath); // 获取目录路径
            //string fileName = Path.GetFileName(filePath); // 获取完整文件名
            //string fileNameWithoutExt = Path.GetFileNameWithoutExtension(filePath); // 无后缀文件名
            //string extension = Path.GetExtension(filePath); // 文件后缀

            //// 输出解析结果
            //Console.WriteLine("完整路径：" + filePath);
            //Console.WriteLine("所在目录：" + directory);
            //Console.WriteLine("完整文件名：" + fileName);
            //Console.WriteLine("文件名（无后缀）：" + fileNameWithoutExt);
            //Console.WriteLine("文件后缀：" + extension);

            //// 拆分目录层级
            //string[] directoryLevels = directory.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            //Console.WriteLine("\n目录层级：");
            //for (int i = 0; i < directoryLevels.Length; i++)
            //{
            //    Console.WriteLine($"第{i + 1}级目录：{directoryLevels[i]}");
            //}


            //filePath = Path.Combine(directory, fileNameWithoutExt + ".jpg");
            //Console.WriteLine(filePath);



            //Console.ReadKey();
            //return;


            // 测试用例1：完全符合（DateTime=20251120，staff_id=1001）
            //string test1 = "20251120_1001_john_doe_001";
            //var result1 = SplitAndValidateFileName(test1);
            //Console.WriteLine(result1.HasValue
            //    ? $"成功：DateTime={result1.Value.dateTime:yyyy-MM-dd}, staffId={result1.Value.staffId}, userAd={result1.Value.userAd}, locationCode={result1.Value.locationCode}"
            //    : "失败：格式/类型不符合");

            //// 测试用例2：DateTime格式错误（2025-13-01 不存在）
            //string test2 = "2025-13-01_1001_john_doe_001";
            //var result2 = SplitAndValidateFileName(test2);
            //Console.WriteLine(result2.HasValue ? $"成功：{result2}" : "失败：格式/类型不符合");

            //// 测试用例3：staff_id非数字（abc）
            //string test3 = "20251120_abc_john_doe_001";
            //var result3 = SplitAndValidateFileName(test3);
            //Console.WriteLine(result3.HasValue ? $"成功：{result3}" : "失败：格式/类型不符合");

            //// 测试用例4：基础格式错误（少一部分）
            //string test4 = "20251120_1001_john_doe";
            //var result4 = SplitAndValidateFileName(test4);
            //Console.WriteLine(result4.HasValue ? $"成功：{result4}" : "失败：格式/类型不符合");


            //Test("20251027T164030");

            //Test("20251027T164030_1_admin_Scam");

            //Test("20251027_164030_1_admin_Scam");

            //Test("20251027164030_2_admin_Scam");

            //Test("20251027164002_2_admin_Scam");

            //Console.ReadKey();
            //return;

            #region SMB
            //Console.WriteLine("SMB");
            //var value = "hello Smb";
            //using var ms = new MemoryStream(Encoding.UTF8.GetBytes(value));

            //using SmbClient client = new SmbClient("192.168.1.38", "smb")
            //{
            //    User = "liu.siyang@outlook.com",
            //    Domain = "",
            //    Password = "Liu95Si08Yang26",
            //    NetBiosOverTCP = false,
            //    Port = 445
            //    //NetBiosOverTCP = true,
            //    //Port = 139
            //};
            //Console.WriteLine("SMB开始链接账号");
            ////开始连接
            //client.Connect();
            //Console.WriteLine("SMB链接账号成功");
            ////设置工作目录
            //if (!client.DirectoryIsExist("RootPath"))
            //{
            //    client.CreateDirectory("RootPath", true);
            //}
            //Console.WriteLine("SMB创建文件夹成功");
            //client.SetWorkingDirectory("RootPath");

            ////string filePath = "ProcessedFiles";
            ////string fileName = Path.Combine(filePath, "test$a#2.txt");

            ////目录是否存在
            //var result = client.DirectoryIsExist(filePath);
            //if (!result)
            //{
            //    //创建目录
            //    client.CreateDirectory(filePath, true);
            //}

            ////获取当前目录下的文件
            //var files = client.GetFiles("");

            //foreach (var file in files)
            //{

            //    string FileExtension = GetFileExtension(file);
            //    string FileExtensionWithDot = GetFileExtensionWithDot(file);
            //    Console.WriteLine(FileExtension);
            //    Console.WriteLine(FileExtensionWithDot);
            //    if (string.IsNullOrEmpty(FileExtensionWithDot) || FileExtensionWithDot != ".dll")
            //    {
            //        Console.WriteLine("不是dll文件");
            //        continue;
            //    }

            //    Console.WriteLine($"正在下载: {file}");

            //    // 修复：为每个文件指定不同的完整路径
            //    string localFilePath = Path.Combine("D:\\1", Path.GetFileName(file));

            //    // 修复：使用using确保文件流正确释放
            //    using (var fs = File.Create(localFilePath))
            //    {
            //        // 修复：Download方法会自动处理工作目录，不需要Path.Combine
            //        client.Download(file, fs);
            //    }
            //    Console.WriteLine($"文件已保存到: {localFilePath}");
            //    // client.Download(Path.Combine(client.WorkingDirectory, file), fs);
            //}

            ////文件是否存在
            //result = client.FileIsExist(fileName);
            //if (result)
            //{
            //    //删除文件
            //    client.Delete(fileName);
            //}

            ////上传文件
            //client.Upload(fileName, ms);





            //if (!client.DirectoryIsExist("/RootPath2"))
            //{
            //    client.CreateDirectory("/RootPath2", true);
            //}

            ////设置当前工作目录
            //client.SetWorkingDirectory("/RootPath2");


            ////filePath = "ProcessedFiles";
            //fileName = Path.Combine(filePath, "test$a#4.txt");

            ////目录是否存在
            //result = client.DirectoryIsExist(filePath);
            //if (!result)
            //{
            //    //创建目录
            //    client.CreateDirectory(filePath, true);
            //}

            ////获取当前目录下的文件
            //files = client.GetFiles("");

            //foreach (var file in files)
            //{
            //    Console.WriteLine($"正在下载: {file}");

            //    // 修复：为每个文件指定不同的完整路径
            //    string localFilePath = Path.Combine("D:\\2", Path.GetFileName(file));

            //    // 修复：使用using确保文件流正确释放
            //    using (var fs = File.Create(localFilePath))
            //    {
            //        // 修复：Download方法会自动处理工作目录，不需要Path.Combine
            //        client.Download(file, fs);
            //    }
            //    Console.WriteLine($"文件已保存到: {localFilePath}");
            //    // client.Download(Path.Combine(client.WorkingDirectory, file), fs);
            //}

            ////文件是否存在
            //result = client.FileIsExist(fileName);
            //if (result)
            //{
            //    //删除文件
            //    client.Delete(fileName);
            //}

            ////上传文件
            //client.Upload(fileName, ms);

            //client.Move(fileName, "1");

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
            #endregion
        }
        #region Other
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
        #endregion



        #region zXING
        public static void Zxing()
        {
             string folderPath = @"C:\Users\liusi\Desktop\图片";

            // 检查文件夹是否存在
            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine($"文件夹不存在：{folderPath}");
                return;
            }

            // 获取文件夹中所有支持的图片格式
            string[] imageExtensions = { "*.jpg", "*.jpeg", "*.png", "*.bmp", "*.gif", "*.tiff", "*.tif" };
            List<string> imageFiles = new List<string>();

            foreach (string extension in imageExtensions)
            {
                try
                {
                    string[] files = Directory.GetFiles(folderPath, extension, SearchOption.AllDirectories);
                    imageFiles.AddRange(files);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"搜索 {extension} 文件时出错：{ex.Message}");
                }
            }

            if (imageFiles.Count == 0)
            {
                Console.WriteLine($"文件夹中没有找到图片文件：{folderPath}");
                return;
            }

            Console.WriteLine($"找到 {imageFiles.Count} 个图片文件，开始识别...");
            Console.WriteLine("==================================================");

            int totalImages = imageFiles.Count;
            int successCount = 0;
            int failCount = 0;


            // 循环识别每个图片文件
            for (int i = 0; i < imageFiles.Count; i++)
            {
                string imagePath = imageFiles[i];
                string fileName = Path.GetFileName(imagePath);

                Console.WriteLine($"\n[{i + 1}/{totalImages}] 正在识别：{fileName}");
                Console.WriteLine($"文件路径：{imagePath}");

                try
                {
                    using Stream imageStream = ReadLocalFileToStream(imagePath);
                    int currentPage = 0;
                    int totalPages = 0;

                    var results = DecodeBarcodes(imageStream, out currentPage, out totalPages);

                    if (results.Any())
                    {
                        successCount++;
                        Console.WriteLine($"  识别成功！找到 {results.Count} 个码：");

                        foreach (var result in results)
                        {
                            Console.WriteLine($"    类型：{result.Type}，内容：{result.Content}");
                        }
                    }
                    else
                    {
                        failCount++;
                        Console.WriteLine("  未识别到任何二维码或条形码");
                    }
                }
                catch (Exception ex)
                {
                    failCount++;
                    Console.WriteLine($"  识别失败：{ex.Message}");
                }

                Console.WriteLine("--------------------------------------------------");
            }

            // 输出统计结果
            Console.WriteLine("\n==================================================");
            Console.WriteLine("识别统计结果：");
            Console.WriteLine($"总图片数：{totalImages}");
            Console.WriteLine($"识别成功：{successCount}");
            Console.WriteLine($"识别失败：{failCount}");
            Console.WriteLine($"成功率：{((double)successCount / totalImages * 100):F2}%");


            // Stream image = ReadLocalFileToStream("C:\\Users\\liusi\\Desktop\\图片\\18.jpg");
            // int currentPage = 0;
            // int totalPages = 0;

            // var res = DecodeBarcodes(image, out currentPage, out totalPages);
            // //读取本地图片
            // Console.WriteLine();
        }


        // 新增方法：获取指定文件夹中的所有图片文件
        public static List<string> GetAllImageFiles(string folderPath)
        {
            var imageFiles = new List<string>();

            if (!Directory.Exists(folderPath))
                return imageFiles;

            // 支持的图片格式
            string[] extensions = { "*.jpg", "*.jpeg", "*.png", "*.bmp", "*.gif", "*.tiff", "*.tif", "*.webp" };

            foreach (string extension in extensions)
            {
                try
                {
                    var files = Directory.GetFiles(folderPath, extension, SearchOption.AllDirectories);
                    imageFiles.AddRange(files);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"搜索 {extension} 文件时出错：{ex.Message}");
                }
            }

            return imageFiles.OrderBy(f => f).ToList();
        }

        /// <summary>
        /// 读取本地文件并转换为Stream（适配条码解码）
        /// </summary>
        /// <param name="filePath">本地文件路径（如：D:\test.png、/home/user/barcode.jpg）</param>
        /// <returns>文件流（使用后需释放）</returns>
        /// <exception cref="FileNotFoundException">文件不存在</exception>
        /// <exception cref="IOException">文件读取失败</exception>
        public static Stream ReadLocalFileToStream(string filePath)
        {
            // 1. 校验文件路径
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentNullException(nameof(filePath), "文件路径不能为空");

            // 2. 校验文件是否存在
            if (!File.Exists(filePath))
                throw new FileNotFoundException("指定文件不存在", filePath);

            // 3. 读取文件为Stream（使用FileStream，支持大文件/二进制文件）
            // 注意：FileStream需手动释放，或用using包裹
            var fileStream = new FileStream(
                path: filePath,
                mode: FileMode.Open,
                access: FileAccess.Read,
                share: FileShare.Read // 允许其他程序同时读取该文件
            );

            // 4. 可选：转换为MemoryStream（将文件加载到内存，脱离文件句柄）
            // 适合小文件，避免后续解码时占用文件
            var memoryStream = new MemoryStream();
            fileStream.CopyTo(memoryStream);
            fileStream.Close(); // 关闭FileStream，释放文件句柄
            memoryStream.Position = 0; // 重置流指针到起始位置（关键！否则SkiaSharp解码会失败）

            return memoryStream;
        }

        public static List<DetectedObject> DecodeBarcodes(Stream imageStream, out int currentPage, out int totalPages)
        {
            var detectedObjects = new List<DetectedObject>();
            currentPage = 0;
            totalPages = 0;

            try
            {
                using var skBitmap = SKBitmap.Decode(imageStream);
                if (skBitmap == null)
                {
                    Console.WriteLine("图像解码失败：SKBitmap.Decode返回null");
                    return detectedObjects;
                }
                Console.WriteLine($"图像尺寸：{skBitmap.Width}x{skBitmap.Height}");

                // ========== 改进的解码器配置 ==========
                Func<BarcodeFormat, BarcodeReaderGeneric> CreateReader = (format) =>
                {
                    return new BarcodeReaderGeneric
                    {
                        AutoRotate = true,
                        Options = new DecodingOptions
                        {
                            TryHarder = true,
                            PureBarcode = false,
                            PossibleFormats = new List<BarcodeFormat> {
                        BarcodeFormat.QR_CODE,
                        BarcodeFormat.CODE_128,
                        BarcodeFormat.CODE_39,
                        BarcodeFormat.DATA_MATRIX,
                        BarcodeFormat.PDF_417,
                        BarcodeFormat.AZTEC
                    },
                            // 添加字符集支持
                            CharacterSet = "UTF-8"
                        }
                    };
                };

                // ========== 方法1：直接解码（不预处理） ==========
                var directResults = TryDecodeDirect(skBitmap, CreateReader);
                if (directResults.Any())
                {
                    detectedObjects.AddRange(directResults);
                    Console.WriteLine("直接解码成功");
                }

                // ========== 方法2：轻度预处理解码 ==========
                if (!detectedObjects.Any())
                {
                    var lightProcessResults = TryDecodeWithLightProcessing(skBitmap, CreateReader);
                    if (lightProcessResults.Any())
                    {
                        detectedObjects.AddRange(lightProcessResults);
                        Console.WriteLine("轻度预处理解码成功");
                    }
                }


                // ========== 方法3：重度预处理解码 ==========
                if (!detectedObjects.Any())
                {
                    var heavyProcessResults = TryDecodeWithHeavyProcessing(skBitmap, CreateReader);
                    if (heavyProcessResults.Any())
                    {
                        detectedObjects.AddRange(heavyProcessResults);
                        Console.WriteLine("重度预处理解码成功");
                    }
                }


                // ========== 方法4：多区域扫描 ==========
                if (!detectedObjects.Any())
                {
                    var multiRegionResults = TryDecodeMultipleRegions(skBitmap, CreateReader);
                    if (multiRegionResults.Any())
                    {
                        detectedObjects.AddRange(multiRegionResults);
                        Console.WriteLine("多区域扫描成功");
                    }
                }

                Console.WriteLine($"总共识别到 {detectedObjects.Count} 个码");


            }
            catch (Exception ex)
            {
                Console.WriteLine($"二维码识别异常：{ex.Message}");
                Console.WriteLine($"StackTrace：{ex.StackTrace}");
            }
            return detectedObjects;
        }


        // ========== 直接解码（不预处理） ==========
        private static List<DetectedObject> TryDecodeDirect(SKBitmap original, Func<BarcodeFormat, BarcodeReaderGeneric> createReader)
        {
            var results = new List<DetectedObject>();

            try
            {
                var luminanceSource = new SKBitmapLuminanceSource(original);
                var reader = createReader(BarcodeFormat.QR_CODE);
                var decodeResults = reader.DecodeMultiple(luminanceSource);

                if (decodeResults != null)
                {
                    foreach (var result in decodeResults)
                    {
                        if (!string.IsNullOrEmpty(result.Text))
                        {
                            results.Add(new DetectedObject
                            {
                                Type = result.BarcodeFormat.ToString(),
                                Content = result.Text
                            });
                            Console.WriteLine($"直接解码：{result.BarcodeFormat} - {result.Text}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"直接解码失败：{ex.Message}");
            }

            return results;
        }

        // ========== 轻度预处理 ==========
        private static List<DetectedObject> TryDecodeWithLightProcessing(SKBitmap original, Func<BarcodeFormat, BarcodeReaderGeneric> createReader)
        {
            var results = new List<DetectedObject>();

            try
            {
                // 轻度预处理：仅缩放和灰度化
                using var processed = LightPreprocessImage(original, 1.2f);
                var luminanceSource = new SKBitmapLuminanceSource(processed);
                var reader = createReader(BarcodeFormat.QR_CODE);
                var decodeResults = reader.DecodeMultiple(luminanceSource);

                if (decodeResults != null)
                {
                    foreach (var result in decodeResults)
                    {
                        if (!string.IsNullOrEmpty(result.Text))
                        {
                            results.Add(new DetectedObject
                            {
                                Type = result.BarcodeFormat.ToString(),
                                Content = result.Text
                            });
                            Console.WriteLine($"轻度预处理解码：{result.BarcodeFormat} - {result.Text}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"轻度预处理解码失败：{ex.Message}");
            }

            return results;
        }

        // ========== 重度预处理 ==========
        private static List<DetectedObject> TryDecodeWithHeavyProcessing(SKBitmap original, Func<BarcodeFormat, BarcodeReaderGeneric> createReader)
        {
            var results = new List<DetectedObject>();

            try
            {
                // 重度预处理：缩放+灰度+二值化
                using var processed = HeavyPreprocessImage(original, 1.5f);
                var luminanceSource = new SKBitmapLuminanceSource(processed);
                var reader = createReader(BarcodeFormat.QR_CODE);
                var decodeResults = reader.DecodeMultiple(luminanceSource);

                if (decodeResults != null)
                {
                    foreach (var result in decodeResults)
                    {
                        if (!string.IsNullOrEmpty(result.Text))
                        {
                            results.Add(new DetectedObject
                            {
                                Type = result.BarcodeFormat.ToString(),
                                Content = result.Text
                            });
                            Console.WriteLine($"重度预处理解码：{result.BarcodeFormat} - {result.Text}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"重度预处理解码失败：{ex.Message}");
            }

            return results;
        }

        // ========== 多区域扫描 ==========
        private static List<DetectedObject> TryDecodeMultipleRegions(SKBitmap original, Func<BarcodeFormat, BarcodeReaderGeneric> createReader)
        {
            var results = new List<DetectedObject>();

            // 定义多个扫描区域
            var regions = new[]
            {
        new SKRectI(0, 0, original.Width, original.Height), // 全图
        new SKRectI(0, 0, original.Width / 2, original.Height), // 左半区
        new SKRectI(original.Width / 2, 0, original.Width, original.Height), // 右半区
        new SKRectI(0, 0, original.Width, original.Height / 2), // 上半区
        new SKRectI(0, original.Height / 2, original.Width, original.Height) // 下半区
    };

            foreach (var region in regions)
            {
                try
                {
                    using var regionBitmap = new SKBitmap(region.Width, region.Height);
                    if (original.ExtractSubset(regionBitmap, region))
                    {
                        var regionResults = TryDecodeDirect(regionBitmap, createReader);
                        results.AddRange(regionResults);

                        if (!regionResults.Any())
                        {
                            regionResults = TryDecodeWithLightProcessing(regionBitmap, createReader);
                            results.AddRange(regionResults);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"区域扫描失败：{ex.Message}");
                }
            }

            return results.DistinctBy(x => x.Content).ToList();
        }

        // ========== 改进的图像预处理方法 ==========
        private static SKBitmap LightPreprocessImage(SKBitmap original, float scale = 1f)
        {
            if (original == null || original.Width == 0 || original.Height == 0)
                return original.Copy();

            try
            {
                // 1. 缩放
                int newWidth = (int)(original.Width * scale);
                int newHeight = (int)(original.Height * scale);
                using var scaled = original.Resize(new SKImageInfo(newWidth, newHeight), SKFilterQuality.Medium);

                // 2. 转灰度图
                using var grayBitmap = new SKBitmap(newWidth, newHeight);
                using (var canvas = new SKCanvas(grayBitmap))
                {
                    using var paint = new SKPaint();
                    paint.ColorFilter = SKColorFilter.CreateColorMatrix(new float[]
                    {
                0.299f, 0.587f, 0.114f, 0, 0,
                0.299f, 0.587f, 0.114f, 0, 0,
                0.299f, 0.587f, 0.114f, 0, 0,
                0,      0,      0,      1, 0
                    });
                    canvas.DrawBitmap(scaled, 0, 0, paint);
                }

                return grayBitmap.Copy();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"轻度预处理失败：{ex.Message}");
                return original.Copy();
            }
        }

        private static SKBitmap HeavyPreprocessImage(SKBitmap original, float scale = 1f)
        {
            if (original == null || original.Width == 0 || original.Height == 0)
                return original.Copy();

            try
            {
                // 1. 轻度预处理
                using var lightProcessed = LightPreprocessImage(original, scale);

                // 2. 二值化（提高对比度）
                using var binaryBitmap = new SKBitmap(lightProcessed.Width, lightProcessed.Height);

                for (int y = 0; y < lightProcessed.Height; y++)
                {
                    for (int x = 0; x < lightProcessed.Width; x++)
                    {
                        var pixel = lightProcessed.GetPixel(x, y);
                        // 计算灰度值
                        byte gray = (byte)((pixel.Red * 0.299 + pixel.Green * 0.587 + pixel.Blue * 0.114));
                        // 二值化阈值
                        byte threshold = 128;
                        byte binaryValue = gray > threshold ? (byte)255 : (byte)0;

                        binaryBitmap.SetPixel(x, y, new SKColor(binaryValue, binaryValue, binaryValue));
                    }
                }

                return binaryBitmap.Copy();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"重度预处理失败：{ex.Message}");
                return original.Copy();
            }
        }

        public class DetectedObject
        {
            public string Type { get; set; }
            public string Content { get; set; }
            // 可补充：位置、置信度等字段
        }
        #endregion
    }
}


