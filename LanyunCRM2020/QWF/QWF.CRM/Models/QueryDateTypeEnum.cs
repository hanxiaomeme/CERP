using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWF.CRM.Models
{
    public enum QueryDateTypeEnum
    {
        _1_等于 = 1,
        _2_大于 = 2,
        _3_大于等于 = 3,
        _4_小于 = 4,
        _5_小于等于 = 5,

        _10_今天 = 10,
        _11_昨天 = 11,
        _12_明天 = 12,
        _20_本周 = 20,
        _21_上一周 = 21,
        _22_下一周 = 22,
        _30_本月 = 30,
        _31_上一月 = 31,
        _32_下一月 = 32,
        _40_今年 = 40,
        _41_去年 = 41,
        _42_明年 = 42,

        _50_最近xx天 = 50,
        _51_之后xx天 = 51,

    }
}
