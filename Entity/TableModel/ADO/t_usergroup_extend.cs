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
    public class t_usergroup_extend : IEntity
    {
        public static t_usergroup_extendColumns _ = new t_usergroup_extendColumns();
		
        private string groupExtendId_;
		[DescriptionAttribute("PrimaryKey")]
        public string groupExtendId
        {
            get { return groupExtendId_; }
            set { groupExtendId_ = value; }
        }

        private string userGroupId_;
        public string userGroupId
        {
            get { return userGroupId_; }
            set { userGroupId_ = value; }
        }

        private string parentGroupId_;
        public string parentGroupId
        {
            get { return parentGroupId_; }
            set { parentGroupId_ = value; }
        }

		[JsonIgnore]
        public override string TableName
        {
            get { return "t_usergroup_extend"; }
        }
        [JsonIgnore]
        public override string SqlTableName
        {
            get { return "t_usergroup_extend as t_usergroup_extend"; }
        }
        [JsonIgnore]
        public override string PrimaryKey
        {
            get { return "groupExtendId"; }
        }
        [JsonIgnore]
        public override string OrderFiled
        {
            get { return "groupExtendId"; }
        }
        [JsonIgnore]
        public override object PrimaryKeyValue
        {
            get { return this.groupExtendId; }
        }

        public override IEntity SetModel(DataRow dataRow)
        {
            t_usergroup_extend model = new t_usergroup_extend();
			model.groupExtendId_ = dataRow["groupExtendId"] as string;
			model.userGroupId_ = dataRow["userGroupId"] as string;
			model.parentGroupId_ = dataRow["parentGroupId"] as string;
            
			return model;
        }

        public override IEntity Copy()
        {
            t_usergroup_extend model = new t_usergroup_extend();
            model.groupExtendId_ = this.groupExtendId;
            model.userGroupId_ = this.userGroupId;
            model.parentGroupId_ = this.parentGroupId;
            return model;
        }

        public override object ColumnValue(string columnName)
        {
            switch (columnName)
            {
				case "groupExtendId": return this.groupExtendId;
				case "userGroupId": return this.userGroupId;
				case "parentGroupId": return this.parentGroupId;

                default: return null;
            }
        }

        public override void SetColumnValue(string columnName, object value)
        {
            switch (columnName)
            {
				case "groupExtendId": this.groupExtendId = (string)value; break;
				case "userGroupId": this.userGroupId = (string)value; break;
				case "parentGroupId": this.parentGroupId = (string)value; break;
            }
        }

        public override bool HasColumn(string columnName)
        {
            switch (columnName)
            {
				case "groupExtendId": return true;
				case "userGroupId": return true;
				case "parentGroupId": return true;
				
                default: return false;
            }
        }

        public override Column GetColumn(string columnName)
        {
            switch (columnName)
            {
				case "groupExtendId": return t_usergroup_extend._.groupExtendId;
				case "userGroupId": return t_usergroup_extend._.userGroupId;
				case "parentGroupId": return t_usergroup_extend._.parentGroupId;
                default: return null;
            }
        }

        public override List<CompareEntity> EntityCompare(IEntity newModel)
        {
            List<CompareEntity> lst = new List<CompareEntity>();
            if (this.groupExtendId != ((t_usergroup_extend)newModel).groupExtendId)
            {
                lst.Add(new CompareEntity("groupExtendId", this.groupExtendId + ""));
            }
            if (this.userGroupId != ((t_usergroup_extend)newModel).userGroupId)
            {
                lst.Add(new CompareEntity("userGroupId", this.userGroupId + ""));
            }
            if (this.parentGroupId != ((t_usergroup_extend)newModel).parentGroupId)
            {
                lst.Add(new CompareEntity("parentGroupId", this.parentGroupId + ""));
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
            return "INSERT t_usergroup_extend(groupExtendId, userGroupId, parentGroupId) VALUES("+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"groupExtendId, "+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"userGroupId, "+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"parentGroupId)";
        }

        public override string GetUpdatePlate()
        {
            return "UPDATE t_usergroup_extend SET userGroupId="+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"userGroupId, parentGroupId="+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"parentGroupId WHERE groupExtendId=" + dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "groupExtendId";
        }

        public override List<DbParameter> GetFullParameters()
        {
            List<DbParameter> lstDbParameter = new List<DbParameter>();
            lstDbParameter.Add(dbplatform.Instance.ExcuteImport.CreateDbParameter(dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "groupExtendId", this.groupExtendId));
            lstDbParameter.Add(dbplatform.Instance.ExcuteImport.CreateDbParameter(dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "userGroupId", this.userGroupId));
            lstDbParameter.Add(dbplatform.Instance.ExcuteImport.CreateDbParameter(dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "parentGroupId", this.parentGroupId));
            return lstDbParameter;
        }

    }

    public class t_usergroup_extendColumns
    {
        public Column groupExtendId = new Column("t_usergroup_extend.groupExtendId", dbplatform.Instance.ExcuteImport);
        public Column userGroupId = new Column("t_usergroup_extend.userGroupId", dbplatform.Instance.ExcuteImport);
        public Column parentGroupId = new Column("t_usergroup_extend.parentGroupId", dbplatform.Instance.ExcuteImport);
    }
}

