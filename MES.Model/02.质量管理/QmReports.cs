using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanyunMES.Entity 
{
   
    public class QmReports: NotifyPropertyChanged
    {
        public QmReports()
        {
 
        }

        private int _POIDs;
        private decimal _arrQty;
        private decimal _qmQty;
        private bool _bChecked;
        private string _cInvCode;
        private string _cFree1;
        private string _cComUnitName;
        private string _remark;
        private string _cPOID;
        private decimal _stockInQty;
        private bool _bQualify;
        private string _cPosCode;
        private string _cPosName;

        public string Guid { get; set; }
        public int AutoId { get; set; }

        /// <summary>
        /// 采购订单行ID
        /// </summary>
        public int POIDs
        {
            get { return _POIDs; }
            set
            {
                if (_POIDs != value)
                {
                    _POIDs = value;
                    OnPropertyChanged("POIDs");
                }
            }
        }

        public bool bQualify
        {
            get
            {
                return _bQualify;
            }
            set
            {
                _bQualify = value;
                OnPropertyChanged("bQuality");
            }
        }

        /// <summary>
        /// 采购订单号
        /// </summary>
        public string cPOID
        {
            get { return _cPOID; }
            set
            {
                _cPOID = value;
                OnPropertyChanged("cPOID");
            }
        }

        /// <summary>
        /// 货位
        /// </summary>
        public string cPosCode
        {
            get
            {
                return _cPosCode;
            }
            set
            {
                _cPosCode = value;
                OnPropertyChanged(cPosCode);
            }
        }

        /// <summary>
        /// 货位名称
        /// </summary>
        public string cPosName
        {
            get
            {
                return _cPosName;
            }
            set
            {
                _cPosName = value;
                OnPropertyChanged(cPosName);
            }
        }

        public string cInvCode
        {
            get { return _cInvCode; }
            set
            {
                _cInvCode = value;
                OnPropertyChanged("cInvCode");
            }
        }

        /// <summary>
        /// 自由项
        /// </summary>
        public string cFree1
        {
            get { return _cFree1; }
            set
            {
                _cFree1 = value;
                OnPropertyChanged("cFree1");
            }
        }

        /// <summary>
        /// 单位
        /// </summary>
        public string cComUnitName
        {
            get { return _cComUnitName; }
            set
            {
                _cComUnitName = value;
                OnPropertyChanged("cComUnitName");
            }
        }


        /// <summary>
        /// 到货数量
        /// </summary>
        public decimal arrQty
        {
            get { return _arrQty; }
            set
            {
                _arrQty = value;
                OnPropertyChanged("arrQty");
            }
        }

        /// <summary>
        /// 报检数量
        /// </summary>
        public decimal qmQty
        {
            get { return _qmQty; }
            set
            {
                _qmQty = value;
                OnPropertyChanged("qmQty");
            }
        }

        public decimal stockInQty
        {
            get { return _stockInQty; }
            set
            {
                _stockInQty = value;
                OnPropertyChanged("stockInQty");
            }
        }

        public string remark
        {
            get { return _remark; }
            set
            {
                _remark = value;
                OnPropertyChanged("remark");
            }
        }

        public bool bChecked
        {
            get { return _bChecked; }
            set
            {
                _bChecked = value;
                OnPropertyChanged("bChecked");
            }
        }

        /// <summary>
        /// U8采购入库单标识
        /// </summary>
        public int U8VouchId { get; set; }

        /// <summary>
        /// U8采购入库单号
        /// </summary>
        public string U8RDCode { get; set; }
    }
}
