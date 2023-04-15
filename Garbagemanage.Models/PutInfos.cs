using Common.CustAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garbagemanage.Models
{
    [Table("PutInfos")]
    [PrimaryKey("PutId", autoIncrement = true)]
    public class PutInfos
    {
        // <summary>
        /// 投放信息编号
        /// </summary>
        public int PutId { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string PutName { get; set; }

        /// <summary>
        /// 投放垃圾类型
        /// </summary>
        public string PutType { get; set; }

        /// <summary>
        /// 投放垃圾重量
        /// </summary>
        public float PutWeight { get; set; }

        public DateTime PutTime { get; set; }
        public float Overflow { get; set; }

        public int IsDeleted { get; set; }

        public float AllWeight { get; set; }
        public override string ToString()
        {
            return PutType + " " + AllWeight;
        }
    }
}
