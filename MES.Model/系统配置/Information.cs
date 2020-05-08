using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanyunMES.Entity
{
    public class Information
    {
        public static User UserInfo { get; set; }

        public static DataScale DataScale { get; set; }

        public static UA_Account AccInfo { get; set; }

        public static DateTime BusiDate { get; set; }

        public static int AccYear { get; set; }

        public static int AccPeriod { get; set; }

    }
}
