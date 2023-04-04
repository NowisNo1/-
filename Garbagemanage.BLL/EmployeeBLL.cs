using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garbagemanage.DAL.Base;
using Garbagemanage.Models;
using Garbagemanage.Models.UIModels;
using Garbagemanage.DAL;
using Garbagemanage.VModels;

namespace Garbagemanage.BLL
{
    public class EmployeeBLL
    {
        //ViewEmployeeDAL viewEmployeeDAL = new ViewEmployeeDAL();
        EmployeeDAL employeeDAL = new EmployeeDAL();
        //ExpDistributeDAL expDistributeDAL = new ExpDistributeDAL();
        /// <summary>
        /// 分页查询员工信息列表
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="blShowDel"></param>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>

        //public PageModel<EmployeeInfo> FindEmployeeList(string keywords, int empTypeId, int stationId, bool blShowDel, int startIndex, int pageSize)
        //{
        //    int isDeleted = blShowDel ? 1 : 0;
        //    //return EmployeeDAL.FindEmployeeList(keywords, empTypeId, stationId, isDeleted, startIndex, pageSize);
        //}
        /// <summary>
        ///  获取员工列表（绑定下拉框）
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        public List<EmployeeInfo> GetCboEmployeeList(int stationId)
        {
            return employeeDAL.GetCboEmployeeList(stationId);
        }

        /// <summary>
        /// 判断员工名称是否存在
        /// </summary>
        /// <param name="empName"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public bool ExistEmpInfo(string empName, string phone)
        {
            return employeeDAL.ExistEmpInfo(empName, phone);
        }

        /// <summary>
        /// 检查员工号是否存在
        /// </summary>
        /// <param name="empNo"></param>
        /// <returns></returns>
        public bool ExistEmpNo(string empNo)
        {
            return employeeDAL.ExistEmpNo(empNo);
        }

        /// <summary>
        /// 获取指定的员工信息
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        public EmployeeInfo GetEmployee(int empId)
        {
            return employeeDAL.GetById(empId, "");
        }

        /// <summary>
        /// 新增员工
        /// </summary>
        /// <param name="empInfo"></param>
        /// <returns></returns>
        public int AddEmployee(EmployeeInfo empInfo)
        {
            return employeeDAL.AddEmployee(empInfo);
        }
        /// <summary>
        /// 修改员工
        /// </summary>
        /// <param name="empInfo"></param>
        /// <returns></returns>
        public bool UpdateEmployee(EmployeeInfo empInfo)
        {
            return employeeDAL.Update(empInfo, "");
        }

        /// <summary>
        /// 员工离职处理
        /// </summary>
        /// <param name="empInfo"></param>
        /// <returns></returns>
        //public int EmpLeaveOut(ViewEmployeeInfo empInfo)
        //{
        //    //int expCount = expDistributeDAL.GetEmpDisExpCount(empInfo.EmpId);
        //    if(expCount>0)
        //    {
        //        return 2;//未处理离职，还有未完成的派送
        //    }
        //    else
        //    {
        //        bool bl = employeeDAL.EmpLeaveOut(empInfo.EmpId);//离职
        //        if (bl)
        //            return 1;//离职处理成功
        //        else
        //            return 0;//离职处理失败
        //    }
        //}

        /// <summary>
        /// 员工删除
        /// </summary>
        /// <param name="employees"></param>
        /// <returns></returns>
        public string DeleteEmployees(List<ViewEmployeeInfo> employees)
        {
            string reStr = "";
            string hasNames = "";//存储在职的员工名称字符串
            List<int> delIds = new List<int>();//存储符合删除的员工编号
            foreach (ViewEmployeeInfo emp in employees)
            {
                if (emp.IsOn)
                {
                    if (hasNames != "")
                        hasNames += ",";
                    hasNames += emp.EmpName;
                }
                else
                    delIds.Add(emp.EmpId);
            }
            bool blDel = false;
            if (delIds.Count > 0)
            {
                blDel = employeeDAL.UpdateEmployeesDelState(delIds, 0, 1);//删除员工列表
            }
            if (blDel)
            {
                if (hasNames == "")
                    reStr = "1";//删除成功
                else
                    reStr = "1;" + hasNames;//删除成功，但存在不能删除的员工
            }
            else
            {
                if (delIds.Count > 0)
                    reStr = "0";//删除失败
                else
                {
                    reStr = "-1;" ;//所有选择的员工都不能删除
                }
            }
            return reStr;
        }
        /// <summary>
        /// 恢复员工
        /// </summary>
        /// <param name="empIds"></param>
        /// <returns></returns>
        public bool RecoverEmployees(List<int> empIds)
        {
            return employeeDAL.UpdateEmployeesDelState(empIds, 0, 0);
        }
        /// <summary>
        /// 移除员工（真删除）
        /// </summary>
        /// <param name="empIds"></param>
        /// <returns></returns>
        public bool RemoveEmployees(List<int> empIds)
        {
            return employeeDAL.UpdateEmployeesDelState(empIds, 1, 2);
        }
    }
}
