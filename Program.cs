using Aspose.BarCode.BarCodeRecognition;
using iTextSharp.text;
using iTextSharp.text.pdf;
using PdfSharpCore.Pdf;
using PdfSharpCore.Drawing;
using ClosedXML.Excel;
using DevExpress.Office.DigitalSignatures;
using DevExpress.Pdf;
using OpenCvSharp;
using Org.BouncyCastle.Crypto.Agreement;
using Org.BouncyCastle.Utilities.Zlib;
using PuppeteerSharp;
using PuppeteerSharp.Media;
using Renci.SshNet;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SkiaSharp;
using SMBLibrary;
using SMBLibrary.Client;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Net;
using System.Net.Http.Json;
using System.Net.WebSockets;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using ZXing;
using ZXing.Common;
using ZXing.SkiaSharp;
using static Test.Program;

namespace Test
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            //Zxing();
            //OpenCv();
            //ChangeImages();
            //OCRChange();
            //OCRImage();
            //DownLoad();
            //DownLoadByFileByApi();

            //string folderPath = @"C:\Users\liusi\Desktop\Form\check";
            //TestSignatureDetection(folderPath);

            //Console.WriteLine(HasSignature("C:\\Users\\liusi\\Desktop\\signature\\doctor_signature-4b0dbda9-0bc2-4c65-b86d-021880a1ac6f.jpg"));

            //移除文件名非法字符
            //ChangeImageName();

            //文件名校验
            //CheckFileName();
            //SMB
            //ReadSmbFile();


            //清理拆分Form的数据
            //FormCsvCleaner();

            //IAM Smart 签名 esign 
            //esignAsync();
            //EsignSignLocalPdfAsync();
            //TestFileHash();



            //Html导出为PDF
            //htmltopdf();

            //retry
            //retry();

            //飞书长连接
            //await feishu();


            // 调用方法，传入TXT文件路径
            //ReadTxtAndConvertToDecimal(@"E:\xxx.txt");
            //checkMath();


            //内存爆炸测试
            //LoadingImg();

            //LoadingImgmimo();
            //LoadingImgStream();
            //LoadingImgPdfSharp();
            //await LoadingImgPdfSharpMultiThread();


            //LoadingImgByDaniel();

            //LoadingImgStreamLowMemory();
            LoadingImgStreamLowMemoryParallel();

            //LoadExcel();
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

        // 创建可空类
        public class QRCodeCheck
        {
            public string? EpisodeID { get; set; }
            public string? QrCodeContent { get; set; }
            public string? PatientID { get; set; }
        }

        //QrCode格式校验
        static bool FormatCheck = true;

        public static void Zxing()
        {
            DateTime Pstarttime = DateTime.Now;
            //string folderPath = @"C:\Users\liusi\Desktop\Zxing";
            string folderPath = @"C:\Users\liusi\Desktop\11";
            string SaveImageFile = @"C:\Users\liusi\Desktop\ZxingDemo";
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
                DateTime starttime = DateTime.Now;
                string imagePath = imageFiles[i];
                string fileName = Path.GetFileName(imagePath);

                Console.WriteLine($"\n[{i + 1}/{totalImages}] 正在识别：{fileName}");
                Console.WriteLine($"文件路径：{imagePath}");

                try
                {
                    using Stream imageStream = ReadLocalFileToStream(imagePath);
                    int currentPage = 0;
                    int totalPages = 0;


                    //識別QRCode
                    #region 識別QRCode

                    var results = DecodeQRcodes(imageStream, out currentPage, out totalPages, SaveImageFile);

                    string EpisodeID = "";
                    string QrCodeContent = "";
                    string PatientID = "";
                    if (results.Any())
                    {
                        successCount++;
                        Console.WriteLine($"  识别成功！找到 {results.Count} 个码：");


                        var QRCodeChecks = new List<QRCodeCheck>();

                        foreach (var result in results.Where(s => s != null && !string.IsNullOrWhiteSpace(s.Content)))
                        {
                            QRCodeCheck qRCodeCheck = new QRCodeCheck();
                            //var xxx = result.resultPoints;
                            Console.WriteLine($"    类型：{result.Type}，内容：{result.Content}");

                            if (result.Type == "QR_CODE" && result.Content.Contains("||"))
                            {
                                var parts = result.Content.Split(new[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
                                if (parts.Length > 0 && parts[0].Contains("."))
                                {
                                    var episodeParts = parts[0].Trim().Split('.');
                                    if (episodeParts.Length > 1 && !string.IsNullOrEmpty(episodeParts[1]))
                                    {
                                        // When there are multiple QR codes, info.EpisodeID could be set already, check if it starts with HN
                                        var extractedEpisodeID = episodeParts[1].Trim();
                                        qRCodeCheck.EpisodeID = extractedEpisodeID;
                                        qRCodeCheck.QrCodeContent = result.Content;
                                    }
                                    // Safely extract Patient ID
                                    if (parts.Length > 1 && !string.IsNullOrEmpty(parts[1]))
                                        qRCodeCheck.PatientID = parts[1].Trim();
                                }
                                QRCodeChecks.Add(qRCodeCheck);
                            }
                        }

                        if (QRCodeChecks == null || QRCodeChecks.Count <= 0)
                        {
                            continue;
                        }

                        //获取QRCodeInfos中包含HN的数据
                        var QRCodeInfo = QRCodeChecks.Where(S => S.EpisodeID.StartsWith("HN")).ToList();

                        if (QRCodeInfo.Count <= 0)
                        {
                            QRCodeInfo = QRCodeChecks.Where(S => !S.EpisodeID.StartsWith("HN")).ToList();
                        }

                        if (QRCodeInfo.Count == 1)
                        {
                            EpisodeID = QRCodeInfo[0].EpisodeID;
                            QrCodeContent = QRCodeInfo[0].QrCodeContent;
                            PatientID = QRCodeInfo[0].PatientID;

                            continue;
                        }

                        //List<string> QRCodeInfoChecks = QRCodeInfo.Select(s => s.QrCodeContent).ToList();

                        //results = results.Where(s => QRCodeInfoChecks.Contains(s.Content)).ToList();

                        results = results.Where(s => QRCodeInfo.Select(q => q.QrCodeContent).Contains(s.Content)).ToList();

                        // 新增：标记二维码坐标并保存图片
                        try
                        {
                            using Stream imageStreamForMarking = ReadLocalFileToStream(imagePath);
                            using var originalBitmap = SKBitmap.Decode(imageStreamForMarking);
                            if (originalBitmap != null)
                            {
                                string markedImagePath = Path.Combine(SaveImageFile, $"marked_{Path.GetFileNameWithoutExtension(fileName)}.png");
                                MarkQRCodeCoordinates(originalBitmap, results, markedImagePath);
                                Console.WriteLine($"  已生成标记坐标的图片：{markedImagePath}");

                                // 新增：标记最左边的二维码
                                string leftmostImagePath = Path.Combine(SaveImageFile, $"leftmost_{Path.GetFileNameWithoutExtension(fileName)}.png");
                                MarkLeftmostQRCode(originalBitmap, results, leftmostImagePath);
                                Console.WriteLine($"  已生成标记最左边二维码的图片：{leftmostImagePath}");

                                // 新增：显示最左边二维码的信息
                                var leftmostQRCode = FindLeftmostQRCode(results);
                                if (leftmostQRCode != null)
                                {

                                    var LeftQRCode = QRCodeInfo.Where(s => s.QrCodeContent.Contains(leftmostQRCode.Content)).FirstOrDefault();
                                    EpisodeID = LeftQRCode.EpisodeID;
                                    QrCodeContent = LeftQRCode.QrCodeContent;
                                    PatientID = LeftQRCode.PatientID;

                                    Console.WriteLine(EpisodeID);
                                    Console.WriteLine(QrCodeContent);
                                    Console.WriteLine(PatientID);

                                    Console.WriteLine($"  最左边二维码信息：");
                                    Console.WriteLine($"    类型：{leftmostQRCode.Type}");
                                    Console.WriteLine($"    内容：{leftmostQRCode.Content}");




                                    // 显示坐标信息
                                    if (leftmostQRCode.resultPoints != null && leftmostQRCode.resultPoints.Length >= 4)
                                    {
                                        Console.WriteLine($"    左上角坐标：({leftmostQRCode.resultPoints[0]?.X:F1}, {leftmostQRCode.resultPoints[0]?.Y:F1})");
                                        Console.WriteLine($"    右上角坐标：({leftmostQRCode.resultPoints[1]?.X:F1}, {leftmostQRCode.resultPoints[1]?.Y:F1})");
                                        Console.WriteLine($"    右下角坐标：({leftmostQRCode.resultPoints[2]?.X:F1}, {leftmostQRCode.resultPoints[2]?.Y:F1})");
                                        Console.WriteLine($"    左下角坐标：({leftmostQRCode.resultPoints[3]?.X:F1}, {leftmostQRCode.resultPoints[3]?.Y:F1})");
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"  标记坐标失败：{ex.Message}");
                        }
                    }
                    else
                    {
                        failCount++;
                        Console.WriteLine("  未识别到任何二维码");
                    }

                    Console.WriteLine("--------------------------------------------------");
                    #endregion

                    //識別Barcode[Code128]
                    #region 识别Barcode
                    //string ImageFile = SaveImageFile + @"\" + Path.GetFileNameWithoutExtension(fileName);
                    ////識別Barcode[Code128]
                    //var Barcodesresults = DecodeBarcodes(imageStream, out currentPage, out totalPages, ImageFile);

                    //if (Barcodesresults.Any())
                    //{
                    //    successCount++;
                    //    Console.WriteLine($"  识别成功！找到 {Barcodesresults.Count} 个码：");

                    //    foreach (var result in Barcodesresults)
                    //    {
                    //        Console.WriteLine($"    类型：{result.Type}，内容：{result.Content}");
                    //    }
                    //}
                    //else
                    //{
                    //    failCount++;
                    //    Console.WriteLine("  未识别到任何條形码");
                    //}
                    #endregion

                }
                catch (Exception ex)
                {
                    failCount++;
                    Console.WriteLine($"  识别失败：{ex.Message}");
                }
                DateTime endtime = DateTime.Now;
                TimeSpan duration = endtime - starttime;
                Console.WriteLine($"图片总耗时: {duration.TotalSeconds} 秒");
                Console.WriteLine("--------------------------------------------------");
            }

            // 输出统计结果
            Console.WriteLine("\n==================================================");
            Console.WriteLine("识别统计结果：");
            Console.WriteLine($"总图片数：{totalImages}");
            Console.WriteLine($"识别成功：{successCount}");
            Console.WriteLine($"识别失败：{failCount}");
            Console.WriteLine($"成功率：{((double)successCount / totalImages * 100):F2}%");

            DateTime Pendtime = DateTime.Now;
            TimeSpan Pduration = Pendtime - Pstarttime;
            Console.WriteLine($"程序总耗时: {Pduration.TotalSeconds} 秒");

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

        public static List<DetectedObject> DecodeQRcodes(Stream imageStream, out int currentPage, out int totalPages, string ImageFile)
        {
            var detectedObjects = new List<DetectedObject>();
            currentPage = 0;
            totalPages = 0;

            try
            {
                //var xxx = DetectBarcodesAspose(imageStream);

                using var skBitmap = SKBitmap.Decode(imageStream);
                if (skBitmap == null)
                {
                    Console.WriteLine("图像解码失败：SKBitmap.Decode返回null");
                    return detectedObjects;
                }
                Console.WriteLine($"图像尺寸：{skBitmap.Width}x{skBitmap.Height}");

                //解码器配置
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
                            BarcodeFormat.QR_CODE
                            //,
                            //BarcodeFormat.CODE_128
                            //,
                            //BarcodeFormat.CODE_39,
                            //BarcodeFormat.DATA_MATRIX,
                            //BarcodeFormat.PDF_417,
                            //BarcodeFormat.AZTEC,
                            //BarcodeFormat.CODABAR,
                            //BarcodeFormat.EAN_8,
                            //BarcodeFormat.EAN_13,
                            //BarcodeFormat.UPC_A,
                            //BarcodeFormat.UPC_E
                    },
                            // 添加字符集支持
                            CharacterSet = "UTF-8"
                        }
                    };
                };

                Console.WriteLine("开始识别...");

                if (!QuickDetectQRCode(skBitmap))
                {
                    Console.WriteLine("快速检测：图片中未发现二维码特征，跳过复杂处理");
                    // 只执行最简单的直接解码
                    detectedObjects = TryDecodeDirect(skBitmap, CreateReader);
                    Console.WriteLine($"快速检测结果：识别到 {detectedObjects.Count} 个码");
                    return detectedObjects;
                }


                // 多级预处理组合
                var strategyResults = new List<DetectedObject>();

                //直接解码（不预处理）
                Console.WriteLine("直接解码");
                strategyResults.AddRange(TryDecodeDirect(skBitmap, CreateReader));
                if (strategyResults.Any()) Console.WriteLine("直接解码成功");

                //轻度预处理
                if (!strategyResults.Any())
                {
                    Console.WriteLine("轻度预处理组合");
                    var lightResults = TryDecodeWithMultiLightProcessing(skBitmap, CreateReader, "");
                    strategyResults.AddRange(lightResults);
                    if (lightResults.Any()) Console.WriteLine("轻度预处理组合成功");
                }

                // 微重度预处理
                if (!strategyResults.Any())
                {
                    Console.WriteLine("微重度预处理组合");
                    var heavyResults = TryDecodeWithHeavyProcessing(skBitmap, CreateReader, ImageFile);
                    strategyResults.AddRange(heavyResults);
                    if (heavyResults.Any()) Console.WriteLine("微重度预处理组合成功");
                }

                // 中重度预处理
                if (!strategyResults.Any())
                {
                    Console.WriteLine("中重度预处理组合");
                    var heavyResults = TryDecodeWithHeavyPlusProcessing(skBitmap, CreateReader, ImageFile);
                    strategyResults.AddRange(heavyResults);
                    if (heavyResults.Any()) Console.WriteLine("中重度预处理组合成功");
                }


                // 多区域扫描
                if (!strategyResults.Any())
                {
                    Console.WriteLine("开始多区域扫描");
                    var regionResults = TryDecodeMultipleRegionsEnhanced(skBitmap, CreateReader);
                    strategyResults.AddRange(regionResults);
                    if (regionResults.Any()) Console.WriteLine("多区域扫描成功");
                }

                //自适应
                if (!strategyResults.Any())
                {
                    Console.WriteLine("开始自适应参数组合");
                    var adaptiveResults = TryDecodeWithAdaptiveParameters(skBitmap, CreateReader);
                    strategyResults.AddRange(adaptiveResults);
                    if (adaptiveResults.Any()) Console.WriteLine("自适应参数组合成功");
                }

                // 去重处理
                detectedObjects = strategyResults
                    .DistinctBy(x => x.Content)
                    .ToList();

                Console.WriteLine($"总共识别到 {detectedObjects.Count} 个码");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"二维码识别异常：{ex.Message}");
                Console.WriteLine($"StackTrace：{ex.StackTrace}");
            }
            return detectedObjects;
        }

        public static List<DetectedObject> DecodeBarcodes(Stream imageStream, out int currentPage, out int totalPages, string ImageFile)
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

                #region 新解碼
                // 保存原始图像
                //SaveBitmapToFile(skBitmap, "original.png", ImageFile);

                //解码器配置
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
                            //BarcodeFormat.QR_CODE
                            //,
                            BarcodeFormat.CODE_128
                            //,
                            //BarcodeFormat.CODE_39,
                            //BarcodeFormat.DATA_MATRIX,
                            //BarcodeFormat.PDF_417,
                            //BarcodeFormat.AZTEC,
                            //BarcodeFormat.CODABAR,
                            //BarcodeFormat.EAN_8,
                            //BarcodeFormat.EAN_13,
                            //BarcodeFormat.UPC_A,
                            //BarcodeFormat.UPC_E
                            },
                            // 添加字符集支持
                            CharacterSet = "UTF-8"
                        }
                    };
                };

                Console.WriteLine("开始裁剪圖片...");

                // Crop to right half
                int halfWidth = skBitmap.Width / 2;
                int rightX = skBitmap.Width - halfWidth;

                var rightHalfRect = new SKRectI(rightX, 0, skBitmap.Width, skBitmap.Height);
                using var rightHalfBitmap = new SKBitmap(rightHalfRect.Width, rightHalfRect.Height);
                skBitmap.ExtractSubset(rightHalfBitmap, rightHalfRect);

                // 保存右半部分图像
                //SaveBitmapToFile(rightHalfBitmap, "right_half.png", ImageFile);

                // Crop to bottom 3/16 of the right half
                int bottomHeight = rightHalfBitmap.Height * 2 / 16;
                int bottomY = rightHalfBitmap.Height - bottomHeight;

                var bottomRect = new SKRectI(0, bottomY, rightHalfBitmap.Width, rightHalfBitmap.Height);
                using var croppedBitmap = new SKBitmap(bottomRect.Width, bottomRect.Height);
                rightHalfBitmap.ExtractSubset(croppedBitmap, bottomRect);

                Console.WriteLine($"裁剪后图像尺寸：{croppedBitmap.Width}x{croppedBitmap.Height}");


                // 保存裁剪后的图像
                SaveBitmapToFile(croppedBitmap, "cropped.png", ImageFile);

                Console.WriteLine("开始识别...");

                // ========== 新增：放大倍数识别测试 ==========

                // 测试不同的放大倍数
                //float[] magnifications = { 1.0f, 1.5f, 2.0f, 2.5f, 3.0f, 5.0f, 10.0f, 15.0f };
                //float[] magnifications = { 1.0f};
                // 多级预处理组合
                var strategyResults = new List<DetectedObject>();

                //foreach (float mag in magnifications)
                //{
                //    Console.WriteLine($"尝试放大倍数: {mag}x");
                //    Console.WriteLine($"-------------------------START({mag}x)-------------------------");

                var magnifiedBitmap = croppedBitmap;
                //if (mag!=1)
                //{
                //     magnifiedBitmap = TryDecodeWithMagnification(croppedBitmap, CreateReader, mag, ImageFile);
                //}

                //直接解码（不预处理）
                Console.WriteLine("直接解码");
                strategyResults.AddRange(TryDecodeDirect(magnifiedBitmap, CreateReader));

                if (strategyResults.Any()) Console.WriteLine("直接解码成功");

                //轻度预处理
                if (!strategyResults.Any())
                {
                    Console.WriteLine("轻度预处理组合");
                    var lightResults = TryDecodeWithMultiLightProcessing(magnifiedBitmap, CreateReader, ImageFile);
                    strategyResults.AddRange(lightResults);
                    if (lightResults.Any()) Console.WriteLine("轻度预处理组合成功");
                }

                // 重度预处理
                if (!strategyResults.Any())
                {
                    Console.WriteLine("重度预处理组合");
                    var heavyResults = TryDecodeWithHeavyProcessing(magnifiedBitmap, CreateReader, ImageFile);
                    strategyResults.AddRange(heavyResults);
                    if (heavyResults.Any()) Console.WriteLine("重度预处理组合成功");
                }

                //自适应
                if (!strategyResults.Any())
                {
                    Console.WriteLine("开始自适应参数组合");
                    var adaptiveResults = TryDecodeWithAdaptiveParameters(magnifiedBitmap, CreateReader);
                    strategyResults.AddRange(adaptiveResults);
                    if (adaptiveResults.Any()) Console.WriteLine("自适应参数组合成功");
                }
                //Console.WriteLine($"-------------------------END({mag}x)-------------------------");

                //    if (strategyResults.Any())
                //    {
                //        break;
                //    }
                //}

                //if (magnificationResults.Any())
                //{
                //    detectedObjects = magnificationResults;
                //    Console.WriteLine($"放大识别成功：识别到 {detectedObjects.Count} 个码");
                //    return detectedObjects;
                //}

                // 去重处理
                detectedObjects = strategyResults
                    .DistinctBy(x => x.Content)
                    .ToList();

                Console.WriteLine($"总共识别到 {detectedObjects.Count} 个码");
                #endregion

                #region 舊解碼
                //// Crop to right half
                //int halfWidth = skBitmap.Width / 2;
                //int rightX = skBitmap.Width - halfWidth;

                //var rightHalfRect = new SKRectI(rightX, 0, skBitmap.Width, skBitmap.Height);
                //using var rightHalfBitmap = new SKBitmap(rightHalfRect.Width, rightHalfRect.Height);
                //skBitmap.ExtractSubset(rightHalfBitmap, rightHalfRect);

                //// Crop to bottom 3/16 of the right half
                //int bottomHeight = rightHalfBitmap.Height * 3 / 16;
                //int bottomY = rightHalfBitmap.Height - bottomHeight;

                //var bottomRect = new SKRectI(0, bottomY, rightHalfBitmap.Width, rightHalfBitmap.Height);
                //using var croppedBitmap = new SKBitmap(bottomRect.Width, bottomRect.Height);
                //rightHalfBitmap.ExtractSubset(croppedBitmap, bottomRect);


                //var bcLuminanceSource = new SKBitmapLuminanceSource(croppedBitmap);
                //var barcodeReader = new BarcodeReaderGeneric
                //{
                //    AutoRotate = true,
                //    Options = new DecodingOptions
                //    {
                //        TryHarder = true,
                //        PureBarcode = false,
                //        PossibleFormats = new List<BarcodeFormat> { BarcodeFormat.CODE_128 }
                //    }
                //};
                //var bcResults = barcodeReader.DecodeMultiple(bcLuminanceSource);
                //if (bcResults != null)
                //{
                //    foreach (var result in bcResults)
                //    {
                //        detectedObjects.Add(new DetectedObject
                //        {
                //            Type = result.BarcodeFormat.ToString(),
                //            Content = result.Text
                //        });
                //    }
                //}
                #endregion
            }
            catch (Exception ex)
            {
                Console.WriteLine($"條形碼识别异常：{ex.Message}");
                Console.WriteLine($"StackTrace：{ex.StackTrace}");
            }
            return detectedObjects;
        }

        // ========== 新增：保存图像到文件 ==========
        private static void SaveBitmapToFile(SKBitmap bitmap, string fileName, string ImageFile)
        {
            try
            {
                if (string.IsNullOrEmpty(ImageFile) || string.IsNullOrEmpty(fileName) || bitmap == null)
                {
                    return;
                }
                // 指定保存到D盘特定文件夹
                string savePath = Path.Combine(ImageFile, fileName);

                // 确保目录存在
                string directory = Path.GetDirectoryName(savePath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                using var image = SKImage.FromBitmap(bitmap);
                using var data = image.Encode(SKEncodedImageFormat.Png, 100);
                using var stream = File.OpenWrite(savePath);
                data.SaveTo(stream);
                Console.WriteLine($"图像已保存: {savePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"保存图像失败 {fileName}: {ex.Message}");
            }
        }

        // ========== 新增：放大倍数识别方法 ==========
        private static SKBitmap TryDecodeWithMagnification(SKBitmap original, Func<BarcodeFormat, BarcodeReaderGeneric> createReader, float magnification, string ImageFile)
        {
            //var results = new List<DetectedObject>();
            try
            {
                // 计算放大后的尺寸
                int newWidth = (int)(original.Width * magnification);
                int newHeight = (int)(original.Height * magnification);

                // 使用高质量缩放
                var magnifiedBitmap = original.Resize(new SKImageInfo(newWidth, newHeight), SKFilterQuality.High);

                // 保存放大后的图像
                SaveBitmapToFile(magnifiedBitmap, $"magnified_{magnification}x.png", ImageFile);

                return magnifiedBitmap;
                //// 尝试解码
                //var luminanceSource = new SKBitmapLuminanceSource(magnifiedBitmap);
                //var reader = createReader(BarcodeFormat.CODE_128);
                //var decodeResults = reader.DecodeMultiple(luminanceSource);

                //if (decodeResults != null)
                //{
                //    foreach (var result in decodeResults)
                //    {
                //        if (!string.IsNullOrEmpty(result.Text))
                //        {
                //            results.Add(new DetectedObject
                //            {
                //                Type = result.BarcodeFormat.ToString(),
                //                Content = result.Text
                //            });
                //            Console.WriteLine($"放大{magnification}x解码：{result.BarcodeFormat} - {result.Text}");
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine($"放大{magnification}x解码失败：{ex.Message}");
                return null;
            }
        }

        // No Aspose.Barcode license
        public static List<DetectedObject> DetectBarcodesAspose(Stream imageStream)
        {
            var detectedObjects = new List<DetectedObject>();
            using (var reader = new BarCodeReader(imageStream, DecodeType.QR, DecodeType.Code128))
            {
                foreach (BarCodeResult result in reader.ReadBarCodes())
                {
                    detectedObjects.Add(new DetectedObject
                    {
                        Type = result.CodeTypeName,
                        Content = result.CodeText
                    });
                }
            }
            return detectedObjects;
        }

        private static bool QuickDetectQRCode(SKBitmap bitmap)
        {
            try
            {
                // 1. 检查图像尺寸（太小或太大的图像可能没有二维码）
                if (bitmap.Width < 50 || bitmap.Height < 50 || bitmap.Width > 5000 || bitmap.Height > 5000)
                    return false;

                // 2. 快速采样检查（检查几个关键区域是否有二维码特征）
                var samplePoints = new[]
                {
                    new SKPointI(bitmap.Width / 4, bitmap.Height / 4),          // 左上1/4
                    new SKPointI(bitmap.Width * 3 / 4, bitmap.Height / 4),      // 右上1/4
                    new SKPointI(bitmap.Width / 4, bitmap.Height * 3 / 4),      // 左下1/4
                    new SKPointI(bitmap.Width * 3 / 4, bitmap.Height * 3 / 4),  // 右下1/4
                    new SKPointI(bitmap.Width / 2, bitmap.Height / 2)           // 中心
                };

                int qrFeatureCount = 0;
                foreach (var point in samplePoints)
                {
                    if (point.X < bitmap.Width && point.Y < bitmap.Height)
                    {
                        var color = bitmap.GetPixel(point.X, point.Y);
                        // 检查是否有高对比度区域（二维码特征）
                        byte gray = (byte)(color.Red * 0.299 + color.Green * 0.587 + color.Blue * 0.114);
                        if (gray < 50 || gray > 200) // 很暗或很亮的区域
                            qrFeatureCount++;
                    }
                }

                // 3. 如果有足够的高对比度区域，认为可能有二维码
                return qrFeatureCount >= 3;
            }
            catch
            {
                // 如果快速检测失败，保守起见认为可能有二维码
                return true;
            }
        }

        //不预处理，直接读取
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
                            if (!FormatCheckFun(result))
                            {
                                continue;
                            }

                            results.Add(new DetectedObject
                            {
                                Type = result.BarcodeFormat.ToString(),
                                Content = result.Text,
                                resultPoints = result.ResultPoints
                            });
                            Console.WriteLine($"直接解码：{result.BarcodeFormat} - {result.Text}");
                            Console.WriteLine($"坐标 左上角:{result.ResultPoints[0]}右上角:{result.ResultPoints[1]}右下角:{result.ResultPoints[2]}左下角:{result.ResultPoints[3]}");
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

        private static bool FormatCheckFun(Result result)
        {
            if (!FormatCheck)
            {
                return false;
            }
            //QR_CODE格式校验
            if (result.BarcodeFormat.ToString() == "QR_CODE" && result.Text.Contains("||"))
            {
                var parts = result.Text.Split(new[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length < 1 || !parts[0].Contains("."))
                {
                    return false;
                }
                var episodeParts = parts[0].Trim().Split('.');
                if (episodeParts.Length < 2 || string.IsNullOrEmpty(episodeParts[1]))
                {
                    return false;
                }
            }
            else if (result.BarcodeFormat.ToString() == "QR_CODE")
            {
                return false; // QR_CODE但不含"||"分隔符
            }

            return true;
        }

        //轻度预处理（适合清晰图像）
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

                // 3. 轻微高斯模糊（去噪）
                using var blurredBitmap = new SKBitmap(newWidth, newHeight);
                using (var canvas = new SKCanvas(blurredBitmap))
                {
                    using var paint = new SKPaint();
                    paint.MaskFilter = SKMaskFilter.CreateBlur(SKBlurStyle.Normal, 0.5f); // 轻微模糊
                    canvas.DrawBitmap(grayBitmap, 0, 0, paint);
                }

                return grayBitmap.Copy();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"轻度预处理失败：{ex.Message}");
                return original.Copy();
            }
        }

        // 重度预处理（适合模糊、低对比度图像）
        private static SKBitmap BinarizeBitmap(SKBitmap src)
        {
            var dst = new SKBitmap(src.Info);

            ReadOnlySpan<byte> srcPixels = src.GetPixelSpan();
            Span<byte> dstPixels = dst.GetPixelSpan();

            int pixelCount = srcPixels.Length / 4; // 每个像素 4 字节
            int stride = src.Width * 4;

            // 第一步：计算平均灰度（简化阈值）
            long sum = 0;
            for (int i = 0; i < pixelCount; i++)
            {
                int offset = i * 4;
                byte b = srcPixels[offset + 0]; // B
                byte g = srcPixels[offset + 1]; // G
                byte r = srcPixels[offset + 2]; // R
                byte a = srcPixels[offset + 3]; // A

                byte gray = (byte)(0.299 * r + 0.587 * g + 0.114 * b);
                sum += gray;
            }
            byte threshold = (byte)(sum / pixelCount);

            // 第二步：二值化并写入目标
            for (int i = 0; i < pixelCount; i++)
            {
                int offset = i * 4;
                byte b = srcPixels[offset + 0];
                byte g = srcPixels[offset + 1];
                byte r = srcPixels[offset + 2];

                byte gray = (byte)(0.299 * r + 0.587 * g + 0.114 * b);
                byte bin = gray < threshold ? (byte)0 : (byte)255;

                dstPixels[offset + 0] = bin; // B
                dstPixels[offset + 1] = bin; // G
                dstPixels[offset + 2] = bin; // R
                dstPixels[offset + 3] = 255; // A
            }

            return dst;
        }

        //多参数轻度预处理
        private static List<DetectedObject> TryDecodeWithMultiLightProcessing(SKBitmap original, Func<BarcodeFormat, BarcodeReaderGeneric> createReader, string ImageFile = "")
        {
            var results = new List<DetectedObject>();
            var scales = new[] { 0.8f, 1.0f, 1.2f, 1.5f, 2.0f };
            //var scales = new[] { 1.0f, 1.2f, 1.5f, 2.0f };

            foreach (var scale in scales)
            {
                try
                {
                    using var processed = LightPreprocessImage(original, scale);

                    SaveBitmapToFile(processed, scale + "Light.png", ImageFile);

                    var luminanceSource = new SKBitmapLuminanceSource(processed);
                    var reader = createReader(BarcodeFormat.CODE_128);
                    var decodeResults = reader.DecodeMultiple(luminanceSource);

                    if (decodeResults != null)
                    {
                        foreach (var result in decodeResults)
                        {
                            if (!string.IsNullOrEmpty(result.Text))
                            {
                                if (!FormatCheckFun(result))
                                {
                                    continue;
                                }

                                results.Add(new DetectedObject
                                {
                                    Type = result.BarcodeFormat.ToString(),
                                    Content = result.Text,
                                    resultPoints = result.ResultPoints
                                });
                                Console.WriteLine($"轻度预处理(缩放{scale})解码：{result.BarcodeFormat} - {result.Text}");
                            }
                        }

                        if (results != null)
                        {
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"轻度预处理(缩放{scale})解码失败：{ex.Message}");
                }
            }

            return results;
        }

        //微重度预处理（使用高效二值化）
        private static List<DetectedObject> TryDecodeWithHeavyProcessing(SKBitmap original, Func<BarcodeFormat, BarcodeReaderGeneric> createReader, string ImageFile = "")
        {
            var results = new List<DetectedObject>();

            try
            {
                // 使用高效二值化方法
                using var processed = BinarizeBitmap(original);
                SaveBitmapToFile(processed, "Heavy.png", ImageFile);

                var luminanceSource = new SKBitmapLuminanceSource(processed);
                var reader = createReader(BarcodeFormat.QR_CODE);
                var decodeResults = reader.DecodeMultiple(luminanceSource);

                if (decodeResults != null)
                {
                    foreach (var result in decodeResults)
                    {
                        if (!string.IsNullOrEmpty(result.Text))
                        {
                            if (!FormatCheckFun(result))
                            {
                                continue;
                            }

                            results.Add(new DetectedObject
                            {
                                Type = result.BarcodeFormat.ToString(),
                                Content = result.Text,
                                resultPoints = result.ResultPoints
                            });
                            Console.WriteLine($"微重度预处理解码：{result.BarcodeFormat} - {result.Text}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"微重度预处理解码失败：{ex.Message}");
            }

            return results;
        }

        //中重度预处理（使用高效二值化） 重度后在按倍率識別一次輕度
        private static List<DetectedObject> TryDecodeWithHeavyPlusProcessing(SKBitmap original, Func<BarcodeFormat, BarcodeReaderGeneric> createReader, string ImageFile = "")
        {
            var results = new List<DetectedObject>();

            try
            {
                // 使用高效二值化方法
                using var processedold = BinarizeBitmap(original);

                return TryDecodeWithMultiLightProcessing(processedold, createReader, ImageFile);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"中重度预处理解码失败：{ex.Message}");
            }

            return results;
        }

        // 多区域扫描
        private static List<DetectedObject> TryDecodeMultipleRegionsEnhanced(SKBitmap original, Func<BarcodeFormat, BarcodeReaderGeneric> createReader)
        {
            var results = new List<DetectedObject>();

            //// 定义更多扫描区域
            //var regions = new[]
            //{
            //    //new SKRectI(0, 0, original.Width, original.Height), // 全图
            //    new SKRectI(0, 0, original.Width / 2, original.Height), // 左半区
            //    new SKRectI(original.Width / 2, 0, original.Width, original.Height), // 右半区
            //    new SKRectI(0, 0, original.Width, original.Height / 2), // 上半区
            //    new SKRectI(0, original.Height / 2, original.Width, original.Height), // 下半区
            //    new SKRectI(original.Width / 4, original.Height / 4, original.Width * 3 / 4, original.Height * 3 / 4), // 中心区
            //    new SKRectI(0, 0, original.Width / 3, original.Height), // 左1/3
            //    new SKRectI(original.Width / 3, 0, original.Width * 2 / 3, original.Height), // 中1/3
            //    new SKRectI(original.Width * 2 / 3, 0, original.Width, original.Height) // 右1/3
            //};

            int w = original.Width;
            int h = original.Height;
            int halfW = w / 2;
            int halfH = h / 2;

            var regions = new[]
            {
                new SKRectI(0,          0,          halfW,      halfH),       // 左上
                new SKRectI(halfW,      0,          w,          halfH),       // 右上
                new SKRectI(0,          halfH,      halfW,      h),           // 左下
                new SKRectI(halfW,      halfH,      w,          h)            // 右下
            };

            foreach (var region in regions)
            {
                try
                {
                    using var regionBitmap = new SKBitmap(region.Width, region.Height);
                    if (original.ExtractSubset(regionBitmap, region))
                    {
                        // 对每个区域尝试多种预处理
                        var regionResults = TryDecodeDirect(regionBitmap, createReader);
                        results.AddRange(regionResults);

                        if (!regionResults.Any())
                        {
                            regionResults = TryDecodeWithMultiLightProcessing(regionBitmap, createReader);
                            results.AddRange(regionResults);
                        }

                        if (!regionResults.Any())
                        {
                            regionResults = TryDecodeWithHeavyProcessing(regionBitmap, createReader);
                            results.AddRange(regionResults);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"多区域失败：{ex.Message}");
                }
            }

            return results.DistinctBy(x => x.Content).ToList();
        }

        //自适应
        private static List<DetectedObject> TryDecodeWithAdaptiveParameters(SKBitmap original, Func<BarcodeFormat, BarcodeReaderGeneric> createReader)
        {
            var results = new List<DetectedObject>();

            // 根据图像尺寸自适应参数
            var imageSize = original.Width * original.Height;
            var isSmallImage = imageSize < 500 * 500;
            var isLargeImage = imageSize > 2000 * 2000;

            // 小图像：使用较大缩放比例
            if (isSmallImage)
            {
                var scales = new[] { 2.0f, 3.0f, 4.0f };
                foreach (var scale in scales)
                {
                    try
                    {
                        using var processed = LightPreprocessImage(original, scale);
                        var luminanceSource = new SKBitmapLuminanceSource(processed);
                        var reader = createReader(BarcodeFormat.QR_CODE);
                        var decodeResults = reader.DecodeMultiple(luminanceSource);

                        if (decodeResults != null)
                        {
                            foreach (var result in decodeResults)
                            {
                                if (!string.IsNullOrEmpty(result.Text))
                                {
                                    if (!FormatCheckFun(result))
                                    {
                                        continue;
                                    }

                                    results.Add(new DetectedObject
                                    {
                                        Type = result.BarcodeFormat.ToString(),
                                        Content = result.Text,
                                        resultPoints = result.ResultPoints
                                    });
                                    Console.WriteLine($"自适应(小图缩放{scale})解码：{result.BarcodeFormat} - {result.Text}");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"自适应(小图缩放{scale})解码失败：{ex.Message}");
                    }
                }
            }

            // 大图像：使用较小缩放比例和更多区域扫描
            if (isLargeImage)
            {
                var scales = new[] { 0.5f, 0.8f, 1.0f };
                foreach (var scale in scales)
                {
                    try
                    {
                        using var processed = LightPreprocessImage(original, scale);
                        var luminanceSource = new SKBitmapLuminanceSource(processed);
                        var reader = createReader(BarcodeFormat.QR_CODE);
                        var decodeResults = reader.DecodeMultiple(luminanceSource);

                        if (decodeResults != null)
                        {
                            foreach (var result in decodeResults)
                            {
                                if (!string.IsNullOrEmpty(result.Text))
                                {
                                    if (!FormatCheckFun(result))
                                    {
                                        continue;
                                    }

                                    results.Add(new DetectedObject
                                    {
                                        Type = result.BarcodeFormat.ToString(),
                                        Content = result.Text,
                                        resultPoints = result.ResultPoints
                                    });
                                    Console.WriteLine($"自适应(大图缩放{scale})解码：{result.BarcodeFormat} - {result.Text}");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"自适应(大图缩放{scale})解码失败：{ex.Message}");
                    }
                }
            }

            return results;
        }

        public class DetectedObject
        {
            public string Type { get; set; }
            public string Content { get; set; }
            // 可补充：位置、置信度等字段
            public ResultPoint[] resultPoints { get; set; }
        }


        /// <summary>
        /// 在图像上标记二维码坐标
        /// </summary>
        /// <param name="originalBitmap">原始图像</param>
        /// <param name="detectedObjects">检测到的二维码对象</param>
        /// <param name="outputPath">输出图片路径</param>
        public static void MarkQRCodeCoordinates(SKBitmap originalBitmap, List<DetectedObject> detectedObjects, string outputPath)
        {
            if (originalBitmap == null || detectedObjects == null || !detectedObjects.Any())
                return;

            try
            {
                // 创建新的画布用于绘制标记
                using var markedBitmap = new SKBitmap(originalBitmap.Width, originalBitmap.Height);
                using var canvas = new SKCanvas(markedBitmap);

                // 绘制原始图像作为背景
                canvas.DrawBitmap(originalBitmap, 0, 0);

                // 设置绘制参数
                var paint = new SKPaint
                {
                    Style = SKPaintStyle.Stroke,
                    Color = SKColors.Red,
                    StrokeWidth = 3,
                    IsAntialias = true
                };

                var textPaint = new SKPaint
                {
                    Color = SKColors.Blue,
                    TextSize = 16,
                    IsAntialias = true,
                    Typeface = SKTypeface.FromFamilyName("Arial")
                };

                int qrCodeIndex = 1;

                foreach (var detectedObject in detectedObjects)
                {
                    if (detectedObject.resultPoints == null || detectedObject.resultPoints.Length < 3)
                        continue;

                    // 绘制二维码边界框
                    var points = detectedObject.resultPoints;

                    // 绘制四个角点
                    for (int i = 0; i < points.Length; i++)
                    {
                        var point = points[i];
                        if (point != null)
                        {
                            // 绘制角点圆圈
                            canvas.DrawCircle(point.X, point.Y, 8, paint);

                            // 绘制角点编号
                            string pointLabel = $"{i + 1}";
                            canvas.DrawText(pointLabel, point.X + 10, point.Y - 10, textPaint);
                        }
                    }

                    // 绘制连接线（形成四边形）
                    if (points.Length >= 4)
                    {
                        // 左上到右上
                        if (points[0] != null && points[1] != null)
                            canvas.DrawLine(points[0].X, points[0].Y, points[1].X, points[1].Y, paint);

                        // 右上到右下
                        if (points[1] != null && points[2] != null)
                            canvas.DrawLine(points[1].X, points[1].Y, points[2].X, points[2].Y, paint);

                        // 右下到左下
                        if (points[2] != null && points[3] != null)
                            canvas.DrawLine(points[2].X, points[2].Y, points[3].X, points[3].Y, paint);

                        // 左下到左上
                        if (points[3] != null && points[0] != null)
                            canvas.DrawLine(points[3].X, points[3].Y, points[0].X, points[0].Y, paint);
                    }

                    // 计算二维码中心位置
                    float centerX = 0, centerY = 0;
                    int validPoints = 0;
                    foreach (var point in points)
                    {
                        if (point != null)
                        {
                            centerX += point.X;
                            centerY += point.Y;
                            validPoints++;
                        }
                    }

                    if (validPoints > 0)
                    {
                        centerX /= validPoints;
                        centerY /= validPoints;

                        // 在中心位置绘制二维码编号和内容
                        string qrInfo = $"QR{qrCodeIndex}: {detectedObject.Content}";
                        canvas.DrawText(qrInfo, centerX - 50, centerY, textPaint);
                    }

                    qrCodeIndex++;
                }

                // 确保输出目录存在
                string directory = Path.GetDirectoryName(outputPath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                // 保存标记后的图像
                using var image = SKImage.FromBitmap(markedBitmap);
                using var data = image.Encode(SKEncodedImageFormat.Png, 100);
                using var stream = File.OpenWrite(outputPath);
                data.SaveTo(stream);

                Console.WriteLine($"成功标记 {detectedObjects.Count} 个二维码坐标");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"标记二维码坐标失败：{ex.Message}");
            }
        }

        /// <summary>
        /// 找到图片中最靠左边的二维码
        /// 如果有多个最靠左边的，取最上面那个
        /// </summary>
        /// <param name="detectedObjects">检测到的二维码对象列表</param>
        /// <returns>最靠左边的二维码对象，如果没有则返回null</returns>
        public static DetectedObject FindLeftmostQRCode(List<DetectedObject> detectedObjects)
        {
            if (detectedObjects == null || !detectedObjects.Any())
                return null;

            try
            {
                // 过滤掉没有坐标点的二维码
                var validQRCodes = detectedObjects
                    .Where(qr => qr.resultPoints != null && qr.resultPoints.Length >= 3)
                    .ToList();

                if (!validQRCodes.Any())
                    return null;

                // 计算每个二维码的中心点X坐标（最左边的点）
                var qrCodesWithLeftmostX = validQRCodes
                    .Select(qr => new
                    {
                        QRCode = qr,
                        // 计算二维码最左边的X坐标（取所有角点中最小的X值）
                        LeftmostX = qr.resultPoints
                            .Where(p => p != null)
                            .Min(p => p.X),
                        // 计算二维码最上边的Y坐标（取所有角点中最小的Y值）
                        TopmostY = qr.resultPoints
                            .Where(p => p != null)
                            .Min(p => p.Y)
                    })
                    .ToList();

                // 找到最左边的X坐标
                var minLeftmostX = qrCodesWithLeftmostX.Min(qr => qr.LeftmostX);

                // 找出所有最左边的二维码（X坐标等于最小值）
                var leftmostQRCodes = qrCodesWithLeftmostX
                    .Where(qr => qr.LeftmostX == minLeftmostX)
                    .ToList();

                // 如果只有一个最左边的二维码，直接返回
                if (leftmostQRCodes.Count == 1)
                    return leftmostQRCodes[0].QRCode;

                // 如果有多个最左边的二维码，取最上面那个（Y坐标最小）
                var topmostQRCode = leftmostQRCodes
                    .OrderBy(qr => qr.TopmostY)
                    .FirstOrDefault();

                return topmostQRCode?.QRCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"查找最左边二维码失败：{ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// 在图像上标记最左边的二维码
        /// </summary>
        /// <param name="originalBitmap">原始图像</param>
        /// <param name="detectedObjects">检测到的二维码对象</param>
        /// <param name="outputPath">输出图片路径</param>
        public static void MarkLeftmostQRCode(SKBitmap originalBitmap, List<DetectedObject> detectedObjects, string outputPath)
        {
            if (originalBitmap == null || detectedObjects == null || !detectedObjects.Any())
                return;

            // 找到最左边的二维码
            var leftmostQRCode = FindLeftmostQRCode(detectedObjects);

            if (leftmostQRCode == null)
            {
                Console.WriteLine("未找到有效的二维码");
                return;
            }

            try
            {
                // 创建新的画布用于绘制标记
                using var markedBitmap = new SKBitmap(originalBitmap.Width, originalBitmap.Height);
                using var canvas = new SKCanvas(markedBitmap);

                // 绘制原始图像作为背景
                canvas.DrawBitmap(originalBitmap, 0, 0);

                // 设置绘制参数
                var highlightPaint = new SKPaint
                {
                    Style = SKPaintStyle.Stroke,
                    Color = SKColors.Green, // 使用绿色高亮显示最左边的二维码
                    StrokeWidth = 5,
                    IsAntialias = true
                };

                var textPaint = new SKPaint
                {
                    Color = SKColors.Red,
                    TextSize = 20,
                    IsAntialias = true,
                    Typeface = SKTypeface.FromFamilyName("Arial", SKFontStyle.Bold)
                };

                // 绘制最左边二维码的边界框
                var points = leftmostQRCode.resultPoints;

                if (points != null && points.Length >= 3)
                {
                    // 绘制四个角点（绿色大圆圈）
                    for (int i = 0; i < points.Length; i++)
                    {
                        var point = points[i];
                        if (point != null)
                        {
                            // 绘制角点圆圈
                            canvas.DrawCircle(point.X, point.Y, 12, highlightPaint);

                            // 绘制角点编号
                            string pointLabel = $"{i + 1}";
                            canvas.DrawText(pointLabel, point.X + 15, point.Y - 15, textPaint);
                        }
                    }

                    // 绘制连接线（形成四边形）
                    if (points.Length >= 4)
                    {
                        // 左上到右上
                        if (points[0] != null && points[1] != null)
                            canvas.DrawLine(points[0].X, points[0].Y, points[1].X, points[1].Y, highlightPaint);

                        // 右上到右下
                        if (points[1] != null && points[2] != null)
                            canvas.DrawLine(points[1].X, points[1].Y, points[2].X, points[2].Y, highlightPaint);

                        // 右下到左下
                        if (points[2] != null && points[3] != null)
                            canvas.DrawLine(points[2].X, points[2].Y, points[3].X, points[3].Y, highlightPaint);

                        // 左下到左上
                        if (points[3] != null && points[0] != null)
                            canvas.DrawLine(points[3].X, points[3].Y, points[0].X, points[0].Y, highlightPaint);
                    }

                    // 计算二维码中心位置
                    float centerX = 0, centerY = 0;
                    int validPoints = 0;
                    foreach (var point in points)
                    {
                        if (point != null)
                        {
                            centerX += point.X;
                            centerY += point.Y;
                            validPoints++;
                        }
                    }

                    if (validPoints > 0)
                    {
                        centerX /= validPoints;
                        centerY /= validPoints;

                        // 在中心位置绘制"最左边二维码"标识
                        string qrInfo = $"最左边二维码: {leftmostQRCode.Content}";
                        canvas.DrawText(qrInfo, centerX - 80, centerY - 30, textPaint);

                        // 绘制箭头指向最左边二维码
                        var arrowPaint = new SKPaint
                        {
                            Color = SKColors.Orange,
                            StrokeWidth = 3,
                            IsAntialias = true
                        };

                        // 在图片左上角绘制箭头指向最左边二维码
                        float arrowStartX = 50;
                        float arrowStartY = 50;
                        canvas.DrawLine(arrowStartX, arrowStartY, centerX, centerY, arrowPaint);

                        // 绘制箭头头部
                        canvas.DrawCircle(centerX, centerY, 8, arrowPaint);
                    }
                }

                // 确保输出目录存在
                string directory = Path.GetDirectoryName(outputPath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                // 保存标记后的图像
                using var image = SKImage.FromBitmap(markedBitmap);
                using var data = image.Encode(SKEncodedImageFormat.Png, 100);
                using var stream = File.OpenWrite(outputPath);
                data.SaveTo(stream);

                Console.WriteLine($"成功标记最左边二维码：{leftmostQRCode.Content}");
                Console.WriteLine($"二维码类型：{leftmostQRCode.Type}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"标记最左边二维码失败：{ex.Message}");
            }
        }
        #endregion

        #region OpenCVBarcode识别

        // 指定你的模型文件路径（确保在 Linux 服务器上这些文件也存在）
        static string detect_prototxt = Path.Combine("data", "wechat_qrcode", "detect.prototxt");
        static string detect_caffemodel = Path.Combine("data", "wechat_qrcode", "detect.caffemodel");
        static string sr_prototxt = Path.Combine("data", "wechat_qrcode", "sr.prototxt");
        static string sr_caffemodel = Path.Combine("data", "wechat_qrcode", "sr.caffemodel");
        public static void OpenCv()
        {
            DateTime Pstarttime = DateTime.Now;
            string folderPath = @"C:\Users\liusi\Desktop\一维码";

            //string folderPath = @"C:\Users\liusi\Desktop\PRD-Report\downloads";
            string SaveImageFile = @"C:\Users\liusi\Desktop\ZxingDemo";
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


            //Code.Scan();
            //Code code = new Code();
            using (Code code = new Code())
            {
                // 循环识别每个图片文件
                for (int i = 0; i < imageFiles.Count; i++)
                {
                    DateTime starttime = DateTime.Now;
                    string imagePath = imageFiles[i];
                    string fileName = Path.GetFileName(imagePath);

                    Console.WriteLine($"\n[{i + 1}/{totalImages}] 正在识别：{fileName}");
                    Console.WriteLine($"文件路径：{imagePath}");

                    try
                    {
                        #region 二维码
                        // var OpenCVresults = code.DecodeByOpenCV(imagePath);


                        //var leftmostQRCode=FindLeftmostQRCode(OpenCVresults);
                        // if (leftmostQRCode != null)
                        // {
                        //     Console.WriteLine($"  最左边二维码信息：");
                        //     Console.WriteLine($"    类型：{leftmostQRCode.Type}");
                        //     Console.WriteLine($"    内容：{leftmostQRCode.Content}");




                        //     // 显示坐标信息
                        //     if (leftmostQRCode.resultPoints != null && leftmostQRCode.resultPoints.Length >= 4)
                        //     {
                        //         Console.WriteLine($"    左上角坐标：({leftmostQRCode.resultPoints[0]?.X:F1}, {leftmostQRCode.resultPoints[0]?.Y:F1})");
                        //         Console.WriteLine($"    右上角坐标：({leftmostQRCode.resultPoints[1]?.X:F1}, {leftmostQRCode.resultPoints[1]?.Y:F1})");
                        //         Console.WriteLine($"    右下角坐标：({leftmostQRCode.resultPoints[2]?.X:F1}, {leftmostQRCode.resultPoints[2]?.Y:F1})");
                        //         Console.WriteLine($"    左下角坐标：({leftmostQRCode.resultPoints[3]?.X:F1}, {leftmostQRCode.resultPoints[3]?.Y:F1})");
                        //     }
                        // }

                        // // 处理识别结果
                        // if (OpenCVresults != null && OpenCVresults.Count > 0)
                        // {
                        //     successCount++;
                        //     Console.WriteLine($"  识别成功！找到 {OpenCVresults.Count} 个二维码：");
                        //     foreach (var result in OpenCVresults)
                        //     {
                        //         Console.WriteLine($"    内容：{result.Content}");
                        //     }
                        // }
                        // else
                        // {
                        //     failCount++;
                        //     Console.WriteLine($"  识别失败：未找到二维码");
                        // }
                        #endregion

                        //条形码
                        var OpenCVBarcoderesults = code.DetectBarcodesByOpenCv(imagePath);

                        //OpenCVresults.AddRange(OpenCVBarcoderesults);

                        continue;
                    }
                    catch (Exception ex)
                    {
                        failCount++;
                        Console.WriteLine($"  识别失败：{ex.Message}");
                    }
                    DateTime endtime = DateTime.Now;
                    TimeSpan duration = endtime - starttime;
                    Console.WriteLine($"图片总耗时: {duration.TotalSeconds} 秒");
                    Console.WriteLine("--------------------------------------------------");
                }
            }
            // 输出统计结果
            Console.WriteLine("\n==================================================");
            Console.WriteLine("识别统计结果：");
            Console.WriteLine($"总图片数：{totalImages}");
            Console.WriteLine($"识别成功：{successCount}");
            Console.WriteLine($"识别失败：{failCount}");
            Console.WriteLine($"成功率：{((double)successCount / totalImages * 100):F2}%");

            DateTime Pendtime = DateTime.Now;
            TimeSpan Pduration = Pendtime - Pstarttime;
            Console.WriteLine($"程序总耗时: {Pduration.TotalSeconds} 秒");

        }
        #endregion

        #region ChangeImages
        public static void ChangeImages()
        {
            string RelativePath = "/FileStore/20251212/1.jpg";
            string RelativePaths = RelativePath.Replace("/FileStore/", "");
            string rootPath = @"C:\Users\liusi\Desktop\图片\FileStore\";
            string relativeFolderPath = Path.GetDirectoryName(RelativePaths);
            string fileName = Path.GetFileNameWithoutExtension(RelativePaths) + ".jpg";

            //检查最后一个字符是否是路径分隔符
            if (!rootPath.EndsWith(Path.DirectorySeparatorChar.ToString()) && !rootPath.EndsWith(Path.AltDirectorySeparatorChar.ToString()))
            {
                // 如果不是，补上路径分隔符
                rootPath += Path.DirectorySeparatorChar;
            }

            string savedFilePath = SaveStreamToFileAsync(rootPath, relativeFolderPath, fileName, null);

            if (System.IO.File.Exists(savedFilePath))
            {
                savedFilePath = savedFilePath.Replace('\\', '/');

                string start = "/FileStore/";
                int Index = savedFilePath.IndexOf(start, StringComparison.OrdinalIgnoreCase);

                if (Index != -1)
                {
                    RelativePath = savedFilePath.Substring(Index);
                }
            }

            Console.WriteLine(RelativePath);
        }

        /// <summary>
        /// 保存流到系统目录（自动创建文件夹）
        /// </summary>
        private static string SaveStreamToFileAsync(string rootPath, string relativeFolderPath, string fileName, Stream fileStream)
        {
            string fullFolderPath = Path.GetFullPath(Path.Combine(rootPath, relativeFolderPath.TrimStart('\\', '/')));

            if (!Directory.Exists(fullFolderPath))
            {
                Directory.CreateDirectory(fullFolderPath);
            }

            string fullFilePath = Path.Combine(fullFolderPath, fileName);

            //if (fileStream.CanSeek)
            //{
            //    fileStream.Position = 0;
            //}
            //using (var outputStream = new FileStream(fullFilePath, FileMode.Create, FileAccess.Write, FileShare.None))
            //{
            //    fileStream.CopyTo(outputStream);
            //}
            return fullFilePath;
        }
        #endregion

        #region OCRChange
        public static void OCRChange()
        {
            #region 基礎數據
            string Data = "ADO-REGTN-001-C-V04-20230305,ADO-REGTN-001-E-V04-20230305,ADO-REGTN-002-C-V05-20230305,ADO-REGTN-002-E-V05-20230305,ADO-DOCNT-003,ADO-DOCNT-004,AHS-PROGN-001-E-V01-20201120,AHS-DISSM-002-E-V01-20201120,AHS-PROGN-003-E-V01-20201120,AHS-REFRL-004-E-V01-20201120,AHS-PROGN-005,AHS-REFRL-006,AHS-REFRL-007-E-V02-20230120,AHS-REQUT-008-E-V02-20220909,AHS-APPSL-009-C-V01-20210702,AHS-APPSL-009-E-V01-20210702,AHS-APPSL-010-C-V01-20210702,AHS-APPSL-010-E-V01-20210702,ASC-ASSES-001-E-V01-20220414,ASC-REPRT-002-E-V01-20220414,ASC-REPRT-003-E-V01-20220414,ASC-REPRT-004-E-V01-20220414,ASC-REPRT-005-E-V01-20220414,ASC-REPRT-006-E-V01-20220414,ASC-REPRT-007-E-V01-20220414,ASC-ASSES-008-C-V02-20230111,ASC-ASSES-008-E-V02-20230111,ASC-ASSES-009-C-V02-20230111,ASC-ASSES-009-E-V02-20230111,ASC-REFRL-010-E-V01-20220704,ASC-REFRL-011-E-V01-20220704,ASC-REFRL-012-E-V01-20220704,ASC-REPRT-013,ASC-REPRT-014,ASC-REPRT-015,ASC-REPRT-016,ASC-REPRT-017,ASC-REPRT-018,ASC-ASSES-019-E-V03-20250205,ASC-CHKLT-020-E-V01-20220719,ASC-REFRL-021-E-V02-20221024,ASC-REPRT-022-E-V01-20221111,ASC-CONST-023-C-V02-20230322,ASC-CONST-023-E-V02-20230322,ASC-CONST-024-C-V02-20231229,ASC-CONST-024-E-V02-20231229,ASC-CONST-025-C-V05-20230808,ASC-CONST-025-E-V05-20230808,ASC-CONST-026-C-V02-20231206,ASC-CONST-026-E-V02-20231206,ASC-CONST-027-C-V02-20231229,ASC-CONST-027-E-V02-20231229,ASC-ASSES-028-B-V02-20230322,ASC-REQUT-029-C-V01-20220907,ASC-REQUT-029-E-V01-20220907,ASC-CONST-030-C-V02-20231206,ASC-CONST-030-E-V02-20231206,ASC-REPRT-031-E-V01-20221111,ASC-REPRT-032-E-V01-20221212,ASC-REPRT-033-E-V01-20221111,ASC-CONST-034-C-V03-20240619,ASC-CONST-034-E-V03-20240619,ASC-CONST-035-C-V02-20231229,ASC-CONST-035-E-V02-20231229,ASC-REPRT-036,ASC-REPRT-037,ASC-ASSES-038-B-V01-20230825,ASC-CONST-039-C-V01-20230904,ASC-CONST-039-E-V01-20230904,ASC-CONST-040-C-V01-20230904,ASC-CONST-040-E-V01-20230904,ASC-CONST-041-C-V01-20230904,ASC-CONST-041-E-V01-20230904,ASC-CONST-042-C-V01-20230904,ASC-CONST-042-E-V01-20230904,ASC-CONST-043-E-V01-20230904,ASC-CONST-044-E-V01-20230904,ASC-CONST-045-E-V01-20230904,ASC-CONST-046-E-V01-20230904,ASC-CONST-047-C-V03-20240619,ASC-CONST-047-E-V03-20240619,ASC-CONST-048-C-V01-20230927,ASC-CONST-048-E-V01-20230927,ASC-CONST-049-C-V01-20231026,ASC-CONST-049-E-V01-20231026,ASC-CONST-050-C-V01-20231026,ASC-CONST-050-E-V01-20231026,ASC-CONST-051-C-V01-20231026,ASC-CONST-051-E-V01-20231026,ASC-CHKLT-052-E-V01-20231117,ASC-REFRL-053-E-V01-20231122,ASC-CONST-054-C-V01-20231229,ASC-CONST-054-E-V01-20231229,ASC-CONST-055-C-V01-20231229,ASC-CONST-055-E-V01-20231229,ASC-CONST-056-C-V01-20240124,ASC-CONST-056-E-V01-20240124,ASC-CONST-057-C-V01-20240124,ASC-CONST-057-E-V01-20240124,ASC-CONST-058-C-V01-20240328,ASC-CONST-058-E-V01-20240328,ASC-CONST-059-C-V01-20240216,ASC-CONST-059-E-V01-20240216,ASC-CONST-060-C-V01-20240216,ASC-CONST-060-E-V01-20240216,ASC-CONST-061-C-V01-20240216,ASC-CONST-061-E-V01-20240216,ASC-CONST-062-C-V01-20240216,ASC-CONST-062-E-V01-20240216,ASC-CONST-063-C-V01-20240216,ASC-CONST-063-E-V01-20240216,ASC-CONST-064-C-V01-20240216,ASC-CONST-064-E-V01-20240216,ASC-CONST-065-C-V01-20240216,ASC-CONST-065-E-V01-20240216,ASC-CONST-066-C-V01-20240216,ASC-CONST-066-E-V01-20240216,ASC-REQUT-067-B-V01-20240730,ASC-REFRL-068-E-V01-20240829,ASC-MEDIC-069,ASC-CONST-070-C-V01-20251023,ASC-CONST-070-E-V01-20251023,ASC-CHARG-071,ASC-NURNT-072,CAD-REPRT-001,CAD-REPRT-002,CAD-REPRT-003,CAD-REPRT-004,CAD-REPRT-005,CAD-REPRT-006,CAD-CONST-007-C-V01-20241125,CAD-CONST-007-E-V01-20241125,CAD-CONST-008-C-V01-20241125,CAD-CONST-008-E-V01-20241125,CAD-CONST-009-C-V01-20241125,CAD-CONST-009-E-V01-20241125,CAD-CONST-010-C-V01-20241125,CAD-CONST-010-E-V01-20241125,CAD-CONST-011-C-V01-20241125,CAD-CONST-011-E-V01-20241125,CAD-CONST-012-C-V01-20241125,CAD-CONST-012-E-V01-20241125,CAD-REPRT-013,CAD-REPRT-014,CAD-REPRT-015,CAD-REPRT-016,CAD-REPRT-017,CUHKMC-DISSM-001-E-V01-20191120,CUHKMC-DISSM-002-E-V01-20191120,CUHKMC-ADMLE-003-E-V05-20231016,CUHKMC-ADMLE-003-E-V03-20231016,CUHKMC-CONSM-004-E-V01-20191120,CUHKMC-PROGN-005-E-V01-20191120,CUHKMC-SICKC-006-B-V01-20191120,CUHKMC-ATTEC-007-B-V01-20191120,CUHKMC-MEDIC-008-B-V01-20191120,CUHKMC-REFRL-009-E-V01-20191120,CUHKMC-REFRL-010-E-V01-20191120,CUHKMC-CONST-011-E-V01-20191218,CUHKMC-CONST-012-C-V01-20191218,CUHKMC-CONST-013-E-V01-20191218,CUHKMC-CONST-014-C-V01-20191218,CUHKMC-CONST-015-E-V01-20191218,CUHKMC-CONST-016-C-V01-20191218,CUHKMC-CONST-017-E-V03-20230914,CUHKMC-CONST-018-C-V02-20230914,CUHKMC-ADMNT-019-E-V01-20200106,CUHKMC-MEDIC-020-B-V01-20200206,CUHKMC-CONST-021-B-V02-20220404,CUHKMC-REGTN-022-B-V01-20200610,CUHKMC-REQUT-023-B-V01-20221202,CUHKMC-REQUT-024-B-V01-20221202,CUHKMC-CONST-025-E-V01-20210125,CUHKMC-CONST-026-C-V01-20210125,CUHKMC-CONST-027-E-V01-20200922,CUHKMC-CONST-028-C-V01-20200922,CUHKMC-CONST-029-C-V02-20230214,CUHKMC-CONST-029-E-V02-20230214,CUHKMC-CONST-030-C-V02-20250524,CUHKMC-CONST-030-E-V01-20250524,CUHKMC-CONST-031-B-V01-20210104,CUHKMC-CONST-032-B-V03-20250925,CUHKMC-CONST-033-B-V01-20210106,CUHKMC-CONST-034-B-V01-20210106,CUHKMC-REFRL-035-E-V01-20210111,CUHKMC-REFRL-036,CUHKMC-DOCNT-037,CUHKMC-REPRT-038,CUHKMC-CONST-039-C-V01-20210531,CUHKMC-CONST-039-E-V01-20210531,CUHKMC-REPRT-040-E-V01-20210201,CUHKMC-REGTN-041-B-V01-20210301,CUHKMC-REFRL-042-E-V01-20210308,CUHKMC-CONST-043-B-V01-20210310,CUHKMC-CONSM-044-E-V01-20210325,CUHKMC-ASSES-045-E-V03-20240209,CUHKMC-REFRL-046-E-V01-20210512,CUHKMC-CONST-047-B-V01-20210608,CUHKMC-SICKC-048-B-V01-20211021,CUHKMC-DISSM-049-E-V01-20211110,CUHKMC-DISSM-050-E-V01-20211110,CUHKMC-CONST-051-C-V01-20211206,CUHKMC-CONST-051-E-V01-20211206,CUHKMC-ADMLE-052-E-V02-20231016,CUHKMC-REFRL-053-E-V01-20220104,CUHKMC-CONSM-054-E-V01-20220222,CUHKMC-CONST-055-C-V01-20220307,CUHKMC-CONST-055-E-V01-20220307,CUHKMC-CONST-056-B-V01-20220310,CUHKMC-CONST-057-C-V01-20220316,CUHKMC-CONST-057-E-V01-20220316,CUHKMC-CHKLT-058-E-V02-20220322,CUHKMC-CONST-059-C-V01-20240312,CUHKMC-CONST-059-E-V02-20240312,CUHKMC-DISSM-060-E-V01-20220321,CUHKMC-CONST-061-C-V01-20220421,CUHKMC-CONST-061-E-V01-20220421,CUHKMC-CONST-062-B-V01-20221207,CUHKMC-CONST-063-E-V01-20221213,CUHKMC-REGTN-064-B-V01-20221229,CUHKMC-CONST-065-C-V01-20230105,CUHKMC-CONST-065-E-V01-20230105,CUHKMC-CONST-066-C-V02-20230515,CUHKMC-CONST-066-C-V02-20230515,CUHKMC-CONST-066-E-V01-20230515,CUHKMC-CONST-067-C-V01-20230110,CUHKMC-CONST-067-E-V01-20230110,CUHKMC-CONST-068-B-V01-20230111,CUHKMC-CONST-068-B-V01-20230111,CUHKMC-CONST-069-C-V01-20230524,CUHKMC-CONST-069-E-V01-20230524,CUHKMC-REFRL-070-E-V01-20230221,CUHKMC-CONST-071-B-V01-20230403,CUHKMC-CONST-072-C-V01-20230914,CUHKMC-CONST-072-E-V01-20230914,CUHKMC-DOCNT-073-C-V01-20230512,CUHKMC-DOCNT-073-E-V01-20230512,CUHKMC-CONST-074-C-V02-20231129,CUHKMC-CONST-074-E-V01-20231129,CUHKMC-DOCNT-075-E-V01-20230706,CUHKMC-REFRL-076-C-V01-20231025,CUHKMC-CONST-077-B-V01-20240105,CUHKMC-CONST-078-E-V01-20231221,CUHKMC-REPRT-079,CUHKMC-CONST-080-C-V01-20240614,CUHKMC-CONST-080-E-V01-20240614,CUHKMC-CONST-081-C-V01-20240726,CUHKMC-CONST-081-E-V01-20240726,CUHKMC-CONST-082-C-V01-20240801,CUHKMC-CONST-082-E-V01-20240801,CUHKMC-REFRL-083-B-V01-20240730,CUHKMC-REFRL-084-C-V01-20241025,CUHKMC-REFRL-085-E-V01-20250604,CUHKMC-ADMLE-086-E-V01-20251121,CUHKMC-ADMLE-087-E-V01-20251121,CUHKMC-ADMLE-088-E-V01-20251121,EDC-BRON-001-E-V01-20200313,EDC-CHOLG-002-E-V01-20200313,EDC-CHOLS-003-E-V01-20200313,EDC-COLO-004-E-V01-20210125,EDC-DUO-005-E-V01-20200313,EDC-EBUS-006-E-V01-20200313,EDC-ENTE-007-E-V01-20200313,EDC-ERCP-008-E-V01-20200313,EDC-EUS-009-E-V01-20200313,EDC-ESO-010-E-V01-20200313,EDC-OGD-011-E-V01-20210129,EDC-SIGM-012-E-V01-20200313,EDC-CHKLT-013-E-V01-20201130,EDC-REPRT-014-E-V01-20201130,EDC-ASSES-015-E-V01-20200928,EDC-DOCNT-016-E-V01-20201231,EDC-NASO-017-E-V01-20210225,EDC-CYSTO-018-E-V01-20210316,EDC-ADMLE-019-E-V01-20210422,EDC-CONST-020-C-V01-20210513,EDC-CONST-020-E-V01-20210513,EDC-CONST-021-C-V01-20210513,EDC-CONST-021-E-V01-20210513,EDC-CONST-022-C-V01-20210513,EDC-CONST-022-E-V01-20210513,EDC-CONST-023-C-V01-20210513,EDC-CONST-023-E-V01-20210513,EDC-CONST-024-C-V01-20210531,EDC-CONST-024-E-V01-20220928,EDC-ASSES-025-C-V01-20210617,EDC-ASSES-025-E-V01-20210617,EDC-REPRT-026-E-V01-20210816,EDC-REPRT-027-E-V01-20211004,EDC-REPRT-028-E-V01-20211008,EDC-ASSES-029-B-V02-20241025,EDC-CONST-030-C-V01-20211018,EDC-CONST-031-C-V01-20211021,EDC-CONST-031-E-V01-20211021,EDC-CONST-032-C-V01-20220315,EDC-CONST-032-E-V01-20220322,EDC-CONST-033-C-V01-20220721,EDC-CONST-033-E-V01-20220721,EDC-REPRT-034,EDC-CONST-035-C-V01-20220803,EDC-CONST-035-E-V01-20220803,EDC-CONST-036-C-V02-20250428,EDC-CONST-036-E-V02-20250428,EDC-CONST-037-C-V01-20250430,EDC-CONST-037-E-V01-20250430,EDC-CONST-038-C-V01-20250722,EDC-CONST-038-E-V01-20250722,ENT-REPRT-001,ENT-REPRT-002,EYC-OCT-001-E-V1-20200427,EYC-OCTA-002-E-V01-20200427,EYC-VF-003-E-V01-20200427,EYC-FP-004-E-V01-20210201,EYC-FF-005-E-V01-20200427,EYC-IOL-006-E-V01-20200427,EYC-VA-007-E-V01-20200427,EYC-AR-008-E-V01-20200427,EYC-TL-009-E-V01-20200427,EYC-NCT-010-E-V01-20200427,EYC-CCT-011-E-V01-20200427,EYC-SM-012-E-V01-20200427,EYC-ASCAN-013-E-V01-20200427,EYC-BSCAN-014-E-V01-20200427,EYC-SLP-015-E-V01-20200427,EYC-PACHY-016-E-V01-20200427,EYC-WP-017-E-V01-20200427,EYC-PANTA-018-E-V01-20200427,EYC-ST-019-E-V01-20200427,EYC-MT-020-E-V01-20220311,EYC-AK-021-E-V01-20200427,EYC-STERE-022-E-V01-20200427,EYC-COLT-023-E-V01-20200427,EYC-EXP-024-E-V01-20200427,EYC-AT-025-E-V01-20200427,EYC-CLF-026-E-V01-20200427,EYC-CNCT-027-E-V01-20200427,EYC-OSCAN-028-E-V01-20200427,EYC-NURNT-029,EYC-REQUT-030,EYC-REQUT-031,EYC-MEDAR-032,EYC-REQUT-033,EYC-NURNT-034,EYC-CHKLT-035,EYC-MEDAR-036,EYC-CHKLT-037,EYC-ASSES-038-B-V01-20210129,EYC-ASSES-039-E-V04-20230308,EYC-PRECN-040-B-V01-20210129,EYC-PRECN-041-B-V01-20210129,EYC-PROGN-042-E-V01-20210129,EYC-REPRT-043-E-V01-20210129,EYC-REPRT-044-E-V01-20210201,EYC-REPRT-045-E-V01-20210201,EYC-DOCNT-046-E-V01-20210201,EYC-DOCNT-047-E-V01-20210201,EYC-DOCNT-048-E-V01-20210201,EYC-DOCNT-049-E-V01-20210201,EYC-DOCNT-050-E-V01-20210201,EYC-DOCNT-051-E-V01-20210201,EYC-DOCNT-052-E-V01-20210201,EYC-ASSES-053-C-V01-20210217,EYC-ASSES-054-C-V01-20210217,EYC-ASSES-055-C-V01-20210217,EYC-CHKLT-056-E-V01-20210217,EYC-CHKLT-057-E-V01-20210217,EYC-ASSES-058-C-V01-20210217,EYC-CHKLT-059-E-V01-20210217,EYC-CHKLT-060-E-V01-20210217,EYC-CHKLT-061-E-V01-20210217,EYC-REFRL-062-E-V01-20210217,EYC-NURNT-063-E-V01-20210407,EYC-REQUT-064-E-V01-20210407,EYC-CHKLT-065-E-V01-20210407,EYC-CHKLT-066-E-V01-20210407,EYC-DOCNT-067-E-V01-20210407,EYC-DOCNT-068-E-V01-20210407,EYC-DOCNT-069-E-V01-20210407,EYC-DOCNT-070-E-V01-20210407,EYC-DOCNT-071-E-V01-20210407,EYC-DOCNT-072-E-V01-20210407,EYC-NURNT-073-E-V01-20210407,EYC-NURNT-074-B-V01-20210407,EYC-REPRT-075,EYC-REPRT-076,EYC-REPRT-077,FIN-CHARG-001-B-V01-20201126,FIN-CHARG-002-B-V01-20201126,FIN-CHARG-003-B-V08-20251002,FIN-CHARG-004-B-V01-20201229,FIN-CHARG-005-B-V01-20201229,FIN-CHARG-006-B-V01-20201229,FIN-CHARG-007-B-V01-20201229,FIN-CHARG-008-B-V01-20201229,FIN-CHARG-009-B-V01-20201229,FIN-CHARG-010,FIN-CHARG-011,HDC-PRECN-001-E-V02-20230104,HDC-NURNT-002-E-V03-20230328,HDC-ASSES-003-E-V01-20220720,HDC-CHKLT-004-E-V01-20220720,HDC-CHKLT-005-E-V01-20220720,HDC-REPRT-006,HDC-NURNT-007-E-V01-20240806,HDC-NURNT-008-E-V01-20240806,HIR-REQUT-001-B-V01-20200615,ICU-REPRT-001,ICU-ASSES-002,ICU-DOCNT-003,ICU-MEDAR-004,ICU-PROGN-005,ICU-DOCNT-006,ICU-CHART-007,ICU-ASSES-008,ICU-CHART-009,ICU-REPRT-010,ICU-CHKLT-011,ICU-ASSES-012,ICU-BRON-013,ICU-REPRT-014,ICU-CHART-015,ICU-NURNT-016,ICU-DOCNT-017,ICU-NURNT-018,ICU-CHART-019,ICU-CHART-020,ICU-CHKLT-021,ICU-CHART-022,ICU-CHART-023,ICU-DOCNT-024,ICU-DOCNT-025,ICU-DOCNT-026,ICU-DOCNT-027,ICU-DOCNT-028,ICU-DOCNT-029,ICU-DOCNT-030,ICU-DOCNT-031,ICU-DOCNT-032,ICU-DOCNT-033,ICU-DOCNT-034,ICU-DOCNT-035,ICU-DOCNT-036,ICU-DOCNT-037,ICU-DOCNT-038,ICU-DOCNT-039,ICU-DOCNT-040,ICU-DOCNT-041,ICU-DOCNT-042,ICU-DOCNT-043,ICU-DOCNT-044,ICU-DOCNT-045,ICU-DOCNT-046,ICU-DOCNT-047,ICU-DOCNT-048,ICU-DOCNT-049,ICU-DOCNT-050,ICU-PROGN-051,ICU-NURNT-052,ICU-NURNT-053,ICU-NURNT-054,ICU-NURNT-055,ICU-NURNT-056,ICU-NURNT-057,ICU-NURNT-058,ICU-NURNT-059,ICU-MEDAR-060,ICU-PROGN-061,ICU-PROGN-062,ICU-PROGN-063,ICU-PROGN-064,ICU-PROGN-065,ICU-PROGN-066,ICU-PROGN-067,ICU-ADM-068,ICU-CHART-069,ICU-CHKLT-070,ICU-CHKLT-071,ICU-REQUT-072-B-V01-20240620,IMC-CONSM-001,IMC-ATTEC-002,IMC-PRECN-003,IMC-PRECN-004,IMC-SICKC-005,IMC-CONST-006-B-V01-20231220,IMC-REGTN-007-C-V05-20251105,IMC-CONST-008-B-V01-20241010,MPS-PRECN-001-E-V01-20200422,MPS-REPRT-002-E-V01-20200622,MPS-REPRT-003-E-V01-20200622,MPS-REQUT-004-E-V01-20200622,MPS-REQUT-005-E-V01-20200622,MPS-PRECN-006,MPS-ASSES-007-E-V01-20210201,MPS-MEDAR-008-E-V01-20221007,MPS-MEDAR-009,MPS-CONST-010-C-V01-20241018,MPS-CONST-010-E-V01-20241018,MPS-MEDAR-011-E-V01-20250715,MPS-MEDAR-012-E-V01-20250715,MPS-MEDAR-013-E-V01-20250807,,,,,,NEU-REPRT-001,NEU-REPRT-002,NUR-APPS-001-B-V01-20191120,NUR-IMMR-002-E-V01-20191120,NUR-ALRG-003-E-V01-20200106,NUR-MEDAR-004-E-V01-20191203,NUR-MEDAR-004-E-V01-20210421,NUR-MEDAR-005-E-V01-20191203,NUR-CHART-006-E-V01-20191203,NUR-ASSES-007-E-V01-20191209,NUR-CHART-008-E-V01-20191210,NUR-NURCP-009-E-V01-20191210,NUR-ASSES-010-E-V01-20191210,NUR-ASSES-011-E-V01-20191210,NUR-ASSES-012-E-V01-20191210,NUR-ASSES-013-E-V01-20191210,NUR-ASSES-014-E-V02-20240520,NUR-ASSES-015-E-V01-20191210,NUR-ASSES-016-E-V01-20191210,NUR-ASSES-017-E-V01-20191210,NUR-ASSES-018-E-V01-20191210,NUR-ASSES-019-B-V03-20250415,NUR-ASSES-020-B-V01-20200117,NUR-ASSES-021-C-V01-20200120,NUR-ASSES-022-E-V01-20200220,NUR-ASSES-023-E-V01-20200317,NUR-CHKLT-024-E-V01-20200928,NUR-ASSES-025-E-V01-20200922,NUR-MEDAR-026-E-V03-20220307,NUR-CONST-027-B-V01-20201126,NUR-CONST-028-B-V01-20201126,NUR-ASSES-029-E-V01-20201126,NUR-CONST-030-B-V01-20230303,NUR-NURNT-031-E-V01-20201223,NUR-NURNT-032-E-V01-20201223,NUR-CHKLT-033-E-V01-20201223,NUR-REQUT-034-E-V02-20240607,NUR-NURNT-035-E-V01-20210127,NUR-CHKLT-036-E-V03-20250610,NUR-ASSES-037-E-V01-20210308,NUR-ASSES-038-E-V01-20210326,NUR-ASSES-039-E-V01-20210326,NUR-CHKLT-040-E-V01-20210326,NUR-CHKLT-041-E-V01-20210326,NUR-CHKLT-042-E-V01-20210326,NUR-CHKLT-043-E-V01-20210326,NUR-CHKLT-044-E-V01-20210326,NUR-CHKLT-045-E-V01-20210326,NUR-CHKLT-046-E-V01-20210326,NUR-CHART-047-E-V01-20210407,NUR-REQUT-048-B-V01-20210430,NUR-REQUT-049-E-V03-20251013,NUR-ASSES-050-E-V01-20210510,NUR-NURNT-051-E-V01-20210510,NUR-ASSES-052-E-V01-20210510,NUR-ASSES-053-E-V01-20210510,NUR-ASSES-054-E-V01-20210510,NUR-CHART-055-E-V02-20210615,NUR-CHART-056-E-V02-20210615,NUR-ALGRE-057-C-V01-20210526,NUR-ALGRE-057-E-V01-20210526,NUR-ALGRE-058-C-V01-20210526,NUR-ALGRE-058-E-V01-20210526,NUR-ASSES-059-C-V01-20210526,NUR-ASSES-059-E-V01-20210526,NUR-ASSES-060-C-V01-20210526,NUR-ASSES-060-E-V01-20210526,NUR-ASSES-061-E-V01-20210526,NUR-ASSES-062-E-V01-20210526,NUR-ASSES-063-E-V01-20210526,NUR-CHKLT-064-E-V01-20210526,NUR-REPRT-065-B-V03-20220628,NUR-ASSES-066-C-V01-20210526,NUR-ASSES-066-E-V01-20210526,NUR-ASSES-067-C-V01-20210526,NUR-ASSES-067-E-V01-20210526,NUR-ASSES-068-C-V01-20210526,NUR-ASSES-068-E-V01-20210526,NUR-ASSES-069-E-V01-20210526,NUR-CHKLT-070-B-V01-20210526,NUR-CHKLT-071-B-V01-20210526,NUR-ASSES-072-E-V01-20210531,NUR-ASSES-073-E-V01-20210531,NUR-ASSES-074-E-V01-20210602,NUR-ASSES-075-E-V01-20210602,NUR-ASSES-076-E-V01-20210602,NUR-ASSES-077-E-V01-20210602,NUR-ASSES-078-E-V01-20210602,NUR-ASSES-079-E-V01-20210602,NUR-ASSES-080-E-V01-20210602,NUR-ASSES-081-E-V01-20210602,NUR-CHKLT-082-C-V01-20210602,NUR-CHKLT-083-C-V01-20210602,NUR-REPRT-084-E-V01-20210608,NUR-REPRT-085-E-V01-20210608,NUR-REPRT-086-E-V01-20210608,NUR-REPRT-087-E-V01-20210608,NUR-ASSES-088-E-V01-20210610,NUR-NURNT-089-E-V01-20210610,NUR-REQUT-090-E-V01-20210610,NUR-CHART-091-E-V01-20210615,NUR-CHART-092-E-V01-20210615,NUR-CHART-093-E-V01-20210615,NUR-CHKLT-094-E-V01-20210621,NUR-ASSES-095-E-V01-20210621,NUR-CHKLT-096-E-V01-20210621,NUR-CHART-097-E-V01-20210621,NUR-NURNT-098-E-V01-20210623,NUR-ASSES-099-E-V01-20210625,NUR-ASSES-100-E-V01-20210629,NUR-ASSES-101-E-V01-20210707,NUR-ASSES-102-E-V01-20210707,NUR-ASSES-103-E-V01-20210707,NUR-CHART-104-E-V01-20210709,NUR-CHART-105-E-V01-20210709,NUR-CHART-106-E-V01-20210709,NUR-REPRT-107-B-V02-20220628,NUR-ASSES-108-E-V01-20210714,NUR-NURNT-109-E-V01-20210714,NUR-NURNT-110-E-V02-20220822,NUR-MEDAR-111-E-V01-20210714,NUR-NURNT-112-E-V01-20210714,NUR-NURNT-113-E-V01-20210714,NUR-NURNT-114-E-V02-20230222,NUR-ASSES-115-C-V02-20230703,NUR-ASSES-115-E-V02-20230703,NUR-NURNT-116-E-V02-20240403,NUR-NURNT-117-E-V03-20240423,NUR-ASSES-118-E-V01-20210831,NUR-NURNT-119-E-V04-20220604,NUR-NURNT-120-E-V01-20210913,NUR-CHART-121-E-V04-20240909,NUR-CHART-122-E-V01-20210913,NUR-ASSES-123-E-V01-20210913,NUR-CHART-124-E-V02-20250808,NUR-ASSES-125-E-V02-20240709,NUR-REQUT-126-E-V01-20210920,NUR-ASSES-127-E-V01-20210920,NUR-CHART-128-E-V02-20230222,NUR-ASSES-129-E-V01-20210920,NUR-NURNT-130-E-V01-20210920,NUR-CHKLT-131-E-V01-20210920,NUR-NURNT-132-E-V02-20230222,NUR-NURNT-133-E-V01-20210920,NUR-CHART-134-E-V01-20210920,NUR-CHART-135-E-V01-20210920,NUR-CHKLT-136-E-V01-20211021,NUR-REFRL-137-E-V01-20211021,NUR-ASSES-138-E-V01-20211021,NUR-NURNT-139-E-V02-20220604,NUR-ASSES-140-C-V02-20230316,NUR-ASSES-140-E-V02-20230329,NUR-CONST-141-C-V01-20211109,NUR-CONST-141-E-V01-20211109,NUR-CHKLT-142-C-V02-20220928,NUR-CHKLT-142-E-V02-20220928,NUR-CONST-143-B-V02-20220823,NUR-CONST-144-B-V01-20211109,NUR-ASSES-145-B-V01-20211213,NUR-NURNT-146-E-V01-20211213,NUR-CONST-147-B-V02-20220322,NUR-NURNT-148-E-V02-20250312,NUR-CHART-149-E-V01-20210920,NUR-CHART-150-E-V01-20220121,NUR-ASSES-151-B-V01-20220221,NUR-MEDAR-152-E-V01-20220322,NUR-MEDAR-153-E-V01-20220322,NUR-MEDAR-154-E-V01-20220322,NUR-MEDAR-155-E-V01-20220322,NUR-ASSES-156-E-V01-20220328,NUR-CHART-157-E-V01-20220425,NUR-ASSES-158-E-V01-20220425,NUR-CHART-159-E-V01-20220520,NUR-CHART-160-E-V01-20220706,NUR-ASSES-161-B-V01-20220607,NUR-CHART-162-E-V01-20220622,NUR-NURNT-163-E-V01-20220706,NUR-ASSES-164-C-V01-20220713,NUR-ASSES-164-E-V01-20220713,NUR-ASSES-165-C-V01-20220713,NUR-ASSES-165-E-V01-20220713,NUR-ASSES-166-C-V01-20220822,NUR-CONST-167-B-V01-20220916,NUR-ASSES-168-B-V01-20221024,NUR-ASSES-169-B-V01-20221024,NUR-ASSES-170-B-V01-20221024,NUR-NURNT-171-E-V01-20221024,NUR-NURNT-172-E-V02-20240612,NUR-MEDAR-173-E-V01-20230206,NUR-MEDAR-174-E-V01-20230203,NUR-MEDAR-175-E-V01-20230203,NUR-MEDAR-176-E-V01-20230203,NUR-NURNT-177-E-V02-20230529,NUR-ASSES-178-C-V01-20230927,NUR-CONST-179-C-V01-20231120,NUR-CONST-180-C-V01-20231120,NUR-CHKLT-181-E-V02-20240524,NUR-CHKLT-182-B-V01-20231219,NUR-ASSES-183-B-V01-20240126,NUR-ASSES-184-C-V01-20240126,NUR-ASSES-184-E-V01-20240126,NUR-ASSES-185-C-V01-20240126,NUR-ASSES-185-E-V01-20240126,NUR-ASSES-186-C-V01-20240205,NUR-ASSES-186-E-V01-20240205,NUR-CHKLT-187-E-V01-20240322,NUR-CHKLT-188-E-V01-20240322,NUR-ASSES-189-E-V01-20240403,NUR-NURNT-190-E-V01-20240614,NUR-ASSES-191-C-V01-20240815,NUR-ASSES-191-E-V01-20240815,NUR-CHKLT-192-E-V01-20240831,NUR-CHART-193-E-V01-20241224,NUR-CHART-194-E-V01-20250217,NUR-NURNT-195-E-V01-20250515,NUR-ASSES-196-E-V01-20250515,NUR-CHKLT-197-B-V01-20250515,NUR-CHART-198-E-V01-20250515,NUR-CHART-199-E-V01-20250515,NUR-DOCNT-200-E-V01-20250527,NUR-ASSES-201-C-V01-20250604,NUR-ASSES-201-E-V01-20250604,NUR-ASSES-202-C-V01-20250604,NUR-ASSES-202-E-V01-20250604,NUR-ASSES-203-C-V01-20250604,NUR-ASSES-203-E-V01-20250604,NUR-ASSES-204-C-V01-20250606,NUR-ASSES-204-E-V01-20250606,NUR-ASSES-205-C-V01-20250606,NUR-ASSES-205-E-V01-20250606,NUR-ASSES-206-E-V01-20250717,NUR-CHART-207-E-V01-20250717,NUR-NURNT-208-E-V01-20250717,NUR-NURNT-209-E-V01-20250717,NUR-CHART-210-E-V01-20250808,ONC-CONST-001-C-V01-20210607,ONC-CONST-001-E-V01-20210607,ONC-MEDAR-002-E-V03-20241212,ONC-MEDAR-003-E-V01-20210712,ONC-MEDAR-004-E-V02-20241212,ONC-MEDAR-005-E-V01-20210712,ONC-MEDAR-006-E-V02-20241212,ONC-MEDAR-007-E-V01-20210712,ONC-MEDAR-008-E-V01-20210712,ONC-MEDAR-009-E-V02-20241212,ONC-MEDAR-010-E-V02-20241212,ONC-MEDAR-011-E-V03-20241212,ONC-MEDAR-012-E-V02-20241212,ONC-MEDAR-013-E-V02-20250116,ONC-MEDAR-014-E-V01-20210712,ONC-MEDAR-015-E-V01-20210712,ONC-MEDAR-016-E-V01-20210712,ONC-MEDAR-017-E-V02-20250116,ONC-NURNT-018-E-V01-20210712,ONC-NURNT-019-E-V01-20210712,ONC-NURNT-020-E-V01-20210712,ONC-NURNT-021-E-V01-20210712,ONC-NURNT-022-E-V01-20210712,ONC-NURNT-023-E-V01-20210712,ONC-NURNT-024-E-V01-20210712,ONC-NURNT-025-E-V01-20210712,ONC-NURNT-026-E-V01-20210712,ONC-NURNT-027-E-V01-20210712,ONC-NURNT-028-E-V01-20210712,ONC-NURNT-029-E-V01-20210712,ONC-NURNT-030-E-V01-20210712,ONC-NURNT-031-E-V01-20210712,ONC-NURNT-032-E-V01-20210712,ONC-MEDAR-033-E-V02-20241122,ONC-MEDAR-034-E-V02-20250116,ONC-MEDAR-035-E-V01-20210712,ONC-NURNT-036-E-V01-20210712,ONC-NURNT-037-E-V01-20210712,ONC-MEDAR-038-E-V02-20250116,ONC-NURNT-039-E-V01-20210712,ONC-MEDAR-040-E-V02-20250116,ONC-MEDAR-041-E-V01-20210805,ONC-MEDAR-042-E-V02-20250116,ONC-MEDAR-043-E-V01-20210805,ONC-MEDAR-044-E-V02-20250116,ONC-MEDAR-045-E-V02-20250116,ONC-MEDAR-046-E-V02-20250212,ONC-MEDAR-047-E-V03-20250212,ONC-MEDAR-048-E-V02-20250210,ONC-MEDAR-049-E-V01-20210805,ONC-MEDAR-050-E-V01-20210805,ONC-NURNT-051-E-V01-20210805,ONC-NURNT-052-E-V01-20210805,ONC-NURNT-053-E-V01-20210805,ONC-NURNT-054-E-V01-20210805,ONC-NURNT-055-E-V01-20210805,ONC-NURNT-056-E-V01-20210805,ONC-NURNT-057-E-V01-20210805,ONC-NURNT-058-E-V01-20210805,ONC-NURNT-059-E-V01-20210805,ONC-MEDAR-060-E-V02-20250602,ONC-MEDAR-061-E-V03-20250901,ONC-MEDAR-062-E-V03-20250901,ONC-MEDAR-063-E-V03-20250526,ONC-MEDAR-064-E-V02-20250212,ONC-MEDAR-065-E-V02-20241122,ONC-MEDAR-066-E-V01-20210916,ONC-NURNT-067-E-V01-20210916,ONC-NURNT-068-E-V01-20210916,ONC-NURNT-069-E-V01-20210916,ONC-NURNT-070-E-V01-20210916,ONC-MEDAR-071-E-V02-20241122,ONC-NURNT-072-E-V01-20211015,ONC-MEDAR-073-E-V01-20211025,ONC-MEDAR-074-E-V01-20211025,ONC-MEDAR-075-E-V02-20250212,ONC-MEDAR-076-E-V02-20250602,ONC-MEDAR-077-E-V02-20250602,ONC-MEDAR-078-E-V01-20211025,ONC-MEDAR-079-E-V02-20250320,ONC-MEDAR-080-E-V02-20250415,ONC-NURNT-081-E-V01-20211025,ONC-NURNT-082-E-V01-20211025,ONC-NURNT-083-E-V01-20211025,ONC-NURNT-084-E-V01-20211025,ONC-NURNT-085-E-V01-20211025,ONC-NURNT-086-E-V01-20211025,ONC-NURNT-087-E-V01-20211025,ONC-MEDAR-088-E-V02-20250602,ONC-MEDAR-089-E-V02-20250526,ONC-MEDAR-090-E-V01-20220125,ONC-MEDAR-091-E-V02-20230911,ONC-MEDAR-092-E-V01-20220125,ONC-MEDAR-093-E-V02-20250526,ONC-MEDAR-094-E-V02-20250328,ONC-MEDAR-095-E-V01-20220125,ONC-MEDAR-096-E-V02-20230908,ONC-MEDAR-097-E-V02-20230908,ONC-MEDAR-098-E-V02-20230908,ONC-NURNT-099-E-V01-20220125,ONC-NURNT-100-E-V01-20220125,ONC-NURNT-101-E-V01-20220125,ONC-NURNT-102-E-V01-20220125,ONC-NURNT-103-E-V01-20220125,ONC-NURNT-104-E-V01-20220125,ONC-NURNT-105-E-V01-20220125,ONC-NURNT-106-E-V01-20220125,ONC-NURNT-107-E-V01-20220125,ONC-NURNT-108-E-V01-20220125,ONC-NURNT-109-E-V01-20220125,ONC-NURNT-110-E-V01-20220126,ONC-MEDAR-111-E-V01-20220302,ONC-NURNT-112-E-V01-20220302,ONC-MEDAR-113-E-V01-20220310,ONC-NURNT-114-E-V01-20220310,ONC-MEDAR-115-E-V02-20250602,ONC-MEDAR-116-E-V02-20250602,ONC-MEDAR-117-E-V02-20250602,ONC-MEDAR-118-E-V02-20250328,ONC-MEDAR-119-E-V02-20241122,ONC-MEDAR-120-E-V02-20250212,ONC-MEDAR-121-E-V02-20241122,ONC-MEDAR-122-E-V02-20250328,ONC-MEDAR-123-E-V01-20220328,ONC-MEDAR-124-E-V03-20250328,ONC-MEDAR-125-E-V01-20220328,ONC-MEDAR-126-E-V02-20250320,ONC-NURNT-127-E-V01-20220328,ONC-NURNT-128-E-V01-20220328,ONC-NURNT-129-E-V01-20220328,ONC-NURNT-130-E-V01-20220328,ONC-NURNT-131-E-V01-20220328,ONC-NURNT-132-E-V01-20220328,ONC-NURNT-133-E-V01-20220328,ONC-NURNT-134-E-V01-20220328,ONC-NURNT-135-E-V01-20220328,ONC-NURNT-136-E-V01-20220328,ONC-NURNT-137-E-V01-20220328,ONC-MEDAR-138-E-V01-20220408,ONC-NURNT-139-E-V01-20220408,ONC-MEDAR-140-E-V02-20250328,ONC-NURNT-141-E-V01-20220506,ONC-MEDAR-142-E-V01-20220617,ONC-NURNT-143-E-V01-20220617,ONC-MEDAR-144-E-V01-20220624,ONC-NURNT-145-E-V01-20220624,ONC-MEDAR-146-E-V01-20220624,ONC-NURNT-147-E-V01-20220624,ONC-MEDAR-148-E-V02-20250320,ONC-NURNT-149-E-V01-20220624,ONC-MEDAR-150-E-V02-20250901,ONC-NURNT-151-E-V01-20220624,ONC-MEDAR-152-E-V02-20250320,ONC-NURNT-153-E-V01-20220811,ONC-MEDAR-154-E-V01-20220919,ONC-NURNT-155-E-V01-20220919,ONC-MEDAR-156-E-V01-20221220,ONC-MEDAR-157-E-V01-20221220,ONC-MEDAR-158-E-V01-20230131,ONC-MEDAR-159-E-V01-20230131,ONC-NURNT-160-E-V01-20230131,ONC-MEDAR-161-E-V01-20230309,ONC-NURNT-162-E-V01-20230309,ONC-MEDAR-163-E-V01-20230309,ONC-NURNT-164-E-V01-20230309,ONC-MEDAR-165-E-V01-20230309,ONC-NURNT-166-E-V01-20230309,ONC-MEDAR-167-E-V01-20230309,ONC-NURNT-168-E-V01-20230309,ONC-MEDAR-169-E-V02-20250526,ONC-NURNT-170-E-V01-20230511,ONC-MEDAR-171-E-V01-20230511,ONC-NURNT-172-E-V01-20230511,ONC-MEDAR-173-E-V01-20230515,ONC-NURNT-174-E-V01-20230515,ONC-MEDAR-175-E-V03-20250415,ONC-NURNT-176-E-V01-20230607,ONC-MEDAR-177-E-V02-20250415,ONC-NURNT-178-E-V01-20230607,ONC-MEDAR-179-E-V01-20230718,ONC-NURNT-180-E-V01-20230718,ONC-MEDAR-181-E-V01-20230718,ONC-NURNT-182-E-V01-20230718,ONC-MEDAR-183-E-V01-20230729,ONC-NURNT-184-E-V01-20230729,ONC-MEDAR-185-E-V01-20230729,ONC-MEDAR-186-E-V02-20250320,ONC-NURNT-187-E-V01-20230729,ONC-MEDAR-188-E-V01-20230824,ONC-NURNT-189-E-V01-20230824,ONC-MEDAR-190-E-V01-20230824,ONC-NURNT-191-E-V01-20230824,ONC-MEDAR-192-E-V02-20250415,ONC-NURNT-193-E-V01-20230912,ONC-MEDAR-194-E-V01-20240131,ONC-NURNT-195-E-V01-20240131,ONC-MEDAR-196-E-V02-20250212,ONC-NURNT-197-E-V01-20240209,ONC-MEDAR-198-E-V01-20240209,ONC-NURNT-199-E-V01-20240209,ONC-MEDAR-200-E-V01-20240209,ONC-NURNT-201-E-V01-20240209,ONC-MEDAR-202-E-V02-20250328,ONC-NURNT-203-E-V01-20240311,ONC-MEDAR-204-E-V01-20240408,ONC-MEDAR-205-E-V01-20240408,ONC-MEDAR-206-E-V01-20240516,ONC-NURNT-207-E-V01-20240516,ONC-MEDAR-208-E-V01-20240618,ONC-NURNT-209-E-V01-20240618,ONC-MEDAR-210-E-V01-20240618,ONC-NURNT-211-E-V01-20240618,ONC-MEDAR-212-E-V01-20240802,ONC-NURNT-213-E-V01-20240802,ONC-MEDAR-214-E-V01-20241009,ONC-MEDAR-215-E-V01-20241020,ONC-MEDAR-216-E-V01-20241020,ONC-MEDAR-217-E-V01-20241110,ONC-NURNT-218-E-V01-20241110,ONC-MEDAR-219-E-V01-20241205,ONC-NURNT-220-E-V01-20241205,ONC-NURNT-221-E-V01-20241205,ONC-MEDAR-222-E-V01-20241213,ONC-NURNT-223-E-V01-20241213,ONC-MEDAR-224-E-V01-20241205,ONC-NURNT-225-E-V01-20241205,ONC-MEDAR-226-E-V01-20250305,ONC-NURNT-227-E-V01-20250305,ONC-MEDAR-228-E-V01-20250415,ONC-NURNT-229-E-V01-20250415,ONC-MEDAR-230-E-V01-20250415,ONC-NURNT-231-E-V01-20250415,ONC-MEDAR-232-E-V01-20250415,ONC-NURNT-233-E-V01-20250415,ONC-MEDAR-234-E-V01-20250523,ONC-MEDAR-235-E-V01-20250523,ONC-MEDAR-236-E-V01-20250523,ONC-NURNT-237-E-V01-20250523,ONC-MEDAR-238-E-V01-20250526,ONC-NURNT-239-E-V01-20250526,ONC-MEDAR-240-E-V01-20250530,ONC-NURNT-241-E-V01-20250530,ONC-MEDAR-242-E-V01-20250609,ONC-NURNT-243-E-V01-20250609,ONC-MEDAR-244-E-V01-20250611,ONC-NURNT-245-E-V01-20250611,ONC-MEDAR-246-E-V01-20250615,ONC-NURNT-247-E-V01-20250615,ONC-MEDAR-248-E-V01-20250618,ONC-NURNT-249-E-V01-20250618,ONC-MEDAR-250-E-V01-20250629,ONC-NURNT-251-E-V01-20250629,ONC-MEDAR-252-E-V01-20250629,ONC-NURNT-253-E-V01-20250629,ONC-MEDAR-254-E-V01-20250629,ONC-NURNT-255-E-V01-20250629,ONC-MEDAR-256-E-V01-20250709,ONC-NURNT-257-E-V01-20250709,ONC-MEDAR-258-E-V01-20250720,ONC-MEDAR-259-E-V01-20250720,ONC-MEDAR-260-E-V01-20250720,ONC-MEDAR-261-E-V01-20250720,ONC-MEDAR-262-E-V01-20250720,ONC-NURNT-263-E-V01-20250720,ONC-NURNT-264-E-V01-20250720,ONC-NURNT-265-E-V01-20250720,ONC-NURNT-266-E-V01-20250720,ONC-MEDAR-267-E-V01-20250801,ONC-NURNT-268-E-V01-20250801,ONC-MEDAR-269-E-V01-20250806,ONC-NURNT-270-E-V01-20250806,ONC-MEDAR-271-E-V01-20250806,ONC-MEDAR-272-E-V01-20250806,ONC-NURNT-273-E-V01-20250806,ONC-NURNT-274-E-V01-20250806,ONC-MEDAR-275-E-V01-20250901,ONC-NURNT-276-E-V01-20250901,ONC-MEDAR-277-E-V01-20251017,ONC-NURNT-278-E-V01-20251017,ONG-REPRT-001,ONG-REPRT-002,ONG-CHKLT-003-E-V01-20220120,ONG-CHKLT-004-E-V04-20230527,ONG-CHKLT-005-E-V03-20240617,OPH-REPRT-001,OPH-REPRT-002,OPT-DOCNT-001-E-V01-20191203,OPT-REPRT-002-E-V01-20191203,OPT-CHKLT-003-E-V01-20200908,OPT-DOCNT-004-E-V02-20210112,OPT-ASSES-005-E-V01-20200908,OPT-CHKLT-006-E-V01-20200622,OPT-NURNT-007-E-V01-20200924,OPT-DOCNT-008,OPT-DOCNT-009,OPT-REQUT-011-E-V02-20210705,OPT-DOCNT-012-E-V01-20210928,OPT-REQUT-013-E-V01-20220809,OPT-CHARG-014,PAE-REPRT-001,PAE-REPRT-002,PAT-NURNT-001-E-V01-20210209,PAT-NURNT-002-E-V01-20210209,PAT-CPS-003-E-V01-20200312,PAT-BBS-004-E-V01-20200312,PAT-CL-005-E-V01-20200312,PAT-CYTO-006-E-V01-20200312,PAT-HMS-007-E-V01-20200312,PAT-ACP-008-E-V01-20200312,PAT-IMS-009-E-V01-20200312,PAT-MBS-010-E-V01-20200312,PAT-MOL-011-E-V01-20200312,PAT-OUT-012-E-V01-20200312,PAT-VRS-013-E-V01-20200312,PAT-NURNT-014-E-V02-20231103,PAT-REQUT-015-E-V01-20200622,PAT-REQUT-016-E-V03-20251119,PAT-REQUT-017-E-V01-20200826,PAT-REQUT-018-E-V01-20200826,PAT-REQUT-019-E-V03-20221101,PAT-REQUT-020-E-V03-20250623,PAT-REQUT-021-E-V02-20221101,PAT-REQUT-022-E-V01-20200826,PAT-REQUT-023-E-V01-20200826,PAT-REQUT-024-E-V01-20210209,PAT-REPRT-025,PAT-REPRT-026,PAT-REQUT-027,PAT-REQUT-028-E-V01-20210209,PAT-REQUT-029-E-V02-20250623,PAT-REQUT-030-E-V01-20211208,PAT-REQUT-031-E-V02-20220217,PAT-REQUT-032-E-V01-20221101,REM-REPRT-001,REM-REPRT-002,RTC-CONST-001-E-V01-20210216,RTC-CONST-002-C-V01-20210216,RTC-REQUT-003-E-V05-20241217,RTC-REPRT-004-E-V01-20210812,RTC-REPRT-005-E-V01-20210812,RTC-CONST-006-C-V01-20220314,RTC-CONST-006-E-V01-20220314,RTC-REPRT-007-E-V01-20220819,RTC-CHKLT-008-B-V01-20250116,RTC-CONST-009-C-V01-20250116,RTC-CONST-009-E-V01-20250116,URO-REPRT-001,URO-REPRT-002,WEC-ASSES-001-B-V03-20230530,XRC-ADM-001-E-V01-20200312,XRC-DXA-002-E-V01-20200312,XRC-CAT-003-E-V01-20200312,XRC-DDR-004-E-V01-20200312,XRC-FXR-005-E-V01-20200312,XRC-IIR-006-E-V01-20200312,XRC-MRI-007-E-V01-20200312,XRC-MMG-008-E-V01-20200312,XRC-MIS-009-E-V01-20200312,XRC-NUR-010-E-V01-20200312,XRC-OXR-011-E-V01-20200312,XRC-PET-012-E-V01-20200312,XRC-RNI-013-E-V01-20200312,XRC-USG-014-E-V01-20200312,XRC-REQUT-015-E-V01-20201124,XRC-ASSES-016-B-V01-20201124,XRC-ASSES-017-E-V01-20201124,XRC-CHKLT-018-E-V01-20201124,XRC-ASSES-019-B-V01-20201124,XRC-NURNT-020-E-V01-20201124,XRC-NURNT-021-E-V01-20201124,XRC-CHARG-022-E-V01-20201124,XRC-CHKLT-023-E-V01-20201230,XRC-CHKLT-024-C-V01-20201230,XRC-REPRT-025,XRC-REPRT-026,XRC-REQUT-027,XRC-CHKLT-028-E-V01-20210803,XRC-DOCNT-029-E-V01-20210803,XRC-DOCNT-030-E-V01-20210803,XRC-CHKLT-031-E-V01-20210803,XRC-NURNT-032-E-V01-20210823,XRC-REQUT-033-E-V01-20210823,XRC-DOCNT-034-E-V01-20210823,XRC-DOCNT-035-E-V01-20210823,XRC-CONST-036-C-V01-20211021,XRC-CONST-036-E-V01-20211021,XRC-CONST-037-E-V01-20211021,XRC-CONST-037-E-V01-20211021,XRC-NURNT-038-E-V01-20211222,XRC-NURNT-039-E-V01-20211222,XRC-REQUT-040-E-V01-20220204,XRC-REQUT-041-E-V01-20220204,XRC-REQUT-042-E-V01-20220204,XRC-REQUT-043-E-V01-20220204,XRC-REQUT-044-E-V01-20220204,XRC-REQUT-045-E-V02-20251013,XRC-REQUT-046-E-V01-20220204,XRC-REQUT-047-E-V01-20220204,XRC-CONST-048-C-V01-20220224,XRC-CONST-048-E-V01-20220224,XRC-REQUT-049-E-V01-20220328,XRC-CHKLT-050-B-V01-20220607,XRC-CHKLT-051-B-V03-20230605,XRC-DOCNT-052,XRC-DOCNT-053-E-V04-20240726,XRC-MEDAR-054-E-V01-20220726,XRC-NURNT-055-E-V02-20230919,XRC-CHKLT-056-E-V01-20220728,XRC-DOCNT-057-E-V02-20240726,XRC-DOCNT-058-E-V02-20240726";
            #endregion

            //var Datas = Data.Split(',', StringSplitOptions.RemoveEmptyEntries);

            //List<string> FormIds = new List<string>();

            //List<string> one = new List<string>();
            //List<string> two = new List<string>();
            //List<string> three = new List<string>();

            //foreach (var item in Datas)
            //{
            //    var parts = item.Split('-', StringSplitOptions.RemoveEmptyEntries);
            //    if (parts.Length >= 3)
            //    {
            //        // 处理第一部分（纯字母）：修复OCR错误
            //        //string part1 = CleanAlphabeticPart(parts[0]);

            //        //// 处理第二部分（纯字母）：修复OCR错误
            //        //string part2 = CleanAlphabeticPart(parts[1]);

            //        //// 处理第三部分（纯数字）：只保留数字
            //        //string part3 = CleanNumericPart(parts[2]);

            //        // 验证各部分格式
            //        if (IsValidAlphabetic(parts[0]) && IsValidAlphabetic(parts[1]) && IsValidNumeric(parts[2]))
            //        {
            //            string FormId = $"{parts[0]}-{parts[1]}-{parts[2]}";
            //            FormIds.Add(FormId);
            //            one.Add(parts[0]);
            //            two.Add(parts[1]);
            //            three.Add(parts[2]);
            //        }
            //        else
            //        {
            //            Console.WriteLine("No");
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("No3");
            //    }
            //}

            //// 去重处理
            //FormIds = FormIds.DistinctBy(x => x)
            //        .ToList();
            //one = one.DistinctBy(x => x)
            //       .ToList();
            //two = two.DistinctBy(x => x)
            //      .ToList();
            //three = three.DistinctBy(x => x)
            //      .ToList();

            //foreach (var item in FormIds)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("----------------------------------------------------------------");

            //foreach (var item in one)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("----------------------------------------------------------------");
            //foreach (var item in two)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("----------------------------------------------------------------");
            //foreach (var item in three)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("----------------------------------------------------------------");

            // 测试各种OCR识别结果
            var testCases = new[]
            {
                "0NC-MEDAR-261",    // 0被识别为O
                "NUR-ASSES-2O6",    // 0被识别为O
                "CUHKMC-C0NST-065", // 0被识别为O
                "CAD-REPRT-0I4",    // 1被识别为I
                "XRC-1NFST-039",     // I被识别为1
                "FIN-CHARG-0N3",
                "NIIR-CHARG-0N3",
                "NLIR-CHARG-0N3",
                "NLLR-CHARG-0N3"
            };

            foreach (var testCase in testCases)
            {
                //var result = FormIdValidator.ValidateAndNormalizeFormId(testCase);
                var result = GetFormIDWithoutVersionNumber(testCase);
                Console.WriteLine($"{testCase} -> {result}");
            }
        }

        public static string GetFormIDWithoutVersionNumber(string formId)
        {
            if (string.IsNullOrWhiteSpace(formId))
                return string.Empty;

            // 1. 转换为大写，统一格式
            formId = formId.ToUpperInvariant().Trim();

            // 2. 修复OCR常见错误（只针对前两部分）
            var parts = formId.Split('-', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length >= 3)
            {
                // 处理第一部分（纯字母）：修复OCR错误
                string part1 = CleanAlphabeticPart(parts[0]);

                // 处理第二部分（纯字母）：修复OCR错误
                string part2 = CleanAlphabeticPart(parts[1]);

                // 处理第三部分（纯数字）：只保留数字
                string part3 = CleanNumericPart(parts[2]);

                // 验证各部分格式
                if (IsValidAlphabetic(part1) && IsValidAlphabetic(part2) && IsValidNumeric(part3))
                {
                    return $"{part1}-{part2}-{part3}";
                }
            }

            return string.Empty;
        }

        // 清理字母部分（只保留字母，修复OCR错误）
        private static string CleanAlphabeticPart(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            // OCR常见错误映射（字母部分）// 扩展映射
            var ocrCorrections = new Dictionary<char, char>
            {
                 {'0', 'O'}, {'1', 'I'}, {'5', 'S'}, {'8', 'B'},
                 {'2', 'Z'}, {'6', 'G'}, {'9', 'Q'}, {'7', 'T'},
                 {'4', 'A'} // 4可能被识别为A
            };

            // 应用OCR修正
            foreach (var correction in ocrCorrections)
            {
                text = text.Replace(correction.Key, correction.Value);
            }

            //特殊處理
            if (text == "NIIR" || text == "NLIR" || text == "NLLR")
            {
                text = "NUR";
            }

            // 只保留字母
            return new string(text.Where(char.IsLetter).ToArray());
        }

        // 清理数字部分（只保留数字）
        private static string CleanNumericPart(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            // 数字部分常见OCR错误修正// 扩展映射
            var corrections = new Dictionary<char, char>
            {
                 { 'O', '0' },{ 'N', '0' },
                 { 'I', '1' },{ 'L', '1' },
                 { 'S', '5' },
                 { 'B', '8' },
                 { 'G', '6' },
                 { 'Z', '2' },
                 { 'Q', '9' }, { 'T', '7'},
                 { 'A', '4' } // A可能被识别为4
            };

            foreach (var correction in corrections)
            {
                text = text.Replace(correction.Key, correction.Value);
            }

            // 只保留数字
            return new string(text.Where(char.IsDigit).ToArray());
        }

        // 验证是否为有效字母部分
        private static bool IsValidAlphabetic(string text)
        {
            return !string.IsNullOrEmpty(text) && text.All(char.IsLetter);
        }

        // 验证是否为有效数字部分
        private static bool IsValidNumeric(string text)
        {
            return !string.IsNullOrEmpty(text) && text.All(char.IsDigit);
        }

        #endregion

        #region OCR API
        // 在namespace Test内部添加以下类定义
        public class SignatureAreaConfig
        {
            [JsonPropertyName("targetParameters")]
            public List<string> TargetParameters { get; set; } = new List<string>();

            [JsonPropertyName("bottomReferenceParameters")]
            public List<string> BottomReferenceParameters { get; set; } = new List<string>();

            [JsonPropertyName("rightReferenceParameters")]
            public List<string> RightReferenceParameters { get; set; } = new List<string>();

            [JsonPropertyName("signatureAreaWidth")]
            public int SignatureAreaWidth { get; set; } = 440;

            [JsonPropertyName("signatureAreaHeight")]
            public int SignatureAreaHeight { get; set; } = 98;
        }

        public class SignatureConfig
        {
            [JsonPropertyName("config")]
            public List<FormSignatureConfig> formSignatureConfig { get; set; }

            [JsonPropertyName("parameters")]
            public SignatureSystemParameters signatureSystemParameters { get; set; }
        }

        public class FormSignatureConfig
        {
            [JsonPropertyName("formId")]
            public string FormId { get; set; } = "";

            [JsonPropertyName("page")]
            public int Page { get; set; } = 3;

            [JsonPropertyName("patient")]
            public SignatureAreaConfig Patient { get; set; } = new SignatureAreaConfig();

            [JsonPropertyName("doctor")]
            public SignatureAreaConfig Doctor { get; set; } = new SignatureAreaConfig();
        }


        public class SignatureSystemParameters
        {
            [JsonPropertyName("irregularThreshold")]
            public int IrregularThreshold { get; set; } = 20;

            [JsonPropertyName("blackRatioThreshold")]
            public float BlackRatioThreshold { get; set; } = 0.006f;
        }

        #region Json
        static string Json = "{\"config\":[{\"formId\":\"EDC-BUDES-013\",\"page\":2,\"patient\":{\"targetParameters\":[\"病人/親屬/監護人/獲授權人士簽署\",\"病人/親/護人/獲授權人士署\",\"病人/親屬/監護人/獲授權人士署\",\"病人/親/監護人/獲授權人士簽署\",\"病人/親屬/護人/獲授權人士簽署\",\"病人/親/监護人/獲授權人士署\",\"病人/親丽/護人/授權人士署\",\"病人/親/监護人/猎授權人士策署\",\"病/親属/监腰大/獲授權大士策署\",\"病人/親屬/監護人簽署\",\"病人/親/護人策署\",\"病人/親丽/護人策署\",\"病人/親丽/監護人簽署\",\"病人/親/監護人署\",\"病人/親屬/監護人署\",\"病人/親屬/護人署\",\"病人/親屬/監護人策署\"],\"signatureAreaWidth\":440,\"signatureAreaHeight\":80},\"doctor\":{\"targetParameters\":[\"醫生簽署\",\"醫生策署\",\"醫生簽\",\"醫生署\",\"医生簽署\",\"医生策署\",\"医生簽\",\"医生署\",\"生署\"],\"bottomReferenceParameters\":[\"Doctor'sSignature\"],\"rightReferenceParameters\":[\"醫生姓名\",\"医生姓名\",\"生姓名\"],\"signatureAreaWidth\":440,\"signatureAreaHeight\":80}},{\"formId\":\"URO-BUDES-009\",\"page\":3,\"patient\":{\"targetParameters\":[\"病人/親屬/監護人/獲授權人士簽署\",\"病人/親/護人/獲授權人士署\",\"病人/親屬/監護人/獲授權人士署\",\"病人/親/監護人/獲授權人士簽署\",\"病人/親屬/護人/獲授權人士簽署\",\"病人/親/监護人/獲授權人士署\",\"病人/親丽/護人/授權人士署\",\"病人/親/监護人/猎授權人士策署\",\"病/親属/监腰大/獲授權大士策署\",\"病人/親屬/監護人簽署\",\"病人/親/護人策署\",\"病人/親丽/護人策署\",\"病人/親丽/監護人簽署\",\"病人/親/監護人署\",\"病人/親屬/監護人署\",\"病人/親屬/護人署\",\"病人/親屬/監護人策署\"],\"signatureAreaWidth\":440,\"signatureAreaHeight\":80},\"doctor\":{\"targetParameters\":[\"醫生簽署\",\"醫生策署\",\"醫生簽\",\"醫生署\",\"医生簽署\",\"医生策署\",\"医生簽\",\"医生署\",\"生署\"],\"bottomReferenceParameters\":[\"Doctor'sSignature\"],\"rightReferenceParameters\":[\"醫生姓名\",\"医生姓名\",\"生姓名\"],\"signatureAreaWidth\":440,\"signatureAreaHeight\":80}},{\"formId\":\"EDC-BUDES-002\",\"page\":4,\"patient\":{\"targetParameters\":[\"病人/親屬/監護人/獲授權人士簽署\",\"病人/親/護人/獲授權人士署\",\"病人/親屬/監護人/獲授權人士署\",\"病人/親/監護人/獲授權人士簽署\",\"病人/親屬/護人/獲授權人士簽署\",\"病人/親/监護人/獲授權人士署\",\"病人/親丽/護人/授權人士署\",\"病人/親/监護人/猎授權人士策署\"],\"signatureAreaWidth\":440,\"signatureAreaHeight\":80},\"doctor\":{\"targetParameters\":[\"醫生策著\",\"醫生簽署\",\"醫生策署\",\"醫生簽\",\"醫生署\",\"医生簽署\",\"医生策署\",\"医生簽\",\"医生署\",\"生署\"],\"bottomReferenceParameters\":[\"Doctor'sSignature\"],\"rightReferenceParameters\":[\"醫生姓名\",\"医生姓名\",\"生姓名\"],\"signatureAreaWidth\":440,\"signatureAreaHeight\":80}},{\"formId\":\"EDC-BUDES-001\",\"page\":4,\"patient\":{\"targetParameters\":[\"病人/親屬/監護人/獲授權人士簽署\",\"病人/親/護人/獲授權人士署\",\"病人/親屬/監護人/獲授權人士署\",\"病人/親/監護人/獲授權人士簽署\",\"病人/親屬/護人/獲授權人士簽署\",\"病人/親/监護人/獲授權人士署\",\"病人/親丽/護人/授權人士署\",\"病人/親/监護人/猎授權人士策署\"],\"signatureAreaWidth\":440,\"signatureAreaHeight\":80},\"doctor\":{\"targetParameters\":[\"醫生簽署\",\"醫生策署\",\"醫生簽\",\"醫生署\",\"医生簽署\",\"医生策署\",\"医生簽\",\"医生署\",\"生署\"],\"bottomReferenceParameters\":[\"Doctor'sSignature\"],\"rightReferenceParameters\":[\"醫生姓名\",\"医生姓名\",\"生姓名\"],\"signatureAreaWidth\":440,\"signatureAreaHeight\":80}},{\"formId\":\"ONG-BUDES-016\",\"page\":3,\"patient\":{\"targetParameters\":[\"病人/親屬/監護人/獲授權人士簽署\",\"病人/親/護人/獲授權人士署\",\"病人/親屬/監護人/獲授權人士署\",\"病人/親/監護人/獲授權人士簽署\",\"病人/親屬/護人/獲授權人士簽署\",\"病人/親/监護人/獲授權人士署\",\"病人/親丽/護人/授權人士署\",\"病人/親/监護人/猎授權人士策署\",\"病人/親/监護人/獲授權人士薯\"],\"signatureAreaWidth\":440,\"signatureAreaHeight\":80},\"doctor\":{\"targetParameters\":[\"醫生簽署\",\"醫生策署\",\"醫生簽\",\"醫生署\",\"医生簽署\",\"医生策署\",\"医生簽\",\"医生署\",\"生署\"],\"bottomReferenceParameters\":[\"Doctor'sSignature\"],\"rightReferenceParameters\":[\"醫生姓名\",\"医生姓名\",\"生姓名\"],\"signatureAreaWidth\":440,\"signatureAreaHeight\":80}},{\"formId\":\"ONG-BUDES-012\",\"page\":3,\"patient\":{\"targetParameters\":[\"病人/親屬/監護人/獲授權人士簽署\",\"病人/親/護人/獲授權人士署\",\"病人/親屬/監護人/獲授權人士署\",\"病人/親/監護人/獲授權人士簽署\",\"病人/親屬/護人/獲授權人士簽署\",\"病人/親/监護人/獲授權人士署\",\"病人/親丽/護人/授權人士署\",\"病人/親/监護人/猎授權人士策署\",\"病人/親/端镇人/授松人士签馨\"],\"signatureAreaWidth\":440,\"signatureAreaHeight\":80},\"doctor\":{\"targetParameters\":[\"醫生簽署\",\"醫生策署\",\"醫生簽\",\"醫生署\",\"医生簽署\",\"医生策署\",\"医生簽\",\"医生署\",\"生署\",\"劈生寇署\"],\"bottomReferenceParameters\":[\"Doctor'sSignature\"],\"rightReferenceParameters\":[\"醫生姓名\",\"医生姓名\",\"生姓名\"],\"signatureAreaWidth\":440,\"signatureAreaHeight\":80}}],\"parameters\":{\"irregularThreshold\":20,\"blackRatioThreshold\":0.006}}";
        #endregion
        static SignatureConfig SConfig = JsonSerializer.Deserialize<SignatureConfig>(Json);

        static List<FormSignatureConfig> configs = SConfig.formSignatureConfig;

        static SignatureSystemParameters SystemParameters = SConfig.signatureSystemParameters;

        static FormSignatureConfig formIdConfig = null;

        public static async Task OCRImage()
        {
            //// 使用配置参数
            //foreach (var config in configs)
            //{
            //    Console.WriteLine($"表单ID: {config.FormId}");
            //    Console.WriteLine($"页码: {config.Page}");

            //    // 患者签名配置
            //    Console.WriteLine("患者签名目标参数:");
            //    foreach (var target in config.Patient.TargetParameters)
            //    {
            //        Console.WriteLine($"  - {target}");
            //    }
            //    Console.WriteLine($"患者签名区域: {config.Patient.SignatureAreaWidth}x{config.Patient.SignatureAreaHeight}");

            //    // 医生签名配置
            //    Console.WriteLine("医生签名目标参数:");
            //    foreach (var target in config.Doctor.TargetParameters)
            //    {
            //        Console.WriteLine($"  - {target}");
            //    }
            //    Console.WriteLine($"医生签名区域: {config.Doctor.SignatureAreaWidth}x{config.Doctor.SignatureAreaHeight}");
            //    Console.WriteLine();
            //}


            DateTime Pstarttime = DateTime.Now;
            //string folderPath = @"C:\Users\liusi\Desktop\Form";
            string folderPath = @"C:\Users\liusi\Desktop\Form";
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
                    //string[] files = Directory.GetFiles(folderPath, extension, SearchOption.AllDirectories);
                    string[] files = Directory.GetFiles(folderPath, extension, SearchOption.AllDirectories).Where(file => !file.Contains("signature_areas")).ToArray();
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
                DateTime starttime = DateTime.Now;
                string imagePath = imageFiles[i];
                string fileName = Path.GetFileName(imagePath);

                // 获取上级文件夹名称
                string parentFolderName = Path.GetFileName(Path.GetDirectoryName(imagePath));
                Console.WriteLine($"\n上级文件夹名称: {parentFolderName}");

                formIdConfig = configs.Where(s => s.FormId.Contains(parentFolderName)).FirstOrDefault();

                if (formIdConfig == null)
                {
                    System.Console.WriteLine($"\nformId不存在,跳过");
                    continue;
                }


                if (!fileName.Contains(formIdConfig.Page.ToString()))
                {
                    System.Console.WriteLine($"\n不是签名页,跳过");
                    continue;
                }

                Console.WriteLine($"\n[{i + 1}/{totalImages}] 正在识别：{fileName}");
                Console.WriteLine($"文件路径：{imagePath}");

                //using Stream imageStream = ReadLocalFileToStream(imagePath);

                if (string.IsNullOrEmpty(imagePath))
                {
                    continue;
                }

                await OCRAPI(imagePath);
            }
        }


        public static async Task OCRAPI(string imagePath)
        {
            using var client = new HttpClient();
            using var content = new MultipartFormDataContent();
            var fileName = Guid.NewGuid().ToString() + ".jpg";

            // 图片路径
            //string imagePath = "C:\\Users\\liusi\\Desktop\\Fw_ DMS discussion on Signature case\\CMP_ENT_V06.00 (1)-逐页转图片\\CMP_ENT_V06.00 (1)-逐页转图片-00002-Y.jpg";

            // 读取图片并转换为Base64
            byte[] imageBytes = File.ReadAllBytes(imagePath);
            string base64Image = Convert.ToBase64String(imageBytes);

            using Stream imageStream = ReadLocalFileToStream(imagePath);

            // Create StreamContent from the input stream
            var streamContent = new StreamContent(imageStream);
            streamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

            // Add the stream to form-data with field name "image"
            content.Add(streamContent, "image", fileName);

            var postUrl = "http://10.68.68.101:5000/api/ocr-stream";
            // Send POST request
            var response = await client.PostAsync(postUrl, content);
            // Ensure success or throw exception
            response.EnsureSuccessStatusCode();

            // Return response body as string
            string ocrResultJson = await response.Content.ReadAsStringAsync();

            //Console.WriteLine(ocrResultJson);

            //保存为本地文件

            // 解析OCR结果
            var ocrResults = JsonSerializer.Deserialize<List<OCRResult>>(ocrResultJson);

            // 保存识别文件和HTML文件
            string FileName = Path.GetFileNameWithoutExtension(imagePath);

            string JosonFilePath = Path.Combine(Path.GetDirectoryName(imagePath), $"{FileName}-ocr.json");
            File.WriteAllText(JosonFilePath, ocrResultJson);
            Console.WriteLine($"OCR识别文件已保存: {JosonFilePath}");

            // 生成HTML文件
            string htmlContent = GenerateOCRVisualizationHTML(base64Image, ocrResults);
            string htmlFilePath = Path.Combine(Path.GetDirectoryName(imagePath), $"{FileName}-ocr.html");
            File.WriteAllText(htmlFilePath, htmlContent);
            Console.WriteLine($"OCR可视化文件已保存: {htmlFilePath}");

            //// 打开HTML文件
            //System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            //{
            //    FileName = htmlFilePath,
            //    UseShellExecute = true
            //});


            // 直接修改原始列表中的 Text 字段
            foreach (var result in ocrResults)
            {
                if (result?.Text != null)
                {
                    result.Text = ToHalfWidth(result.Text);
                }
            }

            // 调用签名区域截取功能
            await ExtractSignatureAreas(ocrResults, imagePath);
        }

        //符号统一[全角转半角方法]
        //／（U+FF0F） → /（U+002F）
        //ＡＢＣ１２３ → ABC123
        //！？＠＃ → !?@#
        //全角空格 → 普通空格
        public static string ToHalfWidth(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            var result = new char[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                // 全角数字、字母、标点 转 半角（范围 U+FF01 ~ U+FF5E 对应 U+0021 ~ U+007E）
                if (c >= '\uFF01' && c <= '\uFF5E')
                {
                    result[i] = (char)(c - 0xFEE0);
                }
                // 全角空格 U+3000 → 半角空格 U+0020
                else if (c == '\u3000')
                {
                    result[i] = ' ';
                }
                else
                {
                    result[i] = c;
                }
            }
            return new string(result).Trim().Replace(" ", "").ToLower();
        }

        // OCR结果类
        public class OCRResult
        {
            public string Text { get; set; }
            public Boundary Boundary { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
        }

        public class Boundary
        {
            public int left { get; set; }
            public int right { get; set; }
            public int top { get; set; }
            public int bottom { get; set; }
        }

        // 生成OCR可视化HTML
        private static string GenerateOCRVisualizationHTML(string base64Image, List<OCRResult> ocrResults)
        {
            StringBuilder html = new StringBuilder();
            html.AppendLine("<!DOCTYPE html>");
            html.AppendLine("<html lang=\"zh-CN\">");
            html.AppendLine("<head>");
            html.AppendLine("    <meta charset=\"UTF-8\">");
            html.AppendLine("    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">");
            html.AppendLine("    <title>OCR结果</title>");
            html.AppendLine("    <style>");
            html.AppendLine("        body { font-family: Arial, sans-serif; margin: 20px; }");
            html.AppendLine("        .container { max-width: 1200px; margin: 0 auto; }");
            html.AppendLine("        .image-container { position: relative; display: inline-block; margin-bottom: 20px; }");
            html.AppendLine("        .ocr-box { position: absolute; border: 2px solid red; background-color: rgba(255, 0, 0, 0.1); pointer-events: none; }");
            html.AppendLine("        .ocr-text { position: absolute; background-color: yellow; color: black; padding: 2px 5px; font-size: 12px; font-weight: bold; border: 1px solid orange; }");
            html.AppendLine("        .results-table { width: 100%; border-collapse: collapse; margin-top: 20px; }");
            html.AppendLine("        .results-table th, .results-table td { border: 1px solid #ddd; padding: 8px; text-align: left; }");
            html.AppendLine("        .results-table th { background-color: #f2f2f2; }");
            html.AppendLine("        .highlight { background-color: #ffff99; }");
            html.AppendLine("    </style>");
            html.AppendLine("</head>");
            html.AppendLine("<body>");
            html.AppendLine("    <div class=\"container\">");
            html.AppendLine("        <h1>OCR结果</h1>");
            html.AppendLine("        <div class=\"image-container\">");
            html.AppendLine($"            <img src=\"data:image/jpeg;base64,{base64Image}\" alt=\"OCR图片\" id=\"ocrImage\" style=\"max-width: 100%; height: auto;\">");

            // 添加OCR框和文本
            if (ocrResults != null && ocrResults.Count > 0)
            {
                foreach (var result in ocrResults)
                {
                    int width = result.Boundary.right - result.Boundary.left;
                    int height = result.Boundary.bottom - result.Boundary.top;

                    // OCR框
                    html.AppendLine($"            <div class=\"ocr-box\" style=\"left: {result.Boundary.left}px; top: {result.Boundary.top}px; width: {width}px; height: {height}px;\"></div>");

                    // OCR文本（显示在框的上方）
                    html.AppendLine($"            <div class=\"ocr-text\" style=\"left: {result.Boundary.left}px; top: {result.Boundary.top - 20}px;\">{result.Text}</div>");
                }

                // JavaScript缩放代码应该放在所有框之后
                html.AppendLine("            <script>");
                html.AppendLine("                window.onload = function() {");
                html.AppendLine("                    const image = document.getElementById('ocrImage');");
                html.AppendLine("                    const container = document.getElementById('imageContainer');");
                html.AppendLine("                    const imageWidth = image.naturalWidth;");
                html.AppendLine("                    const imageHeight = image.naturalHeight;");
                html.AppendLine("                    const displayWidth = image.offsetWidth;");
                html.AppendLine("                    const displayHeight = image.offsetHeight;");
                html.AppendLine("                    ");
                html.AppendLine("                    // 计算缩放比例");
                html.AppendLine("                    const scaleX = displayWidth / imageWidth;");
                html.AppendLine("                    const scaleY = displayHeight / imageHeight;");
                html.AppendLine("                    ");
                html.AppendLine("                    // 调整所有OCR框的位置和大小");
                html.AppendLine("                    const boxes = document.querySelectorAll('.ocr-box, .ocr-text');");
                html.AppendLine("                    boxes.forEach(box => {");
                html.AppendLine("                        const left = parseInt(box.style.left) * scaleX;");
                html.AppendLine("                        const top = parseInt(box.style.top) * scaleY;");
                html.AppendLine("                        const width = parseInt(box.style.width) * scaleX;");
                html.AppendLine("                        const height = parseInt(box.style.height) * scaleY;");
                html.AppendLine("                        ");
                html.AppendLine("                        box.style.left = left + 'px';");
                html.AppendLine("                        box.style.top = top + 'px';");
                html.AppendLine("                        if (box.classList.contains('ocr-box')) {");
                html.AppendLine("                            box.style.width = width + 'px';");
                html.AppendLine("                            box.style.height = height + 'px';");
                html.AppendLine("                        }");
                html.AppendLine("                    });");
                html.AppendLine("                };");
                html.AppendLine("            </script>");
            }

            html.AppendLine("        </div>");

            // 添加结果表格
            if (ocrResults != null && ocrResults.Count > 0)
            {
                html.AppendLine("        <h2>OCR识别结果</h2>");
                html.AppendLine("        <table class=\"results-table\">");
                html.AppendLine("            <thead>");
                html.AppendLine("                <tr>");
                html.AppendLine("                    <th>序号</th>");
                html.AppendLine("                    <th>识别文本</th>");
                html.AppendLine("                    <th>位置 (left, top, right, bottom)</th>");
                html.AppendLine("                    <th>尺寸 (宽 x 高)</th>");
                html.AppendLine("                </tr>");
                html.AppendLine("            </thead>");
                html.AppendLine("            <tbody>");

                for (int i = 0; i < ocrResults.Count; i++)
                {
                    var result = ocrResults[i];
                    html.AppendLine("                <tr>");
                    html.AppendLine($"                    <td>{i + 1}</td>");
                    html.AppendLine($"                    <td class=\"highlight\">{result.Text}</td>");
                    html.AppendLine($"                    <td>({result.Boundary.left}, {result.Boundary.top}, {result.Boundary.right}, {result.Boundary.bottom})</td>");
                    html.AppendLine($"                    <td>{result.Width} x {result.Height}</td>");
                    html.AppendLine("                </tr>");
                }

                html.AppendLine("            </tbody>");
                html.AppendLine("        </table>");
            }
            else
            {
                html.AppendLine("        <p>未识别到任何文本</p>");
            }

            html.AppendLine("    </div>");
            html.AppendLine("</body>");
            html.AppendLine("</html>");

            return html.ToString();
        }


        /// <summary>
        /// 签名区域信息
        /// </summary>
        public class SignatureAreas
        {
            public SignatureArea PatientSignatureArea { get; set; }
            public SignatureArea DoctorSignatureArea { get; set; }
        }

        /// <summary>
        /// 单个签名区域信息
        /// </summary>
        public class SignatureArea
        {
            public string FilePath { get; set; }
            public Rectangle OriginalPosition { get; set; }
            public Rectangle CroppedArea { get; set; }
            public bool IsVerified { get; set; }
        }

        /// <summary>
        /// 矩形区域
        /// </summary>
        public class Rectangle
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }

            public Rectangle(int x, int y, int width, int height)
            {
                X = x;
                Y = y;
                Width = width;
                Height = height;
            }
        }


        /// <summary>
        /// 定位并截取签名区域
        /// </summary>
        /// <param name="ocrResults">OCR识别结果</param>
        /// <param name="imagePath">图片路径</param>
        /// <returns>包含两个签名区域信息的对象</returns>
        public static async Task<SignatureAreas> ExtractSignatureAreas(List<OCRResult> ocrResults, string imagePath)
        {
            var signatureAreas = new SignatureAreas();

            // 定位第一个签名区域：病人/親屬/監護人/獲授權人士簽署
            var patientSignatureArea = await LocatePatientSignatureArea(ocrResults, imagePath);
            if (patientSignatureArea != null)
            {
                signatureAreas.PatientSignatureArea = patientSignatureArea;
                Console.WriteLine($"找到病人签名区域: {patientSignatureArea.FilePath}");
                Console.WriteLine("病人签名是否含有签名：" + HasSignature(patientSignatureArea.FilePath));
            }
            else
            {
                Console.WriteLine("未找到病人签名区域");
            }

            // 定位第二个签名区域：醫生簽署
            var doctorSignatureArea = await LocateDoctorSignatureArea(ocrResults, imagePath);
            if (doctorSignatureArea != null)
            {
                signatureAreas.DoctorSignatureArea = doctorSignatureArea;
                Console.WriteLine($"找到医生签名区域: {doctorSignatureArea.FilePath}");
                Console.WriteLine("医生签名是否含有签名：" + HasSignature(doctorSignatureArea.FilePath));
            }
            else
            {
                Console.WriteLine("未找到医生签名区域");
            }

            return signatureAreas;
        }

        /// <summary>
        /// 定位病人签名区域
        /// </summary>
        private static async Task<SignatureArea> LocatePatientSignatureArea(List<OCRResult> ocrResults, string imagePath)
        {
            // 可能的OCR识别错误模式
            //var patientSignaturePatterns = new[]
            //{
            //"病人/親屬/監護人/獲授權人士簽署",
            //"病人/親/護人/獲授權人士署",
            //"病人/親屬/監護人/獲授權人士署",
            //"病人/親/監護人/獲授權人士簽署",
            //"病人/親屬/護人/獲授權人士簽署"
            //};

            var patientSignaturePatterns = formIdConfig.Patient.TargetParameters;

            // 查找所有匹配的文本
            var signatureList = ocrResults.Where(r =>
                patientSignaturePatterns.Any(pattern =>
                    r.Text.Contains(pattern.ToLower()) ||
                    CalculateSimilarity(r.Text, pattern.ToLower()) > 0.7)).ToList();

            OCRResult signatureText = null;
            if (signatureList != null && signatureList.Any())
            {
                signatureText = signatureList.MinBy(item => item.Boundary.left);
            }

            //// 查找匹配的文本
            //signatureText = ocrResults.FirstOrDefault(r =>
            //    patientSignaturePatterns.Any(pattern =>
            //        r.Text.Contains(pattern.ToLower()) ||
            //        CalculateSimilarity(r.Text, pattern.ToLower()) > 0.7));

            if (signatureText == null)
            {
                Console.WriteLine("未找到病人签名文本");
                return null;
            }

            Console.WriteLine($"找到病人签名文本: {signatureText.Text}");

            // 截取上方584x80的区域
            return await CropSignatureArea(signatureText.Boundary, imagePath, "patient_signature", 440, 80, true);
        }

        /// <summary>
        /// 定位医生签名区域
        /// </summary>
        private static async Task<SignatureArea> LocateDoctorSignatureAreaOld(List<OCRResult> ocrResults, string imagePath)
        {
            // 可能的OCR识别错误模式
            var doctorSignaturePatterns = new[]
            {
            "醫生簽署",
            "醫生策署",
            "醫生簽",
            "醫生署"
            };

            //// 查找医生签名文本
            //var doctorSignatureText = ocrResults.FirstOrDefault(r =>
            //    doctorSignaturePatterns.Any(pattern =>
            //        r.Text.Contains(pattern) ||
            //        CalculateSimilarity(r.Text, pattern) > 0.7));

            // 查找医生签名文本
            var doctorSignatureText = ocrResults.Where(r =>
                doctorSignaturePatterns.Any(pattern =>
                    r.Text.Contains(pattern) ||
                    CalculateSimilarity(r.Text, pattern) > 0.7)).ToList();

            if (doctorSignatureText == null)
            {
                Console.WriteLine("未找到医生签名文本");
                return null;
            }

            foreach (var item in doctorSignatureText)
            {
                Console.WriteLine($"找到医生签名文本: {item.Text}");

                // 查找辅助标记：Doctor'sSignature
                var doctorSignatureMarker = ocrResults.FirstOrDefault(r =>
                    r.Text.Contains("Doctor'sSignature"));

                // 查找辅助标记：醫生姓名
                var doctorNameMarker = ocrResults.FirstOrDefault(r =>
                    r.Text.Contains("醫生姓名"));

                // 验证位置关系
                if (doctorSignatureMarker != null && doctorNameMarker != null)
                {
                    // 检查医生签名是否在Doctor'sSignature正上方
                    bool isAboveDoctorSignature = item.Boundary.bottom < doctorSignatureMarker.Boundary.top;

                    // 检查医生签名是否在醫生姓名左侧
                    bool isLeftOfDoctorName = item.Boundary.right < doctorNameMarker.Boundary.left;

                    if (isAboveDoctorSignature && isLeftOfDoctorName)
                    {
                        Console.WriteLine("医生签名位置验证通过");
                        // 截取上方584x80的区域
                        return await CropSignatureArea(item.Boundary, imagePath, "doctor_signature", 440, 98, true);
                    }
                }
            }

            Console.WriteLine("医生签名位置验证失败，使用默认截取");
            // 如果验证失败，仍然截取但标记为未验证
            var area = await CropSignatureArea(doctorSignatureText[0].Boundary, imagePath, "doctor_signature_unverified", 440, 98, true);
            area.IsVerified = false;
            return area;
        }


        /// <summary>
        /// 定位医生签名区域 - 简化版验证逻辑
        /// </summary>
        private static async Task<SignatureArea> LocateDoctorSignatureArea(List<OCRResult> ocrResults, string imagePath)
        {
            // 可能的OCR识别错误模式
            //var doctorSignaturePatterns = new[]
            //{
            //    "醫生簽署",
            //    "醫生策署",
            //    "醫生簽",
            //    "醫生署"
            //};

            var doctorSignaturePatterns = formIdConfig.Doctor.TargetParameters;

            // 查找医生签名文本
            var doctorSignatureText = ocrResults.Where(r =>
                doctorSignaturePatterns.Any(pattern =>
                    r.Text.Contains(pattern.ToLower()) ||
                    CalculateSimilarity(r.Text, pattern.ToLower()) > 0.7)).ToList();

            if (doctorSignatureText == null || doctorSignatureText.Count == 0)
            {
                Console.WriteLine("未找到医生签名文本");
                return null;
            }

            // 查找所有Doctor'sSignature标记
            //var doctorSignatureMarkers = ocrResults.Where(r =>
            //    r.Text.Contains(formIdConfig.Doctor.BottomReferenceParameters)).ToList();
            var doctorSignatureMarkers = ocrResults.Where(r => formIdConfig.Doctor.BottomReferenceParameters.Any(param => r.Text.Contains(param.ToLower()) ||
                    CalculateSimilarity(r.Text, param.ToLower()) > 0.7)).ToList();

            // 查找所有醫生姓名标记
            //var doctorNameMarkers = ocrResults.Where(r =>
            //    r.Text.Contains(formIdConfig.Doctor.RightReferenceParameters)).ToList();

            //包含匹配，OCR识别可能存在细微差异。
            var doctorNameMarkers = ocrResults.Where(r => formIdConfig.Doctor.RightReferenceParameters.Any(param => r.Text.Contains(param.ToLower()) ||
                    CalculateSimilarity(r.Text, param.ToLower()) > 0.7)).ToList();

            foreach (var item in doctorSignatureText)
            {
                Console.WriteLine($"找到医生签名文本: {item.Text} ({item.Boundary.left}, {item.Boundary.top}, {item.Boundary.right}, {item.Boundary.bottom})");

                // 查找在同一行的醫生姓名标记
                var sameLineDoctorName = doctorNameMarkers
                    .Where(marker =>
                        // 同一行检查：top和bottom基本一致
                        Math.Abs(marker.Boundary.top - item.Boundary.top) < 50 &&
                        Math.Abs(marker.Boundary.bottom - item.Boundary.bottom) < 50) //放宽到50像素
                    .FirstOrDefault();

                // 查找在同一列的Doctor'sSignature标记
                var sameColumnDoctorSignature = doctorSignatureMarkers
                    .Where(marker =>
                        // 同一列检查：left基本一致
                        Math.Abs(marker.Boundary.left - item.Boundary.left) < 50 &&
                        // 上下行挨着检查：用top判断，在正下方且距离适中
                        marker.Boundary.top > item.Boundary.top &&
                        Math.Abs(marker.Boundary.top - item.Boundary.top) < 50) // 用top距离判断，放宽到50像素
                    .FirstOrDefault();

                #region 原始逻辑，两个都判断-Copy备用
                //// 简化验证逻辑
                //if (sameLineDoctorName != null && sameColumnDoctorSignature != null)
                //{
                //    // 验证右侧关系
                //    bool isRightOfDoctorName = item.Boundary.right < sameLineDoctorName.Boundary.left;

                //    // 验证上方关系
                //    bool isAboveDoctorSignature = item.Boundary.top < sameColumnDoctorSignature.Boundary.top;

                //    Console.WriteLine($"醫生姓名位置: ({sameLineDoctorName.Boundary.left}, {sameLineDoctorName.Boundary.top}, {sameLineDoctorName.Boundary.right}, {sameLineDoctorName.Boundary.bottom})");
                //    Console.WriteLine($"Doctor'sSignature位置: ({sameColumnDoctorSignature.Boundary.left}, {sameColumnDoctorSignature.Boundary.top}, {sameColumnDoctorSignature.Boundary.right}, {sameColumnDoctorSignature.Boundary.bottom})");
                //    Console.WriteLine($"右侧验证: {isRightOfDoctorName} (距离: {sameLineDoctorName.Boundary.left - item.Boundary.right}px)");
                //    Console.WriteLine($"上方验证: {isAboveDoctorSignature} (距离: {sameColumnDoctorSignature.Boundary.top - item.Boundary.bottom}px)");

                //    if (isRightOfDoctorName || isAboveDoctorSignature)
                //    {
                //        Console.WriteLine("医生签名位置验证通过 - 简化逻辑");
                //        // 截取上方区域
                //        return await CropSignatureArea(item.Boundary, imagePath, "doctor_signature", 440, 80, true);
                //    }
                //}
                //else
                //{
                //    Console.WriteLine($"未找到匹配的辅助标记 - 同一行醫生姓名: {sameLineDoctorName != null}, 同一列Doctor'sSignature: {sameColumnDoctorSignature != null}");
                //}
                #endregion

                bool isRightOfDoctorName = false;
                bool isAboveDoctorSignature = false;
                // 简化验证逻辑
                if (sameLineDoctorName != null)
                {
                    // 验证右侧关系
                    isRightOfDoctorName = item.Boundary.right < sameLineDoctorName.Boundary.left;
                    Console.WriteLine($"醫生姓名位置: ({sameLineDoctorName.Boundary.left}, {sameLineDoctorName.Boundary.top}, {sameLineDoctorName.Boundary.right}, {sameLineDoctorName.Boundary.bottom})");
                    Console.WriteLine($"右侧验证: {isRightOfDoctorName} (距离: {sameLineDoctorName.Boundary.left - item.Boundary.right}px)");

                }

                if (sameColumnDoctorSignature != null)
                {
                    // 验证上方关系
                    isAboveDoctorSignature = item.Boundary.top < sameColumnDoctorSignature.Boundary.top;
                    Console.WriteLine($"Doctor'sSignature位置: ({sameColumnDoctorSignature.Boundary.left}, {sameColumnDoctorSignature.Boundary.top}, {sameColumnDoctorSignature.Boundary.right}, {sameColumnDoctorSignature.Boundary.bottom})");
                    Console.WriteLine($"上方验证: {isAboveDoctorSignature} (距离: {sameColumnDoctorSignature.Boundary.top - item.Boundary.bottom}px)");
                }

                if (isRightOfDoctorName || isAboveDoctorSignature)
                {
                    Console.WriteLine("医生签名位置验证通过 - 简化逻辑");
                    // 截取上方区域
                    return await CropSignatureArea(item.Boundary, imagePath, "doctor_signature", 440, 80, true);
                }
                else
                {
                    Console.WriteLine($"未找到匹配的辅助标记 - 同一行醫生姓名: {sameLineDoctorName != null}, 同一列Doctor'sSignature: {sameColumnDoctorSignature != null}");
                }
            }

            Console.WriteLine("所有医生签名位置验证失败，使用默认截取");
            // 如果验证失败，仍然截取但标记为未验证
            var area = await CropSignatureArea(doctorSignatureText[0].Boundary, imagePath, "doctor_signature_unverified", 440, 80, true);
            area.IsVerified = false;
            return area;
        }

        /// <summary>
        /// 截取签名区域BySixLabors
        /// </summary>
        private static async Task<SignatureArea> CropSignatureArea(Boundary boundary, string imagePath, string prefix, int width, int height, bool cropAbove)
        {
            return await CropSignatureAreaBySixLabors(boundary, imagePath, prefix, width, height, true);
            //return await CropSignatureAreaBySkiaSharp(boundary, imagePath, prefix, width, height, true);
        }


        /// <summary>
        /// 根据图片实际分辨率动态调整裁剪区域尺寸
        /// </summary>
        /// <param name="imagePath">图片路径</param>
        /// <param name="baseWidth">基于1190x1683分辨率的基准宽度</param>
        /// <param name="baseHeight">基于1190x1683分辨率的基准高度</param>
        /// <returns>调整后的宽度和高度</returns>
        private static (int adjustedWidth, int adjustedHeight) AdjustCropAreaByResolution(string imagePath, int baseWidth, int baseHeight)
        {
            try
            {
                // 获取图片实际分辨率
                using var image = SixLabors.ImageSharp.Image.Load(imagePath);
                int actualWidth = image.Width;
                int actualHeight = image.Height;

                // 基准分辨率 (1190x1683)
                int baseResolutionWidth = 1190;
                int baseResolutionHeight = 1683;

                // 计算缩放比例（使用宽度和高度中较小的比例，确保不会超出边界）
                double widthScale = (double)actualWidth / baseResolutionWidth;
                double heightScale = (double)actualHeight / baseResolutionHeight;

                // 使用平均缩放比例，保持裁剪区域的相对位置
                double scale = (widthScale + heightScale) / 2.0;

                // 调整裁剪区域尺寸
                int adjustedWidth = (int)Math.Round(baseWidth * scale);
                int adjustedHeight = (int)Math.Round(baseHeight * scale);

                Console.WriteLine($"分辨率适配：基准({baseResolutionWidth}x{baseResolutionHeight}) -> 实际({actualWidth}x{actualHeight})");
                Console.WriteLine($"裁剪区域：基准({baseWidth}x{baseHeight}) -> 适配({adjustedWidth}x{adjustedHeight})");

                return (adjustedWidth, adjustedHeight);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"获取图片分辨率失败，使用基准尺寸: {ex.Message}");
                return (baseWidth, baseHeight);
            }
        }

        /// <summary>
        /// 使用SixLabors截取签名区域
        /// </summary>
        private static async Task<SignatureArea> CropSignatureAreaBySixLabors(Boundary boundary, string imagePath, string prefix, int width, int height, bool cropAbove)
        {
            try
            {
                // 根据图片实际分辨率调整裁剪区域尺寸
                (int adjustedWidth, int adjustedHeight) = AdjustCropAreaByResolution(imagePath, width, height);
                width = adjustedWidth;
                height = adjustedHeight;

                using var image = SixLabors.ImageSharp.Image.Load(imagePath);

                // 计算截取区域
                int cropX, cropY;

                if (cropAbove)
                {
                    // 截取上方区域
                    cropX = boundary.left;
                    cropY = Math.Max(0, boundary.top - height);
                }
                else
                {
                    // 截取包含文本的区域
                    cropX = boundary.left;
                    cropY = boundary.top;
                }

                // 确保不超出图片边界
                cropX = Math.Max(0, cropX);
                cropY = Math.Max(0, cropY);
                width = Math.Min(width, image.Width - cropX);
                height = Math.Min(height, image.Height - cropY);

                if (width <= 0 || height <= 0)
                {
                    Console.WriteLine("截取区域超出图片边界");
                    return null;
                }

                // 截取区域
                using var croppedImage = image.Clone(ctx => ctx
                    .Crop(new SixLabors.ImageSharp.Rectangle(cropX, cropY, width, height)));

                // 保存截取图片
                string outputDir = Path.Combine(Path.GetDirectoryName(imagePath), "signature_areas");
                Directory.CreateDirectory(outputDir);

                //string outputPath = Path.Combine(outputDir, $"{prefix}_{DateTime.Now:yyyyMMddHHmmss}.jpg");
                string FileName = Path.GetFileNameWithoutExtension(imagePath);
                string outputPath = Path.Combine(outputDir, $"{prefix}-{FileName}.jpg");
                await croppedImage.SaveAsJpegAsync(outputPath);

                return new SignatureArea
                {
                    FilePath = outputPath,
                    OriginalPosition = new Rectangle(boundary.left, boundary.top, boundary.right - boundary.left, boundary.bottom - boundary.top),
                    CroppedArea = new Rectangle(cropX, cropY, width, height),
                    IsVerified = true
                };



                //// 将裁剪后的图像写入到内存流中而不是保存为文件
                //var memoryStream = new System.IO.MemoryStream();
                //await croppedImage.SaveAsJpegAsync(memoryStream);

                //// 重置流的位置到开始，以便读取
                //memoryStream.Position = 0;

                //// 返回流或其他需要的信息
                //return new
                //{
                //    ImageStream = memoryStream,
                //    OriginalPosition = new Rectangle(boundary.left, boundary.top, boundary.right - boundary.left, boundary.bottom - boundary.top),
                //    CroppedArea = new Rectangle(cropX, cropY, width, height),
                //    IsVerified = true
                //};
            }
            catch (Exception ex)
            {
                Console.WriteLine($"截取签名区域时出错: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// 使用SkiaSharp截取签名区域
        /// </summary>
        private static async Task<SignatureArea> CropSignatureAreaBySkiaSharp(Boundary boundary, string imagePath, string prefix, int width, int height, bool cropAbove)
        {
            try
            {
                // 使用SkiaSharp加载图片
                using var bitmap = SKBitmap.Decode(imagePath);
                if (bitmap == null)
                {
                    Console.WriteLine("无法加载图片");
                    return null;
                }

                // 计算截取区域
                int cropX, cropY;

                if (cropAbove)
                {
                    // 截取上方区域
                    cropX = boundary.left;
                    cropY = Math.Max(0, boundary.top - height);
                }
                else
                {
                    // 截取包含文本的区域
                    cropX = boundary.left;
                    cropY = boundary.top;
                }

                // 确保不超出图片边界
                cropX = Math.Max(0, cropX);
                cropY = Math.Max(0, cropY);
                width = Math.Min(width, bitmap.Width - cropX);
                height = Math.Min(height, bitmap.Height - cropY);

                if (width <= 0 || height <= 0)
                {
                    Console.WriteLine("截取区域超出图片边界");
                    return null;
                }

                // 创建截取区域
                var cropRect = new SKRectI(cropX, cropY, cropX + width, cropY + height);

                // 截取图片
                using var croppedBitmap = new SKBitmap(width, height);
                if (!bitmap.ExtractSubset(croppedBitmap, cropRect))
                {
                    Console.WriteLine("截取图片失败");
                    return null;
                }

                // 保存截取图片
                string outputDir = Path.Combine(Path.GetDirectoryName(imagePath), "signature_areas_skiasharp");
                Directory.CreateDirectory(outputDir);

                string outputPath = Path.Combine(outputDir, $"{prefix}_{DateTime.Now:yyyyMMddHHmmss}.jpg");

                // 使用SKImage保存图片
                using var image = SKImage.FromBitmap(croppedBitmap);
                using var data = image.Encode(SKEncodedImageFormat.Jpeg, 90);
                using var stream = File.OpenWrite(outputPath);
                data.SaveTo(stream);

                return new SignatureArea
                {
                    FilePath = outputPath,
                    OriginalPosition = new Rectangle(boundary.left, boundary.top, boundary.right - boundary.left, boundary.bottom - boundary.top),
                    CroppedArea = new Rectangle(cropX, cropY, width, height),
                    IsVerified = true
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"使用SkiaSharp截取签名区域时出错: {ex.Message}");
                return null;
            }
        }


        /// <summary>
        /// 计算文本相似度（处理OCR识别错误）
        /// </summary>
        private static double CalculateSimilarity(string text1, string text2)
        {
            if (string.IsNullOrEmpty(text1) || string.IsNullOrEmpty(text2))
                return 0;

            text1 = text1.ToLower().Replace(" ", "");
            text2 = text2.ToLower().Replace(" ", "");

            if (text1 == text2)
                return 1.0;

            // 简单的字符匹配计算
            int matches = 0;
            int minLength = Math.Min(text1.Length, text2.Length);

            for (int i = 0; i < minLength; i++)
            {
                if (text1[i] == text2[i])
                    matches++;
            }

            return (double)matches / Math.Max(text1.Length, text2.Length);
        }


        /// <summary>
        /// 判断是否有签名
        /// </summary>
        /// <param name="imageStream"></param>
        /// <returns></returns>
        public static bool HasHandwrittenSignatureOld(string imageFilePath)
        {
            using Stream imageStream = ReadLocalFileToStream(imageFilePath);
            const float minPixelRatio = 0.005f;   // 最小像素占比
            const int minComponentSize = 30;      // 最小连通区域像素数
            const int maxLineWidth = 5;           // 最大允许的“线状”宽度（防横线/竖线）
            const byte colorThreshold = 240;      // 暗色阈值

            try
            {
                using var image = SixLabors.ImageSharp.Image.Load<Rgba32>(imageStream);
                if (image.Width == 0 || image.Height == 0) return false;

                // 转灰度
                var grayImage = image.Clone();
                grayImage.Mutate(x => x.Grayscale());

                // 收集所有暗像素
                var blackPixels = new HashSet<(int X, int Y)>();
                for (int y = 0; y < grayImage.Height; y++)
                {
                    for (int x = 0; x < grayImage.Width; x++)
                    {
                        if (grayImage[x, y].R <= colorThreshold)
                        {
                            blackPixels.Add((x, y));
                        }
                    }
                }

                if (blackPixels.Count == 0) return false;

                float ratio = (float)blackPixels.Count / (image.Width * image.Height);
                if (ratio < minPixelRatio) return false;

                // 连通域分析 + 形状判断
                var visited = new HashSet<(int, int)>();
                foreach (var pixel in blackPixels)
                {
                    if (visited.Contains(pixel)) continue;

                    // BFS 获取整个连通区域
                    var component = new List<(int X, int Y)>();
                    var queue = new Queue<(int, int)>();
                    queue.Enqueue(pixel);
                    visited.Add(pixel);

                    while (queue.Count > 0)
                    {
                        var (x, y) = queue.Dequeue();
                        component.Add((x, y));

                        foreach (var neighbor in new[] { (x + 1, y), (x - 1, y), (x, y + 1), (x, y - 1) })
                        {
                            if (blackPixels.Contains(neighbor) && !visited.Contains(neighbor))
                            {
                                visited.Add(neighbor);
                                queue.Enqueue(neighbor);
                            }
                        }
                    }

                    // 跳过太小的区域
                    if (component.Count < minComponentSize) continue;

                    // 计算包围盒
                    int minX = component.Min(p => p.X);
                    int maxX = component.Max(p => p.X);
                    int minY = component.Min(p => p.Y);
                    int maxY = component.Max(p => p.Y);

                    int width = maxX - minX + 1;
                    int height = maxY - minY + 1;

                    // ❌ 排除“细长线”：比如横线（height <= maxLineWidth）或竖线（width <= maxLineWidth）
                    if (width >= 3 * height && height <= maxLineWidth) continue; // 横线
                    if (height >= 3 * width && width <= maxLineWidth) continue; // 竖线

                    // ✅ 如果有一个区域既不小，又不是细线 → 很可能是签名
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 判断是否有签名
        /// </summary>
        /// <param name="imageStream"></param>
        /// <returns></returns>
        public static bool HasHandwrittenSignature(string imageFilePath)
        {
            using Stream imageStream = ReadLocalFileToStream(imageFilePath);
            const float minInkRatio = 0.002f;   // 最小墨迹占比（0.2%）
            const int minInkPixels = 30;        // 最少墨迹像素数
            const int maxLineWidth = 4;         // 最大允许的“线高”（防下划线）
            const byte darkThreshold = 240;     // RGB < 240 视为墨迹

            try
            {
                using var image = SixLabors.ImageSharp.Image.Load<Rgba32>(imageStream);
                if (image.Width <= 1 || image.Height <= 1) return false;

                int totalPixels = image.Width * image.Height;
                var inkPixels = new List<(int X, int Y)>();

                // 收集所有墨迹像素（支持彩色签名）
                for (int y = 0; y < image.Height; y++)
                {
                    for (int x = 0; x < image.Width; x++)
                    {
                        var p = image[x, y];
                        if (p.R < darkThreshold || p.G < darkThreshold || p.B < darkThreshold)
                        {
                            inkPixels.Add((x, y));
                        }
                    }
                }

                // 条件1: 墨迹太少 → 无签名
                if (inkPixels.Count < minInkPixels ||
                    (float)inkPixels.Count / totalPixels < minInkRatio)
                {
                    return false;
                }

                // 条件2: 计算墨迹在垂直方向的分布（行投影）
                var rowCounts = new int[image.Height];
                foreach (var (x, y) in inkPixels)
                {
                    rowCounts[y]++;
                }

                // 找出有墨迹的行
                var nonEmptyRows = rowCounts.Where(c => c > 0).ToArray();
                if (nonEmptyRows.Length == 0) return false;

                // 如果墨迹集中在 ≤2 行，且每行都很长 → 很可能是文字或横线
                if (nonEmptyRows.Length <= 2)
                {
                    // 检查是否有“长线”：任一行墨迹占比 > 30%
                    foreach (int count in nonEmptyRows)
                    {
                        if ((float)count / image.Width > 0.3f)
                        {
                            return false; // 是横线或文字行
                        }
                    }
                }

                // 条件3: 连通域分析 —— 必须有一个“非细长”的大区域
                var visited = new HashSet<(int, int)>();
                bool hasCompactRegion = false;

                foreach (var pixel in inkPixels)
                {
                    if (visited.Contains(pixel)) continue;

                    // BFS 获取连通区域
                    var component = new List<(int, int)>();
                    var queue = new Queue<(int, int)>();
                    queue.Enqueue(pixel);
                    visited.Add(pixel);

                    while (queue.Count > 0)
                    {
                        var (x, y) = queue.Dequeue();
                        component.Add((x, y));

                        foreach (var nb in new[] { (x + 1, y), (x - 1, y), (x, y + 1), (x, y - 1) })
                        {
                            if (inkPixels.Contains(nb) && !visited.Contains(nb))
                            {
                                visited.Add(nb);
                                queue.Enqueue(nb);
                            }
                        }
                    }

                    if (component.Count < 15) continue;

                    // 计算包围盒
                    int minX = component.Min(p => p.Item1);
                    int maxX = component.Max(p => p.Item1);
                    int minY = component.Min(p => p.Item2);
                    int maxY = component.Max(p => p.Item2);
                    int width = maxX - minX + 1;
                    int height = maxY - minY + 1;

                    // 排除细长区域（横线/竖线）
                    if (height <= maxLineWidth && width > height * 3) continue;
                    if (width <= maxLineWidth && height > width * 3) continue;

                    // ✅ 找到一个紧凑区域 → 很可能是签名
                    hasCompactRegion = true;
                    break;
                }

                return hasCompactRegion;
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// 改进版签名检测方法
        /// </summary>
        public static bool HasHandwrittenSignatureImproved(string imageFilePath)
        {
            using Stream imageStream = ReadLocalFileToStream(imageFilePath);
            const float minInkRatio = 0.0015f;   // 降低墨迹占比要求
            const int minInkPixels = 20;         // 降低最小像素数
            const byte darkThreshold = 200;      // 降低阈值，适应浅色签名
            const int maxLineWidth = 3;          // 更严格的线宽检测

            try
            {
                using var image = SixLabors.ImageSharp.Image.Load<Rgba32>(imageStream);
                if (image.Width <= 1 || image.Height <= 1) return false;

                int totalPixels = image.Width * image.Height;
                var inkPixels = new List<(int X, int Y)>();

                // 改进的墨迹检测：考虑灰度值
                for (int y = 0; y < image.Height; y++)
                {
                    for (int x = 0; x < image.Width; x++)
                    {
                        var p = image[x, y];
                        // 计算灰度值：0.299R + 0.587G + 0.114B
                        byte grayValue = (byte)(0.299 * p.R + 0.587 * p.G + 0.114 * p.B);
                        if (grayValue < darkThreshold)
                        {
                            inkPixels.Add((x, y));
                        }
                    }
                }

                // 基础条件检查
                if (inkPixels.Count < minInkPixels ||
                    (float)inkPixels.Count / totalPixels < minInkRatio)
                {
                    return false;
                }

                // 改进的连通域分析：使用8邻域
                var visited = new HashSet<(int, int)>();
                bool hasValidSignature = false;

                foreach (var pixel in inkPixels)
                {
                    if (visited.Contains(pixel)) continue;

                    // 8邻域BFS
                    var component = new List<(int, int)>();
                    var queue = new Queue<(int, int)>();
                    queue.Enqueue(pixel);
                    visited.Add(pixel);

                    while (queue.Count > 0)
                    {
                        var (x, y) = queue.Dequeue();
                        component.Add((x, y));

                        // 8方向邻域
                        foreach (var nb in new[] {
                            (x+1, y), (x-1, y), (x, y+1), (x, y-1),
                            (x+1, y+1), (x+1, y-1), (x-1, y+1), (x-1, y-1)
                        })
                        {
                            if (nb.Item1 >= 0 && nb.Item1 < image.Width &&
                                nb.Item2 >= 0 && nb.Item2 < image.Height &&
                                inkPixels.Contains(nb) && !visited.Contains(nb))
                            {
                                visited.Add(nb);
                                queue.Enqueue(nb);
                            }
                        }
                    }

                    if (component.Count < 15) continue;

                    // 计算包围盒和形状特征
                    int minX = component.Min(p => p.Item1);
                    int maxX = component.Max(p => p.Item1);
                    int minY = component.Min(p => p.Item2);
                    int maxY = component.Max(p => p.Item2);
                    int width = maxX - minX + 1;
                    int height = maxY - minY + 1;

                    // 排除细长线
                    if ((height <= maxLineWidth && width > height * 4) ||
                        (width <= maxLineWidth && height > width * 4))
                        continue;

                    // 计算紧凑度：面积/(包围盒面积)
                    float compactness = (float)component.Count / (width * height);

                    // 签名通常有中等紧凑度（0.1-0.6）
                    if (compactness > 0.05f && compactness < 0.8f)
                    {
                        hasValidSignature = true;
                        break;
                    }
                }

                return hasValidSignature;
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// 精准签名检测 - 专门针对裁剪图片优化
        /// </summary>
        public static bool HasHandwrittenSignaturePreciseold(string imageFilePath)
        {
            using Stream imageStream = ReadLocalFileToStream(imageFilePath);
            const float minInkRatio = 0.003f;    // 提高墨迹占比要求
            const int minInkPixels = 25;         // 提高最小像素数
            const byte darkThreshold = 180;      // 更严格的阈值
            const int maxLineWidth = 2;          // 更严格的线宽检测

            try
            {
                using var image = SixLabors.ImageSharp.Image.Load<Rgba32>(imageStream);
                if (image.Width <= 10 || image.Height <= 10) return false;

                int totalPixels = image.Width * image.Height;
                var inkPixels = new List<(int X, int Y)>();

                // 预处理：先进行高斯模糊减少噪声
                using var processedImage = image.Clone();
                processedImage.Mutate(x => x.GaussianBlur(0.8f));

                // 改进的墨迹检测：考虑局部对比度
                for (int y = 1; y < processedImage.Height - 1; y++)
                {
                    for (int x = 1; x < processedImage.Width - 1; x++)
                    {
                        var p = processedImage[x, y];
                        byte grayValue = (byte)(0.299 * p.R + 0.587 * p.G + 0.114 * p.B);

                        // 检查是否为真正的暗像素（不是噪声）
                        if (grayValue < darkThreshold)
                        {
                            // 检查周围像素的对比度（避免孤立噪声点）
                            int darkNeighbors = 0;
                            for (int dy = -1; dy <= 1; dy++)
                            {
                                for (int dx = -1; dx <= 1; dx++)
                                {
                                    if (dx == 0 && dy == 0) continue;
                                    var neighbor = processedImage[x + dx, y + dy];
                                    byte neighborGray = (byte)(0.299 * neighbor.R + 0.587 * neighbor.G + 0.114 * neighbor.B);
                                    if (neighborGray < darkThreshold + 30) // 稍微宽松的邻居阈值
                                        darkNeighbors++;
                                }
                            }

                            // 至少有2个暗邻居才认为是有效墨迹
                            if (darkNeighbors >= 2)
                            {
                                inkPixels.Add((x, y));
                            }
                        }
                    }
                }

                // 基础条件检查（更严格）
                if (inkPixels.Count < minInkPixels ||
                    (float)inkPixels.Count / totalPixels < minInkRatio)
                {
                    return false;
                }

                // 分析墨迹分布特征
                var rowDensity = new int[processedImage.Height];
                var colDensity = new int[processedImage.Width];

                foreach (var (x, y) in inkPixels)
                {
                    rowDensity[y]++;
                    colDensity[x]++;
                }

                // 检查是否为规则的文字行（排除印刷文字）
                var nonEmptyRows = rowDensity.Where(c => c > 0).ToArray();
                if (nonEmptyRows.Length > 0)
                {
                    // 计算行的密度变化（签名通常密度变化大，文字行变化小）
                    float densityVariation = (float)nonEmptyRows.Max() / Math.Max(nonEmptyRows.Min(), 1);
                    if (densityVariation < 3.0f && nonEmptyRows.Length >= 3)
                    {
                        // 密度变化小且有多行 → 可能是文字
                        return false;
                    }
                }

                // 连通域分析（更严格的条件）
                var visited = new HashSet<(int, int)>();
                bool hasValidSignature = false;
                int validComponents = 0;

                foreach (var pixel in inkPixels)
                {
                    if (visited.Contains(pixel)) continue;

                    // 8邻域BFS
                    var component = new List<(int, int)>();
                    var queue = new Queue<(int, int)>();
                    queue.Enqueue(pixel);
                    visited.Add(pixel);

                    while (queue.Count > 0)
                    {
                        var (x, y) = queue.Dequeue();
                        component.Add((x, y));

                        foreach (var nb in new[] {
                            (x+1, y), (x-1, y), (x, y+1), (x, y-1),
                            (x+1, y+1), (x+1, y-1), (x-1, y+1), (x-1, y-1)
                        })
                        {
                            if (nb.Item1 >= 0 && nb.Item1 < processedImage.Width &&
                                nb.Item2 >= 0 && nb.Item2 < processedImage.Height &&
                                inkPixels.Contains(nb) && !visited.Contains(nb))
                            {
                                visited.Add(nb);
                                queue.Enqueue(nb);
                            }
                        }
                    }

                    if (component.Count < 20) continue; // 提高最小组件大小

                    // 计算形状特征
                    int minX = component.Min(p => p.Item1);
                    int maxX = component.Max(p => p.Item1);
                    int minY = component.Min(p => p.Item2);
                    int maxY = component.Max(p => p.Item2);
                    int width = maxX - minX + 1;
                    int height = maxY - minY + 1;

                    // 排除细长线（更严格）
                    if ((height <= maxLineWidth && width > height * 5) ||
                        (width <= maxLineWidth && height > width * 5))
                        continue;

                    // 计算紧凑度和复杂度
                    float compactness = (float)component.Count / (width * height);
                    float aspectRatio = (float)width / Math.Max(height, 1);

                    // 签名特征：
                    // - 紧凑度适中（0.1-0.6）
                    // - 宽高比适中（0.5-3.0）
                    // - 不是完美的圆形或方形
                    if (compactness > 0.08f && compactness < 0.7f &&
                        aspectRatio > 0.4f && aspectRatio < 4.0f)
                    {
                        validComponents++;
                        if (validComponents >= 1) // 至少有一个有效组件
                        {
                            hasValidSignature = true;
                            break;
                        }
                    }
                }

                // 添加调试输出
                Console.WriteLine($"图片尺寸: {image.Width}x{image.Height}");
                Console.WriteLine($"墨迹像素数: {inkPixels.Count}");
                Console.WriteLine($"墨迹占比: {(float)inkPixels.Count / totalPixels:P2}");
                Console.WriteLine($"有效组件数: {validComponents}");

                return hasValidSignature;
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// 精准签名检测 - 专门针对裁剪图片优化，排除底部线条
        /// </summary>
        public static bool HasHandwrittenSignaturePreciseOld(string imageFilePath)
        {
            using Stream imageStream = ReadLocalFileToStream(imageFilePath);
            const float minInkRatio = 0.003f;    // 提高墨迹占比要求
            const int minInkPixels = 25;         // 提高最小像素数
            const byte darkThreshold = 180;      // 更严格的阈值
            const int maxLineWidth = 2;          // 更严格的线宽检测
            const float bottomExclusionRatio = 0.15f; // 排除底部15%区域

            try
            {
                using var image = SixLabors.ImageSharp.Image.Load<Rgba32>(imageStream);
                if (image.Width <= 10 || image.Height <= 10) return false;

                int totalPixels = image.Width * image.Height;
                var inkPixels = new List<(int X, int Y)>();

                // 预处理：先进行高斯模糊减少噪声
                using var processedImage = image.Clone();
                processedImage.Mutate(x => x.GaussianBlur(0.8f));

                // 计算底部排除区域
                int bottomExclusionStart = (int)(image.Height * (1 - bottomExclusionRatio));

                // 改进的墨迹检测：考虑局部对比度，排除底部区域
                for (int y = 1; y < processedImage.Height - 1; y++)
                {
                    // 跳过底部15%区域（避免底部线条干扰）
                    if (y >= bottomExclusionStart) continue;

                    for (int x = 1; x < processedImage.Width - 1; x++)
                    {
                        var p = processedImage[x, y];
                        byte grayValue = (byte)(0.299 * p.R + 0.587 * p.G + 0.114 * p.B);

                        // 检查是否为真正的暗像素（不是噪声）
                        if (grayValue < darkThreshold)
                        {
                            // 检查周围像素的对比度（避免孤立噪声点）
                            int darkNeighbors = 0;
                            for (int dy = -1; dy <= 1; dy++)
                            {
                                for (int dx = -1; dx <= 1; dx++)
                                {
                                    if (dx == 0 && dy == 0) continue;
                                    var neighbor = processedImage[x + dx, y + dy];
                                    byte neighborGray = (byte)(0.299 * neighbor.R + 0.587 * neighbor.G + 0.114 * neighbor.B);
                                    if (neighborGray < darkThreshold + 30) // 稍微宽松的邻居阈值
                                        darkNeighbors++;
                                }
                            }

                            // 至少有2个暗邻居才认为是有效墨迹
                            if (darkNeighbors >= 2)
                            {
                                inkPixels.Add((x, y));
                            }
                        }
                    }
                }

                // 基础条件检查（更严格）
                if (inkPixels.Count < minInkPixels ||
                    (float)inkPixels.Count / totalPixels < minInkRatio)
                {
                    return false;
                }

                // 分析墨迹分布特征（排除底部区域后）
                var rowDensity = new int[processedImage.Height];
                var colDensity = new int[processedImage.Width];

                foreach (var (x, y) in inkPixels)
                {
                    rowDensity[y]++;
                    colDensity[x]++;
                }

                // 检查墨迹是否主要集中在底部（如果是，可能是线条）
                int topHalfPixels = 0;
                int bottomHalfPixels = 0;
                int middleY = processedImage.Height / 2;

                foreach (var (x, y) in inkPixels)
                {
                    if (y < middleY) topHalfPixels++;
                    else bottomHalfPixels++;
                }

                // 如果底部像素占比过高（>80%），可能是底部线条
                if (bottomHalfPixels > 0 && (float)bottomHalfPixels / (topHalfPixels + bottomHalfPixels) > 0.8f)
                {
                    return false;
                }

                // 检查是否为规则的文字行（排除印刷文字）
                var nonEmptyRows = rowDensity.Where(c => c > 0).ToArray();
                if (nonEmptyRows.Length > 0)
                {
                    // 计算行的密度变化（签名通常密度变化大，文字行变化小）
                    float densityVariation = (float)nonEmptyRows.Max() / Math.Max(nonEmptyRows.Min(), 1);
                    if (densityVariation < 3.0f && nonEmptyRows.Length >= 3)
                    {
                        // 密度变化小且有多行 → 可能是文字
                        return false;
                    }
                }

                // 连通域分析（更严格的条件）
                var visited = new HashSet<(int, int)>();
                bool hasValidSignature = false;
                int validComponents = 0;

                foreach (var pixel in inkPixels)
                {
                    if (visited.Contains(pixel)) continue;

                    // 8邻域BFS
                    var component = new List<(int, int)>();
                    var queue = new Queue<(int, int)>();
                    queue.Enqueue(pixel);
                    visited.Add(pixel);

                    while (queue.Count > 0)
                    {
                        var (x, y) = queue.Dequeue();
                        component.Add((x, y));

                        foreach (var nb in new[] {
                            (x+1, y), (x-1, y), (x, y+1), (x, y-1),
                            (x+1, y+1), (x+1, y-1), (x-1, y+1), (x-1, y-1)
                        })
                        {
                            if (nb.Item1 >= 0 && nb.Item1 < processedImage.Width &&
                                nb.Item2 >= 0 && nb.Item2 < processedImage.Height &&
                                inkPixels.Contains(nb) && !visited.Contains(nb))
                            {
                                visited.Add(nb);
                                queue.Enqueue(nb);
                            }
                        }
                    }

                    if (component.Count < 20) continue; // 提高最小组件大小

                    // 计算形状特征
                    int minX = component.Min(p => p.Item1);
                    int maxX = component.Max(p => p.Item1);
                    int minY = component.Min(p => p.Item2);
                    int maxY = component.Max(p => p.Item2);
                    int width = maxX - minX + 1;
                    int height = maxY - minY + 1;

                    // 排除细长线（更严格）
                    if ((height <= maxLineWidth && width > height * 5) ||
                        (width <= maxLineWidth && height > width * 5))
                        continue;

                    // 检查组件是否在底部区域（如果是，可能是线条）
                    if (minY >= bottomExclusionStart)
                    {
                        continue; // 跳过底部区域的组件
                    }

                    // 计算紧凑度和复杂度
                    float compactness = (float)component.Count / (width * height);
                    float aspectRatio = (float)width / Math.Max(height, 1);

                    // 签名特征：
                    // - 紧凑度适中（0.1-0.6）
                    // - 宽高比适中（0.5-3.0）
                    // - 不是完美的圆形或方形
                    if (compactness > 0.08f && compactness < 0.7f &&
                        aspectRatio > 0.4f && aspectRatio < 4.0f)
                    {
                        validComponents++;
                        if (validComponents >= 1) // 至少有一个有效组件
                        {
                            hasValidSignature = true;
                            break;
                        }
                    }
                }

                // 添加调试输出
                Console.WriteLine($"图片尺寸: {image.Width}x{image.Height}");
                Console.WriteLine($"墨迹像素数: {inkPixels.Count}");
                Console.WriteLine($"墨迹占比: {(float)inkPixels.Count / totalPixels:P2}");
                Console.WriteLine($"有效组件数: {validComponents}");

                return hasValidSignature;
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// 精准签名检测 - 专门针对裁剪图片优化，排除底部线条和印刷文字
        /// </summary>
        public static bool HasHandwrittenSignaturePrecise(string imageFilePath)
        {
            using Stream imageStream = ReadLocalFileToStream(imageFilePath);
            const float minInkRatio = 0.003f;    // 提高墨迹占比要求
            const int minInkPixels = 25;         // 提高最小像素数
            const byte darkThreshold = 180;      // 更严格的阈值
            const int maxLineWidth = 2;          // 更严格的线宽检测
            const float bottomExclusionRatio = 0.15f; // 排除底部15%区域

            try
            {
                using var image = SixLabors.ImageSharp.Image.Load<Rgba32>(imageStream);
                if (image.Width <= 10 || image.Height <= 10) return false;

                int totalPixels = image.Width * image.Height;
                var inkPixels = new List<(int X, int Y)>();

                // 预处理：先进行高斯模糊减少噪声
                using var processedImage = image.Clone();
                processedImage.Mutate(x => x.GaussianBlur(0.8f));

                // 计算底部排除区域
                int bottomExclusionStart = (int)(image.Height * (1 - bottomExclusionRatio));

                // 改进的墨迹检测：考虑局部对比度，排除底部区域
                for (int y = 1; y < processedImage.Height - 1; y++)
                {
                    // 跳过底部15%区域（避免底部线条干扰）
                    if (y >= bottomExclusionStart) continue;

                    for (int x = 1; x < processedImage.Width - 1; x++)
                    {
                        var p = processedImage[x, y];
                        byte grayValue = (byte)(0.299 * p.R + 0.587 * p.G + 0.114 * p.B);

                        // 检查是否为真正的暗像素（不是噪声）
                        if (grayValue < darkThreshold)
                        {
                            // 检查周围像素的对比度（避免孤立噪声点）
                            int darkNeighbors = 0;
                            for (int dy = -1; dy <= 1; dy++)
                            {
                                for (int dx = -1; dx <= 1; dx++)
                                {
                                    if (dx == 0 && dy == 0) continue;
                                    var neighbor = processedImage[x + dx, y + dy];
                                    byte neighborGray = (byte)(0.299 * neighbor.R + 0.587 * neighbor.G + 0.114 * neighbor.B);
                                    if (neighborGray < darkThreshold + 30) // 稍微宽松的邻居阈值
                                        darkNeighbors++;
                                }
                            }

                            // 至少有2个暗邻居才认为是有效墨迹
                            if (darkNeighbors >= 2)
                            {
                                inkPixels.Add((x, y));
                            }
                        }
                    }
                }

                // 基础条件检查（更严格）
                if (inkPixels.Count < minInkPixels ||
                    (float)inkPixels.Count / totalPixels < minInkRatio)
                {
                    return false;
                }

                // 分析墨迹分布特征（排除底部区域后）
                var rowDensity = new int[processedImage.Height];
                var colDensity = new int[processedImage.Width];

                foreach (var (x, y) in inkPixels)
                {
                    rowDensity[y]++;
                    colDensity[x]++;
                }

                // 检查墨迹是否主要集中在底部（如果是，可能是线条）
                int topHalfPixels = 0;
                int bottomHalfPixels = 0;
                int middleY = processedImage.Height / 2;

                foreach (var (x, y) in inkPixels)
                {
                    if (y < middleY) topHalfPixels++;
                    else bottomHalfPixels++;
                }

                // 如果底部像素占比过高（>80%），可能是底部线条
                if (bottomHalfPixels > 0 && (float)bottomHalfPixels / (topHalfPixels + bottomHalfPixels) > 0.8f)
                {
                    return false;
                }

                // 印刷文字检测：检查墨迹分布是否过于规则
                if (IsPrintedText(inkPixels, processedImage.Width, processedImage.Height))
                {
                    return false;
                }

                // 连通域分析（更严格的条件）
                var visited = new HashSet<(int, int)>();
                bool hasValidSignature = false;
                int validComponents = 0;

                foreach (var pixel in inkPixels)
                {
                    if (visited.Contains(pixel)) continue;

                    // 8邻域BFS
                    var component = new List<(int, int)>();
                    var queue = new Queue<(int, int)>();
                    queue.Enqueue(pixel);
                    visited.Add(pixel);

                    while (queue.Count > 0)
                    {
                        var (x, y) = queue.Dequeue();
                        component.Add((x, y));

                        foreach (var nb in new[] {
                            (x+1, y), (x-1, y), (x, y+1), (x, y-1),
                            (x+1, y+1), (x+1, y-1), (x-1, y+1), (x-1, y-1)
                        })
                        {
                            if (nb.Item1 >= 0 && nb.Item1 < processedImage.Width &&
                                nb.Item2 >= 0 && nb.Item2 < processedImage.Height &&
                                inkPixels.Contains(nb) && !visited.Contains(nb))
                            {
                                visited.Add(nb);
                                queue.Enqueue(nb);
                            }
                        }
                    }

                    if (component.Count < 20) continue; // 提高最小组件大小

                    // 计算形状特征
                    int minX = component.Min(p => p.Item1);
                    int maxX = component.Max(p => p.Item1);
                    int minY = component.Min(p => p.Item2);
                    int maxY = component.Max(p => p.Item2);
                    int width = maxX - minX + 1;
                    int height = maxY - minY + 1;

                    // 排除细长线（更严格）
                    if ((height <= maxLineWidth && width > height * 5) ||
                        (width <= maxLineWidth && height > width * 5))
                        continue;

                    // 检查组件是否在底部区域（如果是，可能是线条）
                    if (minY >= bottomExclusionStart)
                    {
                        continue; // 跳过底部区域的组件
                    }

                    // 计算紧凑度和复杂度
                    float compactness = (float)component.Count / (width * height);
                    float aspectRatio = (float)width / Math.Max(height, 1);

                    // 签名特征：
                    // - 紧凑度适中（0.1-0.6）
                    // - 宽高比适中（0.5-3.0）
                    // - 不是完美的圆形或方形
                    if (compactness > 0.08f && compactness < 0.7f &&
                        aspectRatio > 0.4f && aspectRatio < 4.0f)
                    {
                        validComponents++;
                        if (validComponents >= 1) // 至少有一个有效组件
                        {
                            hasValidSignature = true;
                            break;
                        }
                    }
                }

                // 添加详细的调试输出
                Console.WriteLine($"图片尺寸: {image.Width}x{image.Height}");
                Console.WriteLine($"有效墨迹像素数: {inkPixels.Count}");
                Console.WriteLine($"墨迹占比: {(float)inkPixels.Count / totalPixels:P2}");
                Console.WriteLine($"印刷文字检测: {IsPrintedText(inkPixels, image.Width, image.Height)}");
                Console.WriteLine($"有效组件数: {validComponents}");

                return hasValidSignature;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 检测是否为印刷文字（规则排列的墨迹）
        /// </summary>
        private static bool IsPrintedText(List<(int X, int Y)> inkPixels, int imageWidth, int imageHeight)
        {
            if (inkPixels.Count < 50) return false; // 文字通常有较多像素

            // 分析行间距和列间距的规律性
            var rows = inkPixels.GroupBy(p => p.Y).OrderBy(g => g.Key).ToList();
            var cols = inkPixels.GroupBy(p => p.X).OrderBy(g => g.Key).ToList();

            // 检查是否有明显的行结构
            if (rows.Count >= 3)
            {
                // 计算行间距的规律性
                var rowSpacings = new List<int>();
                for (int i = 1; i < rows.Count; i++)
                {
                    rowSpacings.Add(rows[i].Key - rows[i - 1].Key);
                }

                // 如果行间距相对均匀（变异系数小），可能是文字
                if (rowSpacings.Count >= 2)
                {
                    double avgSpacing = rowSpacings.Average();
                    double stdDev = Math.Sqrt(rowSpacings.Select(s => Math.Pow(s - avgSpacing, 2)).Average());
                    double cv = stdDev / avgSpacing; // 变异系数

                    if (cv < 0.3) // 行间距变异系数小于30%，说明很规则
                    {
                        return true;
                    }
                }
            }

            // 检查是否有明显的列结构（字符间距）
            if (cols.Count >= 10)
            {
                // 计算列间距的规律性
                var colSpacings = new List<int>();
                for (int i = 1; i < cols.Count; i++)
                {
                    colSpacings.Add(cols[i].Key - cols[i - 1].Key);
                }

                // 如果列间距相对均匀，可能是文字
                if (colSpacings.Count >= 5)
                {
                    double avgSpacing = colSpacings.Average();
                    double stdDev = Math.Sqrt(colSpacings.Select(s => Math.Pow(s - avgSpacing, 2)).Average());
                    double cv = stdDev / avgSpacing;

                    if (cv < 0.4) // 列间距变异系数小于40%
                    {
                        return true;
                    }
                }
            }

            // 检查像素分布是否过于分散（文字通常有多个分散的组件）
            var visited = new HashSet<(int, int)>();
            int componentCount = 0;
            int smallComponents = 0;

            foreach (var pixel in inkPixels)
            {
                if (visited.Contains(pixel)) continue;

                // BFS计算组件大小
                var queue = new Queue<(int, int)>();
                queue.Enqueue(pixel);
                visited.Add(pixel);
                int componentSize = 0;

                while (queue.Count > 0)
                {
                    var (x, y) = queue.Dequeue();
                    componentSize++;

                    foreach (var nb in new[] { (x + 1, y), (x - 1, y), (x, y + 1), (x, y - 1) })
                    {
                        if (nb.Item1 >= 0 && nb.Item1 < imageWidth &&
                            nb.Item2 >= 0 && nb.Item2 < imageHeight &&
                            inkPixels.Contains(nb) && !visited.Contains(nb))
                        {
                            visited.Add(nb);
                            queue.Enqueue(nb);
                        }
                    }
                }

                componentCount++;
                if (componentSize < 10) smallComponents++;
            }

            // 如果有很多小组件（可能是字符），且组件数量较多，可能是文字
            if (componentCount >= 5 && smallComponents >= componentCount * 0.6)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 精准判定：过滤边缘打印线条，仅识别签名
        /// </summary>
        public static bool HasSignature(string imageFilePath)
        {
            if (!File.Exists(imageFilePath))
                throw new FileNotFoundException("图片不存在", imageFilePath);

            using var image = SixLabors.ImageSharp.Image.Load<Rgba32>(imageFilePath);
            // 预处理：极严格二值化（只保留深色区域）+ 裁剪边缘（去除截图边缘干扰）
            image.Mutate(x => x
                .Grayscale()
                .BinaryThreshold(0.9f) // 阈值0.9：仅保留最深的黑色区域
                .Crop(new SixLabors.ImageSharp.Rectangle(10, 10, image.Width - 20, image.Height - 20)) // 裁剪边缘10像素
            );

            // 计算三个核心指标：不规则复杂度、黑色像素占比、线条连续性
            var metrics = CalculateSignatureMetrics(image);

            // 截取区域
            using var croppedImage = image.Clone();

            // 保存截取图片
            string outputDir = Path.Combine(Path.GetDirectoryName(imageFilePath), "signature_areas");
            Directory.CreateDirectory(outputDir);

            //string outputPath = Path.Combine(outputDir, $"{prefix}_{DateTime.Now:yyyyMMddHHmmss}.jpg");
            string FileName = Path.GetFileNameWithoutExtension(imageFilePath);
            string outputPath = Path.Combine(outputDir, $"{HasSignature}-{FileName}.jpg");
            croppedImage.SaveAsJpegAsync(outputPath);




            // 三重判定（同时满足才判定为签名）
            const int IrregularThreshold = 20;          // 不规则复杂度阈值
            const float BlackRatioThreshold = 0.006f;   // 黑色像素占比阈值（0.8%）
            //const float LineContinuityThreshold = 0.6f; // 线条连续性阈值（打印线条>0.6，签名<0.6）

            bool isIrregular = metrics.IrregularComplexity > IrregularThreshold;
            bool hasEnoughBlack = metrics.BlackPixelRatio > BlackRatioThreshold;
            //bool isDiscontinuous = metrics.LineContinuity < LineContinuityThreshold;
            return isIrregular && hasEnoughBlack;
            //return isIrregular && hasEnoughBlack && isDiscontinuous;
        }

        /// <summary>
        /// 签名指标：不规则复杂度 + 黑色像素占比 + 线条连续性
        /// </summary>
        private class SignatureMetrics
        {
            public int IrregularComplexity { get; set; } // 不规则复杂度
            public float BlackPixelRatio { get; set; }  // 黑色像素占比
            public float LineContinuity { get; set; }   // 线条连续性（打印线条连续，签名零散）
        }

        private static SignatureMetrics CalculateSignatureMetrics(Image<Rgba32> image)
        {
            int totalPixels = image.Width * image.Height;
            int blackPixelCount = 0;
            int irregularComplexity = 0;
            int continuousLineCount = 0;
            int totalLineSegments = 0;

            // 遍历所有像素（跳过边缘）
            for (int y = 2; y < image.Height - 2; y++)
            {
                for (int x = 2; x < image.Width - 2; x++)
                {
                    bool isBlack = image[x, y].R < 128;
                    if (!isBlack) continue;

                    blackPixelCount++;

                    // 1. 计算不规则复杂度（3x3范围内相同像素少=签名）
                    int sameNeighborCount = 0;
                    for (int dy = -1; dy <= 1; dy++)
                        for (int dx = -1; dx <= 1; dx++)
                            if (image[x + dx, y + dy].R < 128 == isBlack)
                                sameNeighborCount++;
                    if (sameNeighborCount < 6)
                        irregularComplexity++;

                    // 2. 计算线条连续性（打印线条连续，签名零散）
                    bool rightIsBlack = image[x + 1, y].R < 128;
                    bool downIsBlack = image[x, y + 1].R < 128;
                    if (rightIsBlack || downIsBlack)
                        continuousLineCount++;
                    totalLineSegments++;
                }
            }

            // 计算指标
            var metrics = new SignatureMetrics
            {
                IrregularComplexity = irregularComplexity,
                BlackPixelRatio = (float)blackPixelCount / totalPixels,
                LineContinuity = totalLineSegments == 0 ? 0 : (float)continuousLineCount / totalLineSegments
            };
            return metrics;
        }

        // 测试方法：输出所有指标，方便调试
        public static void TestSignatureDetection(string testFolderPath)
        {
            if (!Directory.Exists(testFolderPath))
            {
                Console.WriteLine("测试文件夹不存在");
                return;
            }

            foreach (var file in Directory.GetFiles(testFolderPath).Where(f => f.EndsWith(".png") || f.EndsWith(".jpg")))
            {
                try
                {
                    bool hasSig = HasSignature(file);
                    using var img = SixLabors.ImageSharp.Image.Load<Rgba32>(file);
                    //img.Mutate(x => x.Grayscale().BinaryThreshold(0.9f).Crop(new Rectangle(10, 10, img.Width - 20, img.Height - 20)));

                    // 修正后：
                    img.Mutate(x => x
                        .Grayscale()
                        .BinaryThreshold(0.9f)
                        // 明确使用ImageSharp的Rectangle类型
                        .Crop(new SixLabors.ImageSharp.Rectangle(10, 10, img.Width - 20, img.Height - 20))
                    );
                    var metrics = CalculateSignatureMetrics(img);

                    Console.WriteLine($"【{Path.GetFileName(file)}】");
                    Console.WriteLine($"  不规则复杂度：{metrics.IrregularComplexity}");
                    Console.WriteLine($"  黑色像素占比：{metrics.BlackPixelRatio:P2}");
                    Console.WriteLine($"  线条连续性：{metrics.LineContinuity:P2}");
                    Console.WriteLine($"  结果：{(hasSig ? "有签名" : "无签名")}");
                    Console.WriteLine("------------------------");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"处理{Path.GetFileName(file)}失败：{ex.Message}");
                }
            }
        }
        #endregion

        #region DownLoad
        public static void DownLoad()
        {
            Console.WriteLine("开始执行下载任务");

            int startId = 32044;
            string baseUrl = "https://103.155.102.84/download?ID=";
            string saveDirectory = @"D:\DownloadFiles"; // 指定保存目录，可自行修改

            // 忽略SSL证书验证（如果目标站点是自签名证书）
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;



            for (int i = 0; i < 30; i++)
            {
                int currentId = startId + i;
                string downloadUrl = baseUrl + currentId;

                // 创建保存目录（如果不存在）
                if (!Directory.Exists(saveDirectory))
                {
                    Directory.CreateDirectory(saveDirectory);
                    Console.WriteLine($"创建保存目录: {saveDirectory}");
                }

                try
                {

                    // 打开HTML文件
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = downloadUrl,
                        UseShellExecute = true
                    });

                    // // 第一步：获取文件原始名称
                    // string originalFileName = GetOriginalFileName(downloadUrl);
                    // if (string.IsNullOrEmpty(originalFileName))
                    // {
                    //     // 如果获取不到原始名称，使用备用命名
                    //     originalFileName = $"file_{currentId}.dat";
                    //     Console.WriteLine($"未获取到原始文件名，使用备用名称: {originalFileName}");
                    // }

                    //// 拼接完整保存路径（处理重复文件名）
                    // string savePath = GetUniqueFilePath(saveDirectory, originalFileName);

                    //Console.WriteLine($"正在下载: {downloadUrl}");
                    //Console.WriteLine($"保存路径: {savePath}");

                    //// 创建WebClient对象进行下载
                    //using (WebClient client = new WebClient())
                    //{
                    //    // 执行下载并保存到指定路径
                    //    client.DownloadFile(downloadUrl, savePath);

                    //      Console.WriteLine($"下载完成: {Path.GetFileName(savePath)}");
                    //}
                }
                catch (Exception ex)
                {
                    // 捕获异常，避免单个文件下载失败导致整个循环终止
                    Console.WriteLine($"下载失败 {currentId}: {ex.Message}");
                }

                // 可选：添加短暂延迟，避免请求过快被服务器限制
                System.Threading.Thread.Sleep(1000);
            }

            Console.WriteLine("所有下载任务执行完毕！");
        }

        /// <summary>
        /// 从下载链接获取文件的原始名称
        /// </summary>
        /// <param name="url">下载链接</param>
        /// <returns>文件原始名称</returns>
        private static string GetOriginalFileName(string url)
        {
            try
            {
                // 创建请求但不下载整个文件，只获取响应头
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "HEAD"; // 只请求头信息，不请求文件内容
                request.Timeout = 5000;  // 超时时间5秒

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    // 从响应头中获取Content-Disposition
                    string disposition = response.Headers["Content-Disposition"];
                    if (!string.IsNullOrEmpty(disposition))
                    {
                        // 正则匹配文件名（兼容不同格式的Content-Disposition）
                        Match match = Regex.Match(disposition, @"filename=""?([^;]+)""?", RegexOptions.IgnoreCase);
                        if (match.Success)
                        {
                            string fileName = match.Groups[1].Value.Trim();
                            // 处理中文乱码（如果有）
                            fileName = System.Web.HttpUtility.UrlDecode(fileName);
                            return fileName;
                        }
                    }

                    // 如果没有Content-Disposition，尝试从URL解析（备用方案）
                    return Path.GetFileName(url);
                }
            }
            catch
            {
                // 获取文件名失败时返回空
                return null;
            }
        }

        /// <summary>
        /// 获取唯一的文件路径（避免同名文件覆盖）
        /// </summary>
        /// <param name="directory">保存目录</param>
        /// <param name="fileName">文件名</param>
        /// <returns>唯一路径</returns>
        private static string GetUniqueFilePath(string directory, string fileName)
        {
            string filePath = Path.Combine(directory, fileName);
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(fileName);
            string extension = Path.GetExtension(fileName);

            // 如果文件已存在，添加数字后缀（如：test.jpg → test(1).jpg）
            //int counter = 1;
            //while (File.Exists(filePath))
            //{
            //    filePath = Path.Combine(directory, $"{fileNameWithoutExt}({counter}){extension}");
            //    counter++; // 单独一行执行自增操作
            //}

            return filePath;
        }


        //通过读取本地文件Url跳转浏览器下载
        public static async Task DownLoadByFileByChrome()
        {
            int DoenbLoadNum = 20;
            string filePath = @"C:\Users\liusi\Desktop\PRD-Report\image.txt";
            int counter = 0;


            // 逐行读取文件
            foreach (var line in File.ReadLines(filePath))
            {
                counter++;
                if (counter == DoenbLoadNum + 1)
                {
                    return;
                }

                // 去除首尾空白字符
                var id = line.Trim();
                // 跳过空行
                if (string.IsNullOrWhiteSpace(id)) continue;

                string url = $"https://103.155.102.93/Download?id={id}";

                // 打开HTML文件
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });

            }
            Console.WriteLine("🎉 全部下载任务处理完毕！");
        }


        //通过读取本地文件Url下载
        public static async Task DownLoadByFileByApi()
        {
            int downloadLimit = 200;
            //string filePath = @"C:\Users\liusi\Desktop\PRD-Report\DownLoadImage\CUHKMC-REPRT-038\CUHKMC-REPRT-038.txt";
            //string saveFolder = @"C:\Users\liusi\Desktop\PRD-Report\DownLoadImage\CUHKMC-REPRT-038";

            string filePath = @"C:\Users\liusi\Desktop\PRD-Report\NEW\XRC-REPRT-026--OPH-REPRT-OO2\image.txt";
            string saveFolder = @"C:\Users\liusi\Desktop\PRD-Report\NEW\XRC-REPRT-026--OPH-REPRT-OO2";

            // 确保保存目录存在
            Directory.CreateDirectory(saveFolder);
            // 重点：限制同时下载数量（关键！防止连接爆炸）
            int maxParallelDownloads = 6;
            var semaphore = new SemaphoreSlim(maxParallelDownloads);
            // 创建带证书忽略的HttpClient
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            using HttpClient safeClient = new HttpClient(handler);
            // 添加 apikey Header
            safeClient.DefaultRequestHeaders.Add("apikey", "a30c6b7db243953f5656dd4adcada51b13782d646b842088bd5d9b288796867f");
            int counter = 0;
            var tasks = new List<Task>();
            // 逐行读取文件
            foreach (var line in File.ReadLines(filePath))
            {
                counter++;
                if (counter > downloadLimit)
                {
                    break;
                }

                // 去除首尾空白字符
                var id = line.Trim();
                // 跳过空行
                if (string.IsNullOrWhiteSpace(id))
                {
                    counter--;
                    continue;
                }
                string url = $"https://103.155.102.93/Download?id={id}";


                // 优化：先检查本地是否存在包含该ID的文件，避免不必要的API请求
                //string[] existingFiles = Directory.GetFiles(saveFolder, $"*{id}*", SearchOption.TopDirectoryOnly);
                string[] existingFiles = Directory.GetFiles(saveFolder, $"[{id}]*", SearchOption.TopDirectoryOnly);
                if (existingFiles.Length > 0)
                {
                    Console.WriteLine($"[{counter}] ⏭️ 本地已存在包含ID [{id}] 的文件：{existingFiles[0]}");
                    counter--;
                    continue;
                }


                // 获取文件名
                string realFileName = $"{id}.unknown";
                try
                {
                    using var headResp = await safeClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
                    //using var headResp = await safeClient.SendAsync(new HttpRequestMessage(HttpMethod.Head, url));
                    if (headResp.IsSuccessStatusCode)
                    {
                        realFileName = $"[{id}]" + GetFileNameFromHeader(headResp) ?? realFileName;
                    }
                    else
                    {
                        Console.WriteLine($"{id}异常，跳过");

                        // 将失败的ID写入日志文件，便于下次重试
                        string failedLogPath = $@"{saveFolder}\GetNamefailed_downloads.txt";
                        File.AppendAllText(failedLogPath, $"{id}\n");
                        Console.WriteLine($"[{counter}] 📝 获取用户名错误,已记录失败ID到 {failedLogPath}");
                        continue;
                    }
                }
                catch { }

                string savePath = GetUniqueFilePath(saveFolder, realFileName);
                //Console.WriteLine($"[{counter}] 文件名：{realFileName}  URL:{url}");

                // 核心：检测文件已存在 → 直接跳过
                if (File.Exists(savePath))
                {
                    Console.WriteLine($"[{counter}] ⏭️ 已存在，跳过：{realFileName}");
                    counter--;
                    continue;
                }

                // 排队，控制并发
                await semaphore.WaitAsync();
                // 捕获当前循环变量，避免闭包问题
                int currentCounter = counter;
                string currentId = id;
                string currentUrl = url;
                string currentSavePath = savePath;
                string currentFileName = realFileName;
                tasks.Add(Task.Run(async () =>
                {
                    try
                    {
                        #region 可用有效下载代码
                        //Console.WriteLine($"[{currentCounter}] 📥 下载中：{currentFileName}");
                        //using var stream = await safeClient.GetStreamAsync(currentUrl);
                        //using var fs = new FileStream(currentSavePath, FileMode.Create, FileAccess.Write);
                        //await stream.CopyToAsync(fs);
                        //Console.WriteLine($"[{currentCounter}] ✅ 下载完成：{currentFileName}");
                        #endregion

                        #region 可用有效下载代码++添加文件完整性检测
                        Console.WriteLine($"[{currentCounter}] 📥 下载中：{currentFileName}");

                        // 使用 GetAsync 获取响应，先检查状态码
                        using var response = await safeClient.GetAsync(currentUrl, HttpCompletionOption.ResponseHeadersRead);
                        response.EnsureSuccessStatusCode();

                        // 获取期望文件大小
                        long? expectedSize = response.Content.Headers.ContentLength;

                        // 开始下载
                        using var stream = await response.Content.ReadAsStreamAsync();
                        using var fs = new FileStream(currentSavePath, FileMode.Create, FileAccess.Write);
                        await stream.CopyToAsync(fs);

                        // 验证文件完整性，不完整直接抛出错误
                        long actualSize = fs.Length;
                        if (expectedSize.HasValue && actualSize != expectedSize.Value)
                        {
                            throw new IOException($"文件下载不完整：期望 {expectedSize.Value} 字节，实际 {actualSize} 字节");
                        }

                        Console.WriteLine($"[{currentCounter}] ✅ 下载完成：{currentFileName} ({actualSize} 字节)");
                        #endregion
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[{currentCounter}] ❌ 下载失败 {currentFileName}：{ex.Message}");
                        if (File.Exists(currentSavePath))
                        {
                            File.Delete(currentSavePath);
                        }

                        // 将失败的ID写入日志文件，便于下次重试
                        string failedLogPath = $@"{saveFolder}\failed_downloads.txt";
                        File.AppendAllText(failedLogPath, $"{currentId}\n");
                        Console.WriteLine($"[{currentCounter}] 📝 已记录失败ID到 {failedLogPath}");
                    }
                    finally
                    {
                        semaphore.Release();
                    }
                }));
            }
            // 等待所有下载完成
            await Task.WhenAll(tasks);
            Console.WriteLine("🎉 全部下载任务处理完毕！");
        }

        /// <summary>
        /// 从Content-Disposition头解析真实文件名
        /// </summary>
        private static string GetFileNameFromHeader(HttpResponseMessage response)
        {
            if (!response.Content.Headers.TryGetValues("Content-Disposition", out var values))
                return null;

            foreach (var val in values)
            {
                // 匹配格式：attachment; filename="xxx.jpg"
                var match = System.Text.RegularExpressions.Regex.Match(val, @"filename\s*=\s*""?([^"";]+)""?");
                if (match.Success)
                {
                    return match.Groups[1].Value.Trim();
                }
            }
            return null;
        }

        #endregion

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

        #region 清理拆分Form的数据
        public static void FormCsvCleaner()
        {
            string input = @"C:\\Users\\liusi\\Desktop\\FormList\\FullList.csv";
            string output = @"C:\\Users\\liusi\\Desktop\\FormList\\cleaned_forms.csv";       // 输出文件

            var lines = File.ReadAllLines(input, Encoding.UTF8);
            var result = new List<string>();
            result.Add("Form No.,Types of form"); // 表头

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                // 简单按 Tab 或 逗号 分割（你给的格式是制表符分隔）
                var parts = line.Split(new[] { '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length < 2) continue;

                string formNo = parts[0].Trim();
                string content = parts[1].Trim();

                string cleanText = CleanByLanguageTag(content);
                result.Add($"{formNo},\"{cleanText}\"");
            }

            File.WriteAllLines(output, result, new UTF8Encoding(false));
            Console.WriteLine("完成！");
        }

        /// <summary>
        /// 核心：根据 (English)/(Chinese) 只保留对应语言
        /// </summary>
        static string CleanByLanguageTag(string text)
        {
            bool isEnglish = text.Contains("(English)");
            bool isChinese = text.Contains("(Chinese)");

            // 先移除语言标签
            text = Regex.Replace(text, @"\s*\((English|Chinese)\)", "").Trim();

            if (isEnglish)
            {
                // 只保留英文、数字、符号，删除所有中文
                return Regex.Replace(text, @"[\u4e00-\u9fa5]+", "").Trim();
            }
            else if (isChinese)
            {
                // 只保留中文，删除所有英文、数字、符号
                return Regex.Replace(text, @"[a-zA-Z0-9\s\p{P}]", "").Trim();
            }

            return text;
        }
        #endregion

        #region IAM Smart 签名 esign 

        public class CreateResult
        {
            public string TargetObject { get; set; }
            public bool IsSuccess { get; set; }
            public string Message { get; set; }
            public Errorcode ErrorCode { get; set; }
        }

        public class Errorcode
        {
            public string Code { get; set; }
            public string Message { get; set; }
        }



        public class CallbackResult
        {
            public string targetObject { get; set; }
            public bool isSuccess { get; set; }
            public string message { get; set; }
        }


        public static async Task esignAsync()
        {
            try
            {
                Console.WriteLine("开始执行 IAM Smart 签名任务");

                // 文件路径
                string path = "C:\\Users\\liusi\\Desktop\\esign\\Barry 签名测试文档.pdf";

                //文件路径判断
                if (string.IsNullOrEmpty(path))
                {
                    Console.WriteLine("错误：文件路径不能为空");
                    return;
                }


                if (!File.Exists(path))
                {
                    Console.WriteLine($"错误：文件不存在 - {path}");
                    return;
                }

                //文件格式验证
                string[] allowedExtensions = { ".pdf" };
                string fileExtension = Path.GetExtension(path).ToLower();

                if (!allowedExtensions.Contains(fileExtension))
                {
                    Console.WriteLine($"错误：不支持的文件格式 - {fileExtension}");
                    Console.WriteLine($"支持的格式：{string.Join(", ", allowedExtensions)}");
                    return;
                }


                // 文件大小验证（最大100MB）
                FileInfo fileInfo = new FileInfo(path);
                long maxFileSize = 100 * 1024 * 1024; // 100MB

                if (fileInfo.Length > maxFileSize)
                {
                    Console.WriteLine($"错误：文件大小超过限制 - {fileInfo.Length / 1024 / 1024}MB (最大100MB)");
                    return;
                }

                Console.WriteLine($"文件验证通过：{Path.GetFileName(path)}");
                Console.WriteLine($"文件大小：{fileInfo.Length / 1024}KB");

                //计算文件哈希
                string documentHash = CalculateFileHash(path);
                Console.WriteLine($"文件哈希：{documentHash}");

                string bid = Guid.NewGuid().ToString("N");
                string documentname = Path.GetFileName(path);
                //准备API请求数据
                var requestData = new
                {
                    Bid = bid,
                    DocumentName = documentname,
                    DocumentHash = documentHash,
                    Timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                    Callbackurl = "",
                    RedirectURI = @$"https://www.baidu.com?bid={bid}"
                };

                Console.WriteLine($"Bid: {requestData.Bid}");
                Console.WriteLine($"时间戳: {requestData.Timestamp}");

                //调用API
                string Request = await CallApi("https://sign.nextore.io/api/ds/open-sign/create", requestData);

                if (string.IsNullOrEmpty(Request))
                {
                    Console.WriteLine("API返回错误,停止执行");
                    return;
                }

                CreateResult createResult = JsonSerializer.Deserialize<CreateResult>(Request);
                if (createResult == null || createResult.IsSuccess == false)
                {
                    Console.WriteLine("API返回错误,停止执行");
                    return;
                }

                //等待20秒，让用户去执行扫码签名认证。
                Console.WriteLine("等待IAM Smart扫码签名认证");
                await Task.Delay(10000);

                var CallbackRequestData = new
                {
                    BusinessID = bid,
                    CallbackType = "SignPDF"
                };

                bool Callback = true;
                int num = 0;
                while (Callback)
                {
                    num++;
                    Console.WriteLine("开始检查IAM SmartAPI");
                    Request = await CallApi("https://sign.nextore.io/PollingCallbackResult", CallbackRequestData);

                    if (string.IsNullOrEmpty(Request))
                    {
                        Console.WriteLine("API返回错误,停止执行");
                        break;
                    }

                    CallbackResult callbackResult = JsonSerializer.Deserialize<CallbackResult>(Request);
                    if (callbackResult == null || callbackResult.isSuccess == false)
                    {
                        if (num == 10)
                        {
                            Callback = false;
                            Console.WriteLine($"检查IAM Smart 已经达到{num}次，停止检查。");
                            return;
                        }

                        await Task.Delay(5000);
                        continue;
                    }

                    if (callbackResult != null && callbackResult.isSuccess == true)
                    {
                        // Console.WriteLine("返回OK，执行完毕");
                        //此处可以执行签署PDF,然后下载文件。
                        Console.WriteLine("签名验证成功，开始处理PDF文件...");

                        try
                        {
                            //bool res=SignLocalPdf(path, callbackResult.targetObject, $"C:\\Users\\liusi\\Desktop\\esign\\signed_{DateTime.Now.ToString("yyyyMMddHHmmssfffffff")}.pdf");
                            // if (res)
                            // {
                            //     Console.WriteLine("生成成功");
                            // }
                            // else
                            // {
                            //     Console.WriteLine("生成失败");
                            // }
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine($"处理PDF签名时发生错误：{ex.Message}");
                        }

                        Callback = false;
                        break;
                    }
                }

                // 这里可以调用你的 IAM Smart 签名逻辑
                // 例如：读取文件、计算哈希、调用 API 创建签名任务、等待返回、重新签名文件、下载文件等
                Console.WriteLine("IAM Smart 签名任务执行完毕");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"执行 IAM Smart 签名任务时发生错误: {ex.Message}");

                if (ex.InnerException != null)
                {
                    Console.WriteLine($"内部错误：{ex.InnerException.Message}");
                }
            }
        }

        /// <summary>
        /// 计算文件SHA256哈希值
        /// </summary>
        private static string CalculateFileHash(string filePath)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            using (var fileStream = File.OpenRead(filePath))
            {
                byte[] hashBytes = sha256.ComputeHash(fileStream);
                return Convert.ToBase64String(hashBytes);
            }
        }

        /// <summary>
        /// 调用API
        /// </summary>
        private static async Task<string> CallApi(string apiUrl, object requestData)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.Timeout = TimeSpan.FromSeconds(30);

                // 设置请求头
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36");

                try
                {
                    // 序列化请求数据
                    string jsonData = JsonSerializer.Serialize(requestData, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        WriteIndented = true
                    });

                    Console.WriteLine($"请求数据：{jsonData}");

                    // 发送POST请求
                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync(apiUrl, content);

                    // 检查响应状态
                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"API调用成功！响应：{responseContent}");
                        return responseContent;
                        // 可以在这里解析响应并处理后续逻辑
                        // 例如：等待签名完成、下载签名后的文件等
                    }
                    else
                    {
                        string errorContent = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"API调用失败！状态码：{response.StatusCode}");
                        Console.WriteLine($"错误响应：{errorContent}");
                    }
                }
                catch (HttpRequestException httpEx)
                {
                    Console.WriteLine($"HTTP请求错误：{httpEx.Message}");
                }
                catch (TaskCanceledException timeoutEx)
                {
                    Console.WriteLine("请求超时，请检查网络连接或稍后重试");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"API调用发生错误：{ex.Message}");
                }
                return string.Empty;
            }
        }

        /// <summary>
        /// 载入本地PDF并完成签名
        /// </summary>
        /// <param name="localPdfPath">本地PDF文件路径（如：D:/test.pdf）</param>
        /// <param name="signatureBase64">接口返回的targetObject（Base64签名）</param>
        /// <param name="outputPdfPath">签名后保存的路径（如：D:/signed_test.pdf）</param>
        /// <returns>是否签名成功</returns>
        public static bool SignLocalPdf(string localPdfPath, long Timestamp, string signatureBase64, string outputPdfPath)
        {
            // 验证本地文件是否存在
            if (!File.Exists(localPdfPath))
            {
                Console.WriteLine("本地PDF文件不存在：" + localPdfPath);
                return false;
            }

            // 创建输出目录（如果不存在）
            string outputFolder = Path.GetDirectoryName(outputPdfPath);
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }
            // 读取本地PDF文件为Stream（核心：载入插件的关键）
            using (FileStream pdfFileStream = new FileStream(localPdfPath, FileMode.Open, FileAccess.Read))
            {
                // 转换签名为字节数组
                byte[] signatureBytes = Convert.FromBase64String(signatureBase64);

                // 初始化PDF签名器（载入PDF流）
                using (var signer = new PdfDocumentSigner(pdfFileStream, null, leaveOpen: true))
                {
                    // 配置签名基础信息（和你原有逻辑一致）
                    var digestCalculator = new DigestCalculator(HashAlgorithmType.SHA256);
                    var signerInfo = new ExternalSignerInfo(PdfSignatureType.Pkcs7, 12000, digestCalculator);

                    // 配置签名位置（示例：第1页，坐标X=100, Y=100，宽200，高100）
                    var fieldInfo = new PdfSignatureFieldInfo(new List<int> { 1 })
                    {
                        // SignatureBounds = new PdfRectangle(100, 100, 300, 200), // X1,Y1,X2,Y2
                        SignatureBounds = new DevExpress.Pdf.PdfRectangle(100, 100, 300, 200),
                        //SignatureBounds = new PdfRectangle(50, 650, 250, 750), // 左上角：X1=50, Y1=650, X2=250, Y2=750
                        Name = "Signature_Field"
                    };

                    // 构建延迟签名器（DevExpress核心对象）
                    var builder = new PdfDeferredSignatureBuilder(signerInfo, fieldInfo);
                    //builder.SigningTime = DateTimeOffset.Now;
                    builder.SigningTime = DateTimeOffset.FromUnixTimeSeconds(Timestamp);
                    builder.Location = "Hong Kong";
                    builder.Name = "签名人";
                    builder.Reason = "PDF数字签名";


                    byte[] signatureImageBytes = null;

                    string signatureImagePath = "C:\\Users\\liusi\\Desktop\\esign\\mySignature.png";


                    if (!string.IsNullOrEmpty(signatureImagePath) && File.Exists(signatureImagePath))
                    {
                        signatureImageBytes = File.ReadAllBytes(signatureImagePath);
                    }

                    //byte[] signatureImageBytes = System.Convert.FromBase64String(imageContent);


                    if (signatureImageBytes != null)
                    {
                        builder.SetImageData(signatureImageBytes);
                    }

                    // 载入签名器并计算摘要
                    PdfDeferredSigner deferredSigner = signer.SignDeferred(builder);

                    var documentHash = Convert.ToBase64String(deferredSigner.HashValue);

                    Console.WriteLine($"SignLocalPdf 计算的Hash：{documentHash}");

                    // 写入签名并保存文件（核心：把接口返回的签名写入PDF）
                    deferredSigner.Sign(outputPdfPath, signatureBytes);

                    Console.WriteLine("签名完成，文件保存至：" + outputPdfPath);
                    return true;
                }
            }
        }



        public static async Task EsignSignLocalPdfAsync()
        {
            try
            {
                Console.WriteLine("开始执行 IAM Smart 签名任务");

                // 文件路径
                string path = "C:\\Users\\liusi\\Desktop\\esign\\Barry 签名测试文档.pdf";

                //文件路径判断
                if (string.IsNullOrEmpty(path))
                {
                    Console.WriteLine("错误：文件路径不能为空");
                    return;
                }


                if (!File.Exists(path))
                {
                    Console.WriteLine($"错误：文件不存在 - {path}");
                    return;
                }

                //文件格式验证
                string[] allowedExtensions = { ".pdf" };
                string fileExtension = Path.GetExtension(path).ToLower();

                if (!allowedExtensions.Contains(fileExtension))
                {
                    Console.WriteLine($"错误：不支持的文件格式 - {fileExtension}");
                    Console.WriteLine($"支持的格式：{string.Join(", ", allowedExtensions)}");
                    return;
                }


                // 文件大小验证（最大100MB）
                FileInfo fileInfo = new FileInfo(path);
                long maxFileSize = 100 * 1024 * 1024; // 100MB

                if (fileInfo.Length > maxFileSize)
                {
                    Console.WriteLine($"错误：文件大小超过限制 - {fileInfo.Length / 1024 / 1024}MB (最大100MB)");
                    return;
                }

                Console.WriteLine($"文件验证通过：{Path.GetFileName(path)}");
                Console.WriteLine($"文件大小：{fileInfo.Length / 1024}KB");

                //定义一个公共时间戳
                long Timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();


                string oldpath = path;
                // 预处理 PDF，保存为临时文件
                string tempPdfPath = Path.Combine(Path.GetDirectoryName(path), "temp_" + Path.GetFileName(path));

                using (FileStream pdfFileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    pdfFileStream.Position = 0; // 每次循环开始时重置文件流位置
                    using var ms = new MemoryStream();
                    pdfFileStream.CopyTo(ms);
                    var buffer = UpgradePDFForSigning(ms.ToArray(), false);
                    //using var Upgradestream = new MemoryStream(buffer);
                    File.WriteAllBytes(tempPdfPath, buffer);
                }

                Console.WriteLine($"预处理完成，临时文件：{tempPdfPath}");

                path = tempPdfPath;

                string targetObject = string.Empty;
                // 读取本地PDF文件为Stream（核心：载入插件的关键）
                using (FileStream pdfFileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    // 初始化PDF签名器（载入PDF流）
                    using (var signer = new PdfDocumentSigner(pdfFileStream, null, leaveOpen: true))
                    {
                        // 配置签名基础信息（和你原有逻辑一致）
                        var digestCalculator = new DigestCalculator(HashAlgorithmType.SHA256);
                        var signerInfo = new ExternalSignerInfo(PdfSignatureType.Pkcs7, 12000, digestCalculator);

                        // 配置签名位置（示例：第1页，坐标X=100, Y=100，宽200，高100）
                        var fieldInfo = new PdfSignatureFieldInfo(new List<int> { 1 })
                        {
                            // SignatureBounds = new PdfRectangle(100, 100, 300, 200), // X1,Y1,X2,Y2
                            SignatureBounds = new DevExpress.Pdf.PdfRectangle(100, 100, 300, 200),
                            //SignatureBounds = new PdfRectangle(50, 650, 250, 750), // 左上角：X1=50, Y1=650, X2=250, Y2=750
                            Name = "Signature_Field"
                        };



                        // 构建延迟签名器（DevExpress核心对象）
                        var builder = new PdfDeferredSignatureBuilder(signerInfo, fieldInfo);
                        //builder.SigningTime = DateTimeOffset.Now;
                        builder.SigningTime = DateTimeOffset.FromUnixTimeSeconds(Timestamp);
                        builder.Location = "Hong Kong";
                        builder.Name = "签名人";
                        builder.Reason = "PDF数字签名";


                        byte[] signatureImageBytes = null;

                        string signatureImagePath = "C:\\Users\\liusi\\Desktop\\esign\\mySignature.png";


                        if (!string.IsNullOrEmpty(signatureImagePath) && File.Exists(signatureImagePath))
                        {
                            signatureImageBytes = File.ReadAllBytes(signatureImagePath);
                        }

                        //byte[] signatureImageBytes = System.Convert.FromBase64String(imageContent);


                        if (signatureImageBytes != null)
                        {
                            builder.SetImageData(signatureImageBytes);
                        }

                        // 载入签名器并计算摘要
                        PdfDeferredSigner deferredSigner = signer.SignDeferred(builder);

                        var documentHash = Convert.ToBase64String(deferredSigner.HashValue);

                        Console.WriteLine($"EsignSignLocalPdfAsync 计算的Hash：{documentHash}");

                        string bid = Guid.NewGuid().ToString("N");
                        string documentname = Path.GetFileName(path);


                        //准备API请求数据
                        var requestData = new
                        {
                            Bid = bid,
                            DocumentName = documentname,
                            DocumentHash = documentHash,
                            Timestamp = Timestamp,
                            Callbackurl = "",
                            RedirectURI = @$"http://xxxx.yyy:8080/CheckeSign?bid={bid}&objid=5159"
                        };

                        Console.WriteLine($"Bid: {requestData.Bid}");
                        Console.WriteLine($"时间戳: {requestData.Timestamp}");

                        //调用API
                        string Request = await CallApi("https://sign.nextore.io/api/ds/open-sign/create", requestData);

                        if (string.IsNullOrEmpty(Request))
                        {
                            Console.WriteLine("API返回错误,停止执行");
                            return;
                        }

                        CreateResult createResult = JsonSerializer.Deserialize<CreateResult>(Request);
                        if (createResult == null || createResult.IsSuccess == false)
                        {
                            Console.WriteLine("API返回错误,停止执行");
                            return;
                        }

                        //等待20秒，让用户去执行扫码签名认证。
                        Console.WriteLine("等待IAM Smart扫码签名认证");
                        await Task.Delay(10000);

                        var CallbackRequestData = new
                        {
                            BusinessID = bid,
                            CallbackType = "SignPDF"
                        };

                        bool Callback = true;
                        int num = 0;
                        while (Callback)
                        {
                            num++;
                            Console.WriteLine("开始检查IAM SmartAPI");
                            Request = await CallApi("https://sign.nextore.io/PollingCallbackResult", CallbackRequestData);

                            if (string.IsNullOrEmpty(Request))
                            {
                                Console.WriteLine("API返回错误,停止执行");
                                break;
                            }

                            CallbackResult callbackResult = JsonSerializer.Deserialize<CallbackResult>(Request);
                            if (callbackResult == null || callbackResult.isSuccess == false)
                            {
                                if (num == 10)
                                {
                                    Callback = false;
                                    Console.WriteLine($"检查IAM Smart 已经达到{num}次，停止检查。");
                                    return;
                                }

                                await Task.Delay(5000);
                                continue;
                            }

                            if (callbackResult != null && callbackResult.isSuccess == true)
                            {
                                // Console.WriteLine("返回OK，执行完毕");
                                //此处可以执行签署PDF,然后下载文件。
                                Console.WriteLine("签名验证成功，开始处理PDF文件...");
                                targetObject = callbackResult.targetObject;
                                //try
                                //{
                                //    // 转换签名为字节数组
                                //    byte[] signatureBytes = Convert.FromBase64String(callbackResult.targetObject);

                                //    // 写入签名并保存文件（核心：把接口返回的签名写入PDF）
                                //    string outputPdfPath = $"C:\\Users\\liusi\\Desktop\\esign\\signed_{DateTime.Now.ToString("yyyyMMddHHmmssfffffff")}.pdf";
                                //    deferredSigner.Sign(outputPdfPath, signatureBytes);
                                //    Console.WriteLine("签名完成，文件保存至：" + outputPdfPath);
                                //}
                                //catch (Exception ex)
                                //{

                                //    Console.WriteLine($"处理PDF签名时发生错误：{ex.Message}");
                                //}

                                Callback = false;
                                break;
                            }

                        }
                    }
                }


                string outputPdfPath = $"C:\\Users\\liusi\\Desktop\\esign\\signed_{DateTime.Now.ToString("yyyyMMddHHmmssfffffff")}.pdf";
                //最后开始重现
                SignLocalPdf(path, Timestamp, targetObject, outputPdfPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public static async Task TestFileHash()
        {

            Console.WriteLine("开始执行 IAM Smart 签名任务");

            // 文件路径
            string path = "C:\\Users\\liusi\\Desktop\\esign\\Barry 签名测试文档.pdf";

            //文件路径判断
            if (string.IsNullOrEmpty(path))
            {
                Console.WriteLine("错误：文件路径不能为空");
                return;
            }


            if (!File.Exists(path))
            {
                Console.WriteLine($"错误：文件不存在 - {path}");
                return;
            }

            //文件格式验证
            string[] allowedExtensions = { ".pdf" };
            string fileExtension = Path.GetExtension(path).ToLower();

            if (!allowedExtensions.Contains(fileExtension))
            {
                Console.WriteLine($"错误：不支持的文件格式 - {fileExtension}");
                Console.WriteLine($"支持的格式：{string.Join(", ", allowedExtensions)}");
                return;
            }


            // 文件大小验证（最大100MB）
            FileInfo fileInfo = new FileInfo(path);
            long maxFileSize = 100 * 1024 * 1024; // 100MB

            if (fileInfo.Length > maxFileSize)
            {
                Console.WriteLine($"错误：文件大小超过限制 - {fileInfo.Length / 1024 / 1024}MB (最大100MB)");
                return;
            }

            Console.WriteLine($"文件验证通过：{Path.GetFileName(path)}");
            Console.WriteLine($"文件大小：{fileInfo.Length / 1024}KB");

            //定义一个公共时间戳
            long Timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            bool whileVal = true;
            int num = 0;

            // 预处理 PDF，保存为临时文件
            string tempPdfPath = Path.Combine(Path.GetDirectoryName(path), "temp_" + Path.GetFileName(path));


            using (FileStream pdfFileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                pdfFileStream.Position = 0; // 每次循环开始时重置文件流位置
                using var ms = new MemoryStream();
                pdfFileStream.CopyTo(ms);
                var buffer = UpgradePDFForSigning(ms.ToArray(), false);
                //using var Upgradestream = new MemoryStream(buffer);
                File.WriteAllBytes(tempPdfPath, buffer);
            }

            Console.WriteLine($"预处理完成，临时文件：{tempPdfPath}");
            while (whileVal)
            {
                using (FileStream tempFileStream = new FileStream(tempPdfPath, FileMode.Open, FileAccess.Read))
                // 初始化PDF签名器（载入PDF流）
                using (var signer = new PdfDocumentSigner(tempFileStream, null, leaveOpen: true))
                {
                    num++;
                    // 配置签名基础信息（和你原有逻辑一致）
                    var digestCalculator = new DigestCalculator(HashAlgorithmType.SHA256);
                    var signerInfo = new ExternalSignerInfo(PdfSignatureType.Pkcs7, 12000, digestCalculator);

                    // 配置签名位置（示例：第1页，坐标X=100, Y=100，宽200，高100）
                    var fieldInfo = new PdfSignatureFieldInfo(new List<int> { 1 })
                    {
                        // SignatureBounds = new PdfRectangle(100, 100, 300, 200), // X1,Y1,X2,Y2
                        SignatureBounds = new DevExpress.Pdf.PdfRectangle(100, 100, 300, 200),
                        //SignatureBounds = new PdfRectangle(50, 650, 250, 750), // 左上角：X1=50, Y1=650, X2=250, Y2=750
                        Name = "Signature_Field"
                    };


                    // 构建延迟签名器（DevExpress核心对象）
                    var builder = new PdfDeferredSignatureBuilder(signerInfo, fieldInfo);
                    //builder.SigningTime = DateTimeOffset.Now;
                    builder.SigningTime = DateTimeOffset.FromUnixTimeSeconds(Timestamp);
                    builder.Location = "Hong Kong";
                    builder.Name = "签名人";
                    builder.Reason = "PDF数字签名";

                    byte[] signatureImageBytes = null;

                    string signatureImagePath = "C:\\Users\\liusi\\Desktop\\esign\\mySignature.png";

                    if (!string.IsNullOrEmpty(signatureImagePath) && File.Exists(signatureImagePath))
                    {
                        signatureImageBytes = File.ReadAllBytes(signatureImagePath);
                    }

                    //byte[] signatureImageBytes = System.Convert.FromBase64String(imageContent);


                    if (signatureImageBytes != null)
                    {
                        builder.SetImageData(signatureImageBytes);
                    }

                    // 载入签名器并计算摘要
                    PdfDeferredSigner deferredSigner = signer.SignDeferred(builder);

                    var documentHash = Convert.ToBase64String(deferredSigner.HashValue);

                    Console.WriteLine($"第{num}次：TestFileHash 计算的Hash：{documentHash}");
                }

                //等待一会
                Console.WriteLine("等待下次校验");
                await Task.Delay(5000);
            }

        }

        public static byte[] UpgradePDFForSignature(byte[] pdf)
        {
            // if pdf contains any signatures, no need upgrade pdf for signing
            using (var signer = new PdfDocumentSigner(new MemoryStream(pdf)))
            {
                if (signer.GetSignatureInfo().Count > 0)
                {
                    return pdf;
                }
            }

            using (PdfDocumentProcessor processor = new PdfDocumentProcessor())
            {
                var memoryStream = new MemoryStream();
                processor.LoadDocument(new MemoryStream(pdf));
                processor.SaveDocument(memoryStream);

                return memoryStream.ToArray();
            }
        }

        public static byte[] UpgradePDFForSigning(byte[] pdf, bool forceUpgrade)
        {
            DateTimeOffset now = DateTimeOffset.Now;
            if (forceUpgrade || !testHash(pdf, now).SequenceEqual(testHash(pdf, now)))
            {
                //Log4Net.AddLog("forceUpgrade PDF");
                using (PdfDocumentProcessor processor = new PdfDocumentProcessor())
                {
                    var memoryStream = new MemoryStream();
                    processor.LoadDocument(new MemoryStream(pdf));
                    processor.SaveDocument(memoryStream);

                    return memoryStream.ToArray();
                }
            }
            return pdf;
        }

        public static byte[] testHash(byte[] pdf, DateTimeOffset signingTime)
        {
            using (var signer = new PdfDocumentSigner(new MemoryStream(pdf)))
            {
                var description = new PdfSignatureFieldInfo(1);
                description.Name = "TEST";

                var digestCalculator = new DigestCalculator(HashAlgorithmType.SHA256);

                var signerInfo = new ExternalSignerInfo(PdfSignatureType.Pkcs7, 12000, digestCalculator);

                //Apply the metadata to the form field: 
                var pdfDeferredSignatureBuilder = new PdfDeferredSignatureBuilder(signerInfo, description);
                pdfDeferredSignatureBuilder.SigningTime = signingTime;

                //Add the signature to the document:
                var deferredSigner = signer.SignDeferred(pdfDeferredSignatureBuilder);

                //Obtain the document hash and hash algorithm's object identifier:
                var digest = deferredSigner.HashValue;
                //Log4Net.AddLog($"testHash PDF:{Convert.ToBase64String(digest)}");
                return digest;
            }

        }

        #endregion

        #region Html导出为PDF
        public static async Task htmltopdf()
        {

            // 替换为你的实际 HTML 内容（或从文件读取）
            string htmlContent = File.ReadAllText(@"C:\Users\liusi\Desktop\htmltopdf\test.html");

            try
            {
                Console.WriteLine("启动浏览器中（首次运行会自动下载 Chromium，耐心等待）...");
                new BrowserFetcher().DownloadAsync().Wait();

                using var browser = await Puppeteer.LaunchAsync(new LaunchOptions
                {
                    Headless = true, // 无头模式，不显示浏览器窗口
                    Args = new[] { "--no-sandbox", "--disable-setuid-sandbox" } // 解决权限问题
                });


                using var page = await browser.NewPageAsync();
                //await page.SetContentAsync(htmlContent);

                // 👇 关键：等待页面渲染完成
                //await page.WaitForNetworkIdleAsync(); // 等待网络空闲
                // 或者等待某个元素出现
                // await page.WaitForSelectorAsync("body");


                // 访问本地服务器上的 HTML
                await page.GoToAsync("http://127.0.0.1:5500/test.html", WaitUntilNavigation.Networkidle0);

                // 👇 关键：等待表单完全渲染
                await page.WaitForSelectorAsync("#formDiv", new WaitForSelectorOptions { Timeout = 30000 });

                // 额外等待确保所有动态内容加载完成
                await Task.Delay(3000);

                // 生成 PDF（指定绝对路径，避免找不到文件）
                string pdfPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{Guid.NewGuid()}.pdf");
                await page.PdfAsync(pdfPath, new PdfOptions
                {
                    Format = PaperFormat.A4,
                    PrintBackground = true
                });

                Console.WriteLine($"PDF 已生成：{pdfPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"错误：{ex.Message}");
            }
        }
        #endregion

        #region retry
        public static void retry()
        {

            int maxRetryNum = 3;
            int retryNum = 0;

            //retry
            while (retryNum < maxRetryNum)
            {
                //將Barcode識別單獨處理,錯誤后不影響程序
                try
                {
                    retryNum++;
                    Console.WriteLine($"retryNum:{retryNum}");

                    int xxx = Convert.ToInt32("xxxx");

                    retryNum = maxRetryNum;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"maxRetryNum:{maxRetryNum},retryNum:{retryNum}");
                    // 加个延迟，重试间隔 1 秒
                    System.Threading.Thread.Sleep(1000);
                }
            }

            Console.WriteLine("Over");
        }
        #endregion

        #region 读取文本文件测试数据类型

        /// <summary>
        /// 读取TXT文件并逐行转换为小数
        /// </summary>
        /// <param name="filePath">TXT文件路径</param>
        public static void ReadTxtAndConvertToDecimal(string filePath)
        {
            try
            {
                // decimal(10,5) 的范围：-99999.99999 到 99999.99999
                decimal minValue = -99999.99999m;
                decimal maxValue = 99999.99999m;

                // 逐行读取文件
                foreach (var line in File.ReadLines(filePath))
                {
                    // 去除首尾空白字符
                    var trimmedLine = line.Trim();

                    // 跳过空行
                    if (string.IsNullOrWhiteSpace(trimmedLine))
                        continue;

                    // 尝试转换为小数
                    if (decimal.TryParse(trimmedLine, out decimal result))
                    {
                        //Console.WriteLine($"转换成功: {result}");
                        // 验证是否在 decimal(10,5) 范围内
                        if (result >= minValue && result <= maxValue)
                        {
                            // 验证小数位数不超过5位
                            string[] parts = trimmedLine.Split('.');
                            if (parts.Length == 2 && parts[1].Length > 5)
                            {
                                Console.WriteLine($"错误：小数位数超过5位，无法转为 decimal(10,5): {trimmedLine}");
                            }
                            else
                            {
                                Console.WriteLine($"转换成功: {result}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"错误：超出 decimal(10,5) 范围 [-99999.99999, 99999.99999]: {trimmedLine}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"转换失败，无效的小数格式: {trimmedLine}");
                        Console.WriteLine($"错误：无效的小数格式: {trimmedLine}");
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"错误：文件未找到 - {filePath}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"文件读取错误: {ex.Message}");
            }
        }
        #endregion

        #region 测试Math
        public static void checkMath()
        {
            decimal obstetricFeeRangeStart = 40000;
            decimal ComplexityStart = 0;
            decimal obstetricFeeRangeEnd = 48000;
            decimal ComplexityEnd = 0;
            string AnaesthesiologistEpiduralAnalgesia = $"$ {Math.Round((obstetricFeeRangeStart + ComplexityStart) / 3m / 1000m) * 1000m}  - $ {Math.Round((obstetricFeeRangeEnd + ComplexityEnd) / 3m / 1000m) * 1000m}";
            Console.WriteLine(AnaesthesiologistEpiduralAnalgesia);
        }
        #endregion


        #region 读取Excel 补充超链接
        public static void LoadExcel()
        {

            var filePath = @"C:\Users\liusi\Desktop\PRD-Report\NEW\20260428-20260528.xlsx";
            var imageFolder = @"C:\Users\liusi\Desktop\PRD-Report\NEW\Image";


            // 打开文件
            using var wb = new XLWorkbook(filePath); // XLWorkbook 就是它
            var ws = wb.Worksheet("Sheet1");

            int rowCount = ws.RowsUsed().Count();

            for (int row = 2; row <= rowCount; row++)  // 第2行开始（跳过表头）
            {
                // 读取 A 列编号 ✅
                string TreeObjectId = ws.Cell(row, 10).GetString().Trim();

                if (string.IsNullOrEmpty(TreeObjectId)) continue;

                // 找 [id] 开头的图片
                string findName = $"[{TreeObjectId}]";
                string found = FindImage(imageFolder, findName);



                if (!string.IsNullOrWhiteSpace(found))
                {
                    Console.WriteLine("No." + row + ":存在文件，补充数据。");
                    //写入文件名
                    ws.Cell(row, 12).Value = found;

                    //写入超链接（动态 L 列）
                    // 🔥 正确公式：=HYPERLINK("Image\"&L2&"",L2)  自动变 L2、L3、L4...
                    ws.Cell(row, 13).FormulaA1 = $"=HYPERLINK(\"Image\\\"&L{row}&\"\", L{row})";
                }
                else
                {
                    Console.WriteLine("No." + row + ":不存在文件,跳过。");
                }

                //if (row>=260)
                //{
                //    break;
                //}
            }

            string targetPath = Path.Combine(Path.GetDirectoryName(filePath),  // 取原文件所在目录
               Path.GetFileNameWithoutExtension(filePath) + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfffffff") + ".xlsx"  // 原名_结果
             );

            wb.SaveAs(targetPath);
            Console.WriteLine("完成！");
        }

        static string FindImage(string folder, string startWith)
        {
            if (!Directory.Exists(folder))
                return null;

            var files = Directory.GetFiles(folder, $"{startWith}*", SearchOption.TopDirectoryOnly);
            return files.Length > 0 ? Path.GetFileName(files[0]) : null;
        }
        #endregion

        #region 内存爆炸测试
        public static void LoadingImg()
        {
            //string folderPath = @"C:\Users\liusi\Desktop\Zxing";
            string folderPath = @"C:\Users\liusi\Desktop\PRD-Report\NEW\Image";
            List<Stream> imageStreams = new List<Stream>();

            // 检查文件夹是否存在
            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine($"文件夹不存在：{folderPath}");
                return;
            }

            // 获取文件夹中所有支持的图片格式
            string[] imageExtensions = { "*.jpg", "*.jpeg", "*.png", "*.bmp", "*.gif", "*.tiff", "*.tif" };
            //List<string> imageFiles = new List<string>();

            foreach (string extension in imageExtensions)
            {
                try
                {
                    string[] files = Directory.GetFiles(folderPath, extension, SearchOption.AllDirectories);
                    //imageFiles.AddRange(files);

                    foreach (string filePath in files)
                    {
                        // 方法1：推荐！只读方式打开，性能最好、最安全
                        Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

                        // 方法2：也可以用 File.OpenRead（更简洁）
                        // Stream stream = File.OpenRead(filePath);

                        imageStreams.Add(stream);


                        //using (var pdfStream = SimpleTestPdf(filePath))
                        //{
                        //    Console.WriteLine($"UploadPDF-PDF Stream Length: {pdfStream.Length}, Position: {pdfStream.Position}");

                        //    UploadFile(pdfStream);
                        //}
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"搜索 {extension} 文件时出错：{ex.Message}");
                }
            }

            if (imageStreams.Count == 0)
            {
                Console.WriteLine($"文件夹中没有找到图片文件：{folderPath}");
                return;
            }

            Console.WriteLine($"[OLD] 共加载 {imageStreams.Count} 张图片");
            Console.WriteLine($"[OLD] 启动前内存: {GC.GetTotalMemory(false) / 1024 / 1024} MB");

            using (var pdfStream = MergeImagesToPdfStream2(imageStreams))
            {
                Console.WriteLine($"UploadPDF-PDF Stream Length: {pdfStream.Length}, Position: {pdfStream.Position}");

                //UploadFile(pdfStream);
            }

            Console.WriteLine($"[OLD] 完成后内存: {GC.GetTotalMemory(true) / 1024 / 1024} MB");

            //using (var pdfStream = SimpleTestPdf())
            //{
            //    Console.WriteLine($"UploadPDF-PDF Stream Length: {pdfStream.Length}, Position: {pdfStream.Position}");


            //    UploadFile(pdfStream);
            //}
        }

        public static void UploadFile(Stream fileStream, bool canOverride = true)
        {
            // 验证流是否可读取
            if (!fileStream.CanRead)
            {
                Console.WriteLine("UploadFile: Stream must be readable");
                throw new ArgumentException("Stream must be readable", nameof(fileStream));
            }

            // 创建流副本（安全、不影响外部流）
            using (var copyStream = new MemoryStream())
            {
                // 重置原始流位置
                if (fileStream.CanSeek)
                {
                    fileStream.Position = 0;
                }

                // 复制到副本
                fileStream.CopyTo(copyStream);
                // 副本重置位置
                copyStream.Position = 0;

                string timeStamp = DateTime.Now.ToString("yyyyMMdd_HHmmss_fff");
                string saveFilePath = $@"C:\Users\liusi\Desktop\test\debug_{timeStamp}.pdf";

                using (var fileStreamWrite = new FileStream(saveFilePath, FileMode.Create, FileAccess.Write))
                {
                    copyStream.CopyTo(fileStreamWrite); // ✅ 这里必须用 copyStream
                }

                Console.WriteLine($"✅ PDF 保存成功：{saveFilePath}");
                Console.WriteLine($"UploadFile: 流大小: {copyStream.Length}, 位置: {copyStream.Position}");
            }
        }

        public static MemoryStream MergeImagesToPdfStream4(List<Stream> imageStreams)
        {
            int MROMergePDFChunkSize = 4;
            int MROMergePDFProcessorCount = 1;
            var swTotal = Stopwatch.StartNew();
            var finalStream = new MemoryStream();

            try
            {
                // 预先读取所有图片数据到内存，避免在并行处理中重复读取
                var imageDataList = new (byte[] Data, int OriginalIndex)[imageStreams.Count];

                for (int i = 0; i < imageStreams.Count; i++)
                {
                    var stream = imageStreams[i];
                    if (stream.CanSeek)
                        stream.Position = 0;

                    var bytes = new byte[stream.Length];
                    stream.Read(bytes, 0, bytes.Length);
                    imageDataList[i] = (bytes, i);
                }

                // 分块处理
                var chunkSize = Math.Max(1, MROMergePDFChunkSize);
                var batches = new List<(List<(byte[] Data, int OriginalIndex)> Batch, int BatchIndex)>();

                for (int i = 0; i < imageDataList.Length; i += chunkSize)
                {
                    var batch = imageDataList.Skip(i).Take(chunkSize).ToList();
                    batches.Add((batch, i / chunkSize));
                }

                // 并发处理各批次，生成临时PDF文档
                var tempDocs = new MemoryStream[batches.Count];
                var maxDegree = Math.Max(1, MROMergePDFProcessorCount);
                Parallel.ForEach(batches, new ParallelOptions { MaxDegreeOfParallelism = maxDegree }, batchData =>
                {
                    var (batch, index) = batchData;
                    var swChunk = Stopwatch.StartNew();

                    using var chunkDoc = new Aspose.Pdf.Document();

                    foreach (var (imageData, originalIndex) in batch)
                    {
                        float width, height;
                        using (var skiaStream = new MemoryStream(imageData))
                        using (var imageInfo = SkiaSharp.SKImage.FromEncodedData(skiaStream))
                        {
                            width = imageInfo.Width;
                            height = imageInfo.Height;
                        }

                        var page = chunkDoc.Pages.Add();
                        page.PageInfo.Width = width;
                        page.PageInfo.Height = height;
                        page.PageInfo.Margin = new Aspose.Pdf.MarginInfo(0, 0, 0, 0);

                        var pdfImage = new Aspose.Pdf.Image
                        {
                            ImageStream = new MemoryStream(imageData, 0, imageData.Length, false, true),
                            FixWidth = width,
                            FixHeight = height,
                            Margin = new Aspose.Pdf.MarginInfo(0, 0, 0, 0)
                        };

                        page.Paragraphs.Add(pdfImage);
                    }

                    // 保存分块为临时内存流
                    var tempStream = new MemoryStream();
                    chunkDoc.Save(tempStream);
                    tempStream.Position = 0;

                    // 存储到对应位置
                    tempDocs[index] = tempStream;

                    swChunk.Stop();
                    Console.WriteLine($"UploadPDF-MergeImagesToPdfStream: Processing of chunk {index + 1} completed. Time taken: {swChunk.ElapsedMilliseconds} ms. Number of pages: {batch.Count}. MaxDegreeOfParallelism: {maxDegree}");
                });

                // 创建最终文档
                using var finalDoc = new Aspose.Pdf.Document();

                // 按顺序从每个临时文档复制页面
                for (int i = 0; i < tempDocs.Length; i++)
                {
                    if (tempDocs[i] != null && tempDocs[i].Length > 0)
                    {
                        tempDocs[i].Position = 0;
                        using var tempDoc = new Aspose.Pdf.Document(tempDocs[i]);
                        // 批量复制页面
                        if (tempDoc.Pages.Count > 0)
                        {
                            finalDoc.Pages.Add(tempDoc.Pages);
                        }
                    }
                    break;
                }

                // 保存到最终流
                finalDoc.Save(finalStream);
                finalStream.Position = 0;

                // 释放临时流
                foreach (var tempDoc in tempDocs)
                {
                    tempDoc?.Dispose();
                }

                swTotal.Stop();
                Console.WriteLine($"UploadPDF-MergeImagesToPdfStream: Output stream length: {finalStream.Length}, swTotal: {swTotal.ElapsedMilliseconds}ms");

                return finalStream;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"UploadPDF-MergeImagesToPdfStream：{ex.Message}", ex);
                finalStream?.Dispose();
                throw new Exception("System:Failed to merge images to PDF: " + ex.Message, ex);
            }
        }


        public static MemoryStream MergeImagesToPdfStream3(List<Stream> imageStreams)
        {
            int MROMergePDFChunkSize = 4;
            int MROMergePDFProcessorCount = 1;
            var swTotal = Stopwatch.StartNew();
            var finalStream = new MemoryStream();
            MemoryStream[] tempDocs = new MemoryStream[0];
            try
            {
                // 分块处理
                var chunkSize = Math.Max(1, MROMergePDFChunkSize);
                var batches = new List<(List<(byte[] Data, int OriginalIndex)> Batch, int BatchIndex)>();

                for (int i = 0; i < imageStreams.Count; i += chunkSize)
                {
                    // 这里先占个位置，结构保持不变
                    batches.Add((new List<(byte[], int)>(), i / chunkSize));
                }

                // 并发处理各批次，生成临时PDF文档
                tempDocs = new MemoryStream[batches.Count];
                var maxDegree = Math.Max(1, MROMergePDFProcessorCount);
                Parallel.ForEach(batches, new ParallelOptions { MaxDegreeOfParallelism = maxDegree }, batchData =>
                {
                    var (batch, index) = batchData;
                    var swChunk = Stopwatch.StartNew();

                    using var chunkDoc = new Aspose.Pdf.Document();

                    // 计算当前批次对应原始图片的开始/结束位置
                    int start = index * chunkSize;
                    int end = Math.Min(start + chunkSize, imageStreams.Count);

                    // 直接从原始 imageStreams 取图片，不使用batch里的空数据
                    for (int i = start; i < end; i++)
                    {
                        var stream = imageStreams[i];
                        if (stream == null) continue;
                        if (stream.CanSeek) stream.Position = 0;

                        float width, height;
                        using (var imageInfo = SkiaSharp.SKImage.FromEncodedData(stream))
                        {
                            width = imageInfo.Width;
                            height = imageInfo.Height;
                        }

                        if (stream.CanSeek) stream.Position = 0;

                        var page = chunkDoc.Pages.Add();
                        page.PageInfo.Width = width;
                        page.PageInfo.Height = height;
                        page.PageInfo.Margin = new Aspose.Pdf.MarginInfo(0, 0, 0, 0);

                        var pdfImage = new Aspose.Pdf.Image
                        {
                            ImageStream = stream,
                            FixWidth = width,
                            FixHeight = height,
                            Margin = new Aspose.Pdf.MarginInfo(0, 0, 0, 0)
                        };

                        page.Paragraphs.Add(pdfImage);
                    }

                    // 保存分块为临时内存流
                    var tempStream = new MemoryStream();
                    chunkDoc.Save(tempStream);
                    tempStream.Position = 0;

                    // 存储到对应位置
                    tempDocs[index] = tempStream;

                    swChunk.Stop();
                    Console.WriteLine($"UploadPDF-MergeImagesToPdfStream: Processing of chunk {index + 1} completed. Time taken: {swChunk.ElapsedMilliseconds} ms. Number of pages: {batch.Count}. MaxDegreeOfParallelism: {maxDegree}");
                });

                // 创建最终文档
                using var finalDoc = new Aspose.Pdf.Document();

                // 按顺序从每个临时文档复制页面
                for (int i = 0; i < tempDocs.Length; i++)
                {
                    if (tempDocs[i] != null && tempDocs[i].Length > 0)
                    {
                        tempDocs[i].Position = 0;
                        using var tempDoc = new Aspose.Pdf.Document(tempDocs[i]);
                        // 批量复制页面
                        if (tempDoc.Pages.Count > 0)
                        {
                            finalDoc.Pages.Add(tempDoc.Pages);
                        }
                    }
                }

                // 保存到最终流
                //finalDoc.Save(finalStream);
                finalStream.Position = 0;

                // 释放临时流
                foreach (var tempDoc in tempDocs)
                {
                    tempDoc?.Dispose();
                }

                swTotal.Stop();
                Console.WriteLine($"UploadPDF-MergeImagesToPdfStream: Output stream length: {finalStream.Length}, swTotal: {swTotal.ElapsedMilliseconds}ms");
                //避免回收不全，再回收一次。
                GC.Collect(2, GCCollectionMode.Forced, true, true);
                GC.WaitForPendingFinalizers();
                GC.Collect(2, GCCollectionMode.Forced, true, true);

                GC.Collect(GC.MaxGeneration, GCCollectionMode.Aggressive);
                GC.WaitForPendingFinalizers();
                GC.Collect(GC.MaxGeneration, GCCollectionMode.Aggressive);

                return finalStream;
            }
            catch (Exception ex)
            {


                Console.WriteLine($"UploadPDF-MergeImagesToPdfStream：{ex.Message}", ex);
                finalStream?.Dispose();
                throw new Exception("System:Failed to merge images to PDF: " + ex.Message, ex);
            }
            finally
            {
                if (tempDocs.Length > 0)
                {
                    // 释放临时流
                    foreach (var tempDoc in tempDocs)
                    {
                        tempDoc?.Dispose();
                    }
                }

            }
        }



        public static MemoryStream MergeImagesToPdfStream2(List<Stream> imageStreams)
        {
            int MROMergePDFChunkSize = 4;
            int MROMergePDFProcessorCount = 2;
            var swTotal = Stopwatch.StartNew();
            using var finalStream = new MemoryStream();
            var tempDocs = new List<MemoryStream>();

            try
            {
                // 分块处理
                var chunkSize = Math.Max(1, MROMergePDFChunkSize);
                var batchCount = (imageStreams.Count + chunkSize - 1) / chunkSize;

                // 并发处理各批次，生成临时PDF文档
                tempDocs = new List<MemoryStream>(new MemoryStream[batchCount]);
                var maxDegree = Math.Max(1, MROMergePDFProcessorCount);
                Parallel.For(0, batchCount, new ParallelOptions { MaxDegreeOfParallelism = maxDegree }, index =>
                {
                    var swChunk = Stopwatch.StartNew();

                    using var chunkDoc = new Aspose.Pdf.Document();

                    // 计算当前批次对应原始图片的开始/结束位置
                    int start = index * chunkSize;
                    int end = Math.Min(start + chunkSize, imageStreams.Count);

                    // 直接从原始 imageStreams 取图片，不使用batch里的空数据
                    for (int i = start; i < end; i++)
                    {
                        var stream = imageStreams[i];
                        if (stream == null) continue;
                        if (stream.CanSeek) stream.Position = 0;

                        float width, height;
                        using (var imageInfo = SkiaSharp.SKImage.FromEncodedData(stream))
                        {
                            width = imageInfo.Width;
                            height = imageInfo.Height;
                        }

                        if (stream.CanSeek) stream.Position = 0;

                        var page = chunkDoc.Pages.Add();
                        page.PageInfo.Width = width;
                        page.PageInfo.Height = height;
                        page.PageInfo.Margin = new Aspose.Pdf.MarginInfo(0, 0, 0, 0);

                        var pdfImage = new Aspose.Pdf.Image
                        {
                            ImageStream = stream,
                            FixWidth = width,
                            FixHeight = height,
                            Margin = new Aspose.Pdf.MarginInfo(0, 0, 0, 0)
                        };

                        page.Paragraphs.Add(pdfImage);
                    }

                    // 保存分块为临时内存流
                    var tempStream = new MemoryStream();
                    chunkDoc.Save(tempStream);
                    tempStream.Position = 0;

                    // 存储到对应位置
                    tempDocs[index] = tempStream;

                    swChunk.Stop();
                    Console.WriteLine($"UploadPDF-MergeImagesToPdfStream: Processing of chunk {index + 1} completed. Time taken: {swChunk.ElapsedMilliseconds} ms. Number of pages: {batchCount}. MaxDegreeOfParallelism: {maxDegree}. Memory: {GC.GetTotalMemory(false) / 1024 / 1024} MB");
                });

                Console.WriteLine($"[OLD] Parallel完成, tempDocs数量: {tempDocs.Count}, 内存: {GC.GetTotalMemory(false) / 1024 / 1024} MB");

                // 创建最终文档
                using var finalDoc = new Aspose.Pdf.Document();

                // 按顺序从每个临时文档复制页面
                foreach (var tempStream in tempDocs)
                {
                    if (tempStream == null || tempStream.Length == 0) continue;
                    tempStream.Position = 0;
                    using var tempDoc = new Aspose.Pdf.Document(tempStream);
                    if (tempDoc.Pages.Count > 0)
                        finalDoc.Pages.Add(tempDoc.Pages);
                }

                // 保存到最终流
                finalDoc.Save(finalStream);
                finalStream.Position = 0;

                swTotal.Stop();
                Console.WriteLine($"UploadPDF-MergeImagesToPdfStream: Output stream length: {finalStream.Length}, swTotal: {swTotal.ElapsedMilliseconds}ms");

                return finalStream;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"UploadPDF-MergeImagesToPdfStream：{ex.Message}", ex);
                throw new Exception("System:Failed to merge images to PDF: " + ex.Message, ex);
            }
            finally
            {
                foreach (var stream in tempDocs)
                {
                    stream?.Dispose();
                }
            }
        }

        public static MemoryStream SimpleTestPdf(string testImagePath)
        {
            // 测试用的单张图片（用你文件夹里的一张）
            //string testImagePath = @"C:\Users\liusi\Desktop\Zxing\[399762]Batch_202605071029127_399561.png"; // 改成你自己的图片路径

            var finalStream = new MemoryStream();
            try
            {
                using (var doc = new Aspose.Pdf.Document())
                {
                    // 添加一张图片
                    using (var fs = File.OpenRead(testImagePath))
                    {
                        // 读取图片尺寸
                        using var skiaStream = new MemoryStream();
                        fs.CopyTo(skiaStream);
                        skiaStream.Position = 0;
                        using var imageInfo = SkiaSharp.SKImage.FromEncodedData(skiaStream);
                        float width = imageInfo.Width;
                        float height = imageInfo.Height;

                        // 添加页面
                        var page = doc.Pages.Add();
                        page.PageInfo.Width = width;
                        page.PageInfo.Height = height;
                        page.PageInfo.Margin = new Aspose.Pdf.MarginInfo(0, 0, 0, 0);

                        // 添加图片
                        fs.Position = 0;
                        var pdfImage = new Aspose.Pdf.Image
                        {
                            ImageStream = fs,
                            FixWidth = width,
                            FixHeight = height,
                            Margin = new Aspose.Pdf.MarginInfo(0, 0, 0, 0)
                        };
                        page.Paragraphs.Add(pdfImage);

                        // 保存到流
                        doc.Save(finalStream);
                    }

                    finalStream.Position = 0;
                }
                return finalStream;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"生成PDF失败：{ex.Message}");
                finalStream?.Dispose();
                throw;
            }
        }
        #endregion

        #region MIMO优化版内存测试

        #region 系统信息输出
        static int CountSetBits(long n)
        {
            int count = 0;
            while (n > 0)
            {
                count += (int)(n & 1);
                n >>= 1;
            }
            return count;
        }

        public static void PrintSystemInfo(string tag = "")
        {
            var process = Process.GetCurrentProcess();
            long totalRam = GC.GetGCMemoryInfo().TotalAvailableMemoryBytes;
            int logicalProcessors = Environment.ProcessorCount;
            long affinityMask = (long)process.ProcessorAffinity;
            int allowedCpus = CountSetBits(affinityMask);

            Console.WriteLine($"[{tag}] ====== 系统信息 ======");
            Console.WriteLine($"[{tag}] 系统总物理内存: {totalRam / 1024 / 1024} MB ({totalRam / 1024.0 / 1024.0 / 1024.0:F2} GB)");
            Console.WriteLine($"[{tag}] 逻辑处理器总数: {logicalProcessors}");
            Console.WriteLine($"[{tag}] 进程可用CPU核心: {allowedCpus} / {logicalProcessors} (Affinity: 0x{affinityMask:X})");
            Console.WriteLine($"[{tag}] ======================");
        }

        public static string GetProcessMemoryInfo(string tag = "")
        {
            var process = Process.GetCurrentProcess();
            long workingSet = process.WorkingSet64;
            long privateMem = process.PrivateMemorySize64;
            long managedHeap = GC.GetTotalMemory(false);
            long totalRam = GC.GetGCMemoryInfo().TotalAvailableMemoryBytes;
            double wsPercent = (double)workingSet / totalRam * 100;
            return $"[{tag}] 工作集(Tasks管理器)={workingSet / 1024 / 1024}MB({wsPercent:F1}%), 私有内存={privateMem / 1024 / 1024}MB, 托管堆={managedHeap / 1024 / 1024}MB";
        }
        #endregion

        #region STREAM流式优化版
        public static void LoadingImgStream()
        {
            string folderPath = @"C:\Users\liusi\Desktop\PRD-Report\NEW\Image";

            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine($"文件夹不存在：{folderPath}");
                return;
            }

            var imageExtensions = new[] { "*.jpg", "*.jpeg", "*.png", "*.bmp", "*.gif", "*.tiff", "*.tif" };
            var imagePaths = new List<string>();

            foreach (string extension in imageExtensions)
            {
                try
                {
                    imagePaths.AddRange(Directory.GetFiles(folderPath, extension, SearchOption.AllDirectories));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"搜索 {extension} 文件时出错：{ex.Message}");
                }
            }

            if (imagePaths.Count == 0)
            {
                Console.WriteLine($"文件夹中没有找到图片文件：{folderPath}");
                return;
            }

            PrintSystemInfo("STREAM");
            Console.WriteLine($"[STREAM] 共发现 {imagePaths.Count} 张图片");
            Console.WriteLine($"[STREAM] 启动前: {GetProcessMemoryInfo("STREAM")}");

            using (var pdfStream = MergeImagesToPdfStreamOptimized(imagePaths))
            {
                Console.WriteLine($"[STREAM] PDF Stream Length: {pdfStream.Length}");
            }

            Console.WriteLine($"[STREAM] 完成后: {GetProcessMemoryInfo("STREAM")}");
        }

        public static MemoryStream MergeImagesToPdfStreamOptimized(List<string> imagePaths)
        {
            var swTotal = Stopwatch.StartNew();
            var finalStream = new MemoryStream();
            var tempFilePaths = new List<string>();

            try
            {
                int chunkSize = 4;
                int batchCount = (imagePaths.Count + chunkSize - 1) / chunkSize;
                string tempDir = Path.GetTempPath();

                for (int index = 0; index < batchCount; index++)
                {
                    var swChunk = Stopwatch.StartNew();
                    string tempPath = Path.Combine(tempDir, $"stream_chunk_{Guid.NewGuid():N}.pdf");
                    tempFilePaths.Add(tempPath);

                    int start = index * chunkSize;
                    int end = Math.Min(start + chunkSize, imagePaths.Count);

                    using (var chunkDoc = new Aspose.Pdf.Document())
                    {
                        var chunkStreams = new List<Stream>();

                        for (int i = start; i < end; i++)
                        {
                            Stream stream = new FileStream(imagePaths[i], FileMode.Open, FileAccess.Read, FileShare.Read);
                            chunkStreams.Add(stream);

                            float width, height;
                            try
                            {
                                var imageInfo = SixLabors.ImageSharp.Image.Identify(stream);
                                width = imageInfo.Width;
                                height = imageInfo.Height;
                            }
                            catch
                            {
                                if (stream.CanSeek) stream.Position = 0;
                                using var imageInfo = SKImage.FromEncodedData(stream);
                                width = imageInfo.Width;
                                height = imageInfo.Height;
                            }

                            if (stream.CanSeek) stream.Position = 0;

                            var page = chunkDoc.Pages.Add();
                            page.PageInfo.Width = width;
                            page.PageInfo.Height = height;
                            page.PageInfo.Margin = new Aspose.Pdf.MarginInfo(0, 0, 0, 0);

                            var pdfImage = new Aspose.Pdf.Image
                            {
                                ImageStream = stream,
                                FixWidth = width,
                                FixHeight = height,
                                Margin = new Aspose.Pdf.MarginInfo(0, 0, 0, 0)
                            };

                            page.Paragraphs.Add(pdfImage);
                        }

                        chunkDoc.Save(tempPath);

                        foreach (var s in chunkStreams)
                            s?.Dispose();
                    }

                    swChunk.Stop();
                    Console.WriteLine($"[STREAM] Chunk {index + 1}/{batchCount} done. Time: {swChunk.ElapsedMilliseconds}ms. {GetProcessMemoryInfo("STREAM")}");
                }

                GC.Collect(2, GCCollectionMode.Forced, true, true);
                GC.WaitForPendingFinalizers();

                Console.WriteLine($"[STREAM] 所有Chunk完成: {GetProcessMemoryInfo("STREAM")}");

                var currentFiles = new List<string>(tempFilePaths);
                int round = 0;

                while (currentFiles.Count > 1)
                {
                    round++;
                    var nextFiles = new List<string>();
                    var swRound = Stopwatch.StartNew();

                    for (int i = 0; i < currentFiles.Count; i += 2)
                    {
                        if (i + 1 >= currentFiles.Count)
                        {
                            nextFiles.Add(currentFiles[i]);
                            continue;
                        }

                        string mergedPath = Path.Combine(tempDir, $"stream_merge_r{round}_{Guid.NewGuid():N}.pdf");
                        tempFilePaths.Add(mergedPath);

                        using (var mergedDoc = new Aspose.Pdf.Document())
                        {
                            using (var leftDoc = new Aspose.Pdf.Document(currentFiles[i]))
                            {
                                if (leftDoc.Pages.Count > 0)
                                    mergedDoc.Pages.Add(leftDoc.Pages);
                            }
                            File.Delete(currentFiles[i]);

                            using (var rightDoc = new Aspose.Pdf.Document(currentFiles[i + 1]))
                            {
                                if (rightDoc.Pages.Count > 0)
                                    mergedDoc.Pages.Add(rightDoc.Pages);
                            }
                            File.Delete(currentFiles[i + 1]);

                            mergedDoc.Save(mergedPath);
                        }

                        nextFiles.Add(mergedPath);
                    }

                    swRound.Stop();
                    Console.WriteLine($"[STREAM] Merge round {round}: {currentFiles.Count} -> {nextFiles.Count}. Time: {swRound.ElapsedMilliseconds}ms. {GetProcessMemoryInfo("STREAM")}");
                    currentFiles = nextFiles;
                }

                if (currentFiles.Count == 1)
                {
                    using (var finalDoc = new Aspose.Pdf.Document(currentFiles[0]))
                    {
                        finalDoc.Save(finalStream);
                    }
                    File.Delete(currentFiles[0]);
                }

                finalStream.Position = 0;

                foreach (var path in tempFilePaths)
                {
                    try { if (File.Exists(path)) File.Delete(path); } catch { }
                }

                swTotal.Stop();
                Console.WriteLine($"[STREAM] Output stream length: {finalStream.Length}, swTotal: {swTotal.ElapsedMilliseconds}ms");

                return finalStream;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[STREAM] MergeImagesToPdfStreamOptimized: {ex.Message}", ex);
                foreach (var path in tempFilePaths)
                {
                    try { if (File.Exists(path)) File.Delete(path); } catch { }
                }
                finalStream?.Dispose();
                throw new Exception("System:Failed to merge images to PDF: " + ex.Message, ex);
            }
        }
        #endregion

        #region MIMO多线程优化版
        public static void LoadingImgmimo()
        {
            string folderPath = @"C:\Users\liusi\Desktop\PRD-Report\NEW\Image";
            folderPath = @"C:\Users\liusi\Desktop\PRD-Report\NEW\NewIMAGE";

            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine($"文件夹不存在：{folderPath}");
                return;
            }

            string[] imageExtensions = { "*.jpg", "*.jpeg", "*.png", "*.bmp", "*.gif", "*.tiff", "*.tif" };
            var imagePaths = new List<string>();

            foreach (string extension in imageExtensions)
            {
                try
                {
                    imagePaths.AddRange(Directory.GetFiles(folderPath, extension, SearchOption.AllDirectories));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"搜索 {extension} 文件时出错：{ex.Message}");
                }
            }

            if (imagePaths.Count == 0)
            {
                Console.WriteLine($"文件夹中没有找到图片文件：{folderPath}");
                return;
            }

            PrintSystemInfo("MIMO");
            Console.WriteLine($"[MIMO] 共发现 {imagePaths.Count} 张图片");
            Console.WriteLine($"[MIMO] 启动前: {GetProcessMemoryInfo("MIMO")}");

            using (var pdfStream = MergeImagesToPdfStreambymimo(imagePaths))
            {
                Console.WriteLine($"[MIMO] PDF Stream Length: {pdfStream.Length}");
            }

            Console.WriteLine($"[MIMO] 完成后: {GetProcessMemoryInfo("MIMO")}");
        }

        public static MemoryStream MergeImagesToPdfStreambymimo(List<string> imagePaths)
        {
            var swTotal = Stopwatch.StartNew();
            var finalStream = new MemoryStream();
            var tempFilePaths = new List<string>();

            try
            {
                int chunkSize = 4;
                int batchCount = (imagePaths.Count + chunkSize - 1) / chunkSize;
                string tempDir = Path.GetTempPath();
                //int maxParallel = Math.Max(1, Environment.ProcessorCount);
                int maxParallel = 2;

                Console.WriteLine($"[MIMO] 并行度: {maxParallel}, ChunkSize: {chunkSize}, 批次数: {batchCount}");
                Console.WriteLine($"[MIMO] Chunk处理前: {GetProcessMemoryInfo("MIMO")}");

                var tempPathsArray = new string[batchCount];

                Parallel.For(0, batchCount, new ParallelOptions { MaxDegreeOfParallelism = maxParallel }, index =>
                {
                    var swChunk = Stopwatch.StartNew();
                    string tempPath = Path.Combine(tempDir, $"mimo_chunk_{Guid.NewGuid():N}.pdf");
                    tempPathsArray[index] = tempPath;

                    int start = index * chunkSize;
                    int end = Math.Min(start + chunkSize, imagePaths.Count);

                    using (var chunkDoc = new Aspose.Pdf.Document())
                    {
                        var localStreams = new List<Stream>();

                        for (int i = start; i < end; i++)
                        {
                            Stream stream = new FileStream(imagePaths[i], FileMode.Open, FileAccess.Read, FileShare.Read);
                            localStreams.Add(stream);

                            float width, height;
                            try
                            {
                                var imageInfo = SixLabors.ImageSharp.Image.Identify(stream);
                                width = imageInfo.Width;
                                height = imageInfo.Height;
                            }
                            catch
                            {
                                if (stream.CanSeek) stream.Position = 0;
                                using var imageInfo = SKImage.FromEncodedData(stream);
                                width = imageInfo.Width;
                                height = imageInfo.Height;
                            }

                            if (stream.CanSeek) stream.Position = 0;

                            var page = chunkDoc.Pages.Add();
                            page.PageInfo.Width = width;
                            page.PageInfo.Height = height;
                            page.PageInfo.Margin = new Aspose.Pdf.MarginInfo(0, 0, 0, 0);

                            var pdfImage = new Aspose.Pdf.Image
                            {
                                ImageStream = stream,
                                FixWidth = width,
                                FixHeight = height,
                                Margin = new Aspose.Pdf.MarginInfo(0, 0, 0, 0)
                            };

                            page.Paragraphs.Add(pdfImage);
                        }

                        chunkDoc.Save(tempPath);

                        foreach (var s in localStreams)
                            s?.Dispose();
                    }

                    swChunk.Stop();
                    Console.WriteLine($"[MIMO] Chunk {index + 1}/{batchCount} done. Time: {swChunk.ElapsedMilliseconds}ms. {GetProcessMemoryInfo("MIMO")}");
                });

                tempFilePaths.AddRange(tempPathsArray.Where(p => p != null));

                GC.Collect(2, GCCollectionMode.Forced, true, true);
                GC.WaitForPendingFinalizers();

                Console.WriteLine($"[MIMO] 所有Chunk完成: {GetProcessMemoryInfo("MIMO")}");

                var currentFiles = new List<string>(tempFilePaths);
                int round = 0;

                while (currentFiles.Count > 1)
                {
                    round++;
                    var nextFiles = new List<string>();
                    var swRound = Stopwatch.StartNew();

                    for (int i = 0; i < currentFiles.Count; i += 2)
                    {
                        if (i + 1 >= currentFiles.Count)
                        {
                            nextFiles.Add(currentFiles[i]);
                            continue;
                        }

                        string mergedPath = Path.Combine(tempDir, $"mimo_merge_r{round}_{Guid.NewGuid():N}.pdf");
                        tempFilePaths.Add(mergedPath);

                        using (var mergedDoc = new Aspose.Pdf.Document())
                        {
                            using (var leftDoc = new Aspose.Pdf.Document(currentFiles[i]))
                            {
                                if (leftDoc.Pages.Count > 0)
                                    mergedDoc.Pages.Add(leftDoc.Pages);
                            }
                            File.Delete(currentFiles[i]);

                            using (var rightDoc = new Aspose.Pdf.Document(currentFiles[i + 1]))
                            {
                                if (rightDoc.Pages.Count > 0)
                                    mergedDoc.Pages.Add(rightDoc.Pages);
                            }
                            File.Delete(currentFiles[i + 1]);

                            mergedDoc.Save(mergedPath);
                        }

                        nextFiles.Add(mergedPath);
                    }

                    swRound.Stop();
                    Console.WriteLine($"[MIMO] Merge round {round}: {currentFiles.Count} -> {nextFiles.Count}. Time: {swRound.ElapsedMilliseconds}ms. {GetProcessMemoryInfo("MIMO")}");
                    currentFiles = nextFiles;
                }

                if (currentFiles.Count == 1)
                {
                    using (var finalDoc = new Aspose.Pdf.Document(currentFiles[0]))
                    {
                        finalDoc.Save(finalStream);
                    }
                    File.Delete(currentFiles[0]);
                }

                finalStream.Position = 0;

                foreach (var path in tempFilePaths)
                {
                    try { if (File.Exists(path)) File.Delete(path); } catch { }
                }

                swTotal.Stop();
                Console.WriteLine($"[MIMO] Output stream length: {finalStream.Length}, swTotal: {swTotal.ElapsedMilliseconds}ms");

                return finalStream;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[MIMO] MergeImagesToPdfStreambymimo: {ex.Message}", ex);
                foreach (var path in tempFilePaths)
                {
                    try { if (File.Exists(path)) File.Delete(path); } catch { }
                }
                finalStream?.Dispose();
                return null;
                //throw new Exception("System:Failed to merge images to PDF: " + ex.Message, ex);
            }
        }
        #endregion

        #endregion

        #region iTextSharp免费版
        public static void LoadingImgPdfSharp()
        {
            string folderPath = @"C:\Users\liusi\Desktop\PRD-Report\NEW\Image";
            folderPath = @"C:\Users\liusi\Desktop\PRD-Report\NEW\NewIMAGE";
            string saveFolderPath = @"C:\Users\liusi\Desktop\PRD-Report\NEW\PdfSharpOutput";

            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine($"文件夹不存在：{folderPath}");
                return;
            }

            if (!Directory.Exists(saveFolderPath))
            {
                Directory.CreateDirectory(saveFolderPath);
            }

            var imageExtensions = new[] { "*.jpg", "*.jpeg", "*.png", "*.bmp", "*.gif", "*.tiff", "*.tif" };
            var imagePaths = new List<string>();

            foreach (string extension in imageExtensions)
            {
                try
                {
                    imagePaths.AddRange(Directory.GetFiles(folderPath, extension, SearchOption.AllDirectories));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"搜索 {extension} 文件时出错：{ex.Message}");
                }
            }

            if (imagePaths.Count == 0)
            {
                Console.WriteLine($"文件夹中没有找到图片文件：{folderPath}");
                return;
            }

            PrintSystemInfo("ITEXT");
            Console.WriteLine($"[ITEXT] 共发现 {imagePaths.Count} 张图片");
            Console.WriteLine($"[ITEXT] 输出目录: {saveFolderPath}");
            Console.WriteLine($"[ITEXT] 启动前: {GetProcessMemoryInfo("ITEXT")}");

            var swTotal = Stopwatch.StartNew();
            string finalPdfPath = Path.Combine(saveFolderPath, $"merged_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");

            try
            {
                using (var fs = new FileStream(finalPdfPath, FileMode.Create, FileAccess.Write))
                {
                    var document = new Document(PageSize.A4, 0, 0, 0, 0);
                    var writer = PdfWriter.GetInstance(document, fs);
                    document.Open();

                    for (int i = 0; i < imagePaths.Count; i++)
                    {
                        string imgPath = imagePaths[i];
                        try
                        {
                            using var imgStream = new FileStream(imgPath, FileMode.Open, FileAccess.Read, FileShare.Read);
                            var image = iTextSharp.text.Image.GetInstance(imgStream);

                            float pageWidth = document.PageSize.Width;
                            float pageHeight = document.PageSize.Height;
                            image.ScaleToFit(pageWidth, pageHeight);
                            image.Alignment = Element.ALIGN_CENTER;

                            document.NewPage();
                            document.Add(image);

                            if ((i + 1) % 50 == 0 || i == imagePaths.Count - 1)
                            {
                                Console.WriteLine($"[ITEXT] 进度: {i + 1}/{imagePaths.Count}. {GetProcessMemoryInfo("ITEXT")}");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"[ITEXT] 图片处理失败 {Path.GetFileName(imgPath)}: {ex.Message}");
                        }
                    }

                    document.Close();
                }

                swTotal.Stop();
                var fileInfo = new FileInfo(finalPdfPath);
                Console.WriteLine($"[ITEXT] PDF已保存: {finalPdfPath}");
                Console.WriteLine($"[ITEXT] 文件大小: {fileInfo.Length / 1024.0 / 1024.0:F2} MB");
                Console.WriteLine($"[ITEXT] 总耗时: {swTotal.ElapsedMilliseconds}ms");
                Console.WriteLine($"[ITEXT] 完成后: {GetProcessMemoryInfo("ITEXT")}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ITEXT] 错误: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
            }
        }

        public static async Task LoadingImgPdfSharpMultiThread()
        {
            string folderPath = @"C:\Users\liusi\Desktop\PRD-Report\NEW\Image";
            folderPath = @"C:\Users\liusi\Desktop\PRD-Report\NEW\NewIMAGE";
            string saveFolderPath = @"C:\Users\liusi\Desktop\PRD-Report\NEW\PdfSharpOutput";
            int maxThreads = Environment.ProcessorCount;

            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine($"文件夹不存在：{folderPath}");
                return;
            }

            if (!Directory.Exists(saveFolderPath))
            {
                Directory.CreateDirectory(saveFolderPath);
            }

            var imageExtensions = new[] { "*.jpg", "*.jpeg", "*.png", "*.bmp", "*.gif", "*.tiff", "*.tif" };
            var imagePaths = new List<string>();

            foreach (string extension in imageExtensions)
            {
                try
                {
                    imagePaths.AddRange(Directory.GetFiles(folderPath, extension, SearchOption.AllDirectories));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"搜索 {extension} 文件时出错：{ex.Message}");
                }
            }

            if (imagePaths.Count == 0)
            {
                Console.WriteLine($"文件夹中没有找到图片文件：{folderPath}");
                return;
            }

            PrintSystemInfo("ITEXT-MT");
            Console.WriteLine($"[ITEXT-MT] 共发现 {imagePaths.Count} 张图片");
            Console.WriteLine($"[ITEXT-MT] 线程数: {maxThreads}");
            Console.WriteLine($"[ITEXT-MT] 输出目录: {saveFolderPath}");
            Console.WriteLine($"[ITEXT-MT] 启动前: {GetProcessMemoryInfo("ITEXT-MT")}");

            var swTotal = Stopwatch.StartNew();
            string finalPdfPath = Path.Combine(saveFolderPath, $"merged_mt_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");

            try
            {
                float pageWidth = PageSize.A4.Width;
                float pageHeight = PageSize.A4.Height;


                maxThreads = 2;

                Console.WriteLine($"[ITEXT-MT] 更新线程数: {maxThreads}");
                var semaphore = new SemaphoreSlim(maxThreads);
                var indexedImages = new ConcurrentBag<(int index, iTextSharp.text.Image image)>();

                var swLoad = Stopwatch.StartNew();

                var loadTasks = imagePaths.Select((imgPath, i) => Task.Run(async () =>
                {
                    await semaphore.WaitAsync();
                    try
                    {
                        using var imgStream = new FileStream(imgPath, FileMode.Open, FileAccess.Read, FileShare.Read);
                        var image = iTextSharp.text.Image.GetInstance(imgStream);
                        image.ScaleToFit(pageWidth, pageHeight);
                        image.Alignment = Element.ALIGN_CENTER;
                        indexedImages.Add((i, image));

                        if ((i + 1) % 50 == 0 || i == imagePaths.Count - 1)
                        {
                            Console.WriteLine($"[ITEXT-MT] 加载进度: {i + 1}/{imagePaths.Count}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[ITEXT-MT] 图片加载失败 {Path.GetFileName(imgPath)}: {ex.Message}");
                    }
                    finally
                    {
                        semaphore.Release();
                    }
                })).ToArray();

                await Task.WhenAll(loadTasks);
                swLoad.Stop();
                Console.WriteLine($"[ITEXT-MT] 并行加载完成, 耗时: {swLoad.ElapsedMilliseconds}ms");

                var swWrite = Stopwatch.StartNew();

                using (var fs = new FileStream(finalPdfPath, FileMode.Create, FileAccess.Write))
                {
                    var document = new Document(PageSize.A4, 0, 0, 0, 0);
                    var writer = PdfWriter.GetInstance(document, fs);
                    document.Open();

                    foreach (var item in indexedImages.OrderBy(x => x.index))
                    {
                        document.NewPage();
                        document.Add(item.image);
                    }

                    document.Close();
                }

                swWrite.Stop();
                swTotal.Stop();

                var fileInfo = new FileInfo(finalPdfPath);
                Console.WriteLine($"[ITEXT-MT] PDF已保存: {finalPdfPath}");
                Console.WriteLine($"[ITEXT-MT] 文件大小: {fileInfo.Length / 1024.0 / 1024.0:F2} MB");
                Console.WriteLine($"[ITEXT-MT] 并行加载耗时: {swLoad.ElapsedMilliseconds}ms");
                Console.WriteLine($"[ITEXT-MT] PDF写入耗时: {swWrite.ElapsedMilliseconds}ms");
                Console.WriteLine($"[ITEXT-MT] 总耗时: {swTotal.ElapsedMilliseconds}ms");
                Console.WriteLine($"[ITEXT-MT] 完成后: {GetProcessMemoryInfo("ITEXT-MT")}");

                GC.Collect(GC.MaxGeneration, GCCollectionMode.Aggressive);
                GC.WaitForPendingFinalizers();
                GC.Collect(GC.MaxGeneration, GCCollectionMode.Aggressive);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ITEXT-MT] 错误: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
            }
        }
        #endregion

        #region LoadingImgByDaniel

        private const int TotalImages = 100;       // 总图片数
        private const int ChunkSize = 4;          // 每块图片数 (免费版建议设小)
        private const int ImageWidth = 2000;      // 模拟图片宽度
        private const int ImageHeight = 3000;     // 模拟图片高度

        public static void LoadingImgByDaniel()
        {
            try
            {
                while (true)
                {
                    string folderPath = @"C:\Users\liusi\Desktop\PRD-Report\NEW\Image";

                    if (!Directory.Exists(folderPath))
                    {
                        Console.WriteLine($"文件夹不存在：{folderPath}");
                        return;
                    }

                    var imageExtensions = new[] { "*.jpg", "*.jpeg", "*.png", "*.bmp", "*.gif", "*.tiff", "*.tif" };
                    var imagePaths = new List<string>();

                    foreach (string extension in imageExtensions)
                    {
                        try
                        {
                            imagePaths.AddRange(Directory.GetFiles(folderPath, extension, SearchOption.AllDirectories));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"搜索 {extension} 文件时出错：{ex.Message}");
                        }
                    }

                    var imageStreams = new List<Stream>();
                    foreach (var item in imagePaths)
                    {
                        Stream stream = new FileStream(item, FileMode.Open, FileAccess.Read, FileShare.Read);
                        imageStreams.Add(stream);
                    }

                    // 2. 执行分块处理（不含最终合并）
                    try
                    {
                        ProcessChunksOnly2(imageStreams, ChunkSize);
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\n[ERROR] {ex.Message}");
                        Console.ResetColor();
                    }

                    // 3. 清理测试数据
                    foreach (var s in imageStreams) s?.Dispose();

                    PrintMemory("After final cleanup");

                    Console.WriteLine("\n按 Y 重新运行测试，按其他任意键退出...");
                    var key = Console.ReadKey(intercept: true);
                    if (key.Key != ConsoleKey.Y)
                        break;

                    Console.WriteLine("\n" + new string('-', 60) + "\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"错误：{ex.Message}");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// ★ 核心测试方法：仅执行分块生成，验证内存释放
        /// </summary>
        private static void ProcessChunksOnly2(List<Stream> imageStreams, int chunkSize)
        {
            var swTotal = Stopwatch.StartNew();
            var finalStream = new MemoryStream();
            var tempDocs = new List<MemoryStream>();

            try
            {
                var batchCount = (imageStreams.Count + chunkSize - 1) / chunkSize;

                tempDocs = new List<MemoryStream>(new MemoryStream[batchCount]);
                Parallel.For(0, batchCount, new ParallelOptions { MaxDegreeOfParallelism = 2 }, index =>
                {
                    PrintMemory($"Chunk {index + 1}/{batchCount} START");

                    var swChunk = Stopwatch.StartNew();

                    using var chunkDoc = new Aspose.Pdf.Document();

                    int start = index * chunkSize;
                    int end = Math.Min(start + chunkSize, imageStreams.Count);

                    for (int i = start; i < end; i++)
                    {
                        var stream = imageStreams[i];
                        if (stream == null) continue;
                        if (stream.CanSeek) stream.Position = 0;

                        float width, height;
                        using (var imageInfo = SkiaSharp.SKImage.FromEncodedData(stream))
                        {
                            width = imageInfo.Width;
                            height = imageInfo.Height;
                        }

                        if (stream.CanSeek) stream.Position = 0;

                        var page = chunkDoc.Pages.Add();
                        page.PageInfo.Width = width;
                        page.PageInfo.Height = height;
                        page.PageInfo.Margin = new Aspose.Pdf.MarginInfo(0, 0, 0, 0);

                        var pdfImage = new Aspose.Pdf.Image
                        {
                            ImageStream = stream,
                            FixWidth = width,
                            FixHeight = height,
                            Margin = new Aspose.Pdf.MarginInfo(0, 0, 0, 0)
                        };

                        page.Paragraphs.Add(pdfImage);
                    }

                    var tempStream = new MemoryStream();
                    chunkDoc.Save(tempStream);
                    tempStream.Position = 0;

                    tempDocs[index] = tempStream;

                    swChunk.Stop();

                    PrintMemory($"Chunk {index + 1}/{batchCount} END  ({swChunk.ElapsedMilliseconds}ms)");
                });

                swTotal.Stop();

                foreach (var item in tempDocs)
                {
                    Console.WriteLine($"UploadPDF-MergeImagesToPdfStream: Output stream length: {item.Length}, swTotal: {swTotal.ElapsedMilliseconds}ms");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("System:Failed to merge images to PDF: " + ex.Message, ex);
            }
            finally
            {
                foreach (var stream in tempDocs)
                {
                    stream?.Dispose();
                }
            }

            GC.Collect(GC.MaxGeneration, GCCollectionMode.Aggressive);
            GC.WaitForPendingFinalizers();
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Aggressive);

            PrintMemory("After forced GC");
        }

        /// <summary>
        /// 打印当前进程的内存使用情况
        /// </summary>
        private static void PrintMemory(string label)
        {
            var proc = Process.GetCurrentProcess();
            proc.Refresh();

            long managedMB = GC.GetTotalMemory(false) / 1024 / 1024;
            long privateMB = proc.PrivateMemorySize64 / 1024 / 1024;
            long workingMB = proc.WorkingSet64 / 1024 / 1024;

            Console.WriteLine(
                $"  [MEM] {label,-45} | Managed: {managedMB,5}MB | Private: {privateMB,5}MB | WorkingSet: {workingMB,5}MB");
        }
        #endregion

        #region LoadingImgStreamLowMemory（流式低内存方案 - iTextSharp直接写磁盘）

        /// <summary>
        /// 流式低内存方案：iTextSharp 逐张图片直接写入磁盘 PDF
        /// 不分块、不合并、不缓存图片到内存
        /// 全程只有一张图片在内存中，内存占用 ≈ 1张图片大小
        /// </summary>
        public static void LoadingImgStreamLowMemory()
        {
            string folderPath = @"C:\Users\liusi\Desktop\PRD-Report\NEW\Image";
            string saveFolderPath = @"C:\Users\liusi\Desktop\PRD-Report\NEW\Output";

            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine($"文件夹不存在：{folderPath}");
                return;
            }

            Directory.CreateDirectory(saveFolderPath);

            var imageExtensions = new[] { "*.jpg", "*.jpeg", "*.png", "*.bmp", "*.gif", "*.tiff", "*.tif" };
            var imagePaths = new List<string>();

            foreach (string extension in imageExtensions)
            {
                try
                {
                    imagePaths.AddRange(Directory.GetFiles(folderPath, extension, SearchOption.AllDirectories));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"搜索 {extension} 文件时出错：{ex.Message}");
                }
            }

            if (imagePaths.Count == 0)
            {
                Console.WriteLine($"文件夹中没有找到图片文件：{folderPath}");
                return;
            }

            PrintSystemInfo("LOW-MEM");
            Console.WriteLine($"[LOW-MEM] 共发现 {imagePaths.Count} 张图片");
            Console.WriteLine($"[LOW-MEM] 启动前: {GetProcessMemoryInfo("LOW-MEM")}");

            var swTotal = Stopwatch.StartNew();
            string finalPdfPath = Path.Combine(saveFolderPath, $"merged_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");

            try
            {
                using (var fs = new FileStream(finalPdfPath, FileMode.Create, FileAccess.Write, FileShare.None, 81920))
                using (var document = new Document(PageSize.A4, 0, 0, 0, 0))
                using (var writer = PdfWriter.GetInstance(document, fs))
                {
                    document.Open();

                    float pageWidth = PageSize.A4.Width;
                    float pageHeight = PageSize.A4.Height;

                    for (int i = 0; i < imagePaths.Count; i++)
                    {
                        try
                        {
                            using var imgStream = new FileStream(imagePaths[i], FileMode.Open, FileAccess.Read, FileShare.Read);
                            var image = iTextSharp.text.Image.GetInstance(imgStream);
                            image.ScaleToFit(pageWidth, pageHeight);
                            image.Alignment = Element.ALIGN_CENTER;

                            document.NewPage();
                            document.Add(image);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"[LOW-MEM] 图片处理失败 {Path.GetFileName(imagePaths[i])}: {ex.Message}");
                        }

                        if ((i + 1) % 100 == 0 || i == imagePaths.Count - 1)
                        {
                            Console.WriteLine($"[LOW-MEM] 进度: {i + 1}/{imagePaths.Count}. {GetProcessMemoryInfo("LOW-MEM")}");
                        }
                    }

                    document.Close();
                }

                GC.Collect(2, GCCollectionMode.Forced, true, true);
                GC.WaitForPendingFinalizers();
                GC.Collect(2, GCCollectionMode.Forced, true, true);

                swTotal.Stop();
                var fileInfo = new FileInfo(finalPdfPath);
                Console.WriteLine($"[LOW-MEM] PDF已保存: {finalPdfPath}");
                Console.WriteLine($"[LOW-MEM] 文件大小: {fileInfo.Length / 1024.0 / 1024.0:F2} MB");
                Console.WriteLine($"[LOW-MEM] 总耗时: {swTotal.ElapsedMilliseconds}ms");
                Console.WriteLine($"[LOW-MEM] 完成后: {GetProcessMemoryInfo("LOW-MEM")}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[LOW-MEM] 错误: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
            }
        }

        /// <summary>
        /// API 版本：输入图片文件夹，输出 PDF 文件路径
        /// 不返回 Stream，调用方只拿到文件路径，零内存占用
        /// </summary>
        public static string MergeImagesToPdf(string imageFolderPath, string outputFolderPath)
        {
            var imageExtensions = new[] { "*.jpg", "*.jpeg", "*.png", "*.bmp", "*.gif", "*.tiff", "*.tif" };
            var imagePaths = new List<string>();

            foreach (string extension in imageExtensions)
            {
                try
                {
                    imagePaths.AddRange(Directory.GetFiles(imageFolderPath, extension, SearchOption.AllDirectories));
                }
                catch { }
            }

            if (imagePaths.Count == 0)
                return null;

            Directory.CreateDirectory(outputFolderPath);
            string pdfPath = Path.Combine(outputFolderPath, $"merged_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");

            using (var fs = new FileStream(pdfPath, FileMode.Create, FileAccess.Write, FileShare.None, 81920))
            using (var document = new Document(PageSize.A4, 0, 0, 0, 0))
            using (var writer = PdfWriter.GetInstance(document, fs))
            {
                document.Open();

                float pageWidth = PageSize.A4.Width;
                float pageHeight = PageSize.A4.Height;

                for (int i = 0; i < imagePaths.Count; i++)
                {
                    try
                    {
                        using var imgStream = new FileStream(imagePaths[i], FileMode.Open, FileAccess.Read, FileShare.Read);
                        var image = iTextSharp.text.Image.GetInstance(imgStream);
                        image.ScaleToFit(pageWidth, pageHeight);
                        image.Alignment = Element.ALIGN_CENTER;

                        document.NewPage();
                        document.Add(image);
                    }
                    catch { }
                }

                document.Close();
            }

            GC.Collect(2, GCCollectionMode.Forced, true, true);
            GC.WaitForPendingFinalizers();
            GC.Collect(2, GCCollectionMode.Forced, true, true);

            return pdfPath;
        }

        /// <summary>
        /// 多线程测试：Parallel 分块生成临时 PDF → 合并为最终 PDF
        /// 每个线程处理一个 chunk，写入独立临时文件（线程安全）
        /// 合并阶段单线程顺序合并
        /// </summary>
        public static void LoadingImgStreamLowMemoryParallel()
        {
            string folderPath = @"C:\Users\liusi\Desktop\PRD-Report\NEW\Image";
            folderPath = @"C:\Users\liusi\Desktop\testtest";
            string saveFolderPath = @"C:\Users\liusi\Desktop\PRD-Report\NEW\Output";

            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine($"文件夹不存在：{folderPath}");
                return;
            }

            Directory.CreateDirectory(saveFolderPath);

            var imageExtensions = new[] { "*.jpg", "*.jpeg", "*.png", "*.bmp", "*.gif", "*.tiff", "*.tif" };
            var imagePaths = new List<string>();

            foreach (string extension in imageExtensions)
            {
                try
                {
                    imagePaths.AddRange(Directory.GetFiles(folderPath, extension, SearchOption.AllDirectories));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"搜索 {extension} 文件时出错：{ex.Message}");
                }
            }

            if (imagePaths.Count == 0)
            {
                Console.WriteLine($"文件夹中没有找到图片文件：{folderPath}");
                return;
            }

            int chunkSize = 10;
            int maxParallel = 1;
            int batchCount = (imagePaths.Count + chunkSize - 1) / chunkSize;

            PrintSystemInfo("PARALLEL");
            Console.WriteLine($"[PARALLEL] 共发现 {imagePaths.Count} 张图片");
            Console.WriteLine($"[PARALLEL] ChunkSize={chunkSize}, 并行度={maxParallel}, 批次数={batchCount}");
            Console.WriteLine($"[PARALLEL] 启动前: {GetProcessMemoryInfo("PARALLEL")}");

            var swTotal = Stopwatch.StartNew();
            string tempDir = Path.GetTempPath();
            var tempPaths = new string[batchCount];

            try
            {
                var swChunk = Stopwatch.StartNew();

                Parallel.For(0, batchCount, new ParallelOptions { MaxDegreeOfParallelism = maxParallel }, index =>
                {
                    var swChunkItem = Stopwatch.StartNew();
                    string tempPath = Path.Combine(tempDir, $"lowmem_chunk_{Guid.NewGuid():N}.pdf");
                    tempPaths[index] = tempPath;

                    int start = index * chunkSize;
                    int end = Math.Min(start + chunkSize, imagePaths.Count);

                    Console.WriteLine($"[PARALLEL] Chunk {index + 1}/{batchCount} START (图片 {start + 1}-{end})");

                    using (var fs = new FileStream(tempPath, FileMode.Create, FileAccess.Write, FileShare.None, 81920))
                    using (var document = new Document(PageSize.A4, 0, 0, 0, 0))
                    using (var writer = PdfWriter.GetInstance(document, fs))
                    {
                        document.Open();

                        float pageWidth = PageSize.A4.Width;
                        float pageHeight = PageSize.A4.Height;

                        for (int i = start; i < end; i++)
                        {
                            try
                            {
                                using var imgStream = new FileStream(imagePaths[i], FileMode.Open, FileAccess.Read, FileShare.Read);


                                float width, height;
                                try
                                {
                                    var imageInfo = SixLabors.ImageSharp.Image.Identify(imgStream);
                                    width = imageInfo.Width;
                                    height = imageInfo.Height;
                                }
                                catch
                                {
                                    if (imgStream.CanSeek) imgStream.Position = 0;
                                    using var imageInfo = SKImage.FromEncodedData(imgStream);
                                    width = imageInfo.Width;
                                    height = imageInfo.Height;
                                }

                                imgStream.Position = 0;


                                var image = iTextSharp.text.Image.GetInstance(imgStream);

                                //image.ScaleToFit(pageWidth, pageHeight);
                                image.ScaleToFit(width, height);
                                image.Alignment = Element.ALIGN_CENTER;

                                document.NewPage();
                                document.Add(image);

                                Console.WriteLine($"[PARALLEL] Chunk {index + 1} 进度: {i - start + 1}/{end - start} ({Path.GetFileName(imagePaths[i])})");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"[PARALLEL] 图片处理失败 {Path.GetFileName(imagePaths[i])}: {ex.Message}");
                            }
                        }

                        document.Close();
                    }

                    swChunkItem.Stop();
                    Console.WriteLine($"[PARALLEL] Chunk {index + 1}/{batchCount} DONE ({swChunkItem.ElapsedMilliseconds}ms)");
                });

                swChunk.Stop();
                Console.WriteLine($"[PARALLEL] 分块完成: {swChunk.ElapsedMilliseconds}ms. {GetProcessMemoryInfo("PARALLEL")}");

                GC.Collect(2, GCCollectionMode.Forced, true, true);
                GC.WaitForPendingFinalizers();

                var swMerge = Stopwatch.StartNew();

                string finalPdfPath = Path.Combine(saveFolderPath, $"merged_parallel_{DateTime.Now:yyyyMMdd_HHmmssfffffff}.pdf");

                using (var fs = new FileStream(finalPdfPath, FileMode.Create, FileAccess.Write, FileShare.None, 81920))
                {
                    var finalDoc = new Document();
                    var copy = new iTextSharp.text.pdf.PdfCopy(finalDoc, fs);
                    finalDoc.Open();

                    for (int i = 0; i < tempPaths.Length; i++)
                    {
                        if (string.IsNullOrEmpty(tempPaths[i]) || !File.Exists(tempPaths[i]))
                            continue;

                        Console.WriteLine($"[PARALLEL] 合并: {i + 1}/{tempPaths.Length}");
                        var chunkDoc = new iTextSharp.text.pdf.PdfReader(tempPaths[i]);
                        for (int p = 1; p <= chunkDoc.NumberOfPages; p++)
                        {
                            copy.AddPage(copy.GetImportedPage(chunkDoc, p));
                        }
                        chunkDoc.Close();
                    }

                    finalDoc.Close();
                }

                swMerge.Stop();
                Console.WriteLine($"[PARALLEL] 合并完成: {swMerge.ElapsedMilliseconds}ms. {GetProcessMemoryInfo("PARALLEL")}");

                foreach (var path in tempPaths)
                {
                    try { if (!string.IsNullOrEmpty(path) && File.Exists(path)) File.Delete(path); } catch { }
                }

                GC.Collect(2, GCCollectionMode.Forced, true, true);
                GC.WaitForPendingFinalizers();
                GC.Collect(2, GCCollectionMode.Forced, true, true);

                swTotal.Stop();
                var fileInfo = new FileInfo(finalPdfPath);
                Console.WriteLine($"[PARALLEL] PDF已保存: {finalPdfPath}");
                Console.WriteLine($"[PARALLEL] 文件大小: {fileInfo.Length / 1024.0 / 1024.0:F2} MB");
                Console.WriteLine($"[PARALLEL] 分块耗时: {swChunk.ElapsedMilliseconds}ms, 合并耗时: {swMerge.ElapsedMilliseconds}ms");
                Console.WriteLine($"[PARALLEL] 总耗时: {swTotal.ElapsedMilliseconds}ms");
                Console.WriteLine($"[PARALLEL] 完成后: {GetProcessMemoryInfo("PARALLEL")}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[PARALLEL] 错误: {ex.Message}");
                Console.WriteLine(ex.StackTrace);

                foreach (var path in tempPaths)
                {
                    try { if (!string.IsNullOrEmpty(path) && File.Exists(path)) File.Delete(path); } catch { }
                }
            }
        }

        #endregion
    }
}


