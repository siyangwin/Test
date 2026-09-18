using PuppeteerSharp;
using PuppeteerSharp.Media;
using System.Security.Cryptography;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Text.Json;
using DevExpress.Pdf;
using DevExpress.Office.DigitalSignatures;

namespace Test
{
    public static class EsignTest
    {
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
    }
}
