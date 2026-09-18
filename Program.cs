namespace Test
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            // ========== 按需取消注释运行 ==========

            #region QR码/条码识别 — QRCodeTest.cs, OpenCvTest.cs
            //ZXing二维码识别（批量图片识别QR码+条码，支持多策略预处理）
            //QRCodeTest.Zxing();
            //OpenCV WeChat二维码识别（批量图片识别，支持重试+切块识别）
            //OpenCvTest.OpenCv();
            #endregion

            #region 图片处理 — MiscTest.cs, FileNameTest.cs
            //图片路径处理（FileStore路径解析与保存）
            //MiscTest.ChangeImages();
            //移除文件名非法字符
            //FileNameTest.ChangeImageName();
            #endregion

            #region OCR识别与签名检测 — OcrFormIdTest.cs, OcrSignatureTest.cs
            //FormId OCR识别结果修正（修复OCR常见错误如0→O, 1→I等）
            //OcrFormIdTest.OCRChange();
            //OCR API签名区域识别（调用OCR API定位病人/医生签名区域并截取）
            //await OcrSignatureTest.OCRImage();
            //批量签名检测测试（遍历文件夹检测签名是否存在）
            //string folderPath = @"C:\Users\liusi\Desktop\Form\check";
            //OcrSignatureTest.TestSignatureDetection(folderPath);
            //单张签名检测
            //Console.WriteLine(OcrSignatureTest.HasSignature("C:\\Users\\liusi\\Desktop\\signature\\doctor_signature-4b0dbda9-0bc2-4c65-b86d-021880a1ac6f.jpg"));
            #endregion

            #region 文件下载 — DownloadTest.cs
            //通过浏览器批量下载文件
            //DownloadTest.DownLoad();
            //通过API批量下载文件（支持并发+完整性校验）
            //await DownloadTest.DownLoadByFileByApi();
            #endregion

            #region SMB/SFTP — SmbTest.cs
            //SMB文件读取（监听共享文件夹，抢锁+处理+移动）
            //SmbTest.ReadSmbFile();
            //SFTP写入测试
            //SmbTest.TestSftpWrite();
            #endregion

            #region 文件名校验 — FileNameTest.cs
            //文件名格式校验（DateTime_staffId_userAd_locationCode）
            //FileNameTest.CheckFileName();
            #endregion

            #region IAM Smart电子签名 — EsignTest.cs
            //IAM Smart签名流程（创建签名→轮询回调→签署PDF）
            //await EsignTest.esignAsync();
            //本地PDF签名
            //await EsignTest.EsignSignLocalPdfAsync();
            //文件哈希计算测试
            //EsignTest.TestFileHash();
            //HTML导出为PDF（Puppeteer截图）
            //await EsignTest.htmltopdf();
            //重试机制测试
            //await EsignTest.retry();
            //TXT转Decimal读取
            //EsignTest.ReadTxtAndConvertToDecimal(@"E:\xxx.txt");
            //数学计算测试
            //EsignTest.checkMath();
            #endregion

            #region PDF合并图片（内存优化演进） — PdfMergeTest.cs
            //详见PdfMergeTest.cs中的版本演进注释
            //PdfMergeTest.LoadingImgStreamLowMemoryParallel(); // 最终选用方案
            #endregion

            #region Excel处理 — ExcelTest.cs
            //读取Excel并补充超链接（匹配图片文件名写入超链接）
            //ExcelTest.LoadExcel();
            #endregion

            #region Crypto加密 — CryptoTest.cs
            //string password = "123";
            //password = CryptoTest.GetMD5(password).ToLower();
            //Console.WriteLine("MD5:" + password);
            //string finalBase64 = CryptoTest.EncryptPassword(password);
            //Console.WriteLine("代码生成的结果: " + finalBase64);
            //Console.WriteLine("文档期望的结果: oZU99ouWEbv/...");
            #endregion

            #region 图片完整性检查 — ImageCheckTest.cs
            //批量检查图片文件完整性（Magic Bytes + 实际解码校验）
            //ImageCheckTest.CheckImg();
            #endregion

            #region FormId/枚举/JSON测试 — MiscTest.cs
            //MMMS订单号生成测试
            //MiscTest.MMMSCreateOrderNo();
            //MMMS枚举测试
            //MiscTest.MMMSEnum();
            //JSON解析测试
            //var jsonResponse = MiscTest.ReadTextFile(@"D:\p2.txt");
            //string structuredQuestionsJson = MiscTest.RemoveAllTags(jsonResponse);
            //structuredQuestionsJson = MiscTest.ExtractJsonContent(structuredQuestionsJson);
            #endregion

            #region 文件名拆分测试 — FileNameTest.cs
            //string test1 = "20251120_1001_john_doe_001";
            //string[] result1 = FileNameTest.SplitFileName(test1);
            //Console.WriteLine(result1 != null ? $"拆分结果1: {string.Join(", ", result1)}" : "格式不符合");
            #endregion

            #region Form数据清理 — MiscTest.cs
            //清理拆分Form的CSV数据（按语言标签筛选）
            //MiscTest.FormCsvCleaner();
            #endregion

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
