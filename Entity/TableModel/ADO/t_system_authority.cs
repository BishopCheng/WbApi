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
    public class t_system_authority : IEntity
    {
        public static t_system_authorityColumns _ = new t_system_authorityColumns();
		
        private string authorityId_;
		[DescriptionAttribute("PrimaryKey")]
        public string authorityId
        {
            get { return authorityId_; }
            set { authorityId_ = value; }
        }

        private string authorityName_;
        public string authorityName
        {
            get { return authorityName_; }
            set { authorityName_ = value; }
        }

        private string pageId_;
        public string pageId
        {
            get { return pageId_; }
            set { pageId_ = value; }
        }

        private string authorityIconId_;
        public string authorityIconId
        {
            get { return authorityIconId_; }
            set { authorityIconId_ = value; }
        }

        private string authoritySource_;
        public string authoritySource
        {
            get { return authoritySource_; }
            set { authoritySource_ = value; }
        }

        private string authorityStatus_;
        public string authorityStatus
        {
            get { return authorityStatus_; }
            set { authorityStatus_ = value; }
        }

		[JsonIgnore]
        public override string TableName
        {
            get { return "t_system_authority"; }
        }
        [JsonIgnore]
        public override string SqlTableName
        {
            get { return "t_system_authority as t_system_authority"; }
        }
        [JsonIgnore]
        public override string PrimaryKey
        {
            get { return "authorityId"; }
        }
        [JsonIgnore]
        public override string OrderFiled
        {
            get { return "authorityId"; }
        }
        [JsonIgnore]
        public override object PrimaryKeyValue
        {
            get { return this.authorityId; }
        }

        public override IEntity SetModel(DataRow dataRow)
        {
            t_system_authority model = new t_system_authority();
			model.authorityId_ = dataRow["authorityId"] as string;
			model.authorityName_ = dataRow["authorityName"] as string;
			model.pageId_ = dataRow["pageId"] as string;
			model.authorityIconId_ = dataRow["authorityIconId"] as string;
			model.authoritySource_ = dataRow["authoritySource"] as string;
			model.authorityStatus_ = dataRow["authorityStatus"] as string;
            
			return model;
        }

        public override IEntity Copy()
        {
            t_system_authority model = new t_system_authority();
            model.authorityId_ = this.authorityId;
            model.authorityName_ = this.authorityName;
            model.pageId_ = this.pageId;
            model.authorityIconId_ = this.authorityIconId;
            model.authoritySource_ = this.authoritySource;
            model.authorityStatus_ = this.authorityStatus;
            return model;
        }

        public override object ColumnValue(string columnName)
        {
            switch (columnName)
            {
				case "authorityId": return this.authorityId;
				case "authorityName": return this.authorityName;
				case "pageId": return this.pageId;
				case "authorityIconId": return this.authorityIconId;
				case "authoritySource": return this.authoritySource;
				case "authorityStatus": return this.authorityStatus;

                default: return null;
            }
        }

        public override void SetColumnValue(string columnName, object value)
        {
            switch (columnName)
            {
				case "authorityId": this.authorityId = (string)value; break;
				case "authorityName": this.authorityName = (string)value; break;
				case "pageId": this.pageId = (string)value; break;
				case "authorityIconId": this.authorityIconId = (string)value; break;
				case "authoritySource": this.authoritySource = (string)value; break;
				case "authorityStatus": this.authorityStatus = (string)value; break;
            }
        }

        public override bool HasColumn(string columnName)
        {
            switch (columnName)
            {
				case "authorityId": return true;
				case "authorityName": return true;
				case "pageId": return true;
				case "authorityIconId": return true;
				case "authoritySource": return true;
				case "authorityStatus": return true;
				
                default: return false;
            }
        }

        public override Column GetColumn(string columnName)
        {
            switch (columnName)
            {
				case "authorityId": return t_system_authority._.authorityId;
				case "authorityName": return t_system_authority._.authorityName;
				case "pageId": return t_system_authority._.pageId;
				case "authorityIconId": return t_system_authority._.authorityIconId;
				case "authoritySource": return t_system_authority._.authoritySource;
				case "authorityStatus": return t_system_authority._.authorityStatus;
                default: return null;
            }
        }

        public override List<CompareEntity> EntityCompare(IEntity newModel)
        {
            List<CompareEntity> lst = new List<CompareEntity>();
            if (this.authorityId != ((t_system_authority)newModel).authorityId)
            {
                lst.Add(new CompareEntity("authorityId", this.authorityId + ""));
            }
            if (this.authorityName != ((t_system_authority)newModel).authorityName)
            {
                lst.Add(new CompareEntity("authorityName", this.authorityName + ""));
            }
            if (this.pageId != ((t_system_authority)newModel).pageId)
            {
                lst.Add(new CompareEntity("pageId", this.pageId + ""));
            }
            if (this.authorityIconId != ((t_system_authority)newModel).authorityIconId)
            {
                lst.Add(new CompareEntity("authorityIconId", this.authorityIconId + ""));
            }
            if (this.authoritySource != ((t_system_authority)newModel).authoritySource)
            {
                lst.Add(new CompareEntity("authoritySource", this.authoritySource + ""));
            }
            if (this.authorityStatus != ((t_system_authority)newModel).authorityStatus)
            {
                lst.Add(new CompareEntity("authorityStatus", this.authorityStatus + ""));
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
            return "INSERT t_system_authority(authorityId, authorityName, pageId, authorityIconId, authoritySource, authorityStatus) VALUES("+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"authorityId, "+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"authorityName, "+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"pageId, "+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"authorityIconId, "+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"authoritySource, "+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"authorityStatus)";
        }

        public override string GetUpdatePlate()
        {
            return "UPDATE t_system_authority SET authorityName="+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"authorityName, pageId="+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"pageId, authorityIconId="+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"authorityIconId, authoritySource="+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"authoritySource, authorityStatus="+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"authorityStatus WHERE authorityId=" + dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "authorityId";
        }

        public override List<DbParameter> GetFullParameters()
        {
            List<DbParameter> lstDbParameter = new List<DbParameter>();
            lstDbParameter.Add(dbplatform.Instance.ExcuteImport.CreateDbParameter(dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "authorityId", this.authorityId));
            lstDbParameter.Add(dbplatform.Instance.ExcuteImport.CreateDbParameter(dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "authorityName", this.authorityName));
            lstDbParameter.Add(dbplatform.Instance.ExcuteImport.CreateDbParameter(dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "pageId", this.pageId));
            lstDbParameter.Add(dbplatform.Instance.ExcuteImport.CreateDbParameter(dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "authorityIconId", this.authorityIconId));
            lstDbParameter.Add(dbplatform.Instance.ExcuteImport.CreateDbParameter(dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "authoritySource", this.authoritySource));
            lstDbParameter.Add(dbplatform.Instance.ExcuteImport.CreateDbParameter(dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "authorityStatus", this.authorityStatus));
            return lstDbParameter;
        }

    }

    public class t_system_authorityColumns
    {
        public Column authorityId = new Column("t_system_authority.authorityId", dbplatform.Instance.ExcuteImport);
        public Column authorityName = new Column("t_system_authority.authorityName", dbplatform.Instance.ExcuteImport);
        public Column pageId = new Column("t_system_authority.pageId", dbplatform.Instance.ExcuteImport);
        public Column authorityIconId = new Column("t_system_authority.authorityIconId", dbplatform.Instance.ExcuteImport);
        public Column authoritySource = new Column("t_system_authority.authoritySource", dbplatform.Instance.ExcuteImport);
        public Column authorityStatus = new Column("t_system_authority.authorityStatus", dbplatform.Instance.ExcuteImport);
    }
}

