using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Data;
using System;
using System.Text;
using SQLServer;
using Newtonsoft.Json;
namespace ApiServer.Entity.TableModel.ADO
{
    [Serializable]
    public class t_user : IEntity
    {
        public static t_userColumns _ = new t_userColumns();
		
        private string userId_;
        public string userId
        {
            get { return userId_; }
            set { userId_ = value; }
        }

        private string userName_;
		[DescriptionAttribute("PrimaryKey")]
        public string userName
        {
            get { return userName_; }
            set { userName_ = value; }
        }

        private string passWord_;
        public string passWord
        {
            get { return passWord_; }
            set { passWord_ = value; }
        }

        private string realName_;
        public string realName
        {
            get { return realName_; }
            set { realName_ = value; }
        }

        private string userRole_;
        public string userRole
        {
            get { return userRole_; }
            set { userRole_ = value; }
        }

        private int? loginCount_;
        public int? loginCount
        {
            get { return loginCount_; }
            set { loginCount_ = value; }
        }

        private int? wrongCounts_;
        public int? wrongCounts
        {
            get { return wrongCounts_; }
            set { wrongCounts_ = value; }
        }

        private DateTime? lastLoginTime_;
        public DateTime? lastLoginTime
        {
            get { return lastLoginTime_; }
            set { lastLoginTime_ = value; }
        }

        private int? status_;
        public int? status
        {
            get { return status_; }
            set { status_ = value; }
        }

        private string remark_;
        public string remark
        {
            get { return remark_; }
            set { remark_ = value; }
        }

		[JsonIgnore]
        public override string TableName
        {
            get { return "t_user"; }
        }
        [JsonIgnore]
        public override string SqlTableName
        {
            get { return "t_user as t_user"; }
        }
        [JsonIgnore]
        public override string PrimaryKey
        {
            get { return "userName"; }
        }
        [JsonIgnore]
        public override string OrderFiled
        {
            get { return "userName"; }
        }
        [JsonIgnore]
        public override object PrimaryKeyValue
        {
            get { return this.userName; }
        }

        public override IEntity SetModel(DataRow dataRow)
        {
            t_user model = new t_user();
			model.userId_ = dataRow["userId"] as string;
			model.userName_ = dataRow["userName"] as string;
			model.passWord_ = dataRow["passWord"] as string;
			model.realName_ = dataRow["realName"] as string;
			model.userRole_ = dataRow["userRole"] as string;
			model.loginCount_ = dataRow["loginCount"] as int?;
			model.wrongCounts_ = dataRow["wrongCounts"] as int?;
			model.lastLoginTime_ = dataRow["lastLoginTime"] as DateTime?;
			model.status_ = dataRow["status"] as int?;
			model.remark_ = dataRow["remark"] as string;
            
			return model;
        }

        public override IEntity Copy()
        {
            t_user model = new t_user();
            model.userId_ = this.userId;
            model.userName_ = this.userName;
            model.passWord_ = this.passWord;
            model.realName_ = this.realName;
            model.userRole_ = this.userRole;
            model.loginCount_ = this.loginCount;
            model.wrongCounts_ = this.wrongCounts;
            model.lastLoginTime_ = this.lastLoginTime;
            model.status_ = this.status;
            model.remark_ = this.remark;
            return model;
        }

        public override object ColumnValue(string columnName)
        {
            switch (columnName)
            {
				case "userId": return this.userId;
				case "userName": return this.userName;
				case "passWord": return this.passWord;
				case "realName": return this.realName;
				case "userRole": return this.userRole;
				case "loginCount": return this.loginCount;
				case "wrongCounts": return this.wrongCounts;
				case "lastLoginTime": return this.lastLoginTime;
				case "status": return this.status;
				case "remark": return this.remark;

                default: return null;
            }
        }

        public override void SetColumnValue(string columnName, object value)
        {
            switch (columnName)
            {
				case "userId": this.userId = (string)value; break;
				case "userName": this.userName = (string)value; break;
				case "passWord": this.passWord = (string)value; break;
				case "realName": this.realName = (string)value; break;
				case "userRole": this.userRole = (string)value; break;
				case "loginCount": this.loginCount = (int?)value; break;
				case "wrongCounts": this.wrongCounts = (int?)value; break;
				case "lastLoginTime": this.lastLoginTime = (DateTime?)value; break;
				case "status": this.status = (int?)value; break;
				case "remark": this.remark = (string)value; break;
            }
        }

        public override bool HasColumn(string columnName)
        {
            switch (columnName)
            {
				case "userId": return true;
				case "userName": return true;
				case "passWord": return true;
				case "realName": return true;
				case "userRole": return true;
				case "loginCount": return true;
				case "wrongCounts": return true;
				case "lastLoginTime": return true;
				case "status": return true;
				case "remark": return true;
				
                default: return false;
            }
        }

        public override Column GetColumn(string columnName)
        {
            switch (columnName)
            {
				case "userId": return t_user._.userId;
				case "userName": return t_user._.userName;
				case "passWord": return t_user._.passWord;
				case "realName": return t_user._.realName;
				case "userRole": return t_user._.userRole;
				case "loginCount": return t_user._.loginCount;
				case "wrongCounts": return t_user._.wrongCounts;
				case "lastLoginTime": return t_user._.lastLoginTime;
				case "status": return t_user._.status;
				case "remark": return t_user._.remark;
                default: return null;
            }
        }

