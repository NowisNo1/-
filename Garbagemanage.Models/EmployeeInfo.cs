using Common.CustAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garbagemanage.Models
{
    /// <summary>
    /// 员工信息类
    /// </summary>
    [Table("EmployeeInfos")]
    [PrimaryKey("EmpId", autoIncrement = true)]
    public class EmployeeInfo
    {
        /// <summary>
        /// 员工编号
        /// </summary>
        public int EmpId { get; set; }
        /// <summary>
        /// 员工号
        /// </summary>
        public string EmpNo { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string EmpName { get; set; }
        
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public int? Age { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string EmpIDnumber { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 地区
        /// </summary>
        public string Area { get; set; }
        /// <summary>
        /// 是否在职
        /// </summary>
        public bool IsOn { get; set; }
        
        /// <summary>
        /// 员工类别
        /// </summary>
        public int EmpTypeId { get; set; }
       
    }
}
