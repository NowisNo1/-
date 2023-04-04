using Common.CustAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhaoxi.CainiaoPostStation.Models;

namespace Zhaoxi.CaiNiaoPostStation.Models.VModels
{
    /// <summary>
    /// 快递类别信息视图实体
    /// </summary>
    [Table("View_ExpressTypeInfos")]
    [PrimaryKey("ExpTypeId")]
    public class ViewExpressTypeInfo:ExpressTypeInfo
    {
        public string ParentName { get; set; }
        public ViewExpressTypeInfo() { }
        public ViewExpressTypeInfo(ExpressTypeInfo expType,string parentName)
        {
            ExpTypeId = expType.ExpTypeId;
            ExpTypeName = expType.ExpTypeName;
            ParentId=expType.ParentId;
            ParentName=parentName;
            ExpPYNo=expType.ExpPYNo;
            OrderNum=expType.OrderNum;
            Remark=expType.Remark;
        }
    }
}
