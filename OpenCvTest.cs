using System.Text.RegularExpressions;
using static Test.QRCodeTest;

namespace Test
{
    public static class OpenCvTest
    {
        #region OpenCVBarcode识别

        // 指定你的模型文件路径（确保在 Linux 服务器上这些文件也存在）
        static string detect_prototxt = Path.Combine("data", "wechat_qrcode", "detect.prototxt");
        static string detect_caffemodel = Path.Combine("data", "wechat_qrcode", "detect.caffemodel");
        static string sr_prototxt = Path.Combine("data", "wechat_qrcode", "sr.prototxt");
        static string sr_caffemodel = Path.Combine("data", "wechat_qrcode", "sr.caffemodel");
        public static void OpenCv()
        {
            DateTime Pstarttime = DateTime.Now;
            string folderPath = @"C:\Users\liusi\Desktop\opencv";

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
                        var OpenCVresults = code.DecodeByOpenCV(imagePath);


                        var leftmostQRCode = FindLeftmostQRCode(OpenCVresults);
                        if (leftmostQRCode != null)
                        {
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

                        // 处理识别结果
                        if (OpenCVresults != null && OpenCVresults.Count > 0)
                        {
                            successCount++;
                            Console.WriteLine($"  识别成功！找到 {OpenCVresults.Count} 个二维码：");
                            foreach (var result in OpenCVresults)
                            {
                                Console.WriteLine($"    内容：{result.Content}");
                            }
                        }
                        else
                        {
                            failCount++;
                            Console.WriteLine($"  识别失败：未找到二维码");
                        }
                        #endregion

                        //条形码
                        //var OpenCVBarcoderesults = code.DetectBarcodesByOpenCv(imagePath);

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
    }
}