        public override List<CompareEntity> EntityCompare(IEntity newModel)
        {
            List<CompareEntity> lst = new List<CompareEntity>();
            if (this.userId != ((t_user)newModel).userId)
            {
                lst.Add(new CompareEntity("userId", this.userId + ""));
            }
            if (this.userName != ((t_user)newModel).userName)
            {
                lst.Add(new CompareEntity("userName", this.userName + ""));
            }
            if (this.passWord != ((t_user)newModel).passWord)
            {
                lst.Add(new CompareEntity("passWord", this.passWord + ""));
            }
            if (this.realName != ((t_user)newModel).realName)
            {
                lst.Add(new CompareEntity("realName", this.realName + ""));
            }
            if (this.userRole != ((t_user)newModel).userRole)
            {
                lst.Add(new CompareEntity("userRole", this.userRole + ""));
            }
            if (this.loginCount != ((t_user)newModel).loginCount)
            {
                lst.Add(new CompareEntity("loginCount", this.loginCount + ""));
            }
            if (this.wrongCounts != ((t_user)newModel).wrongCounts)
            {
                lst.Add(new CompareEntity("wrongCounts", this.wrongCounts + ""));
            }
            if (this.lastLoginTime != ((t_user)newModel).lastLoginTime)
            {
                lst.Add(new CompareEntity("lastLoginTime", this.lastLoginTime + ""));
            }
            if (this.status != ((t_user)newModel).status)
            {
                lst.Add(new CompareEntity("status", this.status + ""));
            }
            if (this.remark != ((t_user)newModel).remark)
            {
                lst.Add(new CompareEntity("remark", this.remark + ""));
            }
            return lst;
        }

        public override string GetInsertSql()
        {
            return string.Empty;
        }

        public override string GetUpdateSql()
        {
            return string.Empty;
        }

        public override string GetInsertPlate()
        {
            return "INSERT t_user(userId, userName, passWord, realName, userRole, loginCount, wrongCounts, lastLoginTime, status, remark) VALUES("+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"userId, "+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"userName, "+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"passWord, "+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"realName, "+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"userRole, "+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"loginCount, "+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"wrongCounts, " + string.Format(dbplatform.Instance.ExcuteImport.sqlSetting.DateFiled_sql, dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "lastLoginTime")+", "+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"status, "+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"remark)";
        }

        public override string GetUpdatePlate()
        {
            return "UPDATE t_user SET userId="+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"userId, passWord="+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"passWord, realName="+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"realName, userRole="+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"userRole, loginCount="+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"loginCount, wrongCounts="+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"wrongCounts, lastLoginTime=" + string.Format(dbplatform.Instance.ExcuteImport.sqlSetting.DateFiled_sql, dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "lastLoginTime")+", status="+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"status, remark="+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"remark WHERE userName=" + dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "userName";
        }

        public override List<DbParameter> GetFullParameters()
        {
            List<DbParameter> lstDbParameter = new List<DbParameter>();
            lstDbParameter.Add(dbplatform.Instance.ExcuteImport.CreateDbParameter(dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "userId", this.userId));
            lstDbParameter.Add(dbplatform.Instance.ExcuteImport.CreateDbParameter(dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "userName", this.userName));
            lstDbParameter.Add(dbplatform.Instance.ExcuteImport.CreateDbParameter(dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "passWord", this.passWord));
            lstDbParameter.Add(dbplatform.Instance.ExcuteImport.CreateDbParameter(dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "realName", this.realName));
            lstDbParameter.Add(dbplatform.Instance.ExcuteImport.CreateDbParameter(dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "userRole", this.userRole));
            lstDbParameter.Add(dbplatform.Instance.ExcuteImport.CreateDbParameter(dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "loginCount", this.loginCount));
            lstDbParameter.Add(dbplatform.Instance.ExcuteImport.CreateDbParameter(dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "wrongCounts", this.wrongCounts));
            lstDbParameter.Add(dbplatform.Instance.ExcuteImport.CreateDbParameter(dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "lastLoginTime", this.lastLoginTime));
            lstDbParameter.Add(dbplatform.Instance.ExcuteImport.CreateDbParameter(dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "status", this.status));
            lstDbParameter.Add(dbplatform.Instance.ExcuteImport.CreateDbParameter(dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "remark", this.remark));
            return lstDbParameter;
        }

    }

    public class t_userColumns
    {
        public Column userId = new Column("t_user.userId", dbplatform.Instance.ExcuteImport);
        public Column userName = new Column("t_user.userName", dbplatform.Instance.ExcuteImport);
        public Column passWord = new Column("t_user.passWord", dbplatform.Instance.ExcuteImport);
        public Column realName = new Column("t_user.realName", dbplatform.Instance.ExcuteImport);
        public Column userRole = new Column("t_user.userRole", dbplatform.Instance.ExcuteImport);
        public Column loginCount = new Column("t_user.loginCount", dbplatform.Instance.ExcuteImport);
        public Column wrongCounts = new Column("t_user.wrongCounts", dbplatform.Instance.ExcuteImport);
        public Column lastLoginTime = new Column("t_user.lastLoginTime", dbplatform.Instance.ExcuteImport);
        public Column status = new Column("t_user.status", dbplatform.Instance.ExcuteImport);
        public Column remark = new Column("t_user.remark", dbplatform.Instance.ExcuteImport);
    }
}

