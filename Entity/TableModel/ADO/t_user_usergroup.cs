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
    public class t_user_usergroup : IEntity
    {
        public static t_user_usergroupColumns _ = new t_user_usergroupColumns();
		
        private string uUserGroupId_;
		[DescriptionAttribute("PrimaryKey")]
        public string uUserGroupId
        {
            get { return uUserGroupId_; }
            set { uUserGroupId_ = value; }
        }

        private string userId_;
        public string userId
        {
            get { return userId_; }
            set { userId_ = value; }
        }

        private string userGroupId_;
        public string userGroupId
        {
            get { return userGroupId_; }
            set { userGroupId_ = value; }
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
            get { return "t_user_usergroup"; }
        }
        [JsonIgnore]
        public override string SqlTableName
        {
            get { return "t_user_usergroup as t_user_usergroup"; }
        }
        [JsonIgnore]
        public override string PrimaryKey
        {
            get { return "uUserGroupId"; }
        }
        [JsonIgnore]
        public override string OrderFiled
        {
            get { return "uUserGroupId"; }
        }
        [JsonIgnore]
        public override object PrimaryKeyValue
        {
            get { return this.uUserGroupId; }
        }

        public override IEntity SetModel(DataRow dataRow)
        {
            t_user_usergroup model = new t_user_usergroup();
			model.uUserGroupId_ = dataRow["uUserGroupId"] as string;
			model.userId_ = dataRow["userId"] as string;
			model.userGroupId_ = dataRow["userGroupId"] as string;
			model.remark_ = dataRow["remark"] as string;
            
			return model;
        }

        public override IEntity Copy()
        {
            t_user_usergroup model = new t_user_usergroup();
            model.uUserGroupId_ = this.uUserGroupId;
            model.userId_ = this.userId;
            model.userGroupId_ = this.userGroupId;
            model.remark_ = this.remark;
            return model;
        }

        public override object ColumnValue(string columnName)
        {
            switch (columnName)
            {
				case "uUserGroupId": return this.uUserGroupId;
				case "userId": return this.userId;
				case "userGroupId": return this.userGroupId;
				case "remark": return this.remark;

                default: return null;
            }
        }

        public override void SetColumnValue(string columnName, object value)
        {
            switch (columnName)
            {
				case "uUserGroupId": this.uUserGroupId = (string)value; break;
				case "userId": this.userId = (string)value; break;
				case "userGroupId": this.userGroupId = (string)value; break;
				case "remark": this.remark = (string)value; break;
            }
        }

        public override bool HasColumn(string columnName)
        {
            switch (columnName)
            {
				case "uUserGroupId": return true;
				case "userId": return true;
				case "userGroupId": return true;
				case "remark": return true;
				
                default: return false;
            }
        }

        public override Column GetColumn(string columnName)
        {
            switch (columnName)
            {
				case "uUserGroupId": return t_user_usergroup._.uUserGroupId;
				case "userId": return t_user_usergroup._.userId;
				case "userGroupId": return t_user_usergroup._.userGroupId;
				case "remark": return t_user_usergroup._.remark;
                default: return null;
            }
        }

        public override List<CompareEntity> EntityCompare(IEntity newModel)
        {
            List<CompareEntity> lst = new List<CompareEntity>();
            if (this.uUserGroupId != ((t_user_usergroup)newModel).uUserGroupId)
            {
                lst.Add(new CompareEntity("uUserGroupId", this.uUserGroupId + ""));
            }
            if (this.userId != ((t_user_usergroup)newModel).userId)
            {
                lst.Add(new CompareEntity("userId", this.userId + ""));
            }
            if (this.userGroupId != ((t_user_usergroup)newModel).userGroupId)
            {
                lst.Add(new CompareEntity("userGroupId", this.userGroupId + ""));
            }
            if (this.remark != ((t_user_usergroup)newModel).remark)
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
            return "INSERT t_user_usergroup(uUserGroupId, userId, userGroupId, remark) VALUES("+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"uUserGroupId, "+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"userId, "+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"userGroupId, "+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"remark)";
        }

        public override string GetUpdatePlate()
        {
            return "UPDATE t_user_usergroup SET userId="+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"userId, userGroupId="+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"userGroupId, remark="+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"remark WHERE uUserGroupId=" + dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "uUserGroupId";
        }

        public override List<DbParameter> GetFullParameters()
        {
            List<DbParameter> lstDbParameter = new List<DbParameter>();
            lstDbParameter.Add(dbplatform.Instance.ExcuteImport.CreateDbParameter(dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "uUserGroupId", this.uUserGroupId));
            lstDbParameter.Add(dbplatform.Instance.ExcuteImport.CreateDbParameter(dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "userId", this.userId));
            lstDbParameter.Add(dbplatform.Instance.ExcuteImport.CreateDbParameter(dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "userGroupId", this.userGroupId));
            lstDbParameter.Add(dbplatform.Instance.ExcuteImport.CreateDbParameter(dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "remark", this.remark));
            return lstDbParameter;
        }

    }

    public class t_user_usergroupColumns
    {
        public Column uUserGroupId = new Column("t_user_usergroup.uUserGroupId", dbplatform.Instance.ExcuteImport);
        public Column userId = new Column("t_user_usergroup.userId", dbplatform.Instance.ExcuteImport);
        public Column userGroupId = new Column("t_user_usergroup.userGroupId", dbplatform.Instance.ExcuteImport);
        public Column remark = new Column("t_user_usergroup.remark", dbplatform.Instance.ExcuteImport);
    }
}

