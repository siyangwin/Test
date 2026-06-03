using OpenCvSharp;
using System.Drawing;
using WebDriverBiDi.Bluetooth;
using ZXing;
using static Test.Program;
using Point = OpenCvSharp.Point;


namespace Test
{
    /// <summary>
    /// Barcode QRCode识别 - 条形码和二维码识别
    /// </summary>
    public class Code:IDisposable
    {
        // 模型目录：程序运行目录下 models 文件夹
        //var baseDir = AppDomain.CurrentDomain.BaseDirectory;
        // 指定你的模型文件路径（确保在 Linux 服务器上这些文件也存在）
        static string detect_prototxt = Path.Combine("data", "wechat_qrcode", "detect.prototxt");
        static string detect_caffemodel = Path.Combine("data", "wechat_qrcode", "detect.caffemodel");
        static string sr_prototxt = Path.Combine("data", "wechat_qrcode", "sr.prototxt");
        static string sr_caffemodel = Path.Combine("data", "wechat_qrcode", "sr.caffemodel");


        #region Teru.Code.WechatQrcode.Lite  Nget
        //static WeChatQRCode opencvDecoder;
        //public static void Scan()
        //{
        //    try
        //    {
        //        opencvDecoder = WeChatQRCode.Create("data/wechat_qrcode/detect.prototxt", "data/wechat_qrcode/detect.caffemodel", "data/wechat_qrcode/sr.prototxt", "data/wechat_qrcode/sr.caffemodel");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("OpenCV 初始化失败，请检查文件是否缺失");
        //    }
        //}


        //public List<string>DecodeByOpenCV(string imagePath)
        //{
        //    var results = new List<string>();
        //    Bitmap img = new Bitmap(imagePath);
        //    if (img == null)
        //    {
        //        Console.WriteLine("图片异常");
        //    }

        //    Mat[] rects;
        //    string[] texts;
        //    try
        //    {
        //        Mat mat = OpenCvSharp.Extensions.BitmapConverter.ToMat(img);
        //        opencvDecoder.DetectAndDecode(mat, out rects, out texts);
        //        mat.Dispose();

        //        for (int i = 0; i < texts.Length; i++)
        //        {
        //            Console.WriteLine($"第 {i + 1} 个二维码内容：{texts[i]}");
        //            results.Add(texts[i]);
        //            // 如果你需要获取该二维码的具体坐标，可以从 bbox[i] 中提取
        //            // 例如获取左上角和右下角的坐标：
        //            float x1 = rects[i].At<float>(0, 0);
        //            float y1 = rects[i].At<float>(0, 1);
        //            float x2 = rects[i].At<float>(2, 0);
        //            float y2 = rects[i].At<float>(2, 1);
        //            Console.WriteLine($"位置坐标：({x1}, {y1}) 到 ({x2}, {y2})");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //MessageBox.Show(resultstr, "内部错误");
        //        Console.WriteLine(ex.Message);
        //    }

        //    return results;
        //}

        #endregion

        #region 官方原版OpenCv Wechat 4.13.0.20260302
        //static WeChatQRCode opencvDecoder;
        //public static void Scan()
        //{
        //    try
        //    {
        //        opencvDecoder = WeChatQRCode.Create(detect_prototxt, detect_caffemodel, sr_prototxt, sr_caffemodel);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("OpenCV 初始化失败，请检查文件是否缺失");
        //    }
        //}

        //// 检查模型文件是否存在
        //public static bool CheckModelFilesExist()
        //{
        //    string[] modelFiles = { detect_prototxt, detect_caffemodel, sr_prototxt, sr_caffemodel };
        //    foreach (string file in modelFiles)
        //    {
        //        if (!File.Exists(file))
        //        {
        //            Console.WriteLine($"❌ 模型文件缺失: {file}");
        //            Console.WriteLine($"当前工作目录: {Directory.GetCurrentDirectory()}");
        //            return false;
        //        }
        //    }
        //    Console.WriteLine("✅ 所有模型文件检查通过");
        //    return true;
        //}

        //public List<string> DecodeByOpenCV(string imagePath)
        //{
        //    var results = new List<string>();

