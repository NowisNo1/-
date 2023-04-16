using Helper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garbagemanage.DAL.Base;
using Garbagemanage.Models.UIModels;
using Garbagemanage.Models;

namespace Garbagemanage.DAL
{
    public  class StationDAL:BaseDAL<StationInfo>
    {
        /// <summary>
        /// 分页条件查询站点信息
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="isDeleted"></param>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PageModel<StationInfo> FindStationList(string keywords, int isDeleted, int startIndex, int pageSize)
        {
            string strWhere = $"IsDeleted={isDeleted}";
            if(!string.IsNullOrEmpty(keywords))
            {
                strWhere += " and (StationNo like @keywords or StationName  like @keywords or StationAddress  like @keywords or Manager  like @keywords or Phone  like @keywords or Remark  like @keywords or ApplyTime  like @keywords)";
            }
            string cols = CreateSql.GetColNames<StationInfo>("");//全部属性名都要查询出来
            SqlParameter para = new SqlParameter("@keywords", $"%{keywords}%");
            return GetRowsModelList<StationInfo>(strWhere, cols, "Id", "StationId", startIndex, pageSize,"", para);
        }

        /// <summary>
        /// 获取所有站点列表（绑定下拉框）
        /// </summary>
        /// <returns></returns>
        public List<StationInfo> GetCboStationList()
        {
            return GetModelList("IsRunning=1 and IsDeleted=0", "StationId,StationName", "");
        }

        /// <summary>
        /// 检查名称或编码是否存在
        /// </summary>
        /// <param name="value"></param>
        /// <param name="isNo"></param>
        /// <returns></returns>
        public bool ExistStationNoOrName(string value, bool isNo)
        {
            if (isNo)
                return ExistsByName("StationNo", value);
            else
                return ExistsByName("StationName", value);
        }

        /// <summary>
        /// 添加站点，返回站点编号
        /// </summary>
        /// <param name="station"></param>
        /// <returns></returns>
        public int AddStation(StationInfo station)
        {
            string cols = CreateSql.GetColNames<StationInfo>("StationId");
            return Add(station, cols, 1);
        }

        /// <summary>
        /// 删除/恢复/移除站点信息
        /// </summary>
        /// <param name="stationIds"></param>
        /// <param name="delType">删除类别 0假删除  1真删除</param>
        /// <param name="isDeleted">0恢复  1 删除  2 真删除</param>
        /// <returns></returns>
        public bool UpdateStationDelState(List<int> stationIds, int delType, int isDeleted)
        {
            string strIds = string.Join(",", stationIds);
            string strWhere = $"StationId in ({strIds})";
            List<string> sqlList = new List<string>();
            if(delType==0)
            {
                sqlList.Add(CreateSql.CreateLogicDeleteSql<StationInfo>(strWhere, isDeleted));
            }
            else
            {
                sqlList.Add(CreateSql.CreateDeleteSql<StationInfo>(strWhere));
            }
            return SqlHelper.ExecuteTrans(sqlList);
        }
    }
}
