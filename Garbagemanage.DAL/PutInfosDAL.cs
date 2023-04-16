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
            string cols = CreateSql.GetColNames<PutInfos>("PutId,KitchenWaste,OtherWaste,RecyclableWaste,HarmfulWaste,AllWeight");
            List<SqlParameter> listParas = new List<SqlParameter>();
            return GetRowsModelList<PutInfos>(strWhere, cols, "PutId", "PutTime", startIndex, pageSize,"desc", listParas.ToArray());
        }

        public List<PutInfos> getRecordListByDay(string date)
        {
            string cols = "PutTime,KitchenWaste,OtherWaste,RecyclableWaste,HarmfulWaste,AllWeight";
            string sql = "select PutTime, SUM(type1) 'KitchenWaste' , SUM(type2) 'OtherWaste', SUM(type3) 'RecyclableWaste', SUM(type4) 'HarmfulWaste', SUM(PutWeight) 'AllWeight' from ( "+
                         "select PutTime, PutType, SUM(PutWeight) PutWeight," + 
                           "coalesce(SUM(CASE PutType WHEN '厨余垃圾' THEN PutWeight END), 0) AS type1," +
                        "coalesce(SUM(CASE PutType WHEN '其他垃圾' THEN PutWeight END), 0) AS type2," +
                        "coalesce(SUM(CASE PutType WHEN '可回收垃圾' THEN PutWeight END), 0) AS type3," +
                        "coalesce(SUM(CASE PutType WHEN '有害垃圾' THEN PutWeight END), 0) AS type4" +
                       " from"+
                       "("+
                        "select left(convert(varchar, PutTime, 120), 10) PutTime, PutType, PutWeight from [User].[dbo].[PutInfos]"+
                        "where datepart(year, PutTime) = 2022 and datepart(month, PutTime) = 1 and IsDeleted = 0"+
                       ") as PutInfos group by PutTime, PutType"+
                       ") as PutInfos group by PutTime order by PutTime";
            SqlDataReader dr = SqlHelper.ExecuteReader(sql, 1, null);
            //转换  List<T>
            return DbConvert.DataReaderToList<PutInfos>(dr, cols, "");
        }
    }
}