        //    // 1. 检查图片文件是否存在
        //    if (!File.Exists(imagePath))
        //    {
        //        Console.WriteLine($"❌ 图片文件不存在: {imagePath}");
        //        return results;
        //    }

        //    // 2. 添加重试机制，解决inv_scale_x > 0错误和资源竞争问题
        //    int maxRetries = 3;
        //    for (int retry = 0; retry < maxRetries; retry++)
        //    {
        //        try
        //        {
        //            // 3. 读取图片
        //            using (var image = Cv2.ImRead(imagePath))
        //            {
        //                // 4. 检查图片读取是否成功
        //                if (image is null || image.Empty())
        //                {
        //                    Console.WriteLine($"⚠️ 警告：图片读取失败或文件已损坏，已自动跳过！路径：{imagePath}");
        //                    return results;
        //                }

        //                // 5. 创建处理副本，避免修改原图
        //                using (var processedImage = new Mat())
        //                {
        //                    // 复制原图
        //                    image.CopyTo(processedImage);

        //                    // 6. 图像预处理
        //                    // 如果图片太小，进行放大（保持宽高比）
        //                    if (processedImage.Width < 64 || processedImage.Height < 64)
        //                    {
        //                        double scale = Math.Max(64.0 / processedImage.Width, 64.0 / processedImage.Height);
        //                        Cv2.Resize(processedImage, processedImage, new OpenCvSharp.Size(
        //                            (int)(processedImage.Width * scale),
        //                            (int)(processedImage.Height * scale)));
        //                    }

        //                    if (retry == 1)
        //                    {
        //                        // 图像增强（可选，根据实际效果调整参数）
        //                        Cv2.ConvertScaleAbs(processedImage, processedImage, 1.3, 30);
        //                    }
        //                    else if (retry == 2)
        //                    {
        //                        // 图像增强（可选，根据实际效果调整参数）
        //                        Cv2.ConvertScaleAbs(processedImage, processedImage, 1.6, 30);
        //                        //using var gray = new Mat();
        //                        //// 1. 强制转灰度（微信识别对灰度图响应最快）
        //                        //if (processedImage.Channels() == 3)
        //                        //    Cv2.CvtColor(processedImage, processedImage, ColorConversionCodes.BGR2GRAY);
        //                        //else
        //                        //    processedImage.CopyTo(processedImage);

        //                        //// 2. 直方图均衡化（如果图片太暗或对比度低，这一步是神技）
        //                        //Cv2.EqualizeHist(processedImage, processedImage);
        //                    }

        //                    Mat[] rects = null;
        //                    string[] texts = null;
        //                    try
        //                    {
        //                        // 8. 调用微信二维码识别
        //                        opencvDecoder.DetectAndDecode(processedImage, out rects, out texts);
        //                        //texts = weChatQRCode.DetectAndDecodeRaw(processedImage, out rects);
        //                        // 9. 处理识别结果
        //                        if (texts != null && texts.Length > 0)
        //                        {
        //                            for (int i = 0; i < texts.Length; i++)
        //                            {
        //                                if (!string.IsNullOrEmpty(texts[i]))
        //                                {
        //                                    results.Add(texts[i]);
        //                                    Console.WriteLine($"✅ 第 {i + 1} 个二维码内容：{texts[i]}");
        //                                }
        //                            }
        //                        }
        //                        else
        //                        {
        //                            Console.WriteLine($"ℹ️ 未识别到二维码内容，图片路径：{imagePath}");
        //                            continue;
        //                        }

        //                        // 成功识别，跳出重试循环
        //                        break;
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        // 10. 异常处理
        //                        //if (ex.Message.Contains("inv_scale_x > 0") && retry < maxRetries - 1)
        //                        if ((ex.Message.Contains("inv_scale_x > 0") ||
        //                       ex.Message.Contains("global") ||
        //                       ex.Message.Contains("resource")) &&
        //                      retry < maxRetries - 1)
        //                        {
        //                            // Console.WriteLine($"⚠️ 遇到inv_scale_x错误，第{retry + 1}次重试...");
        //                            Console.WriteLine($"⚠️ 遇到OpenCV资源错误，第{retry + 1}次重试...");
        //                            // 添加延迟，让OpenCV资源有时间释放
        //                            //System.Threading.Thread.Sleep(100);
        //                            System.Threading.Thread.Sleep(200 * (retry + 1)); // 递增延迟

