using Common.CustAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garbagemanage.Models
{
    /// <summary>
    /// 居民信息类
    /// </summary>
    [Table("User1")]
    [PrimaryKey("UserId", autoIncrement = true)]
    public class ResInfo
    {
        /// <summary>
        /// 居民编号
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 居民编码
        /// </summary>
        public string UserNo { get; set; }
        /// <summary>
        /// 居民名称
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public string Age { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string UserIDnumber { get; set; }
        /// <summary>
        /// 电话号
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 所在小区
        /// </summary>
        public string UserVillage { get; set; }
        /// <summary>
        /// 住址
        /// </summary>
        public string UserAddress { get; set; }
        /// <summary>
        /// 投放重量
        /// </summary>
        public double UserWeight { get; set; }
        /// <summary>
        /// 积分
        /// </summary>
        public int UserIntegral { get; set; }
        /// <summary>
        /// 是否为特殊人群
        /// </summary>
        public bool Special { get; set; }

        public int IsDeleted { get; set; }
    }
}
