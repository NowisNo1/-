using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Garbagemanage.UControls
{
    public partial class UPager : UserControl
    {
        public UPager()
        {
            InitializeComponent();
        }

        //定义委托
        public delegate void PageHandler(object sender, EventArgs e);
        //声明事件

        private int record=0;
        /// <summary>
        /// 总记录数
        /// </summary>
        public int Record
        {
            get { return record; }
            set { record = value; 
                  InitPageInfo();
            }
        }

        private int startIndex=1;
        //当前页开始索引
        public int StartIndex
        {
            get { return ((CurrentPage-1)*PageSize) + 1; }
            set { startIndex = value; }
        }

        private int pageSize=10;
        /// <summary>
        /// 每页显示记录数
        /// </summary>
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }

        private int currentPage=1;
        /// <summary>
        /// 当前页索引
        /// </summary>
        public int CurrentPage
        {
            get { return currentPage; }
            set { currentPage = value; }
        }

        private int pageNum = 0;
        /// <summary>
        /// 总页数
        /// </summary>
        public int PageNum
        {
            get
            {
                if(Record==0)
                {
                    pageNum = 0;
                }
                else
                {
                    if(Record%PageSize>0)
                    {
                        pageNum = Record / PageSize + 1;
                    }
                    else
                    {
                        pageNum=Record/ PageSize;
                    }
                }
                return pageNum;
            }
        }

        private void UPager_Load(object sender, EventArgs e)
        {
            OnPageChanged();
        }

        private void OnPageChanged()
        {
            InitPageInfo();
            switch (type)
            {
                case "FrmStationList":
                    ((Garbagemanage.BM.FrmStationList)instance).FunStartmain();
                    break;
                case "FrmSpecialList":
                    ((Garbagemanage.User.FrmSpecialList)instance).FunStartmain();
                    break;
                case "FrmUserList":
                    ((Garbagemanage.User.FrmUserList)instance).FunStartmain();
                    break;
            }
            
        }

        /// <summary>
        /// 刷新分页控件
        /// </summary>
        private void InitPageInfo()
        {
            
            if (Record > 0)
            {
                if(CurrentPage > PageNum)
                     CurrentPage = PageNum;
                if (CurrentPage < 1)
                    CurrentPage = 1;
            }
            if(CurrentPage == 1)
            {
                btnFirst.Enabled = false;
                btnPrev.Enabled = false;
                if(CurrentPage == PageNum)
                {
                    btnNext.Enabled = false;
                    btnLast.Enabled = false;
                    btnGo.Enabled = false;
                }
                else
                {
                    btnNext.Enabled = true;
                    btnLast.Enabled = true;
                    btnGo.Enabled = true;
                }
            }
            else if(CurrentPage > 1)
            {
                btnFirst.Enabled = true;
                btnPrev.Enabled = true;
                if (CurrentPage < PageNum)
                {
                    btnNext.Enabled = true;
                    btnLast.Enabled = true;
                }
                else
                {
                    btnNext.Enabled = false;
                    btnLast.Enabled = false;
                }
                btnGo.Enabled = true;
            }

            foreach(Control c in this.Controls)
            {
                if(c is Button)
                {
                    if(c.Enabled == false)
                        c.BackColor = Color.DarkGray;   //按钮不可用时背景
                    if(c.Enabled == true)
                        c.BackColor = Color.RoyalBlue;
                }
            }

            lblPageInfo.Text = $"共 {Record} 条记录，共 {PageNum} 页  当前第 {CurrentPage} 页";
            
            txtPage.Text = CurrentPage.ToString();
            
        }

        /// <summary>
        /// 首页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFirst_Click(object sender, EventArgs e)
        {
            if(CurrentPage>1)
            {
                CurrentPage = 1;
                OnPageChanged();//翻页
            }
        }
        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (CurrentPage > 1)
            {
                CurrentPage = CurrentPage-1;
                OnPageChanged();//翻页
            }
        }

        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (CurrentPage < PageNum)
            {
                CurrentPage = CurrentPage+1;
                OnPageChanged();//翻页
            }
        }

        /// <summary>
        /// 末页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLast_Click(object sender, EventArgs e)
        {
            if (CurrentPage < PageNum)
            {
                CurrentPage = PageNum;
                OnPageChanged();//翻页
            }
        }
        
        public Form instance { get; set; }
        public string type { get; set; }
        /// <summary>
        /// 转到指定页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGo_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtPage.Text)&&!Regex.IsMatch(txtPage.Text,@"^[\d]*$"))
            {
                MessageBox.Show("请输入正确的页面！");
                return;
            }
            int page = txtPage.Text.GetInt();
            if(page==0)
            {
                page = 1;
            }
            if(page>PageNum)
            {
                page=PageNum;
            }
            CurrentPage = page;
            OnPageChanged();
        }
    }
    
}
