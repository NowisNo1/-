using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Garbagemanage.BLL;



namespace Garbagemanage.Utility
{
    public static class FormUtility
    {
        /// <summary>
        /// 显示异常信息
        /// </summary>
        /// <param name="lblErr"></param>
        /// <param name="msg"></param>
        public static void SetErrorMsg(this Label lblErr, string msg)
        {
            if (!lblErr.Visible)
                lblErr.Visible = true;
            lblErr.Text = msg;
        }

        /// <summary>
        /// 添加窗体到选项卡中
        /// </summary>
        /// <param name="tab"></param>
        /// <param name="form"></param>
        /// <param name="index"></param>
        public static void AddTabFormPage(this TabControl tab, Form form, int index = -1)
        {
            TabPage page = null;
            Form frm = GetOpenForm(form.Name);
            if (frm == null)
            {
                frm = form;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.TopLevel = false;
                frm.WindowState = FormWindowState.Maximized;
                page = new TabPage();
                frm.Parent = page;
                frm.Dock = DockStyle.Fill;
                page.Name = frm.Name;
                page.Text = frm.Text;
                if (index != -1)
                    tab.TabPages.Insert(index, page);
                else
                    tab.TabPages.Add(page);
                frm.Show();
            }
            else
            {
                page = tab.TabPages[frm.Name];
            }
            tab.SelectedTab = page;
        }

        /// <summary>
        /// 打开对应类型的Form页面
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tab"></param>
        public static void ShowTabFormPage<T>(this TabControl tab, object obj = null) where T : Form
        {
            Form frm = Activator.CreateInstance<T>();
            if (obj != null)
                frm.Tag = obj;
            tab.AddTabFormPage(frm);
        }

        /// <summary>
        /// 从导航页打开对应页面的方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="curForm"></param>
        public static void ShowNavForm<T>(this Form curForm, object obj = null) where T : Form
        {
            TabControl tab = curForm.Parent.Parent as TabControl;
            tab.ShowTabFormPage<T>(obj);
        }

        /// <summary>
        /// 返回指定的Form
        /// </summary>
        /// <param name="formName"></param>
        /// <returns></returns>
        public static Form GetOpenForm(string formName)
        {
            Form f = null;
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Name == formName)
                {
                    f = frm;
                    break;
                }
            }
            return f;
        }

        /// <summary>
        /// 关闭指定的窗体
        /// </summary>
        /// <param name="formName"></param>
        public static void CloseOpenForm(string formName)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Name == formName)
                {
                    frm.Close();
                    break;
                }
            }
        }

        /// <summary>
        /// DataGridView数据源更新   新增或修改
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dgv"></param>
        /// <param name="actType"></param>
        /// <param name="info"></param>
        /// <param name="id"></param>
        public static void UpdateDgv<T>(this DataGridView dgv, int actType, T info, int id)
        {
            List<T> list = dgv.DataSource as List<T>;
            if (list == null)
            {
                list = new List<T>();
            }
            dgv.DataSource = null;
            if (actType == 1)
            {
                list.Add(info);
            }
            else if (actType == 2)
            {
                int index = -1;
                Type type = typeof(T);
                string keyName = type.GetPrimaryName();
                foreach (T t in list)
                {
                    int uId = (int)type.GetProperty(keyName).GetValue(t);
                    if (uId == id)
                    {
                        index = list.IndexOf(t);//位置
                        break;
                    }
                }
                list[index] = info;
            }
            dgv.DataSource = list;
        }

        /// <summary>
        /// 更新DataGridView 删除、恢复、移除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dgv"></param>
        /// <param name="delList"></param>
        public static void UpdateDgv<T>(this DataGridView dgv, List<T> delList)
        {
            List<T> list = dgv.DataSource as List<T>;
            dgv.DataSource = null;
            delList.ForEach(t => list.Remove(t));
            dgv.DataSource = list;
        }

        /// <summary>
        /// 生成删除、恢复、移除操作的询问框的标题和提示消息
        /// </summary>
        /// <param name="infoName"></param>
        /// <param name="isDeleted"></param>
        /// <returns></returns>
        public static string[] GetActTitleAndMsg(string infoName,int isDeleted)
        {
            string typeName = GetDelTypeName(isDeleted);
            string title = $"{typeName}{infoName}";
            string msg = $"你确定要对该{infoName}信息进行{typeName}吗？";
            return new string[] { title, msg };
        }

        /// <summary>
        /// 获取操作的名称
        /// </summary>
        /// <param name="isDeleted"></param>
        /// <returns></returns>
        public static string GetDelTypeName(int isDeleted)
        {
            string typeName = "";
            switch (isDeleted)
            {
                case 1: typeName = "删除"; break;
                case 0: typeName = "恢复"; break;
                case 2: typeName = "移除"; break;
                case 3: typeName = "离职"; break;
                default: break;
            }
            return typeName;
        }

        /// <summary>
        /// 单元格的状态因其内容改变而改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void DgvList_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv != null)
            {
                dgv.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        /// <summary>
        /// 加载站点下拉框
        /// </summary>
        /// <param name="cboStations"></param>
        //public static void LoadCboStations(ComboBox cboStations,StationBLL statBLL)
        //{
        //    List<StationInfo> stationList01 = statBLL.GetCboStationList();
        //    stationList01.Insert(0, new StationInfo()
        //    {
        //        StationId = 0,
        //        StationName = "请选择站点"
        //    });
        //    cboStations.DisplayMember = "StationName";
        //    cboStations.ValueMember = "StationId";
        //    cboStations.DataSource = stationList01;

        //}

    }
}
