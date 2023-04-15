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
            //this.dgvSpeList.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvSpeList_CurrentCellDirtyStateChanged);
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
            DateTime newtime = Convert.ToDateTime(txtNewTime.Text.Trim());
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
                lblerr.SetErrorMsg("请输入人员联系电话！");
                txtPhone.Focus();
                return;
            }
            if (string.IsNullOrEmpty(age))
            {
                lblerr.SetErrorMsg("请输入年龄！");
                txtAge.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtNewTime.Text.Trim()))
            { 
                lblerr.SetErrorMsg("请输入最新投放时间！");
                txtNewTime.Focus();
                return;
            }
            
            //封装信息
            SpeInfo spe = new SpeInfo()
            {
                SpeId = editSpeId,
                SpeNo = speNo,
                SpeName = speName,
                SpeAddress = address,
                Sex = sex,
                Phone = phone,
                Age = age,
                SpeVillage = speVillage,
                NewThrow = newtime,
                SpeIDnumber=speidnumber
            };
            //提交处理
            if (actType == 1)
            {
                int reId = speBLL.AddSpe(spe);
                if (reId > 0)
                {
                    MessageHelper.Info("添加人员", $"人员：{speName} 添加成功！");
                    spe.SpeId = reId;
                    //添加站点信息到站点列表中
                    dgvSpeList.UpdateDgv(1, spe, 0);
                    editSpeId = reId;
                    buttok.Text = "修改";
                    actType = 2;
                    oldName = speName;
                    oldNo = speNo;
                }
                else
                {
                    lblerr.SetErrorMsg("人员信息添加失败！");
                    return;
                }
            }
            else
            {
                bool blEdit = speBLL.UpdateSpe(spe);
                if (blEdit)
                {
                    MessageHelper.Info("修改人员信息", $"人员：{speName} 修改成功！");
                    oldName = speName;
                    oldNo = speNo;
                    //更新站点信息到站点列表中
                    dgvSpeList.UpdateDgv(2, spe, editSpeId);
                }
                else
                {
                    lblerr.SetErrorMsg("人员信息修改失败！");
                    return;
                }
            }
        }

        /// <summary>
        /// 修改人员信息加载到信息栏
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
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttDel_Click(object sender, EventArgs e)
        {
            DeleteSpes(1);
        }
        /// <summary>
        /// 批量移除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttRemove_Click(object sender, EventArgs e)
        {
            DeleteSpes(2);
        }
        /// <summary>
        /// 批量恢复
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttRecover_Click(object sender, EventArgs e)
        {
            DeleteSpes(0);
        }

        /// <summary>
        /// 删除、恢复、移除单个人员信息
        /// </summary>
        /// <param name="station">站点信息对象</param>
        /// <param name="isDeleted">1 删除  0 恢复  2 移除（真删除）</param>
        private void DeleteSpe(SpeInfo spe, int isDeleted)
        {
            //操作询问---是---操作； 否则就不操作
            //标题和消息
            string[] titleMsg = FormUtility.GetActTitleAndMsg("人员", isDeleted);
            string msgTitle = titleMsg[0];
            string msg = titleMsg[1];
            if (MessageHelper.Confirm(msgTitle, msg) == DialogResult.OK)
            {
                List<int> ids = new List<int> { spe.SpeId };
                List<SpeInfo> delList = new List<SpeInfo> { spe };
                switch (isDeleted)
                {
                    case 1:
                        string restr = speBLL.DeleteSpe(delList);//删除
                        string[] reArr = restr.Split(';');//结果字符串分隔
                        if (reArr[0] == "1")
                        {
                            MessageHelper.Info(msgTitle, $"人员：{spe.SpeName} 删除成功！");
                            dgvSpeList.UpdateDgv(delList);//更新dgv
                        }
                        else if (reArr[0] == "0")
                        {
                            MessageHelper.Info(msgTitle, $"人员：{spe.SpeName} 删除失败！");
                            return;
                        }
                        else
                        {
                            MessageHelper.Info(msgTitle, $"人员：{spe.SpeName} 为特殊人群，不能删除！");
                            return;
                        }
                        break;
                    case 0:
                        bool blRecover = speBLL.RecoverSpes(ids);
                        if (blRecover)
                        {
                            MessageHelper.Info(msgTitle, $"人员：{spe.SpeName} 恢复成功！");
                            dgvSpeList.UpdateDgv(delList);//更新dgv
                        }
                        else
                        {
                            MessageHelper.Info(msgTitle, $"人员：{spe.SpeName} 恢复失败！");
                            return;
                        }
                        break;
                    case 2:
                        bool blRemove = speBLL.RemoveSpes(ids);
                        if (blRemove)
                        {
                            MessageHelper.Info(msgTitle, $"人员：{spe.SpeName} 移除成功！");
                            dgvSpeList.UpdateDgv(delList);//更新dgv
                        }
                        else
                        {
                            MessageHelper.Info(msgTitle, $"人员：{spe.SpeName} 移除失败！");
                            return;
                        }
                        break;
                }
            }
        }
        /// <summary>
        /// 信息栏初始化
        /// </summary>
        private void InitSpeInfo()
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
            txtSpeNumber.Text = createNo;

            actType = 1;//新增
            buttok.Text = "添加";
        }
        /// <summary>
        /// 重置按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttRe_Click(object sender, EventArgs e)
        {
            InitSpeInfo();
        }

        /// <summary>
        /// 批量删除、恢复、移除人员信息（0 恢复 1删除 2移除）
        /// </summary>
        /// <param name="isDeleted"></param>
        private void DeleteSpes(int isDeleted)
        {
            string actName = FormUtility.GetDelTypeName(isDeleted);
            string msgTitle = $"{actName}人员";
            if (selectItems.Count > 0)
            {
                if (MessageHelper.Confirm(msgTitle, $"你确定要{actName}选择的人员信息吗？") == DialogResult.OK)
                {
                    bool bl = false;//执行结果
                    List<int> delIds = selectItems.Select(s => s.SpeId).ToList();//人员编号集合
                    switch (isDeleted)
                    {
                        case 1:
                            string reStr = speBLL.DeleteSpe(selectItems);//删除方法
                            string[] reArr = reStr.Split(';');
                            if (reArr[0] == "1")
                            {
                                if (reArr.Length == 1)
                                {
                                    //删除成功，没有不能删除的人员
                                    MessageHelper.Info(msgTitle, "选择的人员删除成功！");
                                    dgvSpeList.UpdateDgv(selectItems);
                                }
                                //else
                                //{
                                //    MessageHelper.Info(msgTitle, $"选择的人员中，{reArr[1]}为特殊人群，不能删除！其余的人员删除成功！");
                                //    //刷新  筛选出能删除人员
                                //    var delList = selectItems.Where(s => s.Special == false).ToList();
                                //    dgvUserList.UpdateDgv(delList);
                                //}
                                selectItems.Clear();//清空
                            }
                            else if (reArr[0] == "0")
                            {
                                MessageHelper.Error(msgTitle, "选择的人员删除失败！");
                                return;
                            }
                            else
                            {
                                MessageHelper.Error(msgTitle, "选择的人员都在运营中，不能删除！");
                                return;
                            }
                            break;
                        case 0:
                            bl = speBLL.RecoverSpes(delIds);
                            break;
                        case 2:
                            bl = speBLL.RemoveSpes(delIds);
                            break;
                    }
                    if (isDeleted != 1)
                    {
                        if (bl)
                        {
                            MessageHelper.Info(msgTitle, $"选择的人员{actName}成功！");
                            dgvSpeList.UpdateDgv(selectItems);
                            selectItems.Clear();
                        }
                        else
                        {
                            MessageHelper.Error(msgTitle, $"选择的人员{actName}失败！");
                            return;
                        }
                    }
                }
            }
            else
            {
                MessageHelper.Error(msgTitle, $"请选择要{actName}的人员信息");
                return;
            }
        }
        /// <summary>
        /// 行选择、行内按钮单击操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSpeList_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //当前单元格
            DataGridViewCell cell = dgvSpeList.Rows[e.RowIndex].Cells[e.ColumnIndex];
            SpeInfo speInfo = dgvSpeList.Rows[e.RowIndex].DataBoundItem as SpeInfo;
            //选择行
            if (cell is DataGridViewCheckBoxCell)
            {
                if (cell.FormattedValue.ToString() == "True")
                {
                    selectItems.Add(speInfo);
                }
                else
                {
                    selectItems.Remove(speInfo);
                }
            }
            else if (cell is DataGridViewLinkCell)
            {
                string cellValue = cell.FormattedValue.ToString();
                switch (cellValue)
                {
                    case "修改":
                        InitEditSpeInfo(speInfo);
                        break;
                    case "删除":
                        DeleteSpe(speInfo, 1);
                        break;
                    case "恢复":
                        DeleteSpe(speInfo, 0);
                        break;
                    case "移除":
                        DeleteSpe(speInfo, 2);
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
