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
    public class SpeBLL
    {
        SpecialDAL speDAL = new SpecialDAL();
        /// <summary>
        /// 分页查询站点信息
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="isShowDel"></param>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PageModel<SpeInfo> FindSpeList(string keywords, bool isShowDel, int startIndex, int pageSize)
        {
            int isDeleted = isShowDel ? 1 : 0;
            return speDAL.FindSpeList(keywords, isDeleted, startIndex, pageSize);
        }
        /// <summary>
        /// 获取绑定下拉框的所有站点列表
        /// </summary>
        /// <returns></returns>
        public List<SpeInfo> GetCboSpeList()
        {
            return speDAL.GetCboSpeList();
        }

        /// <summary>
        /// 添加站点，返回站点编号
        /// </summary>
        /// <param name="station"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public int AddSpe(SpeInfo spe)
        {
            if (spe == null)
                throw new Exception("人员信息不能为空！");
            return speDAL.AddSpe(spe);
        }
        /// <summary>
        /// 判断居民编码是否存在
        /// </summary>
        /// <param name="stationNo"></param>
        /// <returns></returns>
        public bool ExistSpeNo(string SpeNo)
        {
            return speDAL.ExistSpeNoOrName(SpeNo, true);
        }

        /// <summary>
        /// 判断居民姓名是否存在
        /// </summary>
        /// <param name="stationName"></param>
        /// <returns></returns>
        public bool ExistSpeName(string speName)
        {
            return speDAL.ExistSpeNoOrName(speName, false);
        }

        /// <summary>
        /// 获取指定居民信息
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        public SpeInfo GetSpe(int speId)
        {
            return speDAL.GetById(speId, "");
        }

        /// <summary>
        /// 删除居民（逻辑删除）
        /// </summary>
        /// <param name="stations"></param>
        /// <returns></returns>
        public string DeleteSpe(List<SpeInfo> spes)
        {
            string reStr = "";
            string hasNames = "";//存储运营中居民名称字符串
            List<int> speIds = new List<int>();//存储符合删除的居民编号
            foreach (SpeInfo spe in spes)
            {
                //if (false)
                //{
                //    if (hasNames != "")
                //        hasNames += ",";
                //    hasNames += spe.SpeName;
                //}
                //else
                    speIds.Add(spe.SpeId);
            }
            bool blDel = false;
            if (speIds.Count > 0)
            {
                blDel = speDAL.UpdateSpeDelState(speIds, 0, 1);//删除信息列表
            }
            if (blDel)
            {
                if (hasNames == "")
                    reStr = "1";//删除成功
                else
                    reStr = "1;" + hasNames;//删除成功，但存在不能删除的信息
            }
            else
            {
                if (speIds.Count > 0)
                    reStr = "0";//删除失败
                else
                {
                    reStr = "-1;";//所有选择的信息都不能删除
                }
            }
            return reStr;
        }
        /// <summary>
        /// 恢复居民信息
        /// </summary>
        /// <param name="stationIds"></param>
        /// <returns></returns>
        public bool RecoverSpes(List<int> speIds)
        {
            return speDAL.UpdateSpeDelState(speIds, 0, 0);
        }

        /// <summary>
        /// 移除居民信息
        /// </summary>
        /// <param name="stationIds"></param>
        /// <returns></returns>
        public bool RemoveSpes(List<int> speIds)
        {
            return speDAL.UpdateSpeDelState(speIds, 1, 2);
        }
    }
}
