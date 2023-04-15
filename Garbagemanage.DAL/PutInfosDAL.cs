using Garbagemanage.DAL.Base;
using Garbagemanage.Models;
using Garbagemanage.Models.UIModels;
using Helper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Garbagemanage.Models.PutInfos;

namespace Garbagemanage.DAL
{
    public class PutInfosDAL : BaseDAL<PutInfos>
    {
        public int GetRecordCount()
        {
            string sql = "select count(1) from PutInfos";
            return SelectAndReIntValue(sql);
        }
        /// <summary>
        /// 分页查询投放信息列表
        /// </summary>
        /// <returns></returns>
        public PageModel<PutInfos> FindRecordList(int startIndex, int pageSize)
        {
            string strWhere = "";
            string cols = CreateSql.GetColNames<PutInfos>("PutId, totalWeight");
            List<SqlParameter> listParas = new List<SqlParameter>();
            return GetRowsModelList<PutInfos>(strWhere, cols, "PutId", "PutTime", startIndex, pageSize, listParas.ToArray());
        }

        public List<PutInfos> getRecordListByDay(string date)
        {
            string cols = "PutType,SUM(PutWeight) as AllWeight";
            string sql = "exec StatisticsWeightByDay @year=2022, @month=01;";
            SqlDataReader dr = SqlHelper.ExecuteReader(sql, 1, null);
            //转换  List<T>
            return DbConvert.DataReaderToList<PutInfos>(dr, cols, "PutType,AllWeight");
        }
    }
}
