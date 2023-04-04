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
            //this.dgvUserList.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvUserList_CurrentCellDirtyStateChanged);
            this.dgvUserList.CurrentCellDirtyStateChanged += new System.EventHandler(FormUtility.DgvList_CurrentCellDirtyStateChanged);
            //加载站点列表
            FindUserList();

            //初始化信息栏
            InitUserInfo();
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
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttfind_Click(object sender, EventArgs e)
        {
            FindUserList();
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

        List<ResInfo> selectItems = new List<ResInfo>();//选择行的数据列表
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
                txtAge.Text = userInfo.Age;
                txtUserVillage.Text = userInfo.UserVillage;
                txtIntegarl.Text = Convert.ToString(userInfo.UserIntegral);
                txtWeight.Text = Convert.ToString(userInfo.UserWeight);
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
            int integral = Convert.ToInt16(txtIntegarl.Text.Trim());
            double weight = Convert.ToDouble(txtWeight.Text.Trim());
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
                lblerr.SetErrorMsg("请输入居民地址！");
                txtAddress.Focus();
                return;
            }
            if (string.IsNullOrEmpty(userVillage))
            {
                lblerr.SetErrorMsg("请输入居民所在小区！");
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
            if (string.IsNullOrEmpty(txtIntegarl.Text.Trim()))
            {
                lblerr.SetErrorMsg("请输入居民积分！");
                txtIntegarl.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtWeight.Text.Trim()))
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
                UserWeight = weight,
                UserIDnumber = useridnumber,
                UserIntegral=integral
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
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttDel_Click(object sender, EventArgs e)
        {
            DeleteUsers(1);
        }
        /// <summary>
        /// 批量移除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttRemove_Click(object sender, EventArgs e)
        {
            DeleteUsers(2);
        }
        /// <summary>
        /// 批量恢复
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttRecover_Click(object sender, EventArgs e)
        {
            DeleteUsers(0);
        }

        /// <summary>
        /// 信息栏初始化
        /// </summary>
        private void InitUserInfo()
        {
            foreach (Control c in groupBox1.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
                else if (c is CheckBox)
                {
                    ((CheckBox)c).Checked = false;
                }
            }
            lblerr.Visible = false;//异常标签
            //默认生成初始编码
            string createNo = "S";
            totalCount++;
            createNo += totalCount.ToString("0000");
            txtUserNumber.Text = createNo;

            actType = 1;//新增
            buttok.Text = "添加";
        }
        /// <summary>
        /// 批量删除、恢复、移除居民信息（0 恢复 1删除 2移除）
        /// </summary>
        /// <param name="isDeleted"></param>
        private void DeleteUsers(int isDeleted)
        {
            string actName = FormUtility.GetDelTypeName(isDeleted);
            string msgTitle = $"{actName}居民";
            if (selectItems.Count > 0)
            {
                if (MessageHelper.Confirm(msgTitle, $"你确定要{actName}选择的居民信息吗？") == DialogResult.OK)
                {
                    bool bl = false;//执行结果
                    List<int> delIds = selectItems.Select(s => s.UserId).ToList();//居民编号集合
                    switch (isDeleted)
                    {
                        case 1:
                            string reStr = resBLL.DeleteUser(selectItems);//删除方法
                            string[] reArr = reStr.Split(';');
                            if (reArr[0] == "1")
                            {
                                if (reArr.Length == 1)
                                {
                                    //删除成功，没有不能删除的居民
                                    MessageHelper.Info(msgTitle, "选择的居民删除成功！");
                                    dgvUserList.UpdateDgv(selectItems);
                                }
                                else
                                {
                                    MessageHelper.Info(msgTitle, $"选择的居民中，{reArr[1]}为特殊人群，不能删除！其余的居民删除成功！");
                                    //刷新  筛选出能删除居民
                                    var delList = selectItems.Where(s => s.Special == false).ToList();
                                    dgvUserList.UpdateDgv(delList);
                                }
                                selectItems.Clear();//清空
                            }
                            else if (reArr[0] == "0")
                            {
                                MessageHelper.Error(msgTitle, "选择的居民删除失败！");
                                return;
                            }
                            else
                            {
                                MessageHelper.Error(msgTitle, "选择的居民都在运营中，不能删除！");
                                return;
                            }
                            break;
                        case 0:
                            bl = resBLL.RecoverUsers(delIds);
                            break;
                        case 2:
                            bl = resBLL.RemoveUsers(delIds);
                            break;
                    }
                    if (isDeleted != 1)
                    {
                        if (bl)
                        {
                            MessageHelper.Info(msgTitle, $"选择的居民{actName}成功！");
                            dgvUserList.UpdateDgv(selectItems);
                            selectItems.Clear();
                        }
                        else
                        {
                            MessageHelper.Error(msgTitle, $"选择的居民{actName}失败！");
                            return;
                        }
                    }
                }
            }
            else
            {
                MessageHelper.Error(msgTitle, $"请选择要{actName}的居民信息");
                return;
            }
        }
        /// <summary>
        /// 重置按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttRe_Click(object sender, EventArgs e)
        {
            InitUserInfo();
        }

        

        /// <summary>
        /// 行选择、行内按钮单击操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvUserList_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //当前单元格
            DataGridViewCell cell = dgvUserList.Rows[e.RowIndex].Cells[e.ColumnIndex];
            ResInfo resInfo = dgvUserList.Rows[e.RowIndex].DataBoundItem as ResInfo;
            //选择行
            if (cell is DataGridViewCheckBoxCell)
            {
                if (cell.FormattedValue.ToString() == "True")
                {
                    selectItems.Add(resInfo);
                }
                else
                {
                    selectItems.Remove(resInfo);
                }
            }
            else if (cell is DataGridViewLinkCell)
            {
                string cellValue = cell.FormattedValue.ToString();
                switch (cellValue)
                {
                    case "修改":
                        InitEditUserInfo(resInfo);
                        break;
                    case "删除":
                        DeleteUser(resInfo, 1);
                        break;
                    case "恢复":
                        DeleteUser(resInfo, 0);
                        break;
                    case "移除":
                        DeleteUser(resInfo, 2);
                        break;
                }
            }
        }
        private void TextBox_MouseDown(object sender, MouseEventArgs e)
        {
            lblerr.Visible = false;
            lblerr.Text = "";
        }
    }
}
