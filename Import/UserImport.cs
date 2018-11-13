using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using ApiServer.Interface;

namespace ApiServer.Import
{
    public class UserImport : ICommonInterface
    {
        public int BantchCreateData<T>(List<T> objectList, ref DbTransaction dbtran) where T : class
        {
            throw new NotImplementedException();
        }

        public int BantchCreateData<T>(List<T> objectList, string userName, ref DbTransaction dbtran) where T : class
        {
            throw new NotImplementedException();
        }

        public int BantchCreateData<T>(List<T> objectList, DateTime dtInsert, ref DbTransaction dbtran) where T : class
        {
            throw new NotImplementedException();
        }

        public int BantchCreateData<T>(List<T> objectList, DateTime dtInsert, string userName, ref DbTransaction dbtran) where T : class
        {
            throw new NotImplementedException();
        }

        public int CreateData(object o)
        {
            throw new NotImplementedException();
        }

        public int CreateData(object o, string userName)
        {
            throw new NotImplementedException();
        }

        public int CreateData(object o, DateTime dtInsert)
        {
            throw new NotImplementedException();
        }

        public int CreateData(object o, string userName, DateTime dtInsert)
        {
            throw new NotImplementedException();
        }

        public T GetData<T>(string key) where T : class
        {
            throw new NotImplementedException();
        }

        public List<T> GetList<T>(string key) where T : class
        {
            throw new NotImplementedException();
        }

        public List<T> GetList<T>(string key, int pageIndex, int pageSize) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
