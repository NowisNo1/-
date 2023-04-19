using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Garbagemanage.BLL;
using Garbagemanage.DAL;
using Garbagemanage.Models;
using Garbagemanage.Models.UIModels;
using Garbagemanage.Utility;

namespace Garbagemanage.BM
{
    public partial class FrmStationList : Form
    {
        public FrmStationList()
        {
            InitializeComponent();
        }

        StationBLL stationBLL = new StationBLL();
        int actType = 1;//信息提交状态  1-新增 2-修改
        int editStationId = 0;//当前正在修改的站点编号
        bool isFirst = true;//第一次加载
        int totalCount = 0;//总站点数
        string oldNo = "", oldName = "";//修改前名称和编码
        private void FrmStationList_Load(object sender, EventArgs e)
        {
            //this.dgvStationList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvList_CellContentClick_1);
            this.dgvStationList.CurrentCellDirtyStateChanged += new System.EventHandler(FormUtility.DgvList_CurrentCellDirtyStateChanged);
            //加载站点列表
            FindStationList();
            //初始化信息栏
            InitStationInfo();
        }
        private void FindStationList()
        {
            string keywords = textBox6.Text.Trim();
            bool showDel = chkShowDel.Checked;
            int startIndex = uPager1.StartIndex;//当页的开始索引
            int pageSize = uPager1.PageSize;//每页记录数
            dgvStationList.AutoGenerateColumns = false;
            PageModel<StationInfo> pageModel = stationBLL.FindStationList(keywords, showDel, startIndex, pageSize);
            if (pageModel.TotalCount > 0)
            {
                dgvStationList.DataSource = pageModel.PageList;
                uPager1.Record = pageModel.TotalCount;
                if (isFirst)
                {
                    totalCount = pageModel.TotalCount;
                    isFirst = false;
                }
            }
            else
            {
                dgvStationList.DataSource = null;
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
            FindStationList();
        }

        private void uPager1_PageChanged(object sender, EventArgs e)
        {
            FindStationList();
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
            dgvStationList.Columns["colEdit"].Visible = !showDel;
            dgvStationList.Columns["colDel"].Visible = !showDel;
            dgvStationList.Columns["colRecover"].Visible = showDel;
            dgvStationList.Columns["colRemove"].Visible = showDel;
        }
        List<StationInfo> selectItems = new List<StationInfo>();//选择行的数据列表
        /// <summary>
        /// 行选择.行内按钮单击操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvStationList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        /// <summary>
        /// 修改站点信息加载到信息栏
        /// </summary>
        /// <param name="stationInfo"></param>
        private void InitEditStationInfo(StationInfo stationInfo)
        {
            if (stationInfo != null)
            {
                txtStationNumber.Text = stationInfo.StationNo;
                txtStationName.Text = stationInfo.StationName;
                txtStationAddress.Text = stationInfo.StationAddress;
                txtManager.Text = stationInfo.Manager;
                txtPhone.Text = stationInfo.Phone;
                txtTime.Text = stationInfo.ApplyTime;
                txtmiaoshu.Text = stationInfo.Remark;
                chkState.Checked = stationInfo.IsRunning;
                editStationId = stationInfo.StationId;
                oldName = stationInfo.StationName;
                oldNo = stationInfo.StationNo;
                actType = 2;
                buttok.Text = "修改";
            }
        }
        /// <summary>
        /// 删除、恢复、移除单个站点信息
        /// </summary>
        /// <param name="station">站点信息对象</param>
        /// <param name="isDeleted">1 删除  0 恢复  2 移除（真删除）</param>
        private void DeleteStation(StationInfo station, int isDeleted)
        {
            //操作询问---是---操作； 否则就不操作
            //标题和消息
            string[] titleMsg = FormUtility.GetActTitleAndMsg("站点", isDeleted);
            string msgTitle = titleMsg[0];
            string msg = titleMsg[1];
            if (MessageHelper.Confirm(msgTitle, msg) == DialogResult.OK)
            {
                List<int> ids = new List<int> { station.StationId };
                List<StationInfo> delList = new List<StationInfo> { station };
                switch (isDeleted)
                {
                    case 1:
                        string restr = stationBLL.DeleteStations(delList);//删除
                        string[] reArr = restr.Split(';');//结果字符串分隔
                        if (reArr[0] == "1")
                        {
                            MessageHelper.Info(msgTitle, $"站点：{station.StationName} 删除成功！");
                            dgvStationList.UpdateDgv(delList);//更新dgv
                        }
                        else if (reArr[0] == "0")
                        {
                            MessageHelper.Info(msgTitle, $"站点：{station.StationName} 删除失败！");
                            return;
                        }
                        else
                        {
                            MessageHelper.Info(msgTitle, $"站点：{station.StationName} 在运营中，不能删除！");
                            return;
                        }
                        break;
                    case 0:
                        bool blRecover = stationBLL.RecoverStations(ids);
                        if (blRecover)
                        {
                            MessageHelper.Info(msgTitle, $"站点：{station.StationName} 恢复成功！");
                            dgvStationList.UpdateDgv(delList);//更新dgv
                        }
                        else
                        {
                            MessageHelper.Info(msgTitle, $"站点：{station.StationName} 恢复失败！");
                            return;
                        }
                        break;
                    case 2:
                        bool blRemove = stationBLL.RemoveStations(ids);
                        if (blRemove)
                        {
                            MessageHelper.Info(msgTitle, $"站点：{station.StationName} 移除成功！");
                            dgvStationList.UpdateDgv(delList);//更新dgv
                        }
                        else
                        {
                            MessageHelper.Info(msgTitle, $"站点：{station.StationName} 移除失败！");
                            return;
                        }
                        break;
                }
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
            string stationNo = txtStationNumber.Text.Trim();
            string stationName = txtStationName.Text.Trim();
            string address = txtStationAddress.Text.Trim();
            string manager = txtManager.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string applytime = txtTime.Text.Trim();
            bool isRunning = chkState.Checked;
            string remark = txtmiaoshu.Text.Trim();
            //信息检查
            if (string.IsNullOrEmpty(stationNo))
            {
                lblerr.SetErrorMsg("请输入站点编码！");
                txtStationNumber.Focus();
                return;
            }
            else if ((actType == 1 || (actType == 2 && oldNo != stationNo)) && stationBLL.ExistStationNo(stationNo))
            {
                lblerr.SetErrorMsg("该站点编码已存在！");
                txtStationNumber.Focus();
                return;
            }
            if (string.IsNullOrEmpty(stationName))
            {
                lblerr.SetErrorMsg("请输入站点名称！");
                txtStationName.Focus();
                return;
            }
            else if ((actType == 1 || (actType == 2 && oldName != stationName)) && stationBLL.ExistStationName(stationName))
            {
                lblerr.SetErrorMsg("该站点名称已存在！");
                txtStationName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(address))
            {
                lblerr.SetErrorMsg("请输入站点地址！");
                txtStationAddress.Focus();
                return;
            }
            if (string.IsNullOrEmpty(manager))
            {
                lblerr.SetErrorMsg("请输入站点管理者！");
                txtManager.Focus();
                return;
            }
            if (string.IsNullOrEmpty(phone))
            {
                lblerr.SetErrorMsg("请输入站点联系电话！");
                txtPhone.Focus();
                return;
            }
            //封装信息
            StationInfo station = new StationInfo()
            {
                StationId = editStationId,
                StationNo = stationNo,
                StationName = stationName,
                StationAddress = address,
                Manager = manager,
                Phone = phone,
                ApplyTime = applytime,
                IsRunning = isRunning,
                Remark = remark,
                IsDeleted = 0
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
        /// 信息栏初始化
        /// </summary>
        private void InitStationInfo()
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
            txtStationNumber.Text = createNo;

            actType = 1;//新增
            buttok.Text = "添加";
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttDel_Click(object sender, EventArgs e)
        {
            DeleteStations(1);
        }
        /// <summary>
        /// 批量移除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttRemove_Click(object sender, EventArgs e)
        {
            DeleteStations(2);
        }
        /// <summary>
        /// 批量恢复
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttRecover_Click(object sender, EventArgs e)
        {
            DeleteStations(0);
        }
        /// <summary>
        /// 批量删除、恢复、移除站点信息（0 恢复 1删除 2移除）
        /// </summary>
        /// <param name="isDeleted"></param>
        private void DeleteStations(int isDeleted)
        {
            string actName = FormUtility.GetDelTypeName(isDeleted);
            string msgTitle = $"{actName}站点";
            if (selectItems.Count > 0)
            {
                if (MessageHelper.Confirm(msgTitle, $"你确定要{actName}选择的站点信息吗？") == DialogResult.OK)
                {
                    bool bl = false;//执行结果
                    List<int> delIds = selectItems.Select(s => s.StationId).ToList();//站点编号集合
                    switch (isDeleted)
                    {
                        case 1:
                            string reStr = stationBLL.DeleteStations(selectItems);//删除方法
                            string[] reArr = reStr.Split(';');
                            if (reArr[0] == "1")
                            {
                                if (reArr.Length == 1)
                                {
                                    //删除成功，没有不能删除的站点
                                    MessageHelper.Info(msgTitle, "选择的站点删除成功！");
                                    dgvStationList.UpdateDgv(selectItems);
                                }
                                else
                                {
                                    MessageHelper.Info(msgTitle, $"选择的站点中，{reArr[1]}正在运营中，不能删除！其余的站点删除成功！");
                                    //刷新  筛选出能删除站点
                                    var delList = selectItems.Where(s => s.IsRunning == false).ToList();
                                    dgvStationList.UpdateDgv(delList);
                                }
                                selectItems.Clear();//清空
                            }
                            else if (reArr[0] == "0")
                            {
                                MessageHelper.Error(msgTitle, "选择的站点删除失败！");
                                return;
                            }
                            else
                            {
                                MessageHelper.Error(msgTitle, "选择的站点都在运营中，不能删除！");
                                return;
                            }
                            break;
                        case 0:
                            bl = stationBLL.RecoverStations(delIds);
                            break;
                        case 2:
                            bl = stationBLL.RemoveStations(delIds);
                            break;
                    }
                    if (isDeleted != 1)
                    {
                        if (bl)
                        {
                            MessageHelper.Info(msgTitle, $"选择的站点{actName}成功！");
                            dgvStationList.UpdateDgv(selectItems);
                            selectItems.Clear();
                        }
                        else
                        {
                            MessageHelper.Error(msgTitle, $"选择的站点{actName}失败！");
                            return;
                        }
                    }
                }
            }
            else
            {
                MessageHelper.Error(msgTitle, $"请选择要{actName}的站点信息");
                return;
            }
        }
        /// <summary>
        /// 行选择、行内按钮单击操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvStationList_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //当前单元格
            DataGridViewCell cell = dgvStationList.Rows[e.RowIndex].Cells[e.ColumnIndex];
            StationInfo stationInfo = dgvStationList.Rows[e.RowIndex].DataBoundItem as StationInfo;
            //选择行
            if (cell is DataGridViewCheckBoxCell)
            {
                if (cell.FormattedValue.ToString() == "True")
                {
                    selectItems.Add(stationInfo);
                }
                else
                {
                    selectItems.Remove(stationInfo);
                }
            }
            else if (cell is DataGridViewLinkCell)
            {
                string cellValue = cell.FormattedValue.ToString();
                switch (cellValue)
                {
                    case "修改":
                        InitEditStationInfo(stationInfo);
                        break;
                    case "删除":
                        DeleteStation(stationInfo, 1);
                        break;
                    case "恢复":
                        DeleteStation(stationInfo, 0);
                        break;
                    case "移除":
                        DeleteStation(stationInfo, 2);
                        break;
                }
            }
        }

        private void buttRe_Click(object sender, EventArgs e)
        {
            InitStationInfo();
        }

        private void TextBox_MouseDown(object sender, MouseEventArgs e)
        {
            lblerr.Visible = false;
            lblerr.Text = "";
        }
    }
}
