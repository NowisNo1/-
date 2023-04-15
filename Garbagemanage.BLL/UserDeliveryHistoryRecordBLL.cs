using Garbagemanage.DAL;
using Garbagemanage.Models;
using Garbagemanage.Models.UIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garbagemanage.BLL
{
    public class UserDeliveryHistoryRecordBLL
    {
        UserDeliveryHistoryRecordDAL userDeliveryHistoryDAL = new UserDeliveryHistoryRecordDAL();

        public int GetRecordCount()
        {
            return userDeliveryHistoryDAL.GetRecordCount();
        }

        /// <summary>
        /// 获取指定条目的数据用于绘制图表
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<UserDeliveryHistoryRecord> test(int idx, int pageSize)
        {            
            return userDeliveryHistoryDAL.FindRecordList(idx, pageSize).PageList;
        }
    }
}
