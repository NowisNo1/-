using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Garbagemanage.Models.UIModels;
using Garbagemanage.DAL;
using Garbagemanage.Models;

namespace Garbagemanage.BLL
{
    public class StationBLL
    {
        StationDAL stationDAL = new StationDAL();
        /// <summary>
        /// 分页查询站点信息
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="isShowDel"></param>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PageModel<StationInfo> FindStationList(string keywords, bool isShowDel, int startIndex, int pageSize)
        {
            int isDeleted = isShowDel ? 1 : 0;
            return stationDAL.FindStationList(keywords, isDeleted, startIndex, pageSize);
        }
        /// <summary>
        /// 获取绑定下拉框的所有站点列表
        /// </summary>
        /// <returns></returns>
        public List<StationInfo> GetCboStationList()
        {
            return stationDAL.GetCboStationList();
        }

        /// <summary>
        /// 添加站点，返回站点编号
        /// </summary>
        /// <param name="station"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public int AddStation(StationInfo station)
        {
            if (station == null)
                throw new Exception("站点信息不能为空！");
            return stationDAL.AddStation(station);
        }

        /// <summary>
        /// 修改站点
        /// </summary>
        /// <param name="station"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool UpdateStation(StationInfo station)
        {
            if (station == null)
                throw new Exception("站点信息不能为空！");
            return stationDAL.Update(station, "");
        }

        /// <summary>
        /// 判断站点编码是否存在
        /// </summary>
        /// <param name="stationNo"></param>
        /// <returns></returns>
        public bool ExistStationNo(string stationNo)
        {
            return stationDAL.ExistStationNoOrName(stationNo, true);
        }

        /// <summary>
        /// 判断站点名称是否存在
        /// </summary>
        /// <param name="stationName"></param>
        /// <returns></returns>
        public bool ExistStationName(string stationName)
        {
            return stationDAL.ExistStationNoOrName(stationName, false);
        }

        /// <summary>
        /// 获取指定站点信息
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        public  StationInfo GetStation(int stationId)
        {
            return stationDAL.GetById(stationId, "");
        }

        /// <summary>
        /// 删除站点（逻辑删除）
        /// </summary>
        /// <param name="stations"></param>
        /// <returns></returns>
        public string DeleteStations(List<StationInfo> stations)
        {
            string reStr = "";
            string hasNames = "";//存储运营中站点名称字符串
            List<int> stationIds = new List<int>();//存储符合删除的站点编号
            foreach(StationInfo station in stations)
            {
                if (station.IsRunning)
                {
                    if (hasNames != "")
                        hasNames += ",";
                    hasNames += station.StationName;
                }
                else
                    stationIds.Add(station.StationId);
            }
            bool blDel = false;
            if(stationIds.Count>0)
            {
                blDel = stationDAL.UpdateStationDelState(stationIds, 0, 1);//删除站点列表
            }
            if(blDel)
            {
                if (hasNames == "")
                    reStr = "1";//删除成功
                else
                    reStr = "1;" + hasNames;//删除成功，但存在不能删除的站点
            }
            else
            {
                if (stationIds.Count > 0)
                    reStr = "0";//删除失败
                else
                {
                    reStr = "-1;" ;//所有选择的站点都不能删除
                }
            }
            return reStr;
        }

        /// <summary>
        /// 恢复站点
        /// </summary>
        /// <param name="stationIds"></param>
        /// <returns></returns>
        public bool RecoverStations(List<int> stationIds)
        {
            return stationDAL.UpdateStationDelState(stationIds, 0, 0);
        }

        /// <summary>
        /// 移除站点
        /// </summary>
        /// <param name="stationIds"></param>
        /// <returns></returns>
        public bool  RemoveStations(List<int> stationIds)
        {
            return stationDAL.UpdateStationDelState(stationIds, 1, 2);
        }
    }
}
