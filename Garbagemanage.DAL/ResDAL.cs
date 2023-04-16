using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garbagemanage.Models.UIModels;
using Garbagemanage.DAL;
using Garbagemanage.Models;
using Garbagemanage.DAL.Base;
using System.Data.SqlClient;
using Helper;

namespace Garbagemanage.DAL
{
    public class ResDAL: BaseDAL<ResInfo>
    {
        /// <summary>
        /// 分页条件查询站点信息
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="isDeleted"></param>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PageModel<ResInfo> FindUserList(string keywords, int isDeleted, int startIndex, int pageSize)
        {
            string strWhere = $"IsDeleted={isDeleted}";
            if (!string.IsNullOrEmpty(keywords))
            {
                strWhere += " and (UserNo like @keywords or UserName  like @keywords or UserIDnumber  like @keywords or Phone  like @keywords or UserAddress  like @keywords )";
            }
            string cols = CreateSql.GetColNames<ResInfo>("");//全部属性名都要查询出来
            SqlParameter para = new SqlParameter("@keywords", $"%{keywords}%");
            return GetRowsModelList<ResInfo>(strWhere, cols, "Id", "UserId", startIndex, pageSize,"", para);
        }

        /// <summary>
        /// 获取所有站点列表（绑定下拉框）
        /// </summary>
        /// <returns></returns>
        public List<ResInfo> GetCboUserList()
        {
            return GetModelList("Special=1 and IsDeleted=0", "UserId,UserName", "");
        }

        /// <summary>
        /// 检查名称或编码是否存在
        /// </summary>
        /// <param name="value"></param>
        /// <param name="isNo"></param>
        /// <returns></returns>
        public bool ExistUserNoOrName(string value, bool isNo)
        {
            if (isNo)
                return ExistsByName("UserNo", value);
            else
                return ExistsByName("UserName", value);
        }

        /// <summary>
        /// 添加居民，返回居民编号
        /// </summary>
        /// <param name="station"></param>
        /// <returns></returns>
        public int AddUser(ResInfo user)
        {
            string cols = CreateSql.GetColNames<ResInfo>("UserId");
            return Add(user, cols, 1);
        }

        /// <summary>
        /// 删除/恢复/移除站点信息
        /// </summary>
        /// <param name="stationIds"></param>
        /// <param name="delType">删除类别 0假删除  1真删除</param>
        /// <param name="isDeleted">0恢复  1 删除  2 真删除</param>
        /// <returns></returns>
        public bool UpdateUserDelState(List<int> UserIds, int delType, int isDeleted)
        {
            string strIds = string.Join(",", UserIds);
            string strWhere = $"UserId in ({strIds})";
            List<string> sqlList = new List<string>();
            if (delType == 0)
            {
                sqlList.Add(CreateSql.CreateLogicDeleteSql<ResInfo>(strWhere, isDeleted));
            }
            else
            {
                sqlList.Add(CreateSql.CreateDeleteSql<ResInfo>(strWhere));
            }
            return SqlHelper.ExecuteTrans(sqlList);
        }
    }
}
