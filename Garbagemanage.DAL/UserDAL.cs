using Garbagemanage.DAL.Base;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garbagemanage.Models;


namespace Garbagemanage.DAL
{
    public class UserDAL:BaseDAL<DLUser>
    {

         //登录系统方法
         public DLUser Login(DLUser userInfo)
        {
            string strWhere = "UserName=@userName and UserPwd=@userPwd and IsDeleted=0";
            SqlParameter[] paras =
            {
                new SqlParameter("@userName",userInfo.UserName),
                new SqlParameter("@userPwd",userInfo.UserPwd)
            };
            DLUser reUser = GetModel(strWhere, "UserState", paras);
            return reUser;
        }
    }
}
