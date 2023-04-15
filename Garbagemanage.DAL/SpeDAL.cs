using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garbagemanage.Models.UIModels;
using Garbagemanage.DAL;
using System.Data.SqlClient;
using Helper;
using Garbagemanage.Models;
using Garbagemanage.DAL.Base;

namespace Garbagemanage.DAL
{
    public class SpeDAL : BaseDAL<SpeInfo>
    {
        /// <summary>
        /// 分页条件查询人员信息
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="isDeleted"></param>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PageModel<SpeInfo> FindSpeList(string keywords, int isDeleted, int startIndex, int pageSize)
        {
            string strWhere = $"IsDeleted={isDeleted}";
            if (!string.IsNullOrEmpty(keywords))
            {
                strWhere += " and (SpeNo like @keywords or SpeName  like @keywords or SpeIDnumber  like @keywords or Phone  like @keywords or SpeAddress  like @keywords )";
            }
            string cols = CreateSql.GetColNames<SpeInfo>("");//全部属性名都要查询出来
            SqlParameter para = new SqlParameter("@keywords", $"%{keywords}%");
            return GetRowsModelList<SpeInfo>(strWhere, cols, "Id", "SpeId", startIndex, pageSize, para);
        }

        /// <summary>
        /// 获取所有人员列表（绑定下拉框）
        /// </summary>
        /// <returns></returns>
        public List<SpeInfo> GetCboSpeList()
        {
            return GetModelList("Special=1 and IsDeleted=0", "SpeId,SpeName", "");
        }

        /// <summary>
        /// 检查名称或编码是否存在
        /// </summary>
        /// <param name="value"></param>
        /// <param name="isNo"></param>
        /// <returns></returns>
        public bool ExistSpeNoOrName(string value, bool isNo)
        {
            if (isNo)
                return ExistsByName("SpeNo", value);
            else
                return ExistsByName("SpeName", value);
        }

        /// <summary>
        /// 添加人员，返回人员编号
        /// </summary>
        /// <param name="station"></param>
        /// <returns></returns>
        public int AddSpe(SpeInfo spe)
        {
            string cols = CreateSql.GetColNames<SpeInfo>("SpeId");
            return Add(spe, cols, 1);
        }

        /// <summary>
        /// 删除/恢复/移除人员信息
        /// </summary>
        /// <param name="stationIds"></param>
        /// <param name="delType">删除类别 0假删除  1真删除</param>
        /// <param name="isDeleted">0恢复  1 删除  2 真删除</param>
        /// <returns></returns>
        public bool UpdateSpeDelState(List<int> SpeIds, int delType, int isDeleted)
        {
            string strIds = string.Join(",", SpeIds);
            string strWhere = $"SpeId in ({strIds})";
            List<string> sqlList = new List<string>();
            if (delType == 0)
            {
                sqlList.Add(CreateSql.CreateLogicDeleteSql<SpeInfo>(strWhere, isDeleted));
            }
            else
            {
                sqlList.Add(CreateSql.CreateDeleteSql<SpeInfo>(strWhere));
            }
            return SqlHelper.ExecuteTrans(sqlList);
        }
    }
}
