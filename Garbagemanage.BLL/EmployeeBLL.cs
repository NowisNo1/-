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
        EmployeeDAL empDAL = new EmployeeDAL();
        /// <summary>
        /// 分页查询员工信息
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="isShowDel"></param>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PageModel<EmployeeInfo> FindEmpList(string keywords, bool isShowDel, int startIndex, int pageSize)
        {
            int isDeleted = isShowDel ? 1 : 0;
            return empDAL.FindEmpList(keywords, isDeleted, startIndex, pageSize);
        }
        /// <summary>
        /// 获取绑定下拉框的所有员工信息列表
        /// </summary>
        /// <returns></returns>
        public List<EmployeeInfo> GetCboEmpList()
        {
            return empDAL.GetCboEmpList();
        }

        /// <summary>
        /// 添加员工，返回员工编号
        /// </summary>
        /// <param name="station"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public int AddEmp(EmployeeInfo emp)
        {
            if (emp == null)
                throw new Exception("员工信息不能为空！");
            return empDAL.AddEmp(emp);
        }

        /// <summary>
        /// 修改员工信息
        /// </summary>
        /// <param name="station"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool UpdateEmp(EmployeeInfo Emp)
        {
            if (Emp == null)
                throw new Exception("员工信息不能为空！");
            return empDAL.Update(Emp, "");
        }

        /// <summary>
        /// 判断员工编码是否存在
        /// </summary>
        /// <param name="stationNo"></param>
        /// <returns></returns>
        public bool ExistEmpNo(string EmpNo)
        {
            return empDAL.ExistEmpNoOrName(EmpNo, true);
        }

        /// <summary>
        /// 判断员工姓名是否存在
        /// </summary>
        /// <param name="stationName"></param>
        /// <returns></returns>
        public bool ExistEmpName(string empName)
        {
            return empDAL.ExistEmpNoOrName(empName, false);
        }

        /// <summary>
        /// 获取指定员工信息
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        public EmployeeInfo GetUser(int empId)
        {
            return empDAL.GetById(empId, "");
        }

        /// <summary>
        /// 删除员工（逻辑删除）
        /// </summary>
        /// <param name="stations"></param>
        /// <returns></returns>
        public string DeleteEmp(List<EmployeeInfo> emp)
        {
            string reStr = "";
            string hasNames = "";//存储运营中员工名称字符串
            List<int> empIds = new List<int>();//存储符合删除的员工编号
            foreach (EmployeeInfo emps in emp)
            {
                if (emps.IsOn)
                {
                    if (hasNames != "")
                        hasNames += ",";
                    hasNames += emps.EmpName;
                }
                else
                    empIds.Add(emps.EmpId);
            }
            bool blDel = false;
            if (empIds.Count > 0)
            {
                blDel = empDAL.UpdateEmpDelState(empIds, 0, 1);//删除信息列表
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
                if (empIds.Count > 0)
                    reStr = "0";//删除失败
                else
                {
                    reStr = "-1;";//所有选择的信息都不能删除
                }
            }
            return reStr;
        }

        /// <summary>
        /// 恢复员工信息
        /// </summary>
        /// <param name="stationIds"></param>
        /// <returns></returns>
        public bool Recoveremps(List<int> empIds)
        {
            return empDAL.UpdateEmpDelState(empIds, 0, 0);
        }

        /// <summary>
        /// 移除员工信息
        /// </summary>
        /// <param name="stationIds"></param>
        /// <returns></returns>
        public bool Removeemps(List<int> empIds)
        {
            return empDAL.UpdateEmpDelState(empIds, 1, 2);
        }
    }
}
