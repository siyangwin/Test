using System.Text.RegularExpressions;
using System.Text;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Test
{
    public static class MiscTest
    {
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
