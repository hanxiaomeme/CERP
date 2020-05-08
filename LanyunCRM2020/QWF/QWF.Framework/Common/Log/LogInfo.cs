using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWF.Framework.Common
{
    internal class LogInfo
    {
        private string directory = string.Empty;
            
        public LogTypeEnum Type { get; set; }
        public string Message { get; set; }

        public string Directory
        {
            get
            {
                return directory;
            }
            set
            {
                directory = value;
            }
        }

    }
}
