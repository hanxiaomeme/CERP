using QWF.Framework.GlobalException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWF.Framework.Services
{
    /// <summary>
    /// 序列号服务接口
    /// </summary>
    public class SeqServices
    {
        private SvrModels.SvrUserIdentifier svrUserId;

        private readonly static object _lock = new object();

        public SeqServices(SvrModels.SvrUserIdentifier svrUserId)
        {
            this.svrUserId = svrUserId;
        }
        /// <summary>
        /// 获取编号
        /// </summary>
        /// <param name="code">唯一编码</param>
        /// <returns></returns>
        public string CreateNewSeqNo(string code)
        {
            lock(_lock)
            {
                using (var tran = new System.Transactions.TransactionScope())
                using (var db = DbAccess.DbFrameworkContext.Create())
                {
                    string seqno = string.Empty;
                    //用 SQL 方式防止并发处理
                    db.Database.ExecuteSqlCommand(string.Format("update  T_QWF_Seq set CurrentNumber = CurrentNumber + 1 where code ='{0}' ",code));
                    
                    //这里开始锁表
                    var seq = db.T_QWF_Seq.Where(w => w.Code == code).FirstOrDefault();
                    if (seq == null)
                        throw new QWF.Framework.GlobalException.UIValidateException(string.Format("获取seqno失败，code=【{0}】不存在", code));

                    //如果流水号的位数大于最大长度则归0，重置1;
                    if (seq.CurrentNumber.ToString().Length > seq.SerialLength)
                    {
                        seq.CurrentNumber = 1;
                        db.SaveChanges();
                    }
                    seqno = string.Format("{0}-{1}-{2}",
                        seq.Prefix,
                        DateTime.Now.ToString(seq.DateFormart).Trim(),
                        seq.CurrentNumber.ToString().PadLeft(seq.SerialLength,'0').Trim());

                    //提交事务
                    tran.Complete();
                    return seqno;
                }
            }
           
        }

        public bool AddSeqSetting(SvrModels.SvrSeqInfo svrModel)
        {
            //数据验证
            var checkModel = QWF.Framework.Validation.ValidationHelper.Validate(svrModel);
            if (!checkModel.IsValid)
                throw new UIValidateException("数据验证失败！" + checkModel.ToString());

            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                var dbModel = new DbAccess.T_QWF_Seq();

                dbModel.Code = svrModel.Code;
                dbModel.Name = svrModel.Name;
                dbModel.Prefix = svrModel.Prefix;
                dbModel.SerialLength = svrModel.SerialLength;
                dbModel.DateFormart = svrModel.DateFormart;

                if (db.T_QWF_Seq.Where(w => w.Code == svrModel.Code).Count() > 0)
                    throw new UIValidateException("编号：【{0}】已存在",svrModel.Code);

                db.T_QWF_Seq.Add(dbModel);

                db.SaveChanges();

                return true;
            }
        }

        public bool EditSeqSetting(SvrModels.SvrSeqInfo svrModel)
        {
            //数据验证
            var checkModel = QWF.Framework.Validation.ValidationHelper.Validate(svrModel);
            if (!checkModel.IsValid)
                throw new UIValidateException("数据验证失败！" + checkModel.ToString());

            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                var dbModel = db.T_QWF_Seq.Where(w => w.Code == svrModel.Code).FirstOrDefault();

                if(dbModel ==null)
                    throw new UIValidateException("编号：【{0}】不存在或已删除", svrModel.Code);

                dbModel.Name = svrModel.Name;
                dbModel.Prefix = svrModel.Prefix;
                dbModel.SerialLength = svrModel.SerialLength;
                dbModel.DateFormart = svrModel.DateFormart;

                db.SaveChanges();

                return true;
            }
        }

        public bool DeleteSeqSetting(string code)
        {
            if (string.IsNullOrEmpty(code))
                throw new UIValidateException("code为null");

            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                var dbModel = db.T_QWF_Seq.Where(w => w.Code == code).FirstOrDefault();

                if (dbModel != null)
                {
                    db.T_QWF_Seq.Remove(dbModel);
                }

                db.SaveChanges();

                return true;
            }
        }
    }
}