        //                            // 强制垃圾回收，清理OpenCV全局资源
        //                            if (retry > 0)
        //                            {
        //                                GC.Collect();
        //                                GC.WaitForPendingFinalizers();
        //                            }
        //                            continue;
        //                        }
        //                        else
        //                        {
        //                            Console.WriteLine($"❌ 识别底层异常：{ex.Message}，图片路径：{imagePath}");
        //                            break;
        //                        }
        //                    }
        //                    finally
        //                    {
        //                        // 11. 安全释放内存
        //                        SafeDisposeRects(rects);

        //                        GC.Collect();
        //                        GC.WaitForPendingFinalizers();
        //                    }
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine($"❌ 图片处理异常：{ex.Message}，图片路径：{imagePath}");
        //            break;
        //        }
        //    }

        //    return results;
        //}

        //// 安全释放rects数组的方法
        //private void SafeDisposeRects(Mat[] rects)
        //{
        //    if (rects != null)
        //    {
        //        foreach (var rect in rects)
        //        {
        //            try
        //            {
        //                rect?.Dispose();
        //            }
        //            catch (Exception ex)
        //            {
        //                Console.WriteLine($"⚠️ 释放内存时出现异常: {ex.Message}");
        //            }
        //        }
        //    }
        //}
        #endregion

        #region OpenCv最新版 4.13.0.20260427
        private WeChatQRCode weChatQRCode;
        private bool disposed = false;

        public Code()
        {
            // 延迟初始化，避免在构造函数中可能出现的异常
            InitializeWeChatQRCode();
        }

        private void InitializeWeChatQRCode()
        {
            try
            {
                // 添加初始化延迟，确保OpenCV底层资源完全就绪
                Console.WriteLine("🔄 正在初始化WeChatQRCode，请稍候...");

                // 第一次初始化可能需要较长时间
                weChatQRCode = new WeChatQRCode(detect_prototxt, detect_caffemodel, sr_prototxt, sr_caffemodel);

                // 等待OpenCV底层资源完全初始化
                //System.Threading.Thread.Sleep(1000); // 等待1秒

                Console.WriteLine("✅ WeChatQRCode初始化成功");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ WeChatQRCode初始化失败: {ex.Message}");
                throw;
            }
        }

