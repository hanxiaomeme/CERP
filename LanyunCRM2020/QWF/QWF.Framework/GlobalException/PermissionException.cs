﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWF.Framework.GlobalException
{
    public class PermissionException:Exception
    {
        public PermissionException(string message)
            : base(message)
        {

        }
    }
}
