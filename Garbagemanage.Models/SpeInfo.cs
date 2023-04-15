using Common.CustAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garbagemanage.Models
{
    /// <summary>
    /// 特殊人群信息类
    /// </summary>
    [Table("SpecialInfos")]
    [PrimaryKey("SpeId", autoIncrement = true)]
    public class SpeInfo
    {
        /// <summary>
        /// 人员编号
        /// </summary>
        public int SpeId { get; set; }
        /// <summary>
        /// 人员编码
        /// </summary>
        public string SpeNo { get; set; }
        /// <summary>
        /// 人员名称
        /// </summary>
        public string SpeName { get; set; }

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
        public string SpeIDnumber { get; set; }
        /// <summary>
        /// 电话号
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 所在小区
        /// </summary>
        public string SpeVillage { get; set; }
        /// <summary>
        /// 住址
        /// </summary>
        public string SpeAddress { get; set; }
        /// <summary>
        /// 最新投放时间
        /// </summary>
        public DateTime NewThrow { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Remark { get; set; }
       
    }
}
