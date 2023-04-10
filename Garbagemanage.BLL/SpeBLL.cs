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
        SpeDAL speDAL = new SpeDAL();
        /// <summary>
        /// 分页查询人员信息
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
        /// 获取绑定下拉框的所有人员列表
        /// </summary>
        /// <returns></returns>
        public List<SpeInfo> GetCboSpeList()
        {
            return speDAL.GetCboSpeList();
        }

        /// <summary>
        /// 添加人员，返回人员编号
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
        /// 判断人员编码是否存在
        /// </summary>
        /// <param name="stationNo"></param>
        /// <returns></returns>
        public bool ExistSpeNo(string SpeNo)
        {
            return speDAL.ExistSpeNoOrName(SpeNo, true);
        }

        /// <summary>
        /// 判断人员姓名是否存在
        /// </summary>
        /// <param name="stationName"></param>
        /// <returns></returns>
        public bool ExistSpeName(string speName)
        {
            return speDAL.ExistSpeNoOrName(speName, false);
        }

        /// <summary>
        /// 获取指定人员信息
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        public SpeInfo GetSpe(int speId)
        {
            return speDAL.GetById(speId, "");
        }

        /// <summary>
        /// 删除人员（逻辑删除）
        /// </summary>
        /// <param name="stations"></param>
        /// <returns></returns>
        public string DeleteSpe(List<SpeInfo> spes)
        {
            string reStr = "";
            string hasNames = "";//存储运营中人员名称字符串
            List<int> speIds = new List<int>();//存储符合删除的人员编号
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
        /// 恢复人员信息
        /// </summary>
        /// <param name="stationIds"></param>
        /// <returns></returns>
        public bool RecoverSpes(List<int> speIds)
        {
            return speDAL.UpdateSpeDelState(speIds, 0, 0);
        }

        /// <summary>
        /// 移除人员信息
        /// </summary>
        /// <param name="stationIds"></param>
        /// <returns></returns>
        public bool RemoveSpes(List<int> speIds)
        {
            return speDAL.UpdateSpeDelState(speIds, 1, 2);
        }
        /// <summary>
        /// 修改人员信息
        /// </summary>
        /// <param name="station"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool UpdateSpe(SpeInfo Spe)
        {
            if (Spe == null)
                throw new Exception("人员信息不能为空！");
            return speDAL.Update(Spe, "");
        }
    }
}
