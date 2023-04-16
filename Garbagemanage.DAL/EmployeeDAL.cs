using Helper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garbagemanage.DAL.Base;
using Garbagemanage.Models;
using Garbagemanage.Models.UIModels;

namespace Garbagemanage.DAL
{
    public class EmployeeDAL:BaseDAL<EmployeeInfo>
    {
        /// <summary>
        /// 分页条件查询站点信息
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="isDeleted"></param>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PageModel<EmployeeInfo> FindEmpList(string keywords, int isDeleted, int startIndex, int pageSize)
        {
            string strWhere = $"IsDeleted={isDeleted}";
            if (!string.IsNullOrEmpty(keywords))
            {
                strWhere += " and (EmpNo like @keywords or EmpName  like @keywords or EmpIDnumber  like @keywords or Phone  like @keywords or EmpAddress  like @keywords )";
            }
            string cols = CreateSql.GetColNames<EmployeeInfo>("");//全部属性名都要查询出来
            SqlParameter para = new SqlParameter("@keywords", $"%{keywords}%");
            return GetRowsModelList<EmployeeInfo>(strWhere, cols, "Id", "EmpId", startIndex, pageSize,"",para);
        }

        /// <summary>
        /// 获取所有站点列表（绑定下拉框）
        /// </summary>
        /// <returns></returns>
        public List<EmployeeInfo> GetCboEmpList()
        {
            return GetModelList("IsOn=1 and IsDeleted=0", "EmpId,EmpName", "");
        }

        /// <summary>
        /// 检查名称或编码是否存在
        /// </summary>
        /// <param name="value"></param>
        /// <param name="isNo"></param>
        /// <returns></returns>
        public bool ExistEmpNoOrName(string value, bool isNo)
        {
            if (isNo)
                return ExistsByName("EmpNo", value);
            else
                return ExistsByName("EmpName", value);
        }

        /// <summary>
        /// 添加居民，返回居民编号
        /// </summary>
        /// <param name="station"></param>
        /// <returns></returns>
        public int AddEmp(EmployeeInfo emp)
        {
            string cols = CreateSql.GetColNames<EmployeeInfo>("EmpId");
            return Add(emp, cols, 1);
        }

        /// <summary>
        /// 删除/恢复/移除站点信息
        /// </summary>
        /// <param name="stationIds"></param>
        /// <param name="delType">删除类别 0假删除  1真删除</param>
        /// <param name="isDeleted">0恢复  1 删除  2 真删除</param>
        /// <returns></returns>
        public bool UpdateEmpDelState(List<int> EmpIds, int delType, int isDeleted)
        {
            string strIds = string.Join(",", EmpIds);
            string strWhere = $"EmpId in ({strIds})";
            List<string> sqlList = new List<string>();
            if (delType == 0)
            {
                sqlList.Add(CreateSql.CreateLogicDeleteSql<EmployeeInfo>(strWhere, isDeleted));
            }
            else
            {
                sqlList.Add(CreateSql.CreateDeleteSql<EmployeeInfo>(strWhere));
            }
            return SqlHelper.ExecuteTrans(sqlList);
        }
    }
}
