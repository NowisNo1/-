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

namespace Garbagemanage.User
{
    public partial class FrmUserList : Form
    {
        public FrmUserList()
        {
            InitializeComponent();
        }
        ResBLL resBLL = new ResBLL();
        int actType = 1;//信息提交状态  1-新增 2-修改
        int editUserId = 0;//当前正在修改的站点编号
        bool isFirst = true;//第一次加载
        int totalCount = 0;//总站点数
        string oldNo = "", oldName = "";//修改前名称和编码

        private void FrmUserList_Load(object sender, EventArgs e)
        {
            this.dgvUserList.CurrentCellDirtyStateChanged += new System.EventHandler(FormUtility.DgvList_CurrentCellDirtyStateChanged);
            //加载站点列表
            FindUserList();
            //初始化信息栏
            InitUserInfo();
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttfind_Click(object sender, EventArgs e)
        {
            FindUserList();
        }

        private void FindUserList()
        {
            string keywords = textBox6.Text.Trim();
            bool showDel = chkShowDel.Checked;
            int startIndex = uPager1.StartIndex;//当页的开始索引
            int pageSize = uPager1.PageSize;//每页记录数
            dgvUserList.AutoGenerateColumns = false;
            PageModel<ResInfo> pageModel = resBLL.FindUserList(keywords, showDel, startIndex, pageSize);
            if (pageModel.TotalCount > 0)
            {
                dgvUserList.DataSource = pageModel.PageList;
                uPager1.Record = pageModel.TotalCount;
                if (isFirst)
                {
                    totalCount = pageModel.TotalCount;
                    isFirst = false;
                }
            }
            else
            {
                dgvUserList.DataSource = null;
                uPager1.Enabled = false;
            }
            SetActBtnsAndColVisible(showDel);
           
        }
        private void uPager1_PageChanged(object sender, EventArgs e)
        {
            FindUserList();
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
            dgvUserList.Columns["colEdit"].Visible = !showDel;
            dgvUserList.Columns["colDel"].Visible = !showDel;
            dgvUserList.Columns["colRecover"].Visible = showDel;
            dgvUserList.Columns["colRemove"].Visible = showDel;
        }

        private void dgvUserList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        List<StationInfo> selectItems = new List<StationInfo>();//选择行的数据列表
        /// <summary>
        /// 修改居民信息加载到信息栏
        /// </summary>
        /// <param name="stationInfo"></param>
        private void InitEditUserInfo(ResInfo userInfo)
        {
            if (userInfo != null)
            {
                txtUserNumber.Text = userInfo.UserNo;
                txtUserName.Text = userInfo.UserName;
                txtSex.Text = userInfo.Sex;
                txtUserIDnumber.Text = userInfo.UserIDnumber;
                txtPhone.Text = userInfo.Phone;
                txtAddress.Text = userInfo.UserAddress;
                chkState.Checked = userInfo.Special;
                editUserId = userInfo.UserId;
                oldName = userInfo.UserName;
                oldNo = userInfo.UserNo;
                actType = 2;
                buttok.Text = "修改";
            }
        }
        /// <summary>
        /// 信息提交功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttok_Click(object sender, EventArgs e)
        {
            //接收信息
            string userNo = txtUserNumber.Text.Trim();
            string userName = txtUserName.Text.Trim();
            string address = txtAddress.Text.Trim();
            string userVillage = txtUserVillage.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string sex = txtSex.Text.Trim();
            string age = txtAge.Text.Trim();
            bool special = chkState.Checked;
            string useridnumber = txtUserIDnumber.Text.Trim();
            string integral = txtIntegarl.Text.Trim();
            string weight = txtWeight.Text.Trim();
            //信息检查
            if (string.IsNullOrEmpty(userNo))
            {
                lblerr.SetErrorMsg("请输入居民编码！");
                txtUserNumber.Focus();
                return;
            }
            else if ((actType == 1 || (actType == 2 && oldNo != userNo)) && resBLL.ExistUserNo(userNo))
            {
                lblerr.SetErrorMsg("该居民编码已存在！");
                txtUserNumber.Focus();
                return;
            }
            if (string.IsNullOrEmpty(userName))
            {
                lblerr.SetErrorMsg("请输入居民名称！");
                txtUserName.Focus();
                return;
            }
            else if ((actType == 1 || (actType == 2 && oldName != userName)) && resBLL.ExistUserName(userName))
            {
                lblerr.SetErrorMsg("该居民已存在！");
                txtUserName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(address))
            {
                lblerr.SetErrorMsg("请输入站点地址！");
                txtAddress.Focus();
                return;
            }
            if (string.IsNullOrEmpty(userVillage))
            {
                lblerr.SetErrorMsg("请输入站点所在小区！");
                txtUserVillage.Focus();
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
            if (string.IsNullOrEmpty(integral))
            {
                lblerr.SetErrorMsg("请输入居民积分！");
                txtIntegarl.Focus();
                return;
            }
            if (string.IsNullOrEmpty(weight))
            {
                lblerr.SetErrorMsg("请输入投放重量！");
                txtWeight.Focus();
                return;
            }
            //封装信息
            ResInfo user = new ResInfo()
            {
                UserId = editUserId,
                UserNo = userNo,
                UserName = userName,
                UserAddress = address,
                Sex = sex,
                Phone = phone,
                Age = age,
                Special = special,
                UserVillage = userVillage,
                UserWeight=weight,
            };
            //提交处理
            if (actType == 1)
            {
                int reId = stationBLL.AddStation(station);
                if (reId > 0)
                {
                    MessageHelper.Info("添加站点", $"站点：{stationName} 添加成功！");
                    station.StationId = reId;
                    //添加站点信息到站点列表中
                    dgvStationList.UpdateDgv(1, station, 0);
                    editStationId = reId;
                    buttok.Text = "修改";
                    actType = 2;
                    oldName = stationName;
                    oldNo = stationNo;
                }
                else
                {
                    lblerr.SetErrorMsg("站点信息添加失败！");
                    return;
                }
            }
            else
            {
                bool blEdit = stationBLL.UpdateStation(station);
                if (blEdit)
                {
                    MessageHelper.Info("修改站点", $"站点：{stationName} 修改成功！");
                    oldName = stationName;
                    oldNo = stationNo;
                    //更新站点信息到站点列表中
                    dgvStationList.UpdateDgv(2, station, editStationId);
                }
                else
                {
                    lblerr.SetErrorMsg("站点信息修改失败！");
                    return;
                }
            }
        }

        /// <summary>
        /// 删除、恢复、移除单个居民信息
        /// </summary>
        /// <param name="station">站点信息对象</param>
        /// <param name="isDeleted">1 删除  0 恢复  2 移除（真删除）</param>
        private void DeleteUser(ResInfo user, int isDeleted)
        {
            //操作询问---是---操作； 否则就不操作
            //标题和消息
            string[] titleMsg = FormUtility.GetActTitleAndMsg("居民", isDeleted);
            string msgTitle = titleMsg[0];
            string msg = titleMsg[1];
            if (MessageHelper.Confirm(msgTitle, msg) == DialogResult.OK)
            {
                List<int> ids = new List<int> { user.UserId };
                List<ResInfo> delList = new List<ResInfo> { user };
                switch (isDeleted)
                {
                    case 1:
                        string restr = resBLL.DeleteUser(delList);//删除
                        string[] reArr = restr.Split(';');//结果字符串分隔
                        if (reArr[0] == "1")
                        {
                            MessageHelper.Info(msgTitle, $"居民：{user.UserName} 删除成功！");
                            dgvUserList.UpdateDgv(delList);//更新dgv
                        }
                        else if (reArr[0] == "0")
                        {
                            MessageHelper.Info(msgTitle, $"居民：{user.UserName} 删除失败！");
                            return;
                        }
                        else
                        {
                            MessageHelper.Info(msgTitle, $"居民：{user.UserName} 为特殊人群，不能删除！");
                            return;
                        }
                        break;
                    case 0:
                        bool blRecover = resBLL.RecoverUsers(ids);
                        if (blRecover)
                        {
                            MessageHelper.Info(msgTitle, $"居民：{user.UserName} 恢复成功！");
                            dgvUserList.UpdateDgv(delList);//更新dgv
                        }
                        else
                        {
                            MessageHelper.Info(msgTitle, $"居民：{user.UserName} 恢复失败！");
                            return;
                        }
                        break;
                    case 2:
                        bool blRemove = resBLL.RemoveUsers(ids);
                        if (blRemove)
                        {
                            MessageHelper.Info(msgTitle, $"居民：{user.UserName} 移除成功！");
                            dgvUserList.UpdateDgv(delList);//更新dgv
                        }
                        else
                        {
                            MessageHelper.Info(msgTitle, $"居民：{user.UserName} 移除失败！");
                            return;
                        }
                        break;
                }
            }
        }
    }
}
