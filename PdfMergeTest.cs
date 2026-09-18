using iTextSharp.text;
using iTextSharp.text.pdf;
using SkiaSharp;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System.Diagnostics;

namespace Test
{
    public static class PdfMergeTest
    {
        // =====================================================================
        // PDF合并图片方案演进记录
        // =====================================================================
        // 最终选用方案: LoadingImgStreamLowMemoryParallel() + MergeImagesToPdf()
        // =====================================================================

        #region 系统信息工具 (ACTIVE)

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

        #region 上传工具 (ACTIVE)

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
                    copyStream.CopyTo(fileStreamWrite);
                }

                Console.WriteLine($"✅ PDF 保存成功：{saveFilePath}");
                Console.WriteLine($"UploadFile: 流大小: {copyStream.Length}, 位置: {copyStream.Position}");
            }
        }

        #endregion

        #region 自然排序工具 (ACTIVE)

        /// <summary>
        /// 自然数字排序：1,2,11,12 而非 1,11,12,2
        /// </summary>
        public static int NaturalStringCompare(string a, string b)
        {
            int i = 0, j = 0;
            while (i < a.Length && j < b.Length)
            {
                bool aIsDigit = char.IsDigit(a[i]);
                bool bIsDigit = char.IsDigit(b[j]);

                if (aIsDigit && bIsDigit)
                {
                    // 提取连续数字串
                    int startA = i, startB = j;
                    while (i < a.Length && char.IsDigit(a[i])) i++;
                    while (j < b.Length && char.IsDigit(b[j])) j++;

                    // 转数字对比
                    if (long.TryParse(a.Substring(startA, i - startA), out long numA)
                        && long.TryParse(b.Substring(startB, j - startB), out long numB))
                    {
                        if (numA != numB)
                            return numA.CompareTo(numB);
                    }
                }
                else
                {
                    // 普通字符字典序
                    if (a[i] != b[j])
                        return a[i].CompareTo(b[j]);
                    i++; j++;
                }
            }
            // 前缀相同，短的在前
            return a.Length.CompareTo(b.Length);
        }

        #endregion


        #region PDF合并图片方案演进记录（V1-V9 已废弃）

        #region V1: LoadingImg - 全量Stream加载，内存爆炸

        // ---------- V1: LoadingImg() [已废弃] ----------
        // 与上一版本的差异：第一个版本，无参照
        // 废弃原因：将所有图片Stream一次性加载到内存List<Stream>中，
        //           再用Aspose分块生成MemoryStream，最后合并。
        //           图片数量多时内存直接爆炸（几百张图片=几百个Stream驻留内存）。
        // 主要问题：内存占用 = 全部图片大小之和，无法处理大量图片
        /*
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
        */


        #endregion

        #region V2: MergeImagesToPdfStream2 - 加入并行，内存仍驻留

        // ---------- V2: MergeImagesToPdfStream2() [已废弃] ----------
        // 相比V1的改进：引入Parallel.For并行处理，每个chunk独立生成临时MemoryStream
        // 废弃原因：虽然分块了，但每个chunk的结果仍驻留在MemoryStream中不释放，
        //           最终合并时所有tempDocs同时存在于内存，内存仍然很高。
        // 主要问题：Parallel+MemoryStream = 内存翻倍（并行线程各持有流）
        /*
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
        */


        #endregion

        #region V3: MergeImagesToPdfStream3 - 尝试GC回收，无效

        // ---------- V3: MergeImagesToPdfStream3() [已废弃] ----------
        // 相比V2的改进：尝试在合并前强制GC回收，加了更多GC.Collect调用
        // 废弃原因：GC回收治标不治本，Aspose Document对象内部持有非托管内存，
        //           手动GC无法有效释放。合并阶段仍然需要同时打开所有tempDoc。
        // 主要问题：GC.Collect无法回收Aspose内部的非托管内存
        /*
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
        */


        #endregion

        #region V4: MergeImagesToPdfStream4 - 预读byte数组，内存更大

        // ---------- V4: MergeImagesToPdfStream4() [已废弃] ----------
        // 相比V3的改进：预先读取所有图片byte[]到数组，避免在并行中重复读取文件
        // 废弃原因：预先读取所有byte[]意味着内存 = 全部图片原始大小，
        //           比V1更差。虽然避免了重复IO，但内存问题更严重。
        // 主要问题：byte[] + MemoryStream双重缓存，内存占用最大
        /*
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
        */


        #endregion

        #region V5: LoadingImgStream - 磁盘临时文件+树合并

        // ---------- V5: LoadingImgStream() [已废弃] ----------
        // 相比V4的改进：彻底改变思路——分块写磁盘临时PDF文件（不再驻留MemoryStream），
        //   用树形归并（两两合并）减少合并阶段的内存压力，用SixLabors代替SkiaSharp读尺寸
        // 废弃原因：树形归并需要多次打开/关闭Aspose Document，IO开销大；
        //           合并阶段仍需要同时打开两个Document再合并为一个，内存有峰值。
        // 主要问题：树合并轮次多，每轮都要序列化/反序列化PDF，速度慢
        /*
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
        */


        #endregion

        #region V6: LoadingImgmimo - V5+并行chunk

        // ---------- V6: LoadingImgmimo() [已废弃] ----------
        // 相比V5的改进：在V5基础上加Parallel.For并行处理chunk（MaxDegree=2），
        //   其余逻辑相同（树形归并+磁盘临时文件）
        // 废弃原因：和V5一样的树合并问题，多线程只加速了chunk生成阶段，
        //           合并阶段仍然是瓶颈。且并行写临时文件增加了文件锁竞争风险。
        // 主要问题：合并阶段仍是串行树合并，没有本质突破
        /*
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
        */


        #endregion

        #region V7: LoadingImgPdfSharp - 换iTextSharp，单线程

        // ---------- V7: LoadingImgPdfSharp() [已废弃] ----------
        // 相比V6的改进：换用iTextSharp（免费库），直接写磁盘文件，
        //   不再需要分块+合并——单线程逐张图片追加到同一个PDF文档
        // 废弃原因：单线程逐张处理，图片多时速度慢（IO瓶颈）。
        //           但内存表现优秀——始终只有一张图片在内存中。
        // 主要问题：速度慢，无法利用多核CPU
        /*
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
        */


        #endregion

        #region V8: LoadingImgPdfSharpMultiThread - iTextSharp多线程预加载

        // ---------- V8: LoadingImgPdfSharpMultiThread() [已废弃] ----------
        // 相比V7的改进：用SemaphoreSlim控制并行度，多线程预加载所有图片到iTextSharp.Image对象，
        //   然后单线程顺序写入PDF
        // 废弃原因：虽然加载阶段并行化了，但所有iTextSharp.Image对象同时驻留内存，
        //           等于把图片全部缓存了。内存问题回来了。
        // 主要问题：预加载阶段内存 = 所有图片大小，和V1本质相同
        /*
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
        */


        #endregion

        #region V9: LoadingImgStreamLowMemory - iTextSharp流式，单线程

        // ---------- V9: LoadingImgStreamLowMemory() [已废弃] ----------
        // 相比V8的改进：回归单线程流式方案，但保留了iTextSharp直接写磁盘的优点，
        //   去掉了多线程预加载，内存始终只有一张图片大小
        // 废弃原因：和V7一样，单线程速度慢。但验证了"iTextSharp逐张写磁盘"这条路可行。
        // 主要问题：单线程，无法满足大批量图片的性能要求
        // 这个版本的意义：确认了最终方案的核心思路（iTextSharp + 写磁盘 + 保留图片原始尺寸）
        /*
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
        */

        #endregion

        #endregion

        #region 最终方案 (ACTIVE)

        /// <summary>
        /// 多线程测试：Parallel 分块生成临时 PDF → 合并为最终 PDF
        /// 每个线程处理一个 chunk，写入独立临时文件（线程安全）
        /// 合并阶段单线程顺序合并
        /// 
        /// 
        /// 最终采用的版本
        /// </summary>
        public static void LoadingImgStreamLowMemoryParallel()
        {
            string folderPath = @"C:\Users\liusi\Desktop\PRD-Report\NEW\Image";
            folderPath = @"C:\Users\liusi\Desktop\testtest";
            folderPath = @"C:\Users\liusi\Desktop\opencv";
            folderPath = @"C:\Users\liusi\Desktop\AI";
            folderPath = @"C:\Users\liusi\Desktop\LOG";
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


            // 2. 按文件名【自然数字排序】
            imagePaths.Sort((pathA, pathB) =>
            {
                string nameA = Path.GetFileNameWithoutExtension(pathA);
                string nameB = Path.GetFileNameWithoutExtension(pathB);
                return NaturalStringCompare(nameA, nameB);
            });

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

                                document.SetPageSize(new iTextSharp.text.Rectangle(width, height));
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

        #endregion
    }
}
