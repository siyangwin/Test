using System.Text.RegularExpressions;
using System.Net;
using System.Net.Http;

namespace Test
{
    public static class DownloadTest
    {
        #region DownLoad
        public static void DownLoad()
        {
            Console.WriteLine("开始执行下载任务");

            int startId = 102677;
            string baseUrl = "https://103.155.102.84/download?ID=";
            string saveDirectory = @"D:\DownloadFiles"; // 指定保存目录，可自行修改

            // 忽略SSL证书验证（如果目标站点是自签名证书）
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;



            for (int i = 0; i < 47; i++)
            {
                int currentId = startId + i;
                string downloadUrl = baseUrl + currentId;

                // 创建保存目录（如果不存在）
                if (!Directory.Exists(saveDirectory))
                {
                    Directory.CreateDirectory(saveDirectory);
                    Console.WriteLine($"创建保存目录: {saveDirectory}");
                }

                try
                {

                    // 打开HTML文件
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = downloadUrl,
                        UseShellExecute = true
                    });

                    // // 第一步：获取文件原始名称
                    // string originalFileName = GetOriginalFileName(downloadUrl);
                    // if (string.IsNullOrEmpty(originalFileName))
                    // {
                    //     // 如果获取不到原始名称，使用备用命名
                    //     originalFileName = $"file_{currentId}.dat";
                    //     Console.WriteLine($"未获取到原始文件名，使用备用名称: {originalFileName}");
                    // }

                    //// 拼接完整保存路径（处理重复文件名）
                    // string savePath = GetUniqueFilePath(saveDirectory, originalFileName);

                    //Console.WriteLine($"正在下载: {downloadUrl}");
                    //Console.WriteLine($"保存路径: {savePath}");

                    //// 创建WebClient对象进行下载
                    //using (WebClient client = new WebClient())
                    //{
                    //    // 执行下载并保存到指定路径
                    //    client.DownloadFile(downloadUrl, savePath);

                    //      Console.WriteLine($"下载完成: {Path.GetFileName(savePath)}");
                    //}
                }
                catch (Exception ex)
                {
                    // 捕获异常，避免单个文件下载失败导致整个循环终止
                    Console.WriteLine($"下载失败 {currentId}: {ex.Message}");
                }

                // 可选：添加短暂延迟，避免请求过快被服务器限制
                System.Threading.Thread.Sleep(1000);
            }

