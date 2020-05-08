﻿using System;
namespace LanyunMES.Entity
{
    /// <summary>
    /// SO_SODetails:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class SO_SODetails
    {
        #region Model

        public string cInvName { get; set; }
        public string cInvStd { get; set; }
        public string cInvCCode { get; set; }
        public string cInvCName { get; set; }
        public string cComUnitName { get; set; }
        private int _autoid;
        private string _csocode;
        private string _cinvcode;
        private DateTime? _dpredate;
        private decimal? _iquantity = 0M;
        private decimal? _inum = 0M;
        private decimal? _iquotedprice = 0M;
        private decimal? _iunitprice = 0M;
        private decimal? _itaxunitprice = 0M;
        private decimal? _imoney = 0M;
        private decimal? _itax = 0M;
        private decimal? _isum = 0M;
        private decimal? _idiscount = 0M;
        private decimal? _inatunitprice = 0M;
        private decimal? _inatmoney = 0M;
        private decimal? _inattax = 0M;
        private decimal? _inatsum = 0M;
        private decimal? _inatdiscount = 0M;
        private decimal? _ifhnum = 0M;
        private decimal? _ifhquantity = 0M;
        private decimal? _ifhmoney = 0M;
        private decimal? _ikpquantity = 0M;
        private decimal? _ikpnum = 0M;
        private decimal? _ikpmoney = 0M;
        private string _cmemo;
        private string _cfree1;
        private string _cfree2;
        private int? _bfh;
        private int _isosid = 0;
        private decimal? _kl = 100;
        private decimal? _kl2 = 100;
        private decimal? _itaxrate = 0M;
        private string _cdefine22;
        private string _cdefine23;
        private string _cdefine24;
        private string _cdefine25;
        private decimal? _cdefine26;
        private decimal? _cdefine27;
        private string _citemcode;
        private string _citem_class;
        private string _citemname;
        private string _citem_cname;
        private string _cfree3;
        private string _cfree4;
        private string _cfree5;
        private string _cfree6;
        private string _cfree7;
        private string _cfree8;
        private string _cfree9;
        private string _cfree10;
        private decimal? _iinvexchrate;
        private string _cunitid;
        private int _id;
        private string _cdefine28;
        private string _cdefine29;
        private string _cdefine30;
        private string _cdefine31;
        private string _cdefine32;
        private string _cdefine33;
        private int? _cdefine34;
        private int? _cdefine35;
        private DateTime? _cdefine36;
        private DateTime? _cdefine37;
        private decimal? _fpurquan;
        private decimal? _fsalecost;
        private decimal? _fsaleprice;
        private string _cquocode;
        private int? _iquoid;
        private string _cscloser;
        private DateTime? _dpremodate;
        private int? _irowno;
        private int? _icusbomid;
        private decimal? _imoquantity;
        private string _ccontractid;
        private string _ccontracttagcode;
        public Guid? cContractRowGuid { get; set; }
        private int? _ippartseqid;
        private int? _ippartid;
        private decimal? _ippartqty;
        private string _ccusinvcode;
        private string _ccusinvname;
        private decimal? _iprekeepquantity;
        private decimal? _iprekeepnum;
        private decimal? _iprekeeptotquantity;
        private decimal? _iprekeeptotnum;
        private DateTime? _dreleasedate;
        private decimal? _fcusminprice;
        private decimal? _fimquantity;
        private decimal? _fomquantity;
        private bool _ballpurchase;
        private decimal? _finquantity;
        private decimal? _icostquantity;
        private decimal? _icostsum;
        private decimal? _foutquantity;
        private decimal? _foutnum;
        private decimal? _iexchsum;
        private decimal? _imoneysum;
        private DateTime? _dufts;
        private int? _iaoids;
        private string _cpreordercode;
        private decimal? _fretquantity;
        private decimal? _fretnum;
        private DateTime? _dbclosedate;
        private DateTime? _dbclosesystime;
        private bool _borderbom = false;
        private int? _borderbomover = 0;
        private int? _idemandtype;
        private string _cdemandcode;
        private string _cdemandmemo;
        private decimal? _fpursum;
        private decimal? _fpurbillqty;
        private decimal? _fpurbillsum;
        private long? _iimid;
        private string _ccorvouchtype;
        private int? _icorrowno;
        private bool _busecusbom;
        public Guid? body_outid { get; set; }
        private decimal? _fveridispqty;
        private decimal? _fveridispsum;
        private bool _bsaleprice;
        private bool _bgift;
        private int? _forecastdid;
        private string _cdetailsdemandcode;
        private string _cdetailsdemandmemo;
        private decimal? _ftransedqty;
        private string _cbsysbarcode;
        private decimal? _fappqty;
        private string _cparentcode;
        private string _cchildcode;
        private decimal? _fchildqty;
        private decimal? _fchildrate;
        private int? _icalctype;
        /// <summary>
        /// 
        /// </summary>
        public int AutoID
        {
            set { _autoid = value; }
            get { return _autoid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cSOCode
        {
            set { _csocode = value; }
            get { return _csocode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cInvCode
        {
            set { _cinvcode = value; }
            get { return _cinvcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dPreDate
        {
            set { _dpredate = value; }
            get { return _dpredate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iQuantity
        {
            set { _iquantity = value; }
            get { return _iquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iNum
        {
            set { _inum = value; }
            get { return _inum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iQuotedPrice
        {
            set { _iquotedprice = value; }
            get { return _iquotedprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iUnitPrice
        {
            set { _iunitprice = value; }
            get { return _iunitprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iTaxUnitPrice
        {
            set { _itaxunitprice = value; }
            get { return _itaxunitprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iMoney
        {
            set { _imoney = value; }
            get { return _imoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iTax
        {
            set { _itax = value; }
            get { return _itax; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iSum
        {
            set { _isum = value; }
            get { return _isum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iDisCount
        {
            set { _idiscount = value; }
            get { return _idiscount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iNatUnitPrice
        {
            set { _inatunitprice = value; }
            get { return _inatunitprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iNatMoney
        {
            set { _inatmoney = value; }
            get { return _inatmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iNatTax
        {
            set { _inattax = value; }
            get { return _inattax; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iNatSum
        {
            set { _inatsum = value; }
            get { return _inatsum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iNatDisCount
        {
            set { _inatdiscount = value; }
            get { return _inatdiscount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iFHNum
        {
            set { _ifhnum = value; }
            get { return _ifhnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iFHQuantity
        {
            set { _ifhquantity = value; }
            get { return _ifhquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iFHMoney
        {
            set { _ifhmoney = value; }
            get { return _ifhmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iKPQuantity
        {
            set { _ikpquantity = value; }
            get { return _ikpquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iKPNum
        {
            set { _ikpnum = value; }
            get { return _ikpnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iKPMoney
        {
            set { _ikpmoney = value; }
            get { return _ikpmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cMemo
        {
            set { _cmemo = value; }
            get { return _cmemo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cFree1
        {
            set { _cfree1 = value; }
            get { return _cfree1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cFree2
        {
            set { _cfree2 = value; }
            get { return _cfree2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? bFH
        {
            set { _bfh = value; }
            get { return _bfh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int iSOsID
        {
            set { _isosid = value; }
            get { return _isosid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? KL
        {
            set { _kl = value; }
            get { return _kl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? KL2
        {
            set { _kl2 = value; }
            get { return _kl2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iTaxRate
        {
            set { _itaxrate = value; }
            get { return _itaxrate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine22
        {
            set { _cdefine22 = value; }
            get { return _cdefine22; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine23
        {
            set { _cdefine23 = value; }
            get { return _cdefine23; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine24
        {
            set { _cdefine24 = value; }
            get { return _cdefine24; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine25
        {
            set { _cdefine25 = value; }
            get { return _cdefine25; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? cDefine26
        {
            set { _cdefine26 = value; }
            get { return _cdefine26; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? cDefine27
        {
            set { _cdefine27 = value; }
            get { return _cdefine27; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cItemCode
        {
            set { _citemcode = value; }
            get { return _citemcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cItem_class
        {
            set { _citem_class = value; }
            get { return _citem_class; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cItemName
        {
            set { _citemname = value; }
            get { return _citemname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cItem_CName
        {
            set { _citem_cname = value; }
            get { return _citem_cname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cFree3
        {
            set { _cfree3 = value; }
            get { return _cfree3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cFree4
        {
            set { _cfree4 = value; }
            get { return _cfree4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cFree5
        {
            set { _cfree5 = value; }
            get { return _cfree5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cFree6
        {
            set { _cfree6 = value; }
            get { return _cfree6; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cFree7
        {
            set { _cfree7 = value; }
            get { return _cfree7; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cFree8
        {
            set { _cfree8 = value; }
            get { return _cfree8; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cFree9
        {
            set { _cfree9 = value; }
            get { return _cfree9; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cFree10
        {
            set { _cfree10 = value; }
            get { return _cfree10; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iInvExchRate
        {
            set { _iinvexchrate = value; }
            get { return _iinvexchrate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cUnitID
        {
            set { _cunitid = value; }
            get { return _cunitid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine28
        {
            set { _cdefine28 = value; }
            get { return _cdefine28; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine29
        {
            set { _cdefine29 = value; }
            get { return _cdefine29; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine30
        {
            set { _cdefine30 = value; }
            get { return _cdefine30; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine31
        {
            set { _cdefine31 = value; }
            get { return _cdefine31; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine32
        {
            set { _cdefine32 = value; }
            get { return _cdefine32; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine33
        {
            set { _cdefine33 = value; }
            get { return _cdefine33; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? cDefine34
        {
            set { _cdefine34 = value; }
            get { return _cdefine34; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? cDefine35
        {
            set { _cdefine35 = value; }
            get { return _cdefine35; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? cDefine36
        {
            set { _cdefine36 = value; }
            get { return _cdefine36; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? cDefine37
        {
            set { _cdefine37 = value; }
            get { return _cdefine37; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FPurQuan
        {
            set { _fpurquan = value; }
            get { return _fpurquan; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fSaleCost
        {
            set { _fsalecost = value; }
            get { return _fsalecost; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fSalePrice
        {
            set { _fsaleprice = value; }
            get { return _fsaleprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cQuoCode
        {
            set { _cquocode = value; }
            get { return _cquocode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? iQuoID
        {
            set { _iquoid = value; }
            get { return _iquoid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cSCloser
        {
            set { _cscloser = value; }
            get { return _cscloser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dPreMoDate
        {
            set { _dpremodate = value; }
            get { return _dpremodate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? iRowNo
        {
            set { _irowno = value; }
            get { return _irowno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? iCusBomID
        {
            set { _icusbomid = value; }
            get { return _icusbomid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iMoQuantity
        {
            set { _imoquantity = value; }
            get { return _imoquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cContractID
        {
            set { _ccontractid = value; }
            get { return _ccontractid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cContractTagCode
        {
            set { _ccontracttagcode = value; }
            get { return _ccontracttagcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? iPPartSeqID
        {
            set { _ippartseqid = value; }
            get { return _ippartseqid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? iPPartID
        {
            set { _ippartid = value; }
            get { return _ippartid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iPPartQty
        {
            set { _ippartqty = value; }
            get { return _ippartqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cCusInvCode
        {
            set { _ccusinvcode = value; }
            get { return _ccusinvcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cCusInvName
        {
            set { _ccusinvname = value; }
            get { return _ccusinvname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iPreKeepQuantity
        {
            set { _iprekeepquantity = value; }
            get { return _iprekeepquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iPreKeepNum
        {
            set { _iprekeepnum = value; }
            get { return _iprekeepnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iPreKeepTotQuantity
        {
            set { _iprekeeptotquantity = value; }
            get { return _iprekeeptotquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iPreKeepTotNum
        {
            set { _iprekeeptotnum = value; }
            get { return _iprekeeptotnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dreleasedate
        {
            set { _dreleasedate = value; }
            get { return _dreleasedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fcusminprice
        {
            set { _fcusminprice = value; }
            get { return _fcusminprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fimquantity
        {
            set { _fimquantity = value; }
            get { return _fimquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fomquantity
        {
            set { _fomquantity = value; }
            get { return _fomquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool ballpurchase
        {
            set { _ballpurchase = value; }
            get { return _ballpurchase; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? finquantity
        {
            set { _finquantity = value; }
            get { return _finquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? icostquantity
        {
            set { _icostquantity = value; }
            get { return _icostquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? icostsum
        {
            set { _icostsum = value; }
            get { return _icostsum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? foutquantity
        {
            set { _foutquantity = value; }
            get { return _foutquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? foutnum
        {
            set { _foutnum = value; }
            get { return _foutnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iexchsum
        {
            set { _iexchsum = value; }
            get { return _iexchsum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? imoneysum
        {
            set { _imoneysum = value; }
            get { return _imoneysum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dufts
        {
            set { _dufts = value; }
            get { return _dufts; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? iaoids
        {
            set { _iaoids = value; }
            get { return _iaoids; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cpreordercode
        {
            set { _cpreordercode = value; }
            get { return _cpreordercode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fretquantity
        {
            set { _fretquantity = value; }
            get { return _fretquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fretnum
        {
            set { _fretnum = value; }
            get { return _fretnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dbclosedate
        {
            set { _dbclosedate = value; }
            get { return _dbclosedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dbclosesystime
        {
            set { _dbclosesystime = value; }
            get { return _dbclosesystime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bOrderBOM
        {
            set { _borderbom = value; }
            get { return _borderbom; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? bOrderBOMOver
        {
            set { _borderbomover = value; }
            get { return _borderbomover; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? idemandtype
        {
            set { _idemandtype = value; }
            get { return _idemandtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cdemandcode
        {
            set { _cdemandcode = value; }
            get { return _cdemandcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cdemandmemo
        {
            set { _cdemandmemo = value; }
            get { return _cdemandmemo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fPurSum
        {
            set { _fpursum = value; }
            get { return _fpursum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fPurBillQty
        {
            set { _fpurbillqty = value; }
            get { return _fpurbillqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fPurBillSum
        {
            set { _fpurbillsum = value; }
            get { return _fpurbillsum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? iimid
        {
            set { _iimid = value; }
            get { return _iimid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ccorvouchtype
        {
            set { _ccorvouchtype = value; }
            get { return _ccorvouchtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? icorrowno
        {
            set { _icorrowno = value; }
            get { return _icorrowno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool busecusbom
        {
            set { _busecusbom = value; }
            get { return _busecusbom; }
        }

        /// <summary>
        /// 
        /// </summary>
        public decimal? fVeriDispQty
        {
            set { _fveridispqty = value; }
            get { return _fveridispqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fVeriDispSum
        {
            set { _fveridispsum = value; }
            get { return _fveridispsum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bsaleprice
        {
            set { _bsaleprice = value; }
            get { return _bsaleprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bgift
        {
            set { _bgift = value; }
            get { return _bgift; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? forecastdid
        {
            set { _forecastdid = value; }
            get { return _forecastdid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cdetailsdemandcode
        {
            set { _cdetailsdemandcode = value; }
            get { return _cdetailsdemandcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cdetailsdemandmemo
        {
            set { _cdetailsdemandmemo = value; }
            get { return _cdetailsdemandmemo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fTransedQty
        {
            set { _ftransedqty = value; }
            get { return _ftransedqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cbSysBarCode
        {
            set { _cbsysbarcode = value; }
            get { return _cbsysbarcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fappqty
        {
            set { _fappqty = value; }
            get { return _fappqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cParentCode
        {
            set { _cparentcode = value; }
            get { return _cparentcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cChildCode
        {
            set { _cchildcode = value; }
            get { return _cchildcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fchildqty
        {
            set { _fchildqty = value; }
            get { return _fchildqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fchildrate
        {
            set { _fchildrate = value; }
            get { return _fchildrate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? iCalcType
        {
            set { _icalctype = value; }
            get { return _icalctype; }
        }
        #endregion Model

    }
}

