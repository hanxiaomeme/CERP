using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWF.CRM.ADO
{
    public class UI_ListPageModel
    {
        public int PageIndex;
        public int PageSize;
        public string TableRelation;
        public string Fields;
        public string Where;
        public string OrderBy;
    }
}
