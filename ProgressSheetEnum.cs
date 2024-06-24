using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public enum ProgressSheetEnum
    {
    }

    public enum ProgressSheetStatusEnum
    {
        /// <summary>
        /// 草稿
        /// </summary>
        Draft = 10,

        /// <summary>
        /// 进行中
        /// </summary>
        WIPPharmacy = 20,

        /// <summary>
        /// 已完成
        /// </summary>
        Completed = 30
    }
}
