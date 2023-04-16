using Garbagemanage.DAL.Base;
using Garbagemanage.Models;
using Garbagemanage.Models.UIModels;
using Garbagemanage.VModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garbagemanage.DAL
{
    public class UserDeliveryHistoryRecordDAL : BaseDAL<UserDeliveryHistoryRecord>
    {
        public int GetRecordCount()
        {
            string sql = "select count(1) from UserDeliveryHistoryRecord";
            return SelectAndReIntValue(sql);
        }
        /// <summary>
        /// 分页查询投放信息列表
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="empTypeId"></param>
        /// <param name="stationId"></param>
        /// <param name="isDeleted"></param>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PageModel<UserDeliveryHistoryRecord> FindRecordList(int startIndex, int pageSize){
            string strWhere = "";
            string cols = CreateSql.GetColNames<UserDeliveryHistoryRecord>("Number");
            List<SqlParameter> listParas = new List<SqlParameter>();
            return GetRowsModelList<UserDeliveryHistoryRecord>(strWhere, cols, "Number", "PutInTime", startIndex, pageSize, "", listParas.ToArray());
        }
    }
}
