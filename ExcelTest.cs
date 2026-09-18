using ClosedXML.Excel;

namespace Test
{
    public static class ExcelTest
    {
        #region 读取Excel 补充超链接
        public static void LoadExcel()
        {

            var filePath = @"C:\Users\liusi\Desktop\PRD-Report\NEW\20260428-20260528.xlsx";
            var imageFolder = @"C:\Users\liusi\Desktop\PRD-Report\NEW\Image";


            // 打开文件
            using var wb = new XLWorkbook(filePath); // XLWorkbook 就是它
            var ws = wb.Worksheet("Sheet1");

            int rowCount = ws.RowsUsed().Count();

            for (int row = 2; row <= rowCount; row++)  // 第2行开始（跳过表头）
            {
                // 读取 A 列编号 ✅
                string TreeObjectId = ws.Cell(row, 10).GetString().Trim();

                if (string.IsNullOrEmpty(TreeObjectId)) continue;

                // 找 [id] 开头的图片
                string findName = $"[{TreeObjectId}]";
                string found = FindImage(imageFolder, findName);



                if (!string.IsNullOrWhiteSpace(found))
                {
                    Console.WriteLine("No." + row + ":存在文件，补充数据。");
                    //写入文件名
                    ws.Cell(row, 12).Value = found;

                    //写入超链接（动态 L 列）
                    // 🔥 正确公式：=HYPERLINK("Image\"&L2&"",L2)  自动变 L2、L3、L4...
                    ws.Cell(row, 13).FormulaA1 = $"=HYPERLINK(\"Image\\\"&L{row}&\"\", L{row})";
                }
                else
                {
                    Console.WriteLine("No." + row + ":不存在文件,跳过。");
                }

                //if (row>=260)
                //{
                //    break;
                //}
            }

            string targetPath = Path.Combine(Path.GetDirectoryName(filePath),  // 取原文件所在目录
               Path.GetFileNameWithoutExtension(filePath) + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfffffff") + ".xlsx"  // 原名_结果
             );

            wb.SaveAs(targetPath);
            Console.WriteLine("完成！");
        }

        static string FindImage(string folder, string startWith)
        {
            if (!Directory.Exists(folder))
                return null;

            var files = Directory.GetFiles(folder, $"{startWith}*", SearchOption.TopDirectoryOnly);
            return files.Length > 0 ? Path.GetFileName(files[0]) : null;
        }
        #endregion
    }
}
