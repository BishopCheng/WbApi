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
    public class t_system : IEntity
    {
        public static t_systemColumns _ = new t_systemColumns();
		
        private string systemId_;
		[DescriptionAttribute("PrimaryKey")]
        public string systemId
        {
            get { return systemId_; }
            set { systemId_ = value; }
        }

        private string systemName_;
        public string systemName
        {
            get { return systemName_; }
            set { systemName_ = value; }
        }

        private string systemLogoUrl_;
        public string systemLogoUrl
        {
            get { return systemLogoUrl_; }
            set { systemLogoUrl_ = value; }
        }

        private string systemWebUrl_;
        public string systemWebUrl
        {
            get { return systemWebUrl_; }
            set { systemWebUrl_ = value; }
        }

        private string systemVersion_;
        public string systemVersion
        {
            get { return systemVersion_; }
            set { systemVersion_ = value; }
        }

        private string status_;
        public string status
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
            get { return "t_system"; }
        }
        [JsonIgnore]
        public override string SqlTableName
        {
            get { return "t_system as t_system"; }
        }
        [JsonIgnore]
        public override string PrimaryKey
        {
            get { return "systemId"; }
        }
        [JsonIgnore]
        public override string OrderFiled
        {
            get { return "systemId"; }
        }
        [JsonIgnore]
        public override object PrimaryKeyValue
        {
            get { return this.systemId; }
        }

        public override IEntity SetModel(DataRow dataRow)
        {
            t_system model = new t_system();
			model.systemId_ = dataRow["systemId"] as string;
			model.systemName_ = dataRow["systemName"] as string;
			model.systemLogoUrl_ = dataRow["systemLogoUrl"] as string;
			model.systemWebUrl_ = dataRow["systemWebUrl"] as string;
			model.systemVersion_ = dataRow["systemVersion"] as string;
			model.status_ = dataRow["status"] as string;
			model.remark_ = dataRow["remark"] as string;
            
			return model;
        }

        public override IEntity Copy()
        {
            t_system model = new t_system();
            model.systemId_ = this.systemId;
            model.systemName_ = this.systemName;
            model.systemLogoUrl_ = this.systemLogoUrl;
            model.systemWebUrl_ = this.systemWebUrl;
            model.systemVersion_ = this.systemVersion;
            model.status_ = this.status;
            model.remark_ = this.remark;
            return model;
        }

        public override object ColumnValue(string columnName)
        {
            switch (columnName)
            {
				case "systemId": return this.systemId;
				case "systemName": return this.systemName;
				case "systemLogoUrl": return this.systemLogoUrl;
				case "systemWebUrl": return this.systemWebUrl;
				case "systemVersion": return this.systemVersion;
				case "status": return this.status;
				case "remark": return this.remark;

                default: return null;
            }
        }

        public override void SetColumnValue(string columnName, object value)
        {
            switch (columnName)
            {
				case "systemId": this.systemId = (string)value; break;
				case "systemName": this.systemName = (string)value; break;
				case "systemLogoUrl": this.systemLogoUrl = (string)value; break;
				case "systemWebUrl": this.systemWebUrl = (string)value; break;
				case "systemVersion": this.systemVersion = (string)value; break;
				case "status": this.status = (string)value; break;
				case "remark": this.remark = (string)value; break;
            }
        }

        public override bool HasColumn(string columnName)
        {
            switch (columnName)
            {
				case "systemId": return true;
				case "systemName": return true;
				case "systemLogoUrl": return true;
				case "systemWebUrl": return true;
				case "systemVersion": return true;
				case "status": return true;
				case "remark": return true;
				
                default: return false;
            }
        }

        public override Column GetColumn(string columnName)
        {
            switch (columnName)
            {
				case "systemId": return t_system._.systemId;
				case "systemName": return t_system._.systemName;
				case "systemLogoUrl": return t_system._.systemLogoUrl;
				case "systemWebUrl": return t_system._.systemWebUrl;
				case "systemVersion": return t_system._.systemVersion;
				case "status": return t_system._.status;
				case "remark": return t_system._.remark;
                default: return null;
            }
        }

        public override List<CompareEntity> EntityCompare(IEntity newModel)
        {
            List<CompareEntity> lst = new List<CompareEntity>();
            if (this.systemId != ((t_system)newModel).systemId)
            {
                lst.Add(new CompareEntity("systemId", this.systemId + ""));
            }
            if (this.systemName != ((t_system)newModel).systemName)
            {
                lst.Add(new CompareEntity("systemName", this.systemName + ""));
            }
            if (this.systemLogoUrl != ((t_system)newModel).systemLogoUrl)
            {
                lst.Add(new CompareEntity("systemLogoUrl", this.systemLogoUrl + ""));
            }
            if (this.systemWebUrl != ((t_system)newModel).systemWebUrl)
            {
                lst.Add(new CompareEntity("systemWebUrl", this.systemWebUrl + ""));
            }
            if (this.systemVersion != ((t_system)newModel).systemVersion)
            {
                lst.Add(new CompareEntity("systemVersion", this.systemVersion + ""));
            }
            if (this.status != ((t_system)newModel).status)
            {
                lst.Add(new CompareEntity("status", this.status + ""));
            }
            if (this.remark != ((t_system)newModel).remark)
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
            return "INSERT t_system(systemId, systemName, systemLogoUrl, systemWebUrl, systemVersion, status, remark) VALUES("+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"systemId, "+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"systemName, "+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"systemLogoUrl, "+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"systemWebUrl, "+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"systemVersion, "+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"status, "+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"remark)";
        }

        public override string GetUpdatePlate()
        {
            return "UPDATE t_system SET systemName="+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"systemName, systemLogoUrl="+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"systemLogoUrl, systemWebUrl="+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"systemWebUrl, systemVersion="+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"systemVersion, status="+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"status, remark="+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"remark WHERE systemId=" + dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "systemId";
        }

        public override List<DbParameter> GetFullParameters()
        {
            List<DbParameter> lstDbParameter = new List<DbParameter>();
            lstDbParameter.Add(dbplatform.Instance.ExcuteImport.CreateDbParameter(dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "systemId", this.systemId));
            lstDbParameter.Add(dbplatform.Instance.ExcuteImport.CreateDbParameter(dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "systemName", this.systemName));
            lstDbParameter.Add(dbplatform.Instance.ExcuteImport.CreateDbParameter(dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "systemLogoUrl", this.systemLogoUrl));
            lstDbParameter.Add(dbplatform.Instance.ExcuteImport.CreateDbParameter(dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "systemWebUrl", this.systemWebUrl));
            lstDbParameter.Add(dbplatform.Instance.ExcuteImport.CreateDbParameter(dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "systemVersion", this.systemVersion));
            lstDbParameter.Add(dbplatform.Instance.ExcuteImport.CreateDbParameter(dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "status", this.status));
            lstDbParameter.Add(dbplatform.Instance.ExcuteImport.CreateDbParameter(dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "remark", this.remark));
            return lstDbParameter;
        }

    }

    public class t_systemColumns
    {
        public Column systemId = new Column("t_system.systemId", dbplatform.Instance.ExcuteImport);
        public Column systemName = new Column("t_system.systemName", dbplatform.Instance.ExcuteImport);
        public Column systemLogoUrl = new Column("t_system.systemLogoUrl", dbplatform.Instance.ExcuteImport);
        public Column systemWebUrl = new Column("t_system.systemWebUrl", dbplatform.Instance.ExcuteImport);
        public Column systemVersion = new Column("t_system.systemVersion", dbplatform.Instance.ExcuteImport);
        public Column status = new Column("t_system.status", dbplatform.Instance.ExcuteImport);
        public Column remark = new Column("t_system.remark", dbplatform.Instance.ExcuteImport);
    }
}

