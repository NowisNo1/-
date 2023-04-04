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
        /// 获取指定员工类别下的员工数
        /// </summary>
        /// <param name="empTypeId"></param>
        /// <returns></returns>
        public int GetEmployeeCount(int empTypeId)
        {
            string sql = "select count(1) from EmployeeInfos where IsDeleted=0  and EmpTypeId=" + empTypeId;
            return SelectAndReIntValue(sql);
        }
        /// <summary>
        /// 分页条件查询员工信息
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="isDeleted"></param>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        //public PageModel<EmployeeInfo> FindEmployeeList(string keywords, int isDeleted, int startIndex, int pageSize)
        //{
        //    string strWhere = $"IsDeleted={isDeleted}";
        //    if (!string.IsNullOrEmpty(keywords))
        //    {
        //        strWhere += " and (EmpNo like @keywords or EmpName  like @keywords or EmpIDnumber  like @keywords or Phone  like @keywords )";
        //    }
        //    string cols = CreateSql.GetColNames<EmployeeInfo>("");//全部属性名都要查询出来
        //    SqlParameter para = new SqlParameter("@keywords", $"%{keywords}%");
        //    return GetRowsModelList<EmployeeInfo>(strWhere, cols, "Id", "EmpId", startIndex, pageSize, para);
        //}
        /// <summary>
        /// 获取员工列表（绑定下拉框）
        /// </summary>
        /// <returns></returns>
        public List<EmployeeInfo> GetCboEmployeeList(int stationId)
        {
            string strWhere = "IsDeleted=0  ";
            if (stationId > 0)
                strWhere += " and StationId=" + stationId;
            return GetModelList(strWhere,"EmpId,EmpName", "");
        }

        /// <summary>
        /// 判断员工名称是否存在
        /// </summary>
        /// <param name="empName"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public bool ExistEmpInfo(string empName, string phone)
        {
            string strWhere = "IsDeleted=0 and EmpName=@empName and Phone=@phone";
            SqlParameter[] paras =
            {
                new SqlParameter("@empName",empName),
                new SqlParameter("@phone",phone)
            };
            return Exists(strWhere, paras);
        }

        /// <summary>
        /// 检查员工号是否存在
        /// </summary>
        /// <param name="empNo"></param>
        /// <returns></returns>
        public bool ExistEmpNo(string empNo)
        {
            return ExistsByName("EmpNo", empNo);
        }

        /// <summary>
        /// 添加员工信息
        /// </summary>
        /// <param name="empInfo"></param>
        /// <returns></returns>
        public int AddEmployee(EmployeeInfo empInfo)
        {
            string cols = CreateSql.GetColNames<EmployeeInfo>("EmpId");
            return Add(empInfo, cols, 1);
        }

        /// <summary>
        /// 员工离职
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        public bool EmpLeaveOut(int empId)
        {
            string sql = "update EmployeeInfos set IsOn=0 where EmpId=" + empId;
            return SqlHelper.ExecuteNonQuery(sql, 1) > 0;
        }

        /// <summary>
        /// 员工信息删除、恢复、移除
        /// </summary>
        /// <param name="empIds"></param>
        /// <param name="delType"></param>
        /// <param name="isDeleted"></param>
        /// <returns></returns>
        public bool UpdateEmployeesDelState(List<int> empIds, int delType, int isDeleted)
        {
            string strIds = string.Join(",", empIds);
            string strWhere = $"EmpId in ({strIds})";
            List<string> sqlList = new List<string>();
            if (delType == 0)
            {
                sqlList.Add(CreateSql.CreateLogicDeleteSql<EmployeeInfo>(strWhere, isDeleted));
                //sqlList.Add(CreateSql.CreateLogicDeleteSql<ExpDistributeInfo>(strWhere, isDeleted));
            }
            else
            {
                sqlList.Add(CreateSql.CreateDeleteSql<EmployeeInfo>(strWhere));
                //sqlList.Add(CreateSql.CreateDeleteSql<ExpDistributeInfo>(strWhere));
            }
            return SqlHelper.ExecuteTrans(sqlList);
        }
    }
}