        public List<DetectedObject> DecodeByOpenCV(string imagePath)
        {
            var results = new List<DetectedObject>();

            // 1. 检查图片文件是否存在
            if (!File.Exists(imagePath))
            {
                Console.WriteLine($"❌ 图片文件不存在: {imagePath}");
                return results;
            }

            // 2. 添加重试机制，解决inv_scale_x > 0错误和资源竞争问题
            int maxRetries = 4;
            for (int retry = 0; retry < maxRetries; retry++)
            {
                try
                {
                    // 3. 读取图片
                    using (var image = Cv2.ImRead(imagePath))
                    {
                        // 4. 检查图片读取是否成功
                        if (image is null || image.Empty())
                        {
                            Console.WriteLine($"⚠️ 警告：图片读取失败或文件已损坏，已自动跳过！路径：{imagePath}");
                            return results;
                        }

                        // 5. 创建处理副本，避免修改原图
                        using (var processedImage = new Mat())
                        {
                            // 复制原图
                            image.CopyTo(processedImage);

                            if (retry == 1)
                            {
                                // 图像增强（可选，根据实际效果调整参数）
                                Cv2.ConvertScaleAbs(processedImage, processedImage, 1.6, 30);
                            }
                            else if (retry == 2)
                            {
                                // 图像增强（可选，根据实际效果调整参数）
                                Cv2.ConvertScaleAbs(processedImage, processedImage, 1.9, 30);
                                //using var gray = new Mat();
                                // 1. 强制转灰度（微信识别对灰度图响应最快）
                                if (processedImage.Channels() == 3)
                                    Cv2.CvtColor(processedImage, processedImage, ColorConversionCodes.BGR2GRAY);
                                else
                                    processedImage.CopyTo(processedImage);

                                // 2. 直方图均衡化（如果图片太暗或对比度低，这一步是神技）
                                Cv2.EqualizeHist(processedImage, processedImage);

                                //Cv2.MorphologyEx(processedImage, processedImage, MorphTypes.Close, Cv2.GetStructuringElement(MorphShapes.Rect, new OpenCvSharp.Size(1, 1)));
                                //终极二值化 + 去噪--降低識別率
                                //Cv2.Threshold(processedImage, processedImage, 110, 255, ThresholdTypes.Binary);
                                //Cv2.MedianBlur(processedImage, processedImage, 3);
                            }
                            else if (retry == 3)
                            {
                                // 第4次：切块识别，直接救回最后那张！
                                bool success = SplitAndDetect(image, weChatQRCode, results);
                                break;
                            }


                            //bool useEnhance = retry >= 1; // 第一次不增强，失败后增强
                            //if (useEnhance)
                            //{
                            //    for (int i = 0; i < retry; i++)
                            //    {
                            //        ProcessImageForQr(processedImage, processedImage);
                            //    }
                            //}


                            // 图像预处理
                            // 如果图片太小，进行放大（保持宽高比）
                            if (processedImage.Width < 64 || processedImage.Height < 64)
                            {
                                double scale = Math.Max(64.0 / processedImage.Width, 64.0 / processedImage.Height);
                                Cv2.Resize(processedImage, processedImage, new OpenCvSharp.Size(
                                    (int)(processedImage.Width * scale),
                                    (int)(processedImage.Height * scale)));
                            }

                         

                            Mat[] rects = null;
                            string[] texts = null;
                            try
                            {
                                // 8. 调用微信二维码识别
                                texts = weChatQRCode.DetectAndDecodeRaw(processedImage, out rects);
                                //texts = weChatQRCode.DetectAndDecode(processedImage, out Point2f[][] points);
                                // 9. 处理识别结果
                                if (texts != null && texts.Length > 0)
                                {

                                    // 1. 克隆一张新图，专门用来画框（原图 processedImage 保持不变）
                                    Mat drawMat = processedImage.Clone();
                                    for (int i = 0; i < texts.Length; i++)
                                    {
                                        DetectedObject detectedObject = new DetectedObject();
                                        detectedObject.Type = "QR_CODE";
                                        if (!string.IsNullOrEmpty(texts[i]))
                                        {
                                            detectedObject.Content = texts[i];
                                            Console.WriteLine($"✅ 第 {i + 1} 个二维码内容：{texts[i]}");
                                        }


                                        if (!string.IsNullOrEmpty(texts[i]))
                                        {
                                            #region 直接读取外接矩形 X、Y、宽、高
                                            Rect box = Cv2.BoundingRect(rects[i]);
                                            int x = box.X;
                                            int y = box.Y;
                                            int w = box.Width;
                                            int h = box.Height;
                                            #endregion


                                            #region 用 .At<float>() 安全读（最稳，不报错）
                                            Mat ptsMat = rects[i]; // 1行×4列×2通道（4个点，每个点x,y）

                                            // 逐个取4个角点：j=0~3 行，0列=x，1列=y
                                            float x1 = ptsMat.At<float>(0, 0);
                                            float y1 = ptsMat.At<float>(0, 1);

                                            float x2 = ptsMat.At<float>(1, 0);
                                            float y2 = ptsMat.At<float>(1, 1);

                                            float x3 = ptsMat.At<float>(2, 0);
                                            float y3 = ptsMat.At<float>(2, 1);

                                            float x4 = ptsMat.At<float>(3, 0);
                                            float y4 = ptsMat.At<float>(3, 1);

                                            Point p1 = new Point((int)Math.Round(x1), (int)Math.Round(y1));
                                            Point p2 = new Point((int)Math.Round(x2), (int)Math.Round(y2));
                                            Point p3 = new Point((int)Math.Round(x3), (int)Math.Round(y3));
                                            Point p4 = new Point((int)Math.Round(x4), (int)Math.Round(y4));

                                            // 画红色框  原图
                                            //Cv2.Polylines(processedImage, new[] { new[] { p1, p2, p3, p4 } }, true, Scalar.Red, 2);

                                            // 2. 在克隆图上画框，不伤原图
                                            Cv2.Polylines(drawMat, new[] { new[] { p1, p2, p3, p4 } }, true, Scalar.Red, 2);

                                            // 初始化 ResultPoint 数组（长度 4）
                                            ResultPoint[] resultPoints = new ResultPoint[4];

                                            // 把坐标写进去
                                            resultPoints[0] = new ResultPoint(p1.X, p1.Y);
                                            resultPoints[1] = new ResultPoint(p2.X, p2.Y);
                                            resultPoints[2] = new ResultPoint(p3.X, p3.Y);
                                            resultPoints[3] = new ResultPoint(p4.X, p4.Y);

                                            detectedObject.resultPoints = resultPoints;
                                            #endregion
                                        }
                                        results.Add(detectedObject);
                                    }

                                    // 3. 显示/保存的是画了框的副本
                                    //先创建窗口：允许手动缩放
                                    //Cv2.NamedWindow("二维码位置", WindowFlags.Normal);

                                    //直接指定窗口大小（宽800，高600）
                                    //Cv2.ResizeWindow("二维码位置", 800, 600);

                                    // 显示画好框的图 弹出图片窗口
                                    //Cv2.ImShow("二维码位置", drawMat);
                                    //Cv2.WaitKey(0);//让弹出的图片窗口不闪退，停在屏幕上，等你按任意键才关闭。

                                    // 如果你需要保存画了框的图片（不需要就删掉）
                                    //string folder = @"D:\二维码结果";
                                    //if (!Directory.Exists(folder))
                                    //    Directory.CreateDirectory(folder);
                                    //Cv2.ImWrite(@"D:\二维码结果\识别图片.jpg", drawMat);

                                    drawMat.Dispose();
                                }
                                else
                                {
                                    Console.WriteLine($"ℹ️ 未识别到二维码内容，图片路径：{imagePath}");
                                    continue;
                                }

                                // 成功识别，跳出重试循环
                                break;
                            }
                            catch (Exception ex)
                            {
                                // 10. 异常处理
                                //if (ex.Message.Contains("inv_scale_x > 0") && retry < maxRetries - 1)
                                if ((ex.Message.Contains("inv_scale_x > 0") ||
                               ex.Message.Contains("global") ||
                               ex.Message.Contains("resource")) &&
                              retry < maxRetries - 1)
                                {
                                    // Console.WriteLine($"⚠️ 遇到inv_scale_x错误，第{retry + 1}次重试...");
                                    Console.WriteLine($"⚠️ 遇到OpenCV资源错误，第{retry + 1}次重试...");
                                    // 添加延迟，让OpenCV资源有时间释放
                                    //System.Threading.Thread.Sleep(100);
                                    System.Threading.Thread.Sleep(200 * (retry + 1)); // 递增延迟

                                    // 强制垃圾回收，清理OpenCV全局资源
                                    if (retry > 0)
                                    {
                                        GC.Collect();
                                        GC.WaitForPendingFinalizers();
                                    }
                                    continue;
                                }
                                else
                                {
                                    Console.WriteLine($"❌ 识别底层异常：{ex.Message}，图片路径：{imagePath}");
                                    break;
                                }
                            }
                            finally
                            {
                                // 11. 安全释放内存
                                SafeDisposeRects(rects);

                                GC.Collect();
                                GC.WaitForPendingFinalizers();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ 图片处理异常：{ex.Message}，图片路径：{imagePath}");
                    break;
                }
            }

            return results;
        }

        // 水平三等分（左、中、右），只要任意一块识别到就成功
        private bool SplitAndDetect(Mat src, WeChatQRCode qr, List<DetectedObject> results)
        {
            int w = src.Width;
            int h = src.Height;

            //水平分
            int stepX = w / 3;
            //int overlap = 20; // 重叠像素，防止切断二维码
            int overlapX = stepX / 2;

            //垂直分
            int stepY = h / 3;
            int overlapY = stepY / 2;


            // 定义所有区域：左中右 + 上中下（带重叠，绝对不会切断！）
            Rect[] regions = new Rect[]
            {
               new Rect(0, 0, stepX + overlapX, h),                // 左
               new Rect(stepX - overlapX, 0, stepX + overlapX*2, h), // 中
               new Rect(stepX*2 - overlapX, 0, stepX + overlapX, h), // 右 
               new Rect(0, 0, w, stepY + overlapY), // 上
               new Rect(0, stepY - overlapY, w, stepY + overlapY * 2), // 中
               new Rect(0, stepY * 2 - overlapY, w, stepY + overlapY)  // 下
            };

            int regionsNum = 0;
            foreach (var rect in regions)
            {
                try
                {
                    using Mat block = new Mat(src, rect);
                    Mat[] rects = null;
                    string[] texts = qr.DetectAndDecodeRaw(block, out rects);

                    if (texts != null && texts.Length > 0)
                    {
                        int i = 0;
                        foreach (var t in texts)
                        {
                            DetectedObject detectedObject = new DetectedObject();
                            detectedObject.Type = "QR_CODE";
                            if (!string.IsNullOrEmpty(t) && !results.Any(s=>s.Content.Contains(t)))
                            {
                                detectedObject.Content = t;
                                Console.WriteLine($"✅ 切块区域{regionsNum + 1},第 {i + 1} 个二维码内容：{t}");



                                #region 用 .At<float>() 安全读（最稳，不报错）
                                Mat ptsMat = rects[i]; // 1行×4列×2通道（4个点，每个点x,y）

                                // 逐个取4个角点：j=0~3 行，0列=x，1列=y
                                float x1 = ptsMat.At<float>(0, 0);
                                float y1 = ptsMat.At<float>(0, 1);

                                float x2 = ptsMat.At<float>(1, 0);
                                float y2 = ptsMat.At<float>(1, 1);

                                float x3 = ptsMat.At<float>(2, 0);
                                float y3 = ptsMat.At<float>(2, 1);

                                float x4 = ptsMat.At<float>(3, 0);
                                float y4 = ptsMat.At<float>(3, 1);

                                OpenCvSharp.Point p1 = new OpenCvSharp.Point((int)Math.Round(x1), (int)Math.Round(y1));
                                OpenCvSharp.Point p2 = new OpenCvSharp.Point((int)Math.Round(x2), (int)Math.Round(y2));
                                OpenCvSharp.Point p3 = new OpenCvSharp.Point((int)Math.Round(x3), (int)Math.Round(y3));
                                OpenCvSharp.Point p4 = new OpenCvSharp.Point((int)Math.Round(x4), (int)Math.Round(y4));


                                // 初始化 ResultPoint 数组（长度 4）
                                ResultPoint[] resultPoints = new ResultPoint[4];

                                // 把坐标写进去
                                resultPoints[0] = new ResultPoint(p1.X, p1.Y);
                                resultPoints[1] = new ResultPoint(p2.X, p2.Y);
                                resultPoints[2] = new ResultPoint(p3.X, p3.Y);
                                resultPoints[3] = new ResultPoint(p4.X, p4.Y);

                                detectedObject.resultPoints = resultPoints;
                                #endregion

                            }
                            i++;

                            results.Add(detectedObject);
                        }
                        return true; // 只要一块识别到，直接成功
                    }
                }
                catch { continue; }

                regionsNum++;
            }
            return false;
        }

        // 安全释放rects数组的方法
        private void SafeDisposeRects(Mat[] rects)
        {
            if (rects != null)
            {
                foreach (var rect in rects)
                {
                    try
                    {
                        rect?.Dispose();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"⚠️ 释放内存时出现异常: {ex.Message}");
                    }
                }
            }
        }
        #endregion

        #region
        public void Dispose()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            //weChatQRCode.Dispose();
        }
        #endregion


    }
}