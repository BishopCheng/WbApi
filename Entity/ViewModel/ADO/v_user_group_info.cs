using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System;
using SQLServer;
using Newtonsoft.Json;
namespace ApiServer.Entity.ViewModel.ADO
{
    [Serializable]
    public class v_user_group_info : IEntity
    {

        public static v_user_group_infoColumns _ = new v_user_group_infoColumns();
		

        private string userId_;
        public string userId
        {
            get { return userId_; }
            set { userId_ = value; }
        }

        private string userName_;
        public string userName
        {
            get { return userName_; }
            set { userName_ = value; }
        }

        private string realName_;
        public string realName
        {
            get { return realName_; }
            set { realName_ = value; }
        }

        private int? status_;
        public int? status
        {
            get { return status_; }
            set { status_ = value; }
        }

        private string userGroupId_;
        public string userGroupId
        {
            get { return userGroupId_; }
            set { userGroupId_ = value; }
        }

        private string userGroupName_;
        public string userGroupName
        {
            get { return userGroupName_; }
            set { userGroupName_ = value; }
        }

        [JsonIgnore]
        public override string TableName
        {
            get { return "v_user_group_info"; }
        }
        [JsonIgnore]
        public override string SqlTableName
        {
            get { return "v_user_group_info as v_user_group_info"; }
        }
        [JsonIgnore]
        public override string PrimaryKey
        {
            get { return "userId"; }
        }
        [JsonIgnore]
        public override string OrderFiled
        {
            get { return "userId"; }
        }
        [JsonIgnore]
        public override object PrimaryKeyValue
        {
            get { return this.userId; }
        }

        public override IEntity SetModel(DataRow dataRow)
        {
            v_user_group_info model = new v_user_group_info();
			model.userId_ = dataRow["userId"] as string;
			model.userName_ = dataRow["userName"] as string;
			model.realName_ = dataRow["realName"] as string;
			model.status_ = dataRow["status"] as int?;
			model.userGroupId_ = dataRow["userGroupId"] as string;
			model.userGroupName_ = dataRow["userGroupName"] as string;
            return model;
        }

        public override IEntity Copy()
        {
            v_user_group_info model = new v_user_group_info();
			model.userId_ = this.userId;
			model.userName_ = this.userName;
			model.realName_ = this.realName;
			model.status_ = this.status;
			model.userGroupId_ = this.userGroupId;
			model.userGroupName_ = this.userGroupName;
            return model;
        }

        public override object ColumnValue(string columnName)
        {
            switch (columnName)
            {
				case "userId": return this.userId;
				case "userName": return this.userName;
				case "realName": return this.realName;
				case "status": return this.status;
				case "userGroupId": return this.userGroupId;
				case "userGroupName": return this.userGroupName;
                default: return null;
            }
        }

        public override void SetColumnValue(string columnName, object value)
        {
            switch (columnName)
            {
				case "userId": this.userId = (string)value; break;
				case "userName": this.userName = (string)value; break;
				case "realName": this.realName = (string)value; break;
				case "status": this.status = (int?)value; break;
				case "userGroupId": this.userGroupId = (string)value; break;
				case "userGroupName": this.userGroupName = (string)value; break;
            }
        }

        public override bool HasColumn(string columnName)
        {
            switch (columnName)
            {
				case "userId": return true;
				case "userName": return true;
				case "realName": return true;
				case "status": return true;
				case "userGroupId": return true;
				case "userGroupName": return true;

                default: return false;
            }
        }

        public override Column GetColumn(string columnName)
        {
            switch (columnName)
            {
				case "userId": return v_user_group_info._.userId;
				case "userName": return v_user_group_info._.userName;
				case "realName": return v_user_group_info._.realName;
				case "status": return v_user_group_info._.status;
				case "userGroupId": return v_user_group_info._.userGroupId;
				case "userGroupName": return v_user_group_info._.userGroupName;
				default: return null;
            }
        }

        public override List<CompareEntity> EntityCompare(IEntity newModel)
        {
            List<CompareEntity> lst = new List<CompareEntity>();
            if (this.userId != ((v_user_group_info)newModel).userId)
            {
                lst.Add(new CompareEntity("userId", this.userId + ""));
            }
            if (this.userName != ((v_user_group_info)newModel).userName)
            {
                lst.Add(new CompareEntity("userName", this.userName + ""));
            }
            if (this.realName != ((v_user_group_info)newModel).realName)
            {
                lst.Add(new CompareEntity("realName", this.realName + ""));
            }
            if (this.status != ((v_user_group_info)newModel).status)
            {
                lst.Add(new CompareEntity("status", this.status + ""));
            }
            if (this.userGroupId != ((v_user_group_info)newModel).userGroupId)
            {
                lst.Add(new CompareEntity("userGroupId", this.userGroupId + ""));
            }
            if (this.userGroupName != ((v_user_group_info)newModel).userGroupName)
            {
                lst.Add(new CompareEntity("userGroupName", this.userGroupName + ""));
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
            return "";
        }

        public override string GetUpdatePlate()
        {
            return "";
        }

        public override List<DbParameter> GetFullParameters()
        {
            return null;
        }

    }

    public class v_user_group_infoColumns
    {
        public Column userId = new Column("v_user_group_info.userId", dbplatform.Instance.ExcuteImport);
        public Column userName = new Column("v_user_group_info.userName", dbplatform.Instance.ExcuteImport);
        public Column realName = new Column("v_user_group_info.realName", dbplatform.Instance.ExcuteImport);
        public Column status = new Column("v_user_group_info.status", dbplatform.Instance.ExcuteImport);
        public Column userGroupId = new Column("v_user_group_info.userGroupId", dbplatform.Instance.ExcuteImport);
        public Column userGroupName = new Column("v_user_group_info.userGroupName", dbplatform.Instance.ExcuteImport);
	}
}

