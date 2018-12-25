using System;
using APIServer.DataAccess.DBPlatform.User;

namespace APIServer.DataAccess.DBPlatform
{
    /// <summary>
    /// 数据库访问类
    /// 作者:程淮榕
    /// 日期：2018-12-23
    /// </summary>
    public class Data
    {
        #region 表单
        public static UserDataAccess UserData = new UserDataAccess();   //用户数据访问类
        #endregion

        #region 视图
        public static VUserUserGroupDataAccess VUserGroupData = new VUserUserGroupDataAccess();  //用户-用户组数据访问类
        #endregion
    }
}
