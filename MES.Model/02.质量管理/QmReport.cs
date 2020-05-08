using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace LanyunMES.Entity
{
    public class QmReport : NotifyPropertyChanged
    {
        public QmReport()
        {
            Details = new List<QmReports>();
        }

        private string _QMCode;
        private DateTime _dDate;
        private string _cMaker;
        private string _cVenCode;
        private string _cModifier;
        private DateTime _dModifyDate;
        private string _cAuditPsn;
        private DateTime _dAuditDate;
        private int _iState;

        public string Guid { get; set; }

        /// <summary>
        /// 单据号
        /// </summary>
        public string QMCode
        {
            get { return _QMCode; }
            set
            {
                if (_QMCode != value)
                {
                    this._QMCode = value;
                    OnPropertyChanged("QMCode");
                }
            }
        }
        /// <summary>
        /// 单据日期
        /// </summary>
        public DateTime dDate
        {
            get { return _dDate; }
            set
            {
                if (_dDate != value)
                {
                    _dDate = value;
                    OnPropertyChanged("dDate");
                }
            }
        }

        /// <summary>
        /// 供应商编码
        /// </summary>
        public string cVenCode
        {
            get { return _cVenCode; }
            set
            {
                if(_cVenCode != value)
                {
                    _cVenCode = value;
                    OnPropertyChanged("cVenCode");
                }
            }
        }

   
        public string cMaker
        {
            get { return _cMaker; }
            set
            { if (_cMaker != value)
                {
                    _cMaker = value;
                    OnPropertyChanged("cMaker");
                }
            }

        }
        public string cModifier
        {
            get
            {
                return _cModifier;
            }
            set
            {
                if(_cModifier != value)
                {
                    _cModifier = value;
                    OnPropertyChanged("cModifier");
                }
            }
        }
        public DateTime dModifyDate
        {
            get
            {
                return _dModifyDate;
            }
            set
            {
                if(_dModifyDate != value)
                {
                    _dModifyDate = value;
                    OnPropertyChanged("dModifyDate");
                }
            }
        }

        public string cAuditPsn
        {
            get
            {
                return _cAuditPsn;
            }
            set
            {
                if (_cAuditPsn != value)
                {
                    _cAuditPsn = value;
                    OnPropertyChanged("cAuditPsn");
                }
            }
        }

        public DateTime dAuditDate
        {
            get
            {
                return _dAuditDate;
            }
            set
            {
                if (_dAuditDate != value)
                {
                    _dAuditDate = value;
                    OnPropertyChanged("dAuditDate");
                }
            }
        }

        public int iState
        {
            get
            {
                return _iState;
            }
            set
            {
                if (_iState != value)
                {
                    _iState = value;
                    OnPropertyChanged("iState");
                }
            }
        }

        public string cMemo
        {
            get { return _cMemo; }
            set
            {
                _cMemo = value;
                OnPropertyChanged("cMemo");
            }
        }

        public List<QmReports> Details;
        private string _cMemo;
    }
}
