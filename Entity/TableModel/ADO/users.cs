using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Data;
using System;
using System.Text;
using SQLServer;
using Newtonsoft.Json;
namespace ApiServer.Entity
{
    [Serializable]
    public class users : IEntity
    {
        public static usersColumns _ = new usersColumns();
		
        private Int64? Id_;
		[DescriptionAttribute("PrimaryKey")]
        public Int64? Id
        {
            get { return Id_; }
            set { Id_ = value; }
        }

        private string PassWord_;
        public string PassWord
        {
            get { return PassWord_; }
            set { PassWord_ = value; }
        }

        private string UserName_;
        public string UserName
        {
            get { return UserName_; }
            set { UserName_ = value; }
        }

		[JsonIgnore]
        public override string TableName
        {
            get { return "users"; }
        }
        [JsonIgnore]
        public override string SqlTableName
        {
            get { return "users as users"; }
        }
        [JsonIgnore]
        public override string PrimaryKey
        {
            get { return "Id"; }
        }
        [JsonIgnore]
        public override string OrderFiled
        {
            get { return "Id"; }
        }
        [JsonIgnore]
        public override object PrimaryKeyValue
        {
            get { return this.Id; }
        }

        public override IEntity SetModel(DataRow dataRow)
        {
            users model = new users();
			model.Id_ = dataRow["Id"] as Int64?;
			model.PassWord_ = dataRow["PassWord"] as string;
			model.UserName_ = dataRow["UserName"] as string;
            
			return model;
        }

        public override IEntity Copy()
        {
            users model = new users();
            model.Id_ = this.Id;
            model.PassWord_ = this.PassWord;
            model.UserName_ = this.UserName;
            return model;
        }

        public override object ColumnValue(string columnName)
        {
            switch (columnName)
            {
				case "Id": return this.Id;
				case "PassWord": return this.PassWord;
				case "UserName": return this.UserName;

                default: return null;
            }
        }

        public override void SetColumnValue(string columnName, object value)
        {
            switch (columnName)
            {
				case "Id": this.Id = (Int64?)value; break;
				case "PassWord": this.PassWord = (string)value; break;
				case "UserName": this.UserName = (string)value; break;
            }
        }

        public override bool HasColumn(string columnName)
        {
            switch (columnName)
            {
				case "Id": return true;
				case "PassWord": return true;
				case "UserName": return true;
				
                default: return false;
            }
        }

        public override Column GetColumn(string columnName)
        {
            switch (columnName)
            {
				case "Id": return users._.Id;
				case "PassWord": return users._.PassWord;
				case "UserName": return users._.UserName;
                default: return null;
            }
        }

        public override List<CompareEntity> EntityCompare(IEntity newModel)
        {
            List<CompareEntity> lst = new List<CompareEntity>();
            if (this.Id != ((users)newModel).Id)
            {
                lst.Add(new CompareEntity("Id", this.Id + ""));
            }
            if (this.PassWord != ((users)newModel).PassWord)
            {
                lst.Add(new CompareEntity("PassWord", this.PassWord + ""));
            }
            if (this.UserName != ((users)newModel).UserName)
            {
                lst.Add(new CompareEntity("UserName", this.UserName + ""));
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
            return "INSERT users(Id, PassWord, UserName) VALUES("+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"Id, "+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"PassWord, "+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"UserName)";
        }

        public override string GetUpdatePlate()
        {
            return "UPDATE users SET PassWord="+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"PassWord, UserName="+dbplatform.Instance.ExcuteImport.sqlSetting.Flag+"UserName WHERE Id=" + dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "Id";
        }

        public override List<DbParameter> GetFullParmeters()
        {
            List<DbParameter> lstDbParameter = new List<DbParameter>();
            lstDbParameter.Add(dbplatform.Instance.ExcuteImport.CreateDbParameter(dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "Id", this.Id));
            lstDbParameter.Add(dbplatform.Instance.ExcuteImport.CreateDbParameter(dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "PassWord", this.PassWord));
            lstDbParameter.Add(dbplatform.Instance.ExcuteImport.CreateDbParameter(dbplatform.Instance.ExcuteImport.sqlSetting.Flag + "UserName", this.UserName));
            return lstDbParameter;
        }

    }

    public class usersColumns
    {
        public Column Id = new Column("users.Id", dbplatform.Instance.ExcuteImport);
        public Column PassWord = new Column("users.PassWord", dbplatform.Instance.ExcuteImport);
        public Column UserName = new Column("users.UserName", dbplatform.Instance.ExcuteImport);
    }
}

