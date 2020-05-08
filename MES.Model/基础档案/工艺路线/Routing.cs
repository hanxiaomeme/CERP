using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LanyunMES.Entity
{
    public class Routing
    {

        public int RoutingId { get; set; }
        public string RoutingCode { get; set; }
        public string RoutingName { get; set; }

        public DataTable DtRoutings { get; set; }
    }
}
