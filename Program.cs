using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            // See https://aka.ms/new-console-template for more information
            //Console.WriteLine("Hello, World!");

            #region MMMS[Progress Sheet]订单号生成测试
            //订单号模板
            string initialNumber = "PS00000";

            //获取数据库中最大的订单号
            string maxCaseNo = "PS00001";

            if (maxCaseNo != null)
            {
                initialNumber = maxCaseNo;
            }

            //去掉前两位
            string numberPart = initialNumber[2..];

            //转换为int类型
            int number = int.Parse(numberPart);
            //把订单号加1
            number++;

            //补齐前面的空缺0,位数补齐
            string incrementedNumber = string.Concat(initialNumber.AsSpan(0, 2), number.ToString("D5"));

            //得到最新的订单号
            string caseNo = incrementedNumber;

            //输出订单号
            Console.WriteLine(caseNo);
            Console.WriteLine(numberPart);
            #endregion

            //Console.ReadKey();
        }
    }
}


