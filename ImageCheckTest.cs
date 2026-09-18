using System.Drawing;
using System.Runtime.InteropServices;

namespace Test
{
    public static class ImageCheckTest
    {
        #region 检查图片文件完整性

        // 各格式标准文件头签名
        private static readonly Dictionary<string, byte[][]> Signatures = new()
        {
            ["png"] = new[] { new byte[] { 137, 80, 78, 71, 13, 10, 26, 10 } },
            ["jpg"] = new[] { new byte[] { 255, 216, 255 } },
            ["jpeg"] = new[] { new byte[] { 255, 216, 255 } },
            ["bmp"] = new[] { new byte[] { 66, 77 } },
            ["gif"] = new[] { new byte[] { 71, 73, 70, 56 } },           // GIF8
            ["tiff"] = new[] { new byte[] { 73, 73, 42, 0 }, new byte[] { 77, 77, 0, 42 } }, // II* or MM*
            ["tif"] = new[] { new byte[] { 73, 73, 42, 0 }, new byte[] { 77, 77, 0, 42 } }
        };

        public static void CheckImg()
        {
            string folderPath = @"C:\Users\liusi\Desktop\PRD-Report\NEW\Image";
            folderPath = @"C:\Users\liusi\Desktop\LOG";

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
                    Console.WriteLine($"⚠️ 搜索 {extension} 文件时出错：{ex.Message}");
                }
            }

            if (imagePaths.Count == 0)
            {
                Console.WriteLine($"📭 文件夹中没有找到图片文件：{folderPath}");
                return;
            }

            Console.WriteLine($"🔍 共找到 {imagePaths.Count} 个图片文件，开始校验...\n");

            int passCount = 0, failCount = 0;
            var failedFiles = new List<(string Path, string Reason)>();

            foreach (var filePath in imagePaths)
            {
                var result = ValidateImageFile(filePath);
                if (result.IsValid)
                {
                    passCount++;
                    Console.WriteLine($"✅ PASS | {Path.GetFileName(filePath)} | {result.SizeKB:F1}KB | {result.Width}x{result.Height}");
                }
                else
                {
                    failCount++;
                    failedFiles.Add((filePath, result.ErrorMessage));
                    Console.WriteLine($"❌ FAIL | {Path.GetFileName(filePath)} | {result.ErrorMessage}");
                }
            }

            // 输出汇总报告
            Console.WriteLine($"\n{'=',-60}");
            Console.WriteLine($"📊 校验完成: 总计 {imagePaths.Count} | ✅ 通过 {passCount} | ❌ 失败 {failCount}");

            if (failedFiles.Any())
            {
                Console.WriteLine($"\n🚨 失败文件清单:");
                foreach (var (path, reason) in failedFiles)
                {
                    Console.WriteLine($"   • {path}");
                    Console.WriteLine($"     原因: {reason}");
                }
            }
        }

        /// <summary>
        /// 三层校验：文件大小 → Magic Bytes → 实际解码
        /// </summary>
        private static ImageValidationResult ValidateImageFile(string filePath)
        {
            try
            {
                var fileInfo = new FileInfo(filePath);

                // L1: 基础校验
                if (fileInfo.Length == 0)
                    return ImageValidationResult.Fail("文件大小为 0 字节");

                if (fileInfo.Length > 100 * 1024 * 1024) // 100MB上限
                    return ImageValidationResult.Fail($"文件过大: {fileInfo.Length / 1024.0 / 1024.0:F1}MB");

                // 读取文件头
                byte[] header = new byte[16];
                using (var fs = File.OpenRead(filePath))
                {
                    int bytesRead = fs.Read(header, 0, header.Length);
                    if (bytesRead < 3)
                        return ImageValidationResult.Fail($"文件过小，仅 {bytesRead} 字节");
                }

                // L2: Magic Bytes 签名校验
                string ext = fileInfo.Extension.TrimStart('.').ToLowerInvariant();
                if (Signatures.TryGetValue(ext, out var validSigs))
                {
                    bool sigMatch = validSigs.Any(sig =>
                        header.Length >= sig.Length && header.Take(sig.Length).SequenceEqual(sig));

                    if (!sigMatch)
                    {
                        string actualHex = BitConverter.ToString(header[..Math.Min(8, header.Length)]);
                        return ImageValidationResult.Fail(
                            $"文件头与 .{ext} 不匹配 (实际: {actualHex})，可能是伪造扩展名");
                    }
                }
                else
                {
                    return ImageValidationResult.Fail($"不支持的图片格式: .{ext}");
                }

                // L3: 实际解码校验（能捕获截断、损坏的PNG等）
                using (var stream = File.OpenRead(filePath))
                using (var image = System.Drawing.Image.FromStream(stream, false, false))
                {
                    int w = image.Width;   // 触发完整解码
                    int h = image.Height;
                    return ImageValidationResult.Ok(fileInfo.Length, w, h);
                }
            }
            catch (OutOfMemoryException)
            {
                // System.Drawing 在遇到损坏图片时常抛 OutOfMemoryException
                return ImageValidationResult.Fail("图片数据损坏或格式异常 (OOM during decode)");
            }
            catch (ExternalException ex)
            {
                return ImageValidationResult.Fail($"GDI+ 解码失败: {ex.Message}");
            }
            catch (IOException ex)
            {
                return ImageValidationResult.Fail($"IO错误: {ex.Message}");
            }
            catch (Exception ex)
            {
                return ImageValidationResult.Fail($"未知错误: {ex.GetType().Name}: {ex.Message}");
            }
        }

        #endregion
    }


    public class ImageValidationResult
    {
        public bool IsValid { get; set; }
        public string ErrorMessage { get; set; }
        public long SizeBytes { get; set; }
        public double SizeKB => SizeBytes / 1024.0;
        public int Width { get; set; }
        public int Height { get; set; }

        public static ImageValidationResult Ok(long sizeBytes, int width, int height) =>
            new() { IsValid = true, SizeBytes = sizeBytes, Width = width, Height = height };

        public static ImageValidationResult Fail(string message) =>
            new() { IsValid = false, ErrorMessage = message };
    }
}