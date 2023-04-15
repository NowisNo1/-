using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garbagemanage.DAL;
using Garbagemanage.Models;

namespace Garbagemanage.BLL
{
    public class UserBLL
    {
        UserDAL userDAL = new UserDAL();

        /// <summary>
        /// 登录系统
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public string Login(DLUser userInfo)
        {
            string reStr = "";
            DLUser reUser = userDAL.Login(userInfo);
            if(reUser==null)
            {
                reStr = "账号或密码错误，请检查！";
            }
            else
            {
                if(reUser.UserState)
                {
                    reStr = "1";//正常
                }
                else
                {
                    reStr = "该账号已账号，不能使用系统！";
                }
            }
            return reStr;
        }
    }
}
