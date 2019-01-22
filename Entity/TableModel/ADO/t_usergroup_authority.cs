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
    public class t_usergroup_authority : IEntity
    {
        public static t_usergroup_authorityColumns _ = new t_usergroup_authorityColumns();
		
        private string groupAuthorityId_;
		[DescriptionAttribute("PrimaryKey")]
        public string groupAuthorityId
        {
            get { return groupAuthorityId_; }
            set { groupAuthorityId_ = value; }
        }

        private string userGroupId_;
        public string userGroupId
        {
            get { return userGroupId_; }
            set { userGroupId_ = value; }
        }

        private string authorityId_;
        public string authorityId
        {
            get { return authorityId_; }
            set { authorityId_ = value; }
        }

        private string status_;
        public string status
        {
            get { return status_; }
            set { status_ = value; }
        }

		[JsonIgnore]
        public override string TableName
        {
            get { return "t_usergroup_authority"; }
        }
        [JsonIgnore]
        public override string SqlTableName
        {
            get { return "t_usergroup_authority as t_usergroup_authority"; }
        }
        [JsonIgnore]
        public override string PrimaryKey
        {
            get { return "groupAuthorityId"; }
        }
        [JsonIgnore]
        public override string OrderFiled
        {
            get { return "groupAuthorityId"; }
        }
        [JsonIgnore]
        public override object PrimaryKeyValue
        {
            get { return this.groupAuthorityId; }
        }

        public override IEntity SetModel(DataRow dataRow)
        {
            t_usergroup_authority model = new t_usergroup_authority();
			model.groupAuthorityId_ = dataRow["groupAuthorityId"] as string;
			model.userGroupId_ = dataRow["userGroupId"] as string;
			model.authorityId_ = dataRow["authorityId"] as string;
			model.status_ = dataRow["status"] as string;
            
			return model;
        }

        public override IEntity Copy()
        {
            t_usergroup_authority model = new t_usergroup_authority();
            model.groupAuthorityId_ = this.groupAuthorityId;
            model.userGroupId_ = this.userGroupId;
            model.authorityId_ = this.authorityId;
            model.status_ = this.status;
            return model;
        }

        public override object ColumnValue(string columnName)
        {
            switch (columnName)
            {
				case "groupAuthorityId": return this.groupAuthorityId;
				case "userGroupId": return this.userGroupId;
				case "authorityId": return this.authorityId;
				case "status": return this.status;

                default: return null;
            }
        }

        public override void SetColumnValue(string columnName, object value)
        {
            switch (columnName)
            {
				case "groupAuthorityId": this.groupAuthorityId = (string)value; break;
				case "userGroupId": this.userGroupId = (string)value; break;
				case "authorityId": this.authorityId = (string)value; break;
				case "status": this.status = (string)value; break;
            }
        }

        public override bool HasColumn(string columnName)
        {
            switch (columnName)
            {
				case "groupAuthorityId": return true;
				case "userGroupId": return true;
				case "authorityId": return true;
				case "status": return true;
				
                default: return false;
            }
        }

        public override Column GetColumn(string columnName)
        {
            switch (columnName)
            {
				case "groupAuthorityId": return t_usergroup_authority._.groupAuthorityId;
				case "userGroupId": return t_usergroup_authority._.userGroupId;
				case "authorityId": return t_usergroup_authority._.authorityId;
				case "status": return t_usergroup_authority._.status;
                default: return null;
            }
        }

        public override List<CompareEntity> EntityCompare(IEntity newModel)
        {
            List<CompareEntity> lst = new List<CompareEntity>();
            if (this.groupAuthorityId != ((t_usergroup_authority)newModel).groupAuthorityId)
            {
                lst.Add(new CompareEntity("groupAuthorityId", this.groupAuthorityId + ""));
            }
            if (this.userGroupId != ((t_usergroup_authority)newModel).userGroupId)
            {
                lst.Add(new CompareEntity("userGroupId", this.userGroupId + ""));
            }
            if (this.authorityId != ((t_usergroup_authority)newModel).authorityId)
            {
                lst.Add(new CompareEntity("authorityId", this.authorityId + ""));
            }
            if (this.status != ((t_usergroup_authority)newModel).status)
            {
                lst.Add(new CompareEntity("status", this.status + ""));
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
            return "INSERT t_usergroup_authority(groupAuthorityId, userGroupId, authorityId, status) VALUES("+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"groupAuthorityId, "+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"userGroupId, "+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"authorityId, "+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"status)";
        }

        public override string GetUpdatePlate()
        {
            return "UPDATE t_usergroup_authority SET userGroupId="+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"userGroupId, authorityId="+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"authorityId, status="+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"status WHERE groupAuthorityId=" + dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "groupAuthorityId";
        }

        public override List<DbParameter> GetFullParameters()
        {
            List<DbParameter> lstDbParameter = new List<DbParameter>();
            lstDbParameter.Add(dbplatform.Instance.ExcuteImport.CreateDbParameter(dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "groupAuthorityId", this.groupAuthorityId));
            lstDbParameter.Add(dbplatform.Instance.ExcuteImport.CreateDbParameter(dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "userGroupId", this.userGroupId));
            lstDbParameter.Add(dbplatform.Instance.ExcuteImport.CreateDbParameter(dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "authorityId", this.authorityId));
            lstDbParameter.Add(dbplatform.Instance.ExcuteImport.CreateDbParameter(dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "status", this.status));
            return lstDbParameter;
        }

    }

    public class t_usergroup_authorityColumns
    {
        public Column groupAuthorityId = new Column("t_usergroup_authority.groupAuthorityId", dbplatform.Instance.ExcuteImport);
        public Column userGroupId = new Column("t_usergroup_authority.userGroupId", dbplatform.Instance.ExcuteImport);
        public Column authorityId = new Column("t_usergroup_authority.authorityId", dbplatform.Instance.ExcuteImport);
        public Column status = new Column("t_usergroup_authority.status", dbplatform.Instance.ExcuteImport);
    }
}

