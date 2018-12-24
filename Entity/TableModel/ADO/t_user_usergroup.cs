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
		
        private string uUgroupId_;
		[DescriptionAttribute("PrimaryKey")]
        public string uUgroupId
        {
            get { return uUgroupId_; }
            set { uUgroupId_ = value; }
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
            get { return "uUgroupId"; }
        }
        [JsonIgnore]
        public override string OrderFiled
        {
            get { return "uUgroupId"; }
        }
        [JsonIgnore]
        public override object PrimaryKeyValue
        {
            get { return this.uUgroupId; }
        }

        public override IEntity SetModel(DataRow dataRow)
        {
            t_user_usergroup model = new t_user_usergroup();
			model.uUgroupId_ = dataRow["uUgroupId"] as string;
			model.userId_ = dataRow["userId"] as string;
			model.userGroupId_ = dataRow["userGroupId"] as string;
            
			return model;
        }

        public override IEntity Copy()
        {
            t_user_usergroup model = new t_user_usergroup();
            model.uUgroupId_ = this.uUgroupId;
            model.userId_ = this.userId;
            model.userGroupId_ = this.userGroupId;
            return model;
        }

        public override object ColumnValue(string columnName)
        {
            switch (columnName)
            {
				case "uUgroupId": return this.uUgroupId;
				case "userId": return this.userId;
				case "userGroupId": return this.userGroupId;

                default: return null;
            }
        }

        public override void SetColumnValue(string columnName, object value)
        {
            switch (columnName)
            {
				case "uUgroupId": this.uUgroupId = (string)value; break;
				case "userId": this.userId = (string)value; break;
				case "userGroupId": this.userGroupId = (string)value; break;
            }
        }

        public override bool HasColumn(string columnName)
        {
            switch (columnName)
            {
				case "uUgroupId": return true;
				case "userId": return true;
				case "userGroupId": return true;
				
                default: return false;
            }
        }

        public override Column GetColumn(string columnName)
        {
            switch (columnName)
            {
				case "uUgroupId": return t_user_usergroup._.uUgroupId;
				case "userId": return t_user_usergroup._.userId;
				case "userGroupId": return t_user_usergroup._.userGroupId;
                default: return null;
            }
        }

        public override List<CompareEntity> EntityCompare(IEntity newModel)
        {
            List<CompareEntity> lst = new List<CompareEntity>();
            if (this.uUgroupId != ((t_user_usergroup)newModel).uUgroupId)
            {
                lst.Add(new CompareEntity("uUgroupId", this.uUgroupId + ""));
            }
            if (this.userId != ((t_user_usergroup)newModel).userId)
            {
                lst.Add(new CompareEntity("userId", this.userId + ""));
            }
            if (this.userGroupId != ((t_user_usergroup)newModel).userGroupId)
            {
                lst.Add(new CompareEntity("userGroupId", this.userGroupId + ""));
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
            return "INSERT t_user_usergroup(uUgroupId, userId, userGroupId) VALUES("+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"uUgroupId, "+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"userId, "+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"userGroupId)";
        }

        public override string GetUpdatePlate()
        {
            return "UPDATE t_user_usergroup SET userId="+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"userId, userGroupId="+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"userGroupId WHERE uUgroupId=" + dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "uUgroupId";
        }

        public override List<DbParameter> GetFullParameters()
        {
            List<DbParameter> lstDbParameter = new List<DbParameter>();
            lstDbParameter.Add(dbplatform.Instance.ExcuteImport.CreateDbParameter(dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "uUgroupId", this.uUgroupId));
            lstDbParameter.Add(dbplatform.Instance.ExcuteImport.CreateDbParameter(dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "userId", this.userId));
            lstDbParameter.Add(dbplatform.Instance.ExcuteImport.CreateDbParameter(dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "userGroupId", this.userGroupId));
            return lstDbParameter;
        }

    }

    public class t_user_usergroupColumns
    {
        public Column uUgroupId = new Column("t_user_usergroup.uUgroupId", dbplatform.Instance.ExcuteImport);
        public Column userId = new Column("t_user_usergroup.userId", dbplatform.Instance.ExcuteImport);
        public Column userGroupId = new Column("t_user_usergroup.userGroupId", dbplatform.Instance.ExcuteImport);
    }
}

