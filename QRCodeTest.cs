using Aspose.BarCode.BarCodeRecognition;
using SkiaSharp;
using ZXing;
using ZXing.Common;
using ZXing.SkiaSharp;
using System.Text.RegularExpressions;

namespace Test
{
    public static class QRCodeTest
    {

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
            string folderPath = @"C:\Users\liusi\Desktop\opencv";
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
    }}