            Console.WriteLine("所有下载任务执行完毕！");
        }

        /// <summary>
        /// 从下载链接获取文件的原始名称
        /// </summary>
        /// <param name="url">下载链接</param>
        /// <returns>文件原始名称</returns>
        private static string GetOriginalFileName(string url)
        {
            try
            {
                // 创建请求但不下载整个文件，只获取响应头
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "HEAD"; // 只请求头信息，不请求文件内容
                request.Timeout = 5000;  // 超时时间5秒

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    // 从响应头中获取Content-Disposition
                    string disposition = response.Headers["Content-Disposition"];
                    if (!string.IsNullOrEmpty(disposition))
                    {
                        // 正则匹配文件名（兼容不同格式的Content-Disposition）
                        Match match = Regex.Match(disposition, @"filename=""?([^;]+)""?", RegexOptions.IgnoreCase);
                        if (match.Success)
                        {
                            string fileName = match.Groups[1].Value.Trim();
                            // 处理中文乱码（如果有）
                            fileName = System.Web.HttpUtility.UrlDecode(fileName);
                            return fileName;
                        }
                    }

                    // 如果没有Content-Disposition，尝试从URL解析（备用方案）
                    return Path.GetFileName(url);
                }
            }
            catch
            {
                // 获取文件名失败时返回空
                return null;
            }
        }

        /// <summary>
        /// 获取唯一的文件路径（避免同名文件覆盖）
        /// </summary>
        /// <param name="directory">保存目录</param>
        /// <param name="fileName">文件名</param>
        /// <returns>唯一路径</returns>
        private static string GetUniqueFilePath(string directory, string fileName)
        {
            string filePath = Path.Combine(directory, fileName);
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(fileName);
            string extension = Path.GetExtension(fileName);

            // 如果文件已存在，添加数字后缀（如：test.jpg → test(1).jpg）
            //int counter = 1;
            //while (File.Exists(filePath))
            //{
            //    filePath = Path.Combine(directory, $"{fileNameWithoutExt}({counter}){extension}");
            //    counter++; // 单独一行执行自增操作
            //}

            return filePath;
        }


        //通过读取本地文件Url跳转浏览器下载
        public static async Task DownLoadByFileByChrome()
        {
            int DoenbLoadNum = 20;
            string filePath = @"C:\Users\liusi\Desktop\PRD-Report\image.txt";
            int counter = 0;


            // 逐行读取文件
            foreach (var line in File.ReadLines(filePath))
            {
                counter++;
                if (counter == DoenbLoadNum + 1)
                {
                    return;
                }

                // 去除首尾空白字符
                var id = line.Trim();
                // 跳过空行
                if (string.IsNullOrWhiteSpace(id)) continue;

                string url = $"https://103.155.102.93/Download?id={id}";

                // 打开HTML文件
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });

            }
            Console.WriteLine("🎉 全部下载任务处理完毕！");
        }


        //通过读取本地文件Url下载
        public static async Task DownLoadByFileByApi()
        {
            int downloadLimit = 200;
            //string filePath = @"C:\Users\liusi\Desktop\PRD-Report\DownLoadImage\CUHKMC-REPRT-038\CUHKMC-REPRT-038.txt";
            //string saveFolder = @"C:\Users\liusi\Desktop\PRD-Report\DownLoadImage\CUHKMC-REPRT-038";

            string filePath = @"C:\Users\liusi\Desktop\PRD-Report\NEW\XRC-REPRT-026--OPH-REPRT-OO2\image.txt";
            string saveFolder = @"C:\Users\liusi\Desktop\PRD-Report\NEW\XRC-REPRT-026--OPH-REPRT-OO2";

            // 确保保存目录存在
            Directory.CreateDirectory(saveFolder);
            // 重点：限制同时下载数量（关键！防止连接爆炸）
            int maxParallelDownloads = 6;
            var semaphore = new SemaphoreSlim(maxParallelDownloads);
            // 创建带证书忽略的HttpClient
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            using HttpClient safeClient = new HttpClient(handler);
            // 添加 apikey Header
            safeClient.DefaultRequestHeaders.Add("apikey", "a30c6b7db243953f5656dd4adcada51b13782d646b842088bd5d9b288796867f");
            int counter = 0;
            var tasks = new List<Task>();
            // 逐行读取文件
            foreach (var line in File.ReadLines(filePath))
            {
                counter++;
                if (counter > downloadLimit)
                {
                    break;
                }

                // 去除首尾空白字符
                var id = line.Trim();
                // 跳过空行
                if (string.IsNullOrWhiteSpace(id))
                {
                    counter--;
                    continue;
                }
                string url = $"https://103.155.102.93/Download?id={id}";


                // 优化：先检查本地是否存在包含该ID的文件，避免不必要的API请求
                //string[] existingFiles = Directory.GetFiles(saveFolder, $"*{id}*", SearchOption.TopDirectoryOnly);
                string[] existingFiles = Directory.GetFiles(saveFolder, $"[{id}]*", SearchOption.TopDirectoryOnly);
                if (existingFiles.Length > 0)
                {
                    Console.WriteLine($"[{counter}] ⏭️ 本地已存在包含ID [{id}] 的文件：{existingFiles[0]}");
                    counter--;
                    continue;
                }


                // 获取文件名
                string realFileName = $"{id}.unknown";
                try
                {
                    using var headResp = await safeClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
                    //using var headResp = await safeClient.SendAsync(new HttpRequestMessage(HttpMethod.Head, url));
                    if (headResp.IsSuccessStatusCode)
                    {
                        realFileName = $"[{id}]" + GetFileNameFromHeader(headResp) ?? realFileName;
                    }
                    else
                    {
                        Console.WriteLine($"{id}异常，跳过");

                        // 将失败的ID写入日志文件，便于下次重试
                        string failedLogPath = $@"{saveFolder}\GetNamefailed_downloads.txt";
                        File.AppendAllText(failedLogPath, $"{id}\n");
                        Console.WriteLine($"[{counter}] 📝 获取用户名错误,已记录失败ID到 {failedLogPath}");
                        continue;
                    }
                }
                catch { }

                string savePath = GetUniqueFilePath(saveFolder, realFileName);
                //Console.WriteLine($"[{counter}] 文件名：{realFileName}  URL:{url}");

                // 核心：检测文件已存在 → 直接跳过
                if (File.Exists(savePath))
                {
                    Console.WriteLine($"[{counter}] ⏭️ 已存在，跳过：{realFileName}");
                    counter--;
                    continue;
                }

                // 排队，控制并发
                await semaphore.WaitAsync();
                // 捕获当前循环变量，避免闭包问题
                int currentCounter = counter;
                string currentId = id;
                string currentUrl = url;
                string currentSavePath = savePath;
                string currentFileName = realFileName;
                tasks.Add(Task.Run(async () =>
                {
                    try
                    {
                        #region 可用有效下载代码
                        //Console.WriteLine($"[{currentCounter}] 📥 下载中：{currentFileName}");
                        //using var stream = await safeClient.GetStreamAsync(currentUrl);
                        //using var fs = new FileStream(currentSavePath, FileMode.Create, FileAccess.Write);
                        //await stream.CopyToAsync(fs);
                        //Console.WriteLine($"[{currentCounter}] ✅ 下载完成：{currentFileName}");
                        #endregion

                        #region 可用有效下载代码++添加文件完整性检测
                        Console.WriteLine($"[{currentCounter}] 📥 下载中：{currentFileName}");

                        // 使用 GetAsync 获取响应，先检查状态码
                        using var response = await safeClient.GetAsync(currentUrl, HttpCompletionOption.ResponseHeadersRead);
                        response.EnsureSuccessStatusCode();

                        // 获取期望文件大小
                        long? expectedSize = response.Content.Headers.ContentLength;

                        // 开始下载
                        using var stream = await response.Content.ReadAsStreamAsync();
                        using var fs = new FileStream(currentSavePath, FileMode.Create, FileAccess.Write);
                        await stream.CopyToAsync(fs);

                        // 验证文件完整性，不完整直接抛出错误
                        long actualSize = fs.Length;
                        if (expectedSize.HasValue && actualSize != expectedSize.Value)
                        {
                            throw new IOException($"文件下载不完整：期望 {expectedSize.Value} 字节，实际 {actualSize} 字节");
                        }

                        Console.WriteLine($"[{currentCounter}] ✅ 下载完成：{currentFileName} ({actualSize} 字节)");
                        #endregion
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[{currentCounter}] ❌ 下载失败 {currentFileName}：{ex.Message}");
                        if (File.Exists(currentSavePath))
                        {
                            File.Delete(currentSavePath);
                        }

                        // 将失败的ID写入日志文件，便于下次重试
                        string failedLogPath = $@"{saveFolder}\failed_downloads.txt";
                        File.AppendAllText(failedLogPath, $"{currentId}\n");
                        Console.WriteLine($"[{currentCounter}] 📝 已记录失败ID到 {failedLogPath}");
                    }
                    finally
                    {
                        semaphore.Release();
                    }
                }));
            }
            // 等待所有下载完成
            await Task.WhenAll(tasks);
            Console.WriteLine("🎉 全部下载任务处理完毕！");
        }

        /// <summary>
        /// 从Content-Disposition头解析真实文件名
        /// </summary>
        private static string GetFileNameFromHeader(HttpResponseMessage response)
        {
            if (!response.Content.Headers.TryGetValues("Content-Disposition", out var values))
                return null;

            foreach (var val in values)
            {
                // 匹配格式：attachment; filename="xxx.jpg"
                var match = System.Text.RegularExpressions.Regex.Match(val, @"filename\s*=\s*""?([^"";]+)""?");
                if (match.Success)
                {
                    return match.Groups[1].Value.Trim();
                }
            }
            return null;
        }

        #endregion
    }
}
