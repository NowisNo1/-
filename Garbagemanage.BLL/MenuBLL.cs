using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garbagemanage.Models;
using Garbagemanage.DAL;

namespace Garbagemanage.BLL
{
    public class MenuBLL
    {
        MenuDAL menuDAL = new MenuDAL();
        /// <summary>
        /// 获取所有的菜单数据
        /// </summary>
        /// <returns></returns>
        public List<MenuInfo> GetMenuList()
        {
            return menuDAL.GetAllModelList("","",0);
        }
    }
}
