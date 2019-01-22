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

        private string systemCode_;
        public string systemCode
        {
            get { return systemCode_; }
            set { systemCode_ = value; }
        }

        private string status_;
        public string status
        {
            get { return status_; }
            set { status_ = value; }
        }

        private string instruction_;
        public string instruction
        {
            get { return instruction_; }
            set { instruction_ = value; }
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
			model.systemCode_ = dataRow["systemCode"] as string;
			model.status_ = dataRow["status"] as string;
			model.instruction_ = dataRow["instruction"] as string;
			model.remark_ = dataRow["remark"] as string;
            
			return model;
        }

        public override IEntity Copy()
        {
            t_usergroup model = new t_usergroup();
            model.userGroupId_ = this.userGroupId;
            model.userGroupName_ = this.userGroupName;
            model.systemCode_ = this.systemCode;
            model.status_ = this.status;
            model.instruction_ = this.instruction;
            model.remark_ = this.remark;
            return model;
        }

        public override object ColumnValue(string columnName)
        {
            switch (columnName)
            {
				case "userGroupId": return this.userGroupId;
				case "userGroupName": return this.userGroupName;
				case "systemCode": return this.systemCode;
				case "status": return this.status;
				case "instruction": return this.instruction;
				case "remark": return this.remark;

                default: return null;
            }
        }

        public override void SetColumnValue(string columnName, object value)
        {
            switch (columnName)
            {
				case "userGroupId": this.userGroupId = (string)value; break;
				case "userGroupName": this.userGroupName = (string)value; break;
				case "systemCode": this.systemCode = (string)value; break;
				case "status": this.status = (string)value; break;
				case "instruction": this.instruction = (string)value; break;
				case "remark": this.remark = (string)value; break;
            }
        }

        public override bool HasColumn(string columnName)
        {
            switch (columnName)
            {
				case "userGroupId": return true;
				case "userGroupName": return true;
				case "systemCode": return true;
				case "status": return true;
				case "instruction": return true;
				case "remark": return true;
				
                default: return false;
            }
        }

        public override Column GetColumn(string columnName)
        {
            switch (columnName)
            {
				case "userGroupId": return t_usergroup._.userGroupId;
				case "userGroupName": return t_usergroup._.userGroupName;
				case "systemCode": return t_usergroup._.systemCode;
				case "status": return t_usergroup._.status;
				case "instruction": return t_usergroup._.instruction;
				case "remark": return t_usergroup._.remark;
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
            if (this.systemCode != ((t_usergroup)newModel).systemCode)
            {
                lst.Add(new CompareEntity("systemCode", this.systemCode + ""));
            }
            if (this.status != ((t_usergroup)newModel).status)
            {
                lst.Add(new CompareEntity("status", this.status + ""));
            }
            if (this.instruction != ((t_usergroup)newModel).instruction)
            {
                lst.Add(new CompareEntity("instruction", this.instruction + ""));
            }
            if (this.remark != ((t_usergroup)newModel).remark)
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
            return "INSERT t_usergroup(userGroupId, userGroupName, systemCode, status, instruction, remark) VALUES("+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"userGroupId, "+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"userGroupName, "+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"systemCode, "+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"status, "+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"instruction, "+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"remark)";
        }

        public override string GetUpdatePlate()
        {
            return "UPDATE t_usergroup SET userGroupName="+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"userGroupName, systemCode="+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"systemCode, status="+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"status, instruction="+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"instruction, remark="+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"remark WHERE userGroupId=" + dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "userGroupId";
        }

        public override List<DbParameter> GetFullParameters()
        {
            List<DbParameter> lstDbParameter = new List<DbParameter>();
            lstDbParameter.Add(dbplatform.Instance.ExcuteImport.CreateDbParameter(dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "userGroupId", this.userGroupId));
            lstDbParameter.Add(dbplatform.Instance.ExcuteImport.CreateDbParameter(dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "userGroupName", this.userGroupName));
            lstDbParameter.Add(dbplatform.Instance.ExcuteImport.CreateDbParameter(dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "systemCode", this.systemCode));
            lstDbParameter.Add(dbplatform.Instance.ExcuteImport.CreateDbParameter(dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "status", this.status));
            lstDbParameter.Add(dbplatform.Instance.ExcuteImport.CreateDbParameter(dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "instruction", this.instruction));
            lstDbParameter.Add(dbplatform.Instance.ExcuteImport.CreateDbParameter(dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "remark", this.remark));
            return lstDbParameter;
        }

    }

    public class t_usergroupColumns
    {
        public Column userGroupId = new Column("t_usergroup.userGroupId", dbplatform.Instance.ExcuteImport);
        public Column userGroupName = new Column("t_usergroup.userGroupName", dbplatform.Instance.ExcuteImport);
        public Column systemCode = new Column("t_usergroup.systemCode", dbplatform.Instance.ExcuteImport);
        public Column status = new Column("t_usergroup.status", dbplatform.Instance.ExcuteImport);
        public Column instruction = new Column("t_usergroup.instruction", dbplatform.Instance.ExcuteImport);
        public Column remark = new Column("t_usergroup.remark", dbplatform.Instance.ExcuteImport);
    }
}

