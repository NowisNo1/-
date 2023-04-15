using Garbagemanage.DAL;
using Garbagemanage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garbagemanage.BLL
{
    public class PutInfosBLL
    {
        PutInfosDAL putInfosDAL = new PutInfosDAL();

        public int GetRecordCount()
        {
            return putInfosDAL.GetRecordCount();
        }

        /// <summary>
        /// 获取指定条目的数据用于绘制图表
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<PutInfos> test(int idx, int pageSize)
        {
            return putInfosDAL.FindRecordList(idx, pageSize).PageList;
        }

        public List<PutInfos> getRecordListByDay(string date)
        {
            return putInfosDAL.getRecordListByDay(date);
        }
    }
}
