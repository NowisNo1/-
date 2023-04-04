using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garbagemanage.Models.UIModels;
using Garbagemanage.DAL;
using Garbagemanage.Models;

namespace Garbagemanage.BLL
{
    public class ResBLL
    {
        ResDAL resDAL = new ResDAL();
        /// <summary>
        /// 分页查询居民信息
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="isShowDel"></param>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PageModel<ResInfo> FindUserList(string keywords, bool isShowDel, int startIndex, int pageSize)
        {
            int isDeleted = isShowDel ? 1 : 0;
            return resDAL.FindUserList(keywords, isDeleted, startIndex, pageSize);
        }
        /// <summary>
        /// 获取绑定下拉框的所有居民信息列表
        /// </summary>
        /// <returns></returns>
        public List<ResInfo> GetCboStationList()
        {
            return resDAL.GetCboStationList();
        }

        /// <summary>
        /// 添加居民，返回居民编号
        /// </summary>
        /// <param name="station"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public int AddUser(ResInfo User)
        {
            if (User == null)
                throw new Exception("居民信息不能为空！");
            return resDAL.AddStation(User);
        }

        /// <summary>
        /// 修改居民信息
        /// </summary>
        /// <param name="station"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool UpdateUser(ResInfo User)
        {
            if (User == null)
                throw new Exception("居民信息不能为空！");
            return resDAL.Update(User, "");
        }

        /// <summary>
        /// 判断居民编码是否存在
        /// </summary>
        /// <param name="stationNo"></param>
        /// <returns></returns>
        public bool ExistUserNo(string UserNo)
        {
            return resDAL.ExistStationNoOrName(UserNo, true);
        }

        /// <summary>
        /// 判断居民姓名是否存在
        /// </summary>
        /// <param name="stationName"></param>
        /// <returns></returns>
        public bool ExistUserName(string userName)
        {
            return resDAL.ExistStationNoOrName(userName, false);
        }

        /// <summary>
        /// 获取指定居民信息
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        public ResInfo GetUser(int userId)
        {
            return resDAL.GetById(userId, "");
        }

        /// <summary>
        /// 删除居民（逻辑删除）
        /// </summary>
        /// <param name="stations"></param>
        /// <returns></returns>
        public string DeleteUser(List<ResInfo> users)
        {
            string reStr = "";
            string hasNames = "";//存储运营中居民名称字符串
            List<int> userIds = new List<int>();//存储符合删除的居民编号
            foreach (ResInfo user in users)
            {
                if (user.Special)
                {
                    if (hasNames != "")
                        hasNames += ",";
                    hasNames += user.UserName;
                }
                else
                    userIds.Add(user.UserId);
            }
            bool blDel = false;
            if (userIds.Count > 0)
            {
                blDel = resDAL.UpdateUserDelState(userIds, 0, 1);//删除信息列表
            }
            if (blDel)
            {
                if (hasNames == "")
                    reStr = "1";//删除成功
                else
                    reStr = "1;" + hasNames;//删除成功，但存在不能删除的信息
            }
            else
            {
                if (userIds.Count > 0)
                    reStr = "0";//删除失败
                else
                {
                    reStr = "-1;";//所有选择的信息都不能删除
                }
            }
            return reStr;
        }

        /// <summary>
        /// 恢复居民信息
        /// </summary>
        /// <param name="stationIds"></param>
        /// <returns></returns>
        public bool RecoverUsers(List<int> userIds)
        {
            return resDAL.UpdateUserDelState(userIds, 0, 0);
        }

        /// <summary>
        /// 移除居民信息
        /// </summary>
        /// <param name="stationIds"></param>
        /// <returns></returns>
        public bool RemoveUsers(List<int> userIds)
        {
            return resDAL.UpdateUserDelState(userIds, 1, 2);
        }
    }
}
