using OpenCvSharp;
using System.Drawing;
using WebDriverBiDi.Bluetooth;

namespace Test
{
    /// <summary>
    /// Barcode QRCode识别 - 条形码和二维码识别
    /// </summary>
    public class Code:IDisposable
    {

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
                System.Threading.Thread.Sleep(1000); // 等待1秒

                Console.WriteLine("✅ WeChatQRCode初始化成功");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ WeChatQRCode初始化失败: {ex.Message}");
                throw;
            }
        }

        public List<string> DecodeByOpenCV(string imagePath)
        {
            var results = new List<string>();

            // 1. 检查图片文件是否存在
            if (!File.Exists(imagePath))
            {
                Console.WriteLine($"❌ 图片文件不存在: {imagePath}");
                return results;
            }

            // 2. 添加重试机制，解决inv_scale_x > 0错误和资源竞争问题
            int maxRetries = 3;
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

                            // 6. 图像预处理
                            // 如果图片太小，进行放大（保持宽高比）
                            if (processedImage.Width < 64 || processedImage.Height < 64)
                            {
                                double scale = Math.Max(64.0 / processedImage.Width, 64.0 / processedImage.Height);
                                Cv2.Resize(processedImage, processedImage, new OpenCvSharp.Size(
                                    (int)(processedImage.Width * scale),
                                    (int)(processedImage.Height * scale)));
                            }

                            if (retry == 1)
                            {
                                // 图像增强（可选，根据实际效果调整参数）
                                Cv2.ConvertScaleAbs(processedImage, processedImage, 1.3, 30);
                            }
                            else if (retry == 2)
                            {
                                // 图像增强（可选，根据实际效果调整参数）
                                Cv2.ConvertScaleAbs(processedImage, processedImage, 1.6, 30);
                                //using var gray = new Mat();
                                //// 1. 强制转灰度（微信识别对灰度图响应最快）
                                //if (processedImage.Channels() == 3)
                                //    Cv2.CvtColor(processedImage, processedImage, ColorConversionCodes.BGR2GRAY);
                                //else
                                //    processedImage.CopyTo(processedImage);

                                //// 2. 直方图均衡化（如果图片太暗或对比度低，这一步是神技）
                                //Cv2.EqualizeHist(processedImage, processedImage);
                            }

                            Mat[] rects = null;
                            string[] texts = null;
                            try
                            {
                                // 8. 调用微信二维码识别
                                //opencvDecoder.DetectAndDecode(processedImage, out rects, out texts);
                                texts = weChatQRCode.DetectAndDecodeRaw(processedImage, out rects);
                                //texts = weChatQRCode.DetectAndDecode(processedImage, out Point2f[][] points);
                                // 9. 处理识别结果
                                if (texts != null && texts.Length > 0)
                                {
                                    for (int i = 0; i < texts.Length; i++)
                                    {
                                        if (!string.IsNullOrEmpty(texts[i]))
                                        {
                                            results.Add(texts[i]);
                                            Console.WriteLine($"✅ 第 {i + 1} 个二维码内容：{texts[i]}");
                                        }
                                    }
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