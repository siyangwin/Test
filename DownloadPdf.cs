using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UglyToad.PdfPig;

namespace Test
{
    /// <summary>
    /// 下载
    /// </summary>
    public static class DownLoadPdf
    {
        /// <summary>
        /// 按页码循环获取数据
        /// </summary>
        /// <returns></returns>
        public static async Task GetPage()
        {
            for (int i = 1; i <= 4; i++)
            {
                string baseUrl = "https://xqctk.jtys.sz.gov.cn/gbl/";
                string savePath = @"C:\Users\liusi\Desktop\摇号数据";

                string Request = await CallApi($"{baseUrl}index_{i}.html");
                if (i == 1)
                {
                    Console.WriteLine($"{baseUrl}index.html");
                    Request = await CallApi($"{baseUrl}index.html");
                }
                else
                {
                    Console.WriteLine($"{baseUrl}index_{i}.html");
                }
              
                #region //Demo
                string Request1 = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
<html xmlns=""http://www.w3.org/1999/xhtml"">
<head>
<meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" />
<title>通知公告-列表</title>
<link rel=""shortcut icon"" href=""https://xqctk.jtys.sz.gov.cn/templates/default/images/favicon.ico"" />
<link href=""https://xqctk.jtys.sz.gov.cn/templates/default/css/subcss.css"" rel=""stylesheet"" type=""text/css"" />
<!--[if IE 6]>
    <script type=""text/javascript"" src=""../js/DD_belatedPNG_0.0.8a.js""></script>
    <script type=""text/javascript"">
    DD_belatedPNG.fix('img,.header_left,.header_right,.subbg_t,.step1on,.step2on,.step3on,.step4on,.step1,.step2,.step3,.step4');
    </script>
<![endif]-->
<script type='text/javascript' src=""https://xqctk.jtys.sz.gov.cn/templates/default/js/jquery/jquery.js""></script>
<script type='text/javascript'>
$(function(){
	$(""#jump"").click(function(){
		var pageNum=$(""#pageNumber"").val();
		if(pageNum<=1){
			 window.location.href='https://xqctk.jtys.sz.gov.cn/gbl/index.html';
		}
		else if(pageNum>=39){
			window.location.href='https://xqctk.jtys.sz.gov.cn/gbl/index_39.html';
		}
		else if(pageNum>1&&pageNum<39){
			var link='https://xqctk.jtys.sz.gov.cn/gbl/index.html';
			var prefix=link.substring(0,link.indexOf("".html""));
			var suffix=""_""+pageNum+"".html"";
			window.location.href=prefix+suffix;
		}
	});
});

</script>
<script>
(function(){
    var bp = document.createElement('script');
    var curProtocol = window.location.protocol.split(':')[0];
    if (curProtocol === 'https') {
        bp.src = 'https://zz.bdstatic.com/linksubmit/push.js';
    }
    else {
        bp.src = 'http://push.zhanzhang.baidu.com/push.js';
    }
    var s = document.getElementsByTagName(""script"")[0];
    s.parentNode.insertBefore(bp, s);
})();
</script>

<script>
var _hmt = _hmt || [];
(function() {
  var hm = document.createElement(""script"");
  hm.src = ""https://hm.baidu.com/hm.js?d5330a3aab1f8681bd4f82488c72714c"";
  var s = document.getElementsByTagName(""script"")[0]; 
  s.parentNode.insertBefore(hm, s);
})();
</script>
</head>

<body>
<!-- top start-->
<div class=""wrap"">
<div class=""subheader"">
        <div class=""header_left""><a href=""https://xqctk.jtys.sz.gov.cn""><img style=""height:84px;width:615px;"" src=""https://xqctk.jtys.sz.gov.cn/templates/default/images/top_bt.png""/></a></div>
        <div class=""header_right""><a href=""http://www.sz.gov.cn/""><img src=""https://xqctk.jtys.sz.gov.cn/templates/default/images/szzx.png""/></a></div>
	</div>
</div>
<!-- top end-->

<div class=""subbg_t""></div>

<div class=""subbg"">

	<!-- content start-->
	<div class=""content"">
		<!-- 当前位置 start-->
		<dl class=""place"">
			<dd class=""float_left""><a href=""https://xqctk.jtys.sz.gov.cn"">首页</a>
										 >>
					<span><a href=""https://xqctk.jtys.sz.gov.cn/gbl/index.html"">通知公告</a> </span>
					</dd>
			<dt class=""float_right""><a href=""https://xqctk.jtys.sz.gov.cn"" class=""link_orange"">返回首页</a></dt>
		</dl>
		<!-- 当前位置end-->
		
		<!-- 中间主要内容 start-->
		<div class=""main_content"">
			<div class=""main_content_bg "">
			  <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"">
				
				<tr>
				  <td class=""align_ceter"">
				  <div class=""blist"">		
				        <dl>
							<dd>
								<a class=""text"" href=""https://xqctk.jtys.sz.gov.cn/gbl/2015310/1425979869874_1.html"" target=""_blank"" rel=""noopener noreferrer"">深圳市2015年第1期小汽车增量指标竞价情况</a>
								<span class=""date"">2015-03-16</span>
							</dd>
							<dd>
								<a class=""text"" href=""https://xqctk.jtys.sz.gov.cn/gbl/2015310/1425975715942_1.html"" target=""_blank"" rel=""noopener noreferrer"">深圳市2015年第1期小汽车增量指标摇号结果公告</a>
								<span class=""date"">2015-03-15</span>
							</dd>
							<dd>
								<a class=""text"" href=""https://xqctk.jtys.sz.gov.cn/gbl/2015216/1424077658496_1.html"" target=""_blank"" rel=""noopener noreferrer"">深圳市2015年第1期小汽车增量指标摇号公告</a>
								<span class=""date"">2015-02-16</span>
							</dd>
							<dd>
								<a class=""text"" href=""https://xqctk.jtys.sz.gov.cn/gbl/2015212/1423704050477_1.html"" target=""_blank"" rel=""noopener noreferrer"">深圳市2015年第1期小汽车增量指标竞价公告</a>
								<span class=""date"">2015-02-12</span>
							</dd>
							<dd>
								<a class=""text"" href=""https://xqctk.jtys.sz.gov.cn/gbl/2015212/1423703493059_1.html"" target=""_blank"" rel=""noopener noreferrer"">关于2015年深圳市小汽车增量指标配置数量的公告</a>
								<span class=""date"">2015-02-12</span>
							</dd>
							<dd>
								<a class=""text"" href=""https://xqctk.jtys.sz.gov.cn/gbl/2015123/1421968489233_1.html"" target=""_blank"" rel=""noopener noreferrer"">深圳市小汽车指标网上申请开通</a>
								<span class=""date"">2015-01-23</span>
							</dd>
						</dl>	
					</div>	
				</td>
				</tr>
				<tr>
				  <td></td>
				</tr>
				<!-- 翻页 开始-->
				<tr>
				  <td>
					<table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" style=""margin-top:10px; width: 90%;	margin-left: 5%;	margin-right: 5%;"">
			  <tr>
				<td></td>
				<td>
					<div class=""pageturn2"">
						<b>共<span class=""f_orange"">39</span>页/共<span class=""f_orange"">766</span>条</b>
						  <span>跳转到<input name=""pageNumber"" id=""pageNumber"" type=""text""  />页<a id=""jump"" href=""#"">跳转</a></span>
							<span></span>
					</div>
					<div class=""pageturn"">
							<ul>
								<li class=""prev disabled""><a href=""https://xqctk.jtys.sz.gov.cn/gbl/index_38.html"">前一页</a></li>
								<!--<li><a >跳转到<input name="""" type=""text"" style=""width:30px; height:12px; line-height:12px;"" />页</a></li>
								<li><a href=""#"">跳转</a></li>-->
										<li><a href=""https://xqctk.jtys.sz.gov.cn/gbl/index_37.html"">37</a></li>
										<li><a href=""https://xqctk.jtys.sz.gov.cn/gbl/index_38.html"">38</a></li>
										<li class=""active""><a href=""https://xqctk.jtys.sz.gov.cn/gbl/index_39.html"" >39</a></li>
								<li><a >下一页 </a></li>
							</ul>
							
						</div>
				</td>
			  </tr>
			</table>
				  </td>
				</tr><!-- 翻页 end-->
				
			  </table>
			</div>
		</div>
			<!-- 中间主要内容 end-->
		
	</div>
	<!-- content end-->
</div>

<div class=""subbg_b""></div>

<div id=""foot"">Copyright ？ 2015 深圳市小汽车指标调控管理中心   备案号：粤ICP备 06038972号
</div>

</body>
</html>";
                #endregion

                Console.WriteLine("===== 正则表达式提取（开箱即用） =====");
                var res = Method1_Regex(Request);

                //休眠10秒
                Thread.Sleep(10000);

                foreach (var item in res)
                {
                    //Console.WriteLine($"     {item}");
                    string PageRequest = await CallApi(item.href);
                    var Pageres = Method1_Regex(PageRequest);

                    // 定义正则表达式
                    string pattern = @"/gbl/(\d{8})/";

                    // 执行匹配
                    Match match = Regex.Match(item.href, pattern);

                    string day = "";
                    if (match.Success)
                    {
                        // Groups[1] 代表第一个括号捕获组的内容，即 20250926
                        string dateStr = match.Groups[1].Value;
                        Console.WriteLine($"提取到的时间字符串: {dateStr}");

                        // 如果需要转换成 DateTime 对象方便后续处理
                        DateTime date = DateTime.ParseExact(dateStr, "yyyyMMdd", null);
                        Console.WriteLine($"转换后的日期对象: {date.ToString("yyyy-MM-dd")}");

                        day = date.ToString("yyyyMM");
                    }
                    else
                    {
                        Console.WriteLine("未在URL中找到匹配的时间格式");
                        continue;
                    }

                    int num = 0;
                    foreach (var Pageresitem in Pageres)
                    {
                        string PDFName = $"{day}{Pageresitem.linkText}.pdf";
                        await DownloadPdfAsync(Pageresitem.href, $"{savePath}\\{PDFName}");
                        //休眠10秒
                        Thread.Sleep(10000);
                        num++;
                    }
                    //休眠10秒
                    Thread.Sleep(10000);
                }
            }
            //return;
        }

        /// <summary>
        /// 调用API
        /// </summary>
        private static async Task<string> CallApi(string apiUrl)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.Timeout = TimeSpan.FromSeconds(30);

                // 设置请求头
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36");

                try
                {
                    var response = await httpClient.GetAsync(apiUrl);

                    // 检查响应状态
                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        //Console.WriteLine($"API调用成功！响应：{responseContent}");
                        return responseContent;
                        // 可以在这里解析响应并处理后续逻辑
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
        /// 方法一：正则表达式匹配包含"结果"的 a 标签并提取 href
        /// 这是对你原始思路 Request.IndexOf("结果") 的升级版
        /// </summary>
        static List<UrlInfo> Method1_Regex(string html)
        {
            // 正则说明：
            // <a\s+[^>]*href=""([^""]*)""[^>]*>  -> 匹配 <a> 标签并捕获 href 值
            // (.*?)                               -> 非贪婪捕获标签内的文本
            // </a>                                -> 匹配闭合标签
            string pattern = @"<a\s+[^>]*href=""([^""]*)""[^>]*>(.*?)</a>";

            var matches = Regex.Matches(html, pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);

            var results = new List<UrlInfo>();
            foreach (Match match in matches)
            {
                string href = match.Groups[1].Value;
                string linkText = match.Groups[2].Value; ;

                // 定义正则：匹配 <span ...> 和 </span> 之间的内容
                string spanpattern = @"<span[^>]*>([\s\S]*?)</span>";
                Match spanmatch = Regex.Match(match.Groups[2].Value, spanpattern, RegexOptions.IgnoreCase);

                if (spanmatch.Success)
                {
                    // 匹配成功，返回提取到的内容
                    linkText=spanmatch.Groups[1].Value; ;
                }

                // 核心判断：链接文本中是否包含"结果"
                if (linkText.Contains("结果"))
                {
                    UrlInfo urlInfo = new UrlInfo();
                    urlInfo.href = href;
                    urlInfo.linkText=linkText;
                    Console.WriteLine($"  [匹配] href={href}  text={linkText}");

                    results.Add(urlInfo);
                }
            }

            Console.WriteLine($"\n  => 共找到 {results.Count} 个包含'结果'的链接");
            //foreach (var r in results)
            //{
            //    Console.WriteLine($"     {r}");
            //}

            return results;
        }

        // 建议将 HttpClient 作为单例复用，避免端口耗尽
        //private static readonly HttpClient client = new HttpClient();

        public static async Task DownloadPdfAsync(string url, string savePath)
        {
            using (var httpClient = new HttpClient())
            {
                // 使用 ResponseHeadersRead 选项，先获取响应头，再流式读取内容
                using var response = await httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode(); // 确保请求成功

                // 创建文件流，将网络流直接写入本地文件
                await using var stream = await response.Content.ReadAsStreamAsync();
                await using var fileStream = new FileStream(savePath, FileMode.Create, FileAccess.Write, FileShare.None);

                await stream.CopyToAsync(fileStream);
                Console.WriteLine($"PDF文件已保存至：{savePath}");
            }
        }


        //读取本地PDF识别文件
        public static void RecognizePDFcontent()
        {
            //string savePath = @"C:\Users\liusi\Desktop\摇号数据\201504单位电动小汽车摇号指标配置结果.pdf";

            string folderPath = @"C:\Users\liusi\Desktop\摇号数据";
            // 检查文件夹是否存在
            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine($"文件夹不存在：{folderPath}");
                return;
            }

            // 获取文件夹中所有支持的图片格式
            string[] imageExtensions = { "*.pdf"};
            List<string> Files = new List<string>();

            foreach (string extension in imageExtensions)
            {
                try
                {
                    string[] files = Directory.GetFiles(folderPath, extension, SearchOption.AllDirectories);
                    Files.AddRange(files);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"搜索 {extension} 文件时出错：{ex.Message}");
                }
            }

            if (Files.Count == 0)
            {
                Console.WriteLine($"文件夹中没有找到文件：{folderPath}");
                return;
            }

            using var workbook = new XLWorkbook();

            foreach (var itemPath in Files)
            {
                string pdfPath = itemPath;
                if (!File.Exists(pdfPath))
                {
                    Console.WriteLine("文件不存在：" + pdfPath);
                    return;
                }

                bool Status = true;
                if (pdfPath.IndexOf("个人") >= 0)
                {
                    Status = true;
                }
                else if(pdfPath.IndexOf("单位") >= 0)
                {
                    Status = false;
                }
                else
                {
                    //跳过
                    Console.WriteLine("--------------------------------------------------------------------------------------------------");
                    Console.WriteLine($"{pdfPath}没有标识，跳过");
                    Console.WriteLine("--------------------------------------------------------------------------------------------------");
                    continue;
                }

                Console.WriteLine("--------------------------------------------------------------------------------------------------");
                Console.WriteLine($"--{pdfPath}--");
                Console.WriteLine("--------------------------------------------------------------------------------------------------");

                using var document = PdfDocument.Open(pdfPath);
                //正文是否开始
                bool Start = false;

                string No = "";
                string Desc = "";
                string Date = "";
                string Time = "";
                string CodeCount = "";
                string MetricCount = "";
                string InitValue = "";

                foreach (var page in document.GetPages())
                {
                    //Console.WriteLine($"===== 第 {page.Number} 页 =====");
                    var letters = page.Letters;

                    // 按 Y 坐标分组，同一行归到一起
                    var lines = letters
                        .GroupBy(l => Math.Round(l.Location.Y, 1))
                        .OrderByDescending(g => g.Key)
                        .Select(g => string.Concat(
                            g.OrderBy(l => l.Location.X).Select(l => l.Value)
                        ))
                        .ToList();

                    foreach (var line in lines)
                    {
                        string trimmed = line.Trim();
                        if (string.IsNullOrEmpty(trimmed))
                            continue;

                        //第一页
                        if (page.Number == 1 && Start == false)
                        {
                            //本期编号：201504
                            if (trimmed.IndexOf("编号") > 0)
                            {
                                string  value = trimmed.Substring(trimmed.IndexOf("：") + 1, (trimmed.Length - trimmed.IndexOf("：")) - 1);
                                No = value;
                                Console.WriteLine("编号：" + value);
                                continue;
                            }

                            //本期描述：2015年04月单位指标配置
                            if (trimmed.IndexOf("描述") > 0)
                            {
                                string value = trimmed.Substring(trimmed.IndexOf("：") + 1, (trimmed.Length - trimmed.IndexOf("：")) - 1);
                                Desc = value;
                                Console.WriteLine("描述：" + value);
                                continue;
                            }

                            //本期指标配置日期：2015-04-27
                            if (trimmed.IndexOf("配置日期") > 0)
                            {
                                string value = trimmed.Substring(trimmed.IndexOf("：") + 1, (trimmed.Length - trimmed.IndexOf("：")) - 1);
                                Date = value;
                                Console.WriteLine("配置日期：" + value);
                                continue;
                            }
                            //数据生成时间：2015-04-27 15:43:47
                            if (trimmed.IndexOf("时间") > 0)
                            {
                                string value = trimmed.Substring(trimmed.IndexOf("：") + 1, (trimmed.Length - trimmed.IndexOf("：")) - 1);
                                Time = value;
                                Console.WriteLine("生成时间：" + value);
                                continue;
                            }
                            //有效单位申请编码总数：28
                            if (trimmed.IndexOf("编码总数") > 0)
                            {
                                string value = trimmed.Substring(trimmed.IndexOf("：") + 1, (trimmed.Length - trimmed.IndexOf("：")) - 1);
                                CodeCount = value;
                                Console.WriteLine("编码总数：" + value);
                                continue;
                            }

                            //配置单位普通指标总数：787
                            if (trimmed.IndexOf("指标总数") > 0)
                            {
                                string value = trimmed.Substring(trimmed.IndexOf("：") + 1, (trimmed.Length - trimmed.IndexOf("：")) - 1);
                                MetricCount = value;
                                Console.WriteLine("指标总数：" + value);
                                continue;
                            }

                            //指标配置初始值：222666
                            if (trimmed.IndexOf("配置初始值") > 0)
                            {
                                string value = trimmed.Substring(trimmed.IndexOf("：") + 1, (trimmed.Length - trimmed.IndexOf("：")) - 1);
                                InitValue = value;
                                Console.WriteLine("配置初始值：" + value);
                                continue;
                            }
                        }


                        //continue;
                        //判断是否开始详细数据
                        if (trimmed.IndexOf("序号") >= 0 && trimmed.IndexOf("申请编码") > 0 && (trimmed.IndexOf("名称") > 0 || trimmed.IndexOf("姓名") > 0))
                        {
                            Start = true;
                            Console.WriteLine("详细数据开始识别");

                            int sheetNo = 1;
                            if (!Status)
                            {
                                sheetNo = 2;
                            }

                            // 直接调用静态方法写入 Sheet1
                            AppendRowToSheet(workbook, sheetNo, new object[]
                            {
                                No,
                                Desc,
                                Date,
                                Time,
                                CodeCount,
                                MetricCount,
                                InitValue
                            });

                            continue;
                        }

                        if (Start)
                        {
                            //使用正则表达式分割
                            //string[] context = Regex.Split(trimmed, @"\s+");

                            // 使用 Split 并移除空项
                            //StringSplitOptions枚举  RemoveEmptyEntries 可以自动忽略连续的空格，只保留有实际内容的部分。
                            string[] parts = trimmed.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                            if (parts.Length >= 3)
                            {
                                string id = parts[0];           // 1
                                string code = parts[1];         // 018087978944349
                                string name = parts[2];         // 深圳市XX投资发展有限公司
                                Console.WriteLine($"序号: {id}, 编码: {code}, 名称: {name}");

                                int sheetNo = 3;
                                if (!Status)
                                {
                                    sheetNo = 4;
                                }

                                // 直接调用静态方法写入 Sheet1
                                AppendRowToSheet(workbook, sheetNo, new object[]
                                {
                                   No,
                                   id,
                                   code,
                                   name
                                });
                            }


                        }
                        // 这里做逐行分析
                        //Console.WriteLine(trimmed);
                    }
                }
            }
            // 5. 最后保存
            workbook.SaveAs(@$"{folderPath}\Result.xlsx");
        }



        #region 写入Excel
        /// <summary>
        /// 写入第 1/2 个 Sheet：编号、描述、配置日期、生成时间、编码总数、指标总数、配置初始值
        /// </summary>
        private static readonly string[] Sheet1Headers = new[]
        {
        "编号", "描述", "配置日期", "生成时间", "编码总数", "指标总数", "配置初始值"
    };

        /// <summary>
        /// 写入第 3/4 个 Sheet：编号、序号、编码、名称
        /// </summary>
        private static readonly string[] Sheet3Headers = new[]
        {
        "编号", "序号", "编码", "名称"
    };

        /// <summary>
        /// 向指定的 Sheet 追加一行数据。如果 Sheet 不存在或没有表头，会自动初始化。
        /// </summary>
        /// <param name="workbook">当前的 XLWorkbook 实例</param>
        /// <param name="sheetIndex">Sheet 编号（1-4）</param>
        /// <param name="values">要写入的数据行</param>
        public static void AppendRowToSheet(XLWorkbook workbook, int sheetIndex, IEnumerable<object> values)
        {

            if (workbook == null) throw new ArgumentNullException(nameof(workbook));
            if (values == null) throw new ArgumentNullException(nameof(values));


            // 决定使用哪套表头
            string[] headers;

            if (sheetIndex == 1 || sheetIndex == 2)
            {
                headers = Sheet1Headers;
            }
            else if (sheetIndex == 3 || sheetIndex == 4)
            {
                headers = Sheet3Headers;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(sheetIndex), "当前只支持 Sheet1~Sheet4。");
            }

            // 2. 获取或创建工作表
            string sheetName = $"Sheet{sheetIndex}";
            IXLWorksheet worksheet;

            if (!workbook.Worksheets.TryGetWorksheet(sheetName, out worksheet))
            {
                worksheet = workbook.Worksheets.Add(sheetName);
            }

            // 3. 检查并初始化表头（如果第一行是空的，就写入表头）
            if (worksheet.Cell(1, 1).IsEmpty())
            {
                for (int col = 0; col < headers.Length; col++)
                {
                    worksheet.Cell(1, col + 1).Value = headers[col];
                    // 可选：给表头加个粗体
                    worksheet.Cell(1, col + 1).Style.Font.Bold = true;
                }
            }

            // 4. 计算下一行的行号
            // LastRowUsed() 可能会比较慢，如果数据量极大，建议自己在外部维护行号
            int nextRow = worksheet.LastRowUsed()?.RowNumber() + 1 ?? 2;

            // 5. 写入数据
            var dataList = values.ToList();
            for (int col = 0; col < dataList.Count; col++)
            {
                // 防止列数超过表头太多，也可以不限制
                worksheet.Cell(nextRow, col + 1).Value = dataList[col]?.ToString() ?? string.Empty;
            }
        }
        #endregion

    }

    public class UrlInfo
    {

        public string href { get; set; }
        public string linkText { get; set; }
    }
}
