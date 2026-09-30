using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;
using ZXing.Common;

namespace Test
{
    public static class Barcode
    {
        /// <summary>
        /// 生成条码并保存为 PNG 文件
        /// </summary>
        /// <param name="content">条码内容</param>
        /// <param name="filePath">完整文件路径</param>
        /// <param name="pixelsPerModule">每个模块的像素数，建议 3~6</param>
        public static void GenerateBarcode(string content)
        {
            //仅支持Windows
            //var writer = new BarcodeWriter<Bitmap>
            //{
            //    Format = BarcodeFormat.CODE_128,
            //    Options = new EncodingOptions
            //    {
            //        Width = 300,
            //        Height = 100,
            //        Margin = 2,
            //        PureBarcode = false
            //    }
            //};

            //using var bitmap = writer.Write(content);
            //string safeName = string.Join("_", content.Split(Path.GetInvalidFileNameChars()));
            //bitmap.Save($"barcodes/{safeName}.png", ImageFormat.Png);

            string basePath = @"C:\Users\liusi\Desktop\Barcode";
            string fileName = $"{content}-{DateTime.Now.ToString("yyyyMMddHHmmss")}.png";                          // 用内容做文件名
            string filePath = Path.Combine(basePath, fileName);          // 拼成完整路径

            int modules = GetCode128ModuleCount(content);   // 189
            int perModule = 3;                              // 每个模块 3 像素
            int width = modules * perModule;                // 756

            //跨平台支持
            var writer = new ZXing.SkiaSharp.BarcodeWriter
            {
                Format = BarcodeFormat.CODE_128,
                Options = new EncodingOptions {Width= width, Height = 150, Margin = 2, PureBarcode = true }
            };

            using var image = writer.Write(content);

            // 确保目录存在
            var dir = Path.GetDirectoryName(filePath);
            if (!string.IsNullOrEmpty(dir))
                Directory.CreateDirectory(dir);

            using var stream = File.Create(filePath);
            using var data = image.Encode(SKEncodedImageFormat.Png, 100);
            data.SaveTo(stream);
        }

        /// <summary>
        /// 生成条码并返回 Base64 字符串（可直接用于网页 <img src="data:image/png;base64,...">）
        /// </summary>
        public static string GenerateBarcodeBase64(string content)
        {
            int modules = GetCode128ModuleCount(content);
            int perModule = 3;                              // 每个模块 3 像素
            int width = modules * perModule;

            var writer = new ZXing.SkiaSharp.BarcodeWriter
            {
                Format = BarcodeFormat.CODE_128,
                Options = new EncodingOptions
                {
                    Width = width,
                    Height = 100,
                    Margin = 2,
                    PureBarcode = true
                }
            };

            using var image = writer.Write(content);
            using var data = image.Encode(SKEncodedImageFormat.Png, 100);
            byte[] bytes = data.ToArray();
            string Base64String= Convert.ToBase64String(bytes);
            Console.WriteLine(Base64String);
            return Base64String;
        }


        /// <summary>
        /// 计算 CODE_128 条码的模块数（上限值，不含 Code C 压缩优化）
        /// </summary>
        public static int GetCode128ModuleCount(string content)
        {
            if (string.IsNullOrEmpty(content)) return 0;
            return 11 * (content.Length + 2) + 13;
        }
    }
}
