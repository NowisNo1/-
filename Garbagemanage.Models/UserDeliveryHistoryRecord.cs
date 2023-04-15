using Common.CustAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garbagemanage.Models
{    
    [Table("UserDeliveryHistoryRecord")]
    [PrimaryKey("Number", autoIncrement = true)]
    public class UserDeliveryHistoryRecord
    {
        // <summary>
        /// 投放信息编号
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// 员工号
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 投放垃圾类型
        /// </summary>
        public string GarbageType { get; set; }
        /// <summary>
        /// 垃圾桶当前容量
        /// </summary>
        public float GarbagePercentage { get; set; }
        /// <summary>
        /// 投放垃圾重量
        /// </summary>
        public float GarbageWeight { get; set; }
        /// <summary>
        /// 站点所在小区名称
        /// </summary>
        public string HousingEstateOfsite { get; set; }
        /// <summary>
        /// 站点编号
        /// </summary>
        public string SiteNumber { get; set; }
        /// <summary>
        /// 投放时间
        /// </summary>
        public DateTime PutInTime { get; set; }

        public override string ToString()
        {
            return UserID + " " + UserName + " " + SiteNumber + " " + PutInTime;
        }
    }
}
