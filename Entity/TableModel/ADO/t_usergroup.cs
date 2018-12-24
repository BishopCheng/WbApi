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
    public class t_usergroup : IEntity
    {
        public static t_usergroupColumns _ = new t_usergroupColumns();
		
        private string userGroupId_;
		[DescriptionAttribute("PrimaryKey")]
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

        private string parentId_;
        public string parentId
        {
            get { return parentId_; }
            set { parentId_ = value; }
        }

        private string remark_;
        public string remark
        {
            get { return remark_; }
            set { remark_ = value; }
        }

        private int? status_;
        public int? status
        {
            get { return status_; }
            set { status_ = value; }
        }

		[JsonIgnore]
        public override string TableName
        {
            get { return "t_usergroup"; }
        }
        [JsonIgnore]
        public override string SqlTableName
        {
            get { return "t_usergroup as t_usergroup"; }
        }
        [JsonIgnore]
        public override string PrimaryKey
        {
            get { return "userGroupId"; }
        }
        [JsonIgnore]
        public override string OrderFiled
        {
            get { return "userGroupId"; }
        }
        [JsonIgnore]
        public override object PrimaryKeyValue
        {
            get { return this.userGroupId; }
        }

        public override IEntity SetModel(DataRow dataRow)
        {
            t_usergroup model = new t_usergroup();
			model.userGroupId_ = dataRow["userGroupId"] as string;
			model.userGroupName_ = dataRow["userGroupName"] as string;
			model.parentId_ = dataRow["parentId"] as string;
			model.remark_ = dataRow["remark"] as string;
			model.status_ = dataRow["status"] as int?;
            
			return model;
        }

        public override IEntity Copy()
        {
            t_usergroup model = new t_usergroup();
            model.userGroupId_ = this.userGroupId;
            model.userGroupName_ = this.userGroupName;
            model.parentId_ = this.parentId;
            model.remark_ = this.remark;
            model.status_ = this.status;
            return model;
        }

        public override object ColumnValue(string columnName)
        {
            switch (columnName)
            {
				case "userGroupId": return this.userGroupId;
				case "userGroupName": return this.userGroupName;
				case "parentId": return this.parentId;
				case "remark": return this.remark;
				case "status": return this.status;

                default: return null;
            }
        }

        public override void SetColumnValue(string columnName, object value)
        {
            switch (columnName)
            {
				case "userGroupId": this.userGroupId = (string)value; break;
				case "userGroupName": this.userGroupName = (string)value; break;
				case "parentId": this.parentId = (string)value; break;
				case "remark": this.remark = (string)value; break;
				case "status": this.status = (int?)value; break;
            }
        }

        public override bool HasColumn(string columnName)
        {
            switch (columnName)
            {
				case "userGroupId": return true;
				case "userGroupName": return true;
				case "parentId": return true;
				case "remark": return true;
				case "status": return true;
				
                default: return false;
            }
        }

        public override Column GetColumn(string columnName)
        {
            switch (columnName)
            {
				case "userGroupId": return t_usergroup._.userGroupId;
				case "userGroupName": return t_usergroup._.userGroupName;
				case "parentId": return t_usergroup._.parentId;
				case "remark": return t_usergroup._.remark;
				case "status": return t_usergroup._.status;
                default: return null;
            }
        }

        public override List<CompareEntity> EntityCompare(IEntity newModel)
        {
            List<CompareEntity> lst = new List<CompareEntity>();
            if (this.userGroupId != ((t_usergroup)newModel).userGroupId)
            {
                lst.Add(new CompareEntity("userGroupId", this.userGroupId + ""));
            }
            if (this.userGroupName != ((t_usergroup)newModel).userGroupName)
            {
                lst.Add(new CompareEntity("userGroupName", this.userGroupName + ""));
            }
            if (this.parentId != ((t_usergroup)newModel).parentId)
            {
                lst.Add(new CompareEntity("parentId", this.parentId + ""));
            }
            if (this.remark != ((t_usergroup)newModel).remark)
            {
                lst.Add(new CompareEntity("remark", this.remark + ""));
            }
            if (this.status != ((t_usergroup)newModel).status)
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
            return "INSERT t_usergroup(userGroupId, userGroupName, parentId, remark, status) VALUES("+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"userGroupId, "+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"userGroupName, "+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"parentId, "+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"remark, "+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"status)";
        }

        public override string GetUpdatePlate()
        {
            return "UPDATE t_usergroup SET userGroupName="+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"userGroupName, parentId="+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"parentId, remark="+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"remark, status="+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"status WHERE userGroupId=" + dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "userGroupId";
        }

        public override List<DbParameter> GetFullParameters()
        {
            List<DbParameter> lstDbParameter = new List<DbParameter>();
            lstDbParameter.Add(dbplatform.Instance.ExcuteImport.CreateDbParameter(dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "userGroupId", this.userGroupId));
            lstDbParameter.Add(dbplatform.Instance.ExcuteImport.CreateDbParameter(dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "userGroupName", this.userGroupName));
            lstDbParameter.Add(dbplatform.Instance.ExcuteImport.CreateDbParameter(dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "parentId", this.parentId));
            lstDbParameter.Add(dbplatform.Instance.ExcuteImport.CreateDbParameter(dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "remark", this.remark));
            lstDbParameter.Add(dbplatform.Instance.ExcuteImport.CreateDbParameter(dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "status", this.status));
            return lstDbParameter;
        }

    }

    public class t_usergroupColumns
    {
        public Column userGroupId = new Column("t_usergroup.userGroupId", dbplatform.Instance.ExcuteImport);
        public Column userGroupName = new Column("t_usergroup.userGroupName", dbplatform.Instance.ExcuteImport);
        public Column parentId = new Column("t_usergroup.parentId", dbplatform.Instance.ExcuteImport);
        public Column remark = new Column("t_usergroup.remark", dbplatform.Instance.ExcuteImport);
        public Column status = new Column("t_usergroup.status", dbplatform.Instance.ExcuteImport);
    }
}

