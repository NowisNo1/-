using Garbagemanage.BLL;
using Garbagemanage.Models;
using Garbagemanage.Models.UIModels;
using Garbagemanage.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Garbagemanage.Special
{
    public partial class FrmSpecialList : Form
    {
        public FrmSpecialList()
        {
            InitializeComponent();
        }
        SpeBLL speBLL = new SpeBLL();
        int actType = 1;//信息提交状态  1-新增 2-修改
        int editSpeId = 0;//当前正在修改的站点编号
        bool isFirst = true;//第一次加载
        int totalCount = 0;//总站点数
        string oldNo = "", oldName = "";//修改前名称和编码

        private void FrmSpecialList_Load(object sender, EventArgs e)
        {
            this.dgvSpeList.CurrentCellDirtyStateChanged += new System.EventHandler(FormUtility.DgvList_CurrentCellDirtyStateChanged);
            //加载站点列表
            FindSpeList();

            //初始化信息栏
            InitSpeInfo();
        }
        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttfind_Click(object sender, EventArgs e)
        {
            FindSpeList();
        }

        private void FindSpeList()
        {
            string keywords = textBox6.Text.Trim();
            bool showDel = chkShowDel.Checked;
            int startIndex = uPager1.StartIndex;//当页的开始索引
            int pageSize = uPager1.PageSize;//每页记录数
            dgvSpeList.AutoGenerateColumns = false;
            PageModel<SpeInfo> pageModel = speBLL.FindSpeList(keywords, showDel, startIndex, pageSize);
            if (pageModel.TotalCount > 0)
            {
                dgvSpeList.DataSource = pageModel.PageList;
                uPager1.Record = pageModel.TotalCount;
                if (isFirst)
                {
                    totalCount = pageModel.TotalCount;
                    isFirst = false;
                }
            }
            else
            {
                dgvSpeList.DataSource = null;
                uPager1.Enabled = false;
            }
            SetActBtnsAndColVisible(showDel);
        }
        private void uPager1_PageChanged(object sender, EventArgs e)
        {
            FindSpeList();
        }
        /// <summary>
        /// 设置操作按钮和行内操作列的显示
        /// </summary>
        /// <param name="showDel"></param>
        private void SetActBtnsAndColVisible(bool showDel)
        {
            buttDel.Visible = !showDel;
            buttRecover.Visible = showDel;
            buttRemove.Visible = showDel;
            dgvSpeList.Columns["colEdit"].Visible = !showDel;
            dgvSpeList.Columns["colDel"].Visible = !showDel;
            dgvSpeList.Columns["colRecover"].Visible = showDel;
            dgvSpeList.Columns["colRemove"].Visible = showDel;
        }
        List<SpeInfo> selectItems = new List<SpeInfo>();//选择行的数据列表
        /// <summary>
        /// 信息提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttok_Click(object sender, EventArgs e)
        {
            //接收信息
            string speNo = txtSpeNumber.Text.Trim();
            string speName = txtSpeName.Text.Trim();
            string address = txtAddress.Text.Trim();
            string speVillage = txtVillage.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string sex = txtSex.Text.Trim();
            string age = txtAge.Text.Trim();
            string speidnumber = txtSpeIDnumber.Text.Trim();
            string newtime = txtNewTime.Text.Trim();
            string remark = txtmiaoshu.Text.Trim();
            //信息检查
            if (string.IsNullOrEmpty(speNo))
            {
                lblerr.SetErrorMsg("请输入人员编码！");
                txtSpeNumber.Focus();
                return;
            }
            else if ((actType == 1 || (actType == 2 && oldNo != speNo)) && speBLL.ExistSpeNo(speNo))
            {
                lblerr.SetErrorMsg("该人员编码已存在！");
                txtSpeNumber.Focus();
                return;
            }
            if (string.IsNullOrEmpty(speName))
            {
                lblerr.SetErrorMsg("请输入人员名称！");
                txtSpeName.Focus();
                return;
            }
            else if ((actType == 1 || (actType == 2 && oldName != speName)) && speBLL.ExistSpeName(speName))
            {
                lblerr.SetErrorMsg("该人员已存在！");
                txtSpeName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(address))
            {
                lblerr.SetErrorMsg("请输入人员地址！");
                txtAddress.Focus();
                return;
            }
            if (string.IsNullOrEmpty(speVillage))
            {
                lblerr.SetErrorMsg("请输入人员所在小区！");
                txtVillage.Focus();
                return;
            }
            if (string.IsNullOrEmpty(sex))
            {
                lblerr.SetErrorMsg("请输入性别！");
                txtSex.Focus();
                return;
            }
            if (string.IsNullOrEmpty(phone))
            {
                lblerr.SetErrorMsg("请输入站点联系电话！");
                txtPhone.Focus();
                return;
            }
            if (string.IsNullOrEmpty(age))
            {
                lblerr.SetErrorMsg("请输入年龄！");
                txtAge.Focus();
                return;
            }
            if (string.IsNullOrEmpty(newtime))
            { 
                lblerr.SetErrorMsg("请输入最新投放时间！");
                txtNewTime.Focus();
                return;
            }
            
            //封装信息
            SpeInfo spe = new SpeInfo()
            {
                SpeId = editSpeId,
                UserNo = userNo,
                UserName = userName,
                UserAddress = address,
                Sex = sex,
                Phone = phone,
                Age = age,
                Special = special,
                UserVillage = userVillage,
                UserWeight = weight,
                UserIDnumber = useridnumber,
                UserIntegral = integral
            };
            //提交处理
            if (actType == 1)
            {
                int reId = resBLL.AddUser(user);
                if (reId > 0)
                {
                    MessageHelper.Info("添加居民", $"居民：{userName} 添加成功！");
                    user.UserId = reId;
                    //添加站点信息到站点列表中
                    dgvUserList.UpdateDgv(1, user, 0);
                    editUserId = reId;
                    buttok.Text = "修改";
                    actType = 2;
                    oldName = userName;
                    oldNo = userNo;
                }
                else
                {
                    lblerr.SetErrorMsg("居民信息添加失败！");
                    return;
                }
            }
            else
            {
                bool blEdit = resBLL.UpdateUser(user);
                if (blEdit)
                {
                    MessageHelper.Info("修改居民信息", $"居民：{userName} 修改成功！");
                    oldName = userName;
                    oldNo = userNo;
                    //更新站点信息到站点列表中
                    dgvUserList.UpdateDgv(2, user, editUserId);
                }
                else
                {
                    lblerr.SetErrorMsg("居民信息修改失败！");
                    return;
                }
            }
        }

        /// <summary>
        /// 修改居民信息加载到信息栏
        /// </summary>
        /// <param name="stationInfo"></param>
        private void InitEditSpeInfo(SpeInfo speInfo)
        {
            if (speInfo != null)
            {
                txtSpeNumber.Text = speInfo.SpeNo;
                txtSpeName.Text = speInfo.SpeName;
                txtSex.Text = speInfo.Sex;
                txtSpeIDnumber.Text = speInfo.SpeIDnumber;
                txtPhone.Text = speInfo.Phone;
                txtAddress.Text = speInfo.SpeAddress;
                txtAge.Text = speInfo.Age;
                txtVillage.Text = speInfo.SpeVillage;
                txtNewTime.Text = Convert.ToString(speInfo.NewThrow);
                txtmiaoshu.Text = speInfo.Remark;
                editSpeId = speInfo.SpeId;
                oldName = speInfo.SpeName;
                oldNo = speInfo.SpeNo;
                actType = 2;
                buttok.Text = "修改";
            }
        }

    }
}
