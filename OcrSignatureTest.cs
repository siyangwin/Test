using static Test.QRCodeTest;
using System.Text;
using System.Net.Http.Json;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Drawing;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SkiaSharp;

namespace Test
{
    public static class OcrSignatureTest
    {
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
        static string Json = "{\"config\":[{\"formId\":\"ENT-BUDES-001\",\"page\":3,\"patient\":{\"targetParameters\":[\"病人/親屬/監護人/獲授權人士簽署\",\"病人/親屬/監護人/獲授權人士署\",\"病人/親屬/監護人/獲授權人士策署\",\"病人/親屬/監護人/授權人士簽署\",\"病人/親屬/監護人/授權人士署\",\"病人/親屬/監護人/授權人士策署\",\"病人/親屬/監護人/猎授權人士策署\",\"病人/親屬/監護人/獲授權大士策署\",\"病人/親屬/護人/獲授權人士簽署\",\"病人/親屬/護人/獲授權人士署\",\"病人/親屬/護人/獲授權人士策署\",\"病人/親/監護人/獲授權人士簽署\",\"病人/親/監護人/獲授權人士署\",\"病人/親/監護人/獲授權人士策署\",\"病人/親/護人/獲授權人士簽署\",\"病人/親/護人/獲授權人士署\",\"病人/親/護人/獲授權人士策署\",\"病人/親丽/護人/授權人士署\",\"病/親属/監護人/獲授權人士策署\",\"病/親属/监腰大/獲授權大士策署\",\"病人/親/监護人/獲授權人士署\",\"病人/親丽/護人/授權人士署\",\"病人/親屬/監護人簽署\",\"病人/親屬/監護人署\",\"病人/親屬/監護人策署\",\"病人/親屬/護人簽署\",\"病人/親屬/護人署\",\"病人/親屬/護人策署\",\"病人/親/監護人簽署\",\"病人/親/監護人署\",\"病人/親/監護人策署\",\"病人/親/護人簽署\",\"病人/親/護人署\",\"病人/親/護人策署\",\"病人/親丽/監護人簽署\",\"病人/親丽/護人策署\"],\"signatureAreaWidth\":440,\"signatureAreaHeight\":80},\"doctor\":{\"targetParameters\":[\"醫生簽署\",\"醫生策署\",\"醫生簽\",\"醫生署\",\"医生簽署\",\"医生策署\",\"医生簽\",\"医生署\",\"生署\"],\"bottomReferenceParameters\":[\"Doctor'sSignature\"],\"rightReferenceParameters\":[\"醫生姓名\",\"医生姓名\",\"生姓名\"],\"signatureAreaWidth\":440,\"signatureAreaHeight\":80}},{\"formId\":\"EDC-BUDES-013\",\"page\":2,\"patient\":{\"targetParameters\":[\"病人/親屬/監護人/獲授權人士簽署\",\"病人/親/護人/獲授權人士署\",\"病人/親屬/監護人/獲授權人士署\",\"病人/親/監護人/獲授權人士簽署\",\"病人/親屬/護人/獲授權人士簽署\",\"病人/親/监護人/獲授權人士署\",\"病人/親丽/護人/授權人士署\",\"病人/親/监護人/猎授權人士策署\",\"病/親属/监腰大/獲授權大士策署\",\"病人/親屬/監護人簽署\",\"病人/親/護人策署\",\"病人/親丽/護人策署\",\"病人/親丽/監護人簽署\",\"病人/親/監護人署\",\"病人/親屬/監護人署\",\"病人/親屬/護人署\",\"病人/親屬/監護人策署\"],\"signatureAreaWidth\":440,\"signatureAreaHeight\":80},\"doctor\":{\"targetParameters\":[\"醫生簽署\",\"醫生策署\",\"醫生簽\",\"醫生署\",\"医生簽署\",\"医生策署\",\"医生簽\",\"医生署\",\"生署\"],\"bottomReferenceParameters\":[\"Doctor'sSignature\"],\"rightReferenceParameters\":[\"醫生姓名\",\"医生姓名\",\"生姓名\"],\"signatureAreaWidth\":440,\"signatureAreaHeight\":80}},{\"formId\":\"URO-BUDES-009\",\"page\":3,\"patient\":{\"targetParameters\":[\"病人/親屬/監護人/獲授權人士簽署\",\"病人/親/護人/獲授權人士署\",\"病人/親屬/監護人/獲授權人士署\",\"病人/親/監護人/獲授權人士簽署\",\"病人/親屬/護人/獲授權人士簽署\",\"病人/親/监護人/獲授權人士署\",\"病人/親丽/護人/授權人士署\",\"病人/親/监護人/猎授權人士策署\",\"病/親属/监腰大/獲授權大士策署\",\"病人/親屬/監護人簽署\",\"病人/親/護人策署\",\"病人/親丽/護人策署\",\"病人/親丽/監護人簽署\",\"病人/親/監護人署\",\"病人/親屬/監護人署\",\"病人/親屬/護人署\",\"病人/親屬/監護人策署\"],\"signatureAreaWidth\":440,\"signatureAreaHeight\":80},\"doctor\":{\"targetParameters\":[\"醫生簽署\",\"醫生策署\",\"醫生簽\",\"醫生署\",\"医生簽署\",\"医生策署\",\"医生簽\",\"医生署\",\"生署\"],\"bottomReferenceParameters\":[\"Doctor'sSignature\"],\"rightReferenceParameters\":[\"醫生姓名\",\"医生姓名\",\"生姓名\"],\"signatureAreaWidth\":440,\"signatureAreaHeight\":80}},{\"formId\":\"EDC-BUDES-002\",\"page\":4,\"patient\":{\"targetParameters\":[\"病人/親屬/監護人/獲授權人士簽署\",\"病人/親/護人/獲授權人士署\",\"病人/親屬/監護人/獲授權人士署\",\"病人/親/監護人/獲授權人士簽署\",\"病人/親屬/護人/獲授權人士簽署\",\"病人/親/监護人/獲授權人士署\",\"病人/親丽/護人/授權人士署\",\"病人/親/监護人/猎授權人士策署\"],\"signatureAreaWidth\":440,\"signatureAreaHeight\":80},\"doctor\":{\"targetParameters\":[\"醫生策著\",\"醫生簽署\",\"醫生策署\",\"醫生簽\",\"醫生署\",\"医生簽署\",\"医生策署\",\"医生簽\",\"医生署\",\"生署\"],\"bottomReferenceParameters\":[\"Doctor'sSignature\"],\"rightReferenceParameters\":[\"醫生姓名\",\"医生姓名\",\"生姓名\"],\"signatureAreaWidth\":440,\"signatureAreaHeight\":80}},{\"formId\":\"EDC-BUDES-001\",\"page\":4,\"patient\":{\"targetParameters\":[\"病人/親屬/監護人/獲授權人士簽署\",\"病人/親/護人/獲授權人士署\",\"病人/親屬/監護人/獲授權人士署\",\"病人/親/監護人/獲授權人士簽署\",\"病人/親屬/護人/獲授權人士簽署\",\"病人/親/监護人/獲授權人士署\",\"病人/親丽/護人/授權人士署\",\"病人/親/监護人/猎授權人士策署\"],\"signatureAreaWidth\":440,\"signatureAreaHeight\":80},\"doctor\":{\"targetParameters\":[\"醫生簽署\",\"醫生策署\",\"醫生簽\",\"醫生署\",\"医生簽署\",\"医生策署\",\"医生簽\",\"医生署\",\"生署\"],\"bottomReferenceParameters\":[\"Doctor'sSignature\"],\"rightReferenceParameters\":[\"醫生姓名\",\"医生姓名\",\"生姓名\"],\"signatureAreaWidth\":440,\"signatureAreaHeight\":80}},{\"formId\":\"ONG-BUDES-016\",\"page\":3,\"patient\":{\"targetParameters\":[\"病人/親屬/監護人/獲授權人士簽署\",\"病人/親/護人/獲授權人士署\",\"病人/親屬/監護人/獲授權人士署\",\"病人/親/監護人/獲授權人士簽署\",\"病人/親屬/護人/獲授權人士簽署\",\"病人/親/监護人/獲授權人士署\",\"病人/親丽/護人/授權人士署\",\"病人/親/监護人/猎授權人士策署\",\"病人/親/监護人/獲授權人士薯\"],\"signatureAreaWidth\":440,\"signatureAreaHeight\":80},\"doctor\":{\"targetParameters\":[\"醫生簽署\",\"醫生策署\",\"醫生簽\",\"醫生署\",\"医生簽署\",\"医生策署\",\"医生簽\",\"医生署\",\"生署\"],\"bottomReferenceParameters\":[\"Doctor'sSignature\"],\"rightReferenceParameters\":[\"醫生姓名\",\"医生姓名\",\"生姓名\"],\"signatureAreaWidth\":440,\"signatureAreaHeight\":80}},{\"formId\":\"ONG-BUDES-012\",\"page\":3,\"patient\":{\"targetParameters\":[\"病人/親屬/監護人/獲授權人士簽署\",\"病人/親/護人/獲授權人士署\",\"病人/親屬/監護人/獲授權人士署\",\"病人/親/監護人/獲授權人士簽署\",\"病人/親屬/護人/獲授權人士簽署\",\"病人/親/监護人/獲授權人士署\",\"病人/親丽/護人/授權人士署\",\"病人/親/监護人/猎授權人士策署\",\"病人/親/端镇人/授松人士签馨\"],\"signatureAreaWidth\":440,\"signatureAreaHeight\":80},\"doctor\":{\"targetParameters\":[\"醫生簽署\",\"醫生策署\",\"醫生簽\",\"醫生署\",\"医生簽署\",\"医生策署\",\"医生簽\",\"医生署\",\"生署\",\"劈生寇署\"],\"bottomReferenceParameters\":[\"Doctor'sSignature\"],\"rightReferenceParameters\":[\"醫生姓名\",\"医生姓名\",\"生姓名\"],\"signatureAreaWidth\":440,\"signatureAreaHeight\":80}}],\"parameters\":{\"irregularThreshold\":20,\"blackRatioThreshold\":0.006}}";
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
            folderPath = @"C:\Users\liusi\Desktop\ENT-BUDES-001";
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
    }
}
