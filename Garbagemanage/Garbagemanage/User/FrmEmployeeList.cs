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
    public partial class FrmEmployeeList : Form
    {
        public FrmEmployeeList()
        {
            InitializeComponent();
        }
        EmployeeBLL empBLL = new EmployeeBLL();
        int actType = 1;//信息提交状态  1-新增 2-修改
        int editEmpId = 0;//当前正在修改的站点编号
        bool isFirst = true;//第一次加载
        int totalCount = 0;//总站点数
        string oldNo = "", oldName = "";//修改前名称和编码

        private void FrmEmployeeList_Load(object sender, EventArgs e)
        {
            this.dgvEmpList.CurrentCellDirtyStateChanged += new System.EventHandler(FormUtility.DgvList_CurrentCellDirtyStateChanged);
            //加载站点列表
            FindEmpList();

            //初始化信息栏
            InitEmpInfo();
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttfind_Click(object sender, EventArgs e)
        {
            FindEmpList();
        }

        private void FindEmpList()
        {
            string keywords = textBox6.Text.Trim();
            bool showDel = chkShowDel.Checked;
            int startIndex = uPager1.StartIndex;//当页的开始索引
            int pageSize = uPager1.PageSize;//每页记录数
            dgvEmpList.AutoGenerateColumns = false;
            PageModel<EmployeeInfo> pageModel = empBLL.FindEmpList(keywords, showDel, startIndex, pageSize);
            if (pageModel.TotalCount > 0)
            {
                dgvEmpList.DataSource = pageModel.PageList;
                uPager1.Record = pageModel.TotalCount;
                if (isFirst)
                {
                    totalCount = pageModel.TotalCount;
                    isFirst = false;
                }
            }
            else
            {
                dgvEmpList.DataSource = null;
                uPager1.Enabled = false;
            }
            SetActBtnsAndColVisible(showDel);
        }
        private void uPager1_PageChanged(object sender, EventArgs e)
        {
            FindEmpList();
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
            dgvEmpList.Columns["colEdit"].Visible = !showDel;
            dgvEmpList.Columns["colDel"].Visible = !showDel;
            dgvEmpList.Columns["colRecover"].Visible = showDel;
            dgvEmpList.Columns["colRemove"].Visible = showDel;
        }
        List<EmployeeInfo> selectItems = new List<EmployeeInfo>();//选择行的数据列表
        /// <summary>
        /// 提交功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttok_Click(object sender, EventArgs e)
        {
            //接收信息
            string empNo = txtEmpNumber.Text.Trim();
            string empName = txtEmpName.Text.Trim();
            string area = txtArea.Text.Trim();
            string typled = txtEmpTypled.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string sex = txtSex.Text.Trim();
            string age = txtAge.Text.Trim();
            bool ison = chkState.Checked;
            string empidnumber = txtEmpIDnumber.Text.Trim();
            //信息检查
            if (string.IsNullOrEmpty(empNo))
            {
                lblerr.SetErrorMsg("请输入员工编码！");
                txtEmpNumber.Focus();
                return;
            }
            else if ((actType == 1 || (actType == 2 && oldNo != empNo)) && empBLL.ExistEmpNo(empNo))
            {
                lblerr.SetErrorMsg("该员工编码已存在！");
                txtEmpNumber.Focus();
                return;
            }
            if (string.IsNullOrEmpty(empName))
            {
                lblerr.SetErrorMsg("请输入员工名称！");
                txtEmpName.Focus();
                return;
            }
            else if ((actType == 1 || (actType == 2 && oldName != empName)) && empBLL.ExistEmpName(empName))
            {
                lblerr.SetErrorMsg("该员工已存在！");
                txtEmpName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(area))
            {
                lblerr.SetErrorMsg("请输入员工地址！");
                txtArea.Focus();
                return;
            }
            if (string.IsNullOrEmpty(typled))
            {
                lblerr.SetErrorMsg("请输入员工所在小区！");
                txtEmpTypled.Focus();
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
            
            //封装信息
            EmployeeInfo emp = new EmployeeInfo()
            {
                EmpId = editEmpId,
                EmpNo = empNo,
                EmpName = empName,
                Area = area,
                Sex = sex,
                Phone = phone,
                Age = age,
                IsOn = ison,
                EmpTypled = typled,
                EmpIDnumber = empidnumber,
            };
            //提交处理
            if (actType == 1)
            {
                int reId = empBLL.AddEmp(emp);
                if (reId > 0)
                {
                    MessageHelper.Info("添加员工", $"员工：{empName} 添加成功！");
                    emp.EmpId = reId;
                    //添加站点信息到站点列表中
                    dgvEmpList.UpdateDgv(1, emp, 0);
                    editEmpId = reId;
                    buttok.Text = "修改";
                    actType = 2;
                    oldName = empName;
                    oldNo = empNo;
                }
                else
                {
                    lblerr.SetErrorMsg("员工信息添加失败！");
                    return;
                }
            }
            else
            {
                bool blEdit = empBLL.UpdateEmp(emp);
                if (blEdit)
                {
                    MessageHelper.Info("修改员工信息", $"员工：{empName} 修改成功！");
                    oldName = empName;
                    oldNo = empNo;
                    //更新站点信息到站点列表中
                    dgvEmpList.UpdateDgv(2, emp, editEmpId);
                }
                else
                {
                    lblerr.SetErrorMsg("员工信息修改失败！");
                    return;
                }
            }
        }
        /// <summary>
        /// 修改员工信息加载到信息栏
        /// </summary>
        /// <param name="stationInfo"></param>
        private void InitEditEmpInfo(EmployeeInfo empInfo)
        {
            if (empInfo != null)
            {
                txtEmpNumber.Text = empInfo.EmpNo;
                txtEmpName.Text = empInfo.EmpName;
                txtSex.Text = empInfo.Sex;
                txtEmpIDnumber.Text = empInfo.EmpIDnumber;
                txtPhone.Text = empInfo.Phone;
                txtArea.Text = empInfo.Area;
                txtAge.Text = empInfo.Age;
                txtEmpTypled.Text = empInfo.EmpTypled;
                chkState.Checked = empInfo.IsOn;
                editEmpId = empInfo.EmpId;
                oldName = empInfo.EmpName;
                oldNo = empInfo.EmpNo;
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
            DeleteEmps(1);
        }
        /// <summary>
        /// 批量移除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttRemove_Click(object sender, EventArgs e)
        {
            DeleteEmps(2);
        }
        /// <summary>
        /// 批量恢复
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttRecover_Click(object sender, EventArgs e)
        {
            DeleteEmps(0);
        }

        /// <summary>
        /// 删除、恢复、移除单个员工信息
        /// </summary>
        /// <param name="station">站点信息对象</param>
        /// <param name="isDeleted">1 删除  0 恢复  2 移除（真删除）</param>
        private void DeleteEmp(EmployeeInfo emp, int isDeleted)
        {
            //操作询问---是---操作； 否则就不操作
            //标题和消息
            string[] titleMsg = FormUtility.GetActTitleAndMsg("员工", isDeleted);
            string msgTitle = titleMsg[0];
            string msg = titleMsg[1];
            if (MessageHelper.Confirm(msgTitle, msg) == DialogResult.OK)
            {
                List<int> ids = new List<int> { emp.EmpId };
                List<EmployeeInfo> delList = new List<EmployeeInfo> { emp };
                switch (isDeleted)
                {
                    case 1:
                        string restr = empBLL.DeleteEmp(delList);//删除
                        string[] reArr = restr.Split(';');//结果字符串分隔
                        if (reArr[0] == "1")
                        {
                            MessageHelper.Info(msgTitle, $"员工：{emp.EmpName} 删除成功！");
                            dgvEmpList.UpdateDgv(delList);//更新dgv
                        }
                        else if (reArr[0] == "0")
                        {
                            MessageHelper.Info(msgTitle, $"员工：{emp.EmpName} 删除失败！");
                            return;
                        }
                        else
                        {
                            MessageHelper.Info(msgTitle, $"员工：{emp.EmpName} 为特殊人群，不能删除！");
                            return;
                        }
                        break;
                    case 0:
                        bool blRecover = empBLL.Recoveremps(ids);
                        if (blRecover)
                        {
                            MessageHelper.Info(msgTitle, $"员工：{emp.EmpName} 恢复成功！");
                            dgvEmpList.UpdateDgv(delList);//更新dgv
                        }
                        else
                        {
                            MessageHelper.Info(msgTitle, $"员工：{emp.EmpName} 恢复失败！");
                            return;
                        }
                        break;
                    case 2:
                        bool blRemove = empBLL.Removeemps(ids);
                        if (blRemove)
                        {
                            MessageHelper.Info(msgTitle, $"员工：{emp.EmpName} 移除成功！");
                            dgvEmpList.UpdateDgv(delList);//更新dgv
                        }
                        else
                        {
                            MessageHelper.Info(msgTitle, $"员工：{emp.EmpName} 移除失败！");
                            return;
                        }
                        break;
                }
            }
        }
        /// <summary>
        /// 信息栏初始化
        /// </summary>
        private void InitEmpInfo()
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
            txtEmpNumber.Text = createNo;

            actType = 1;//新增
            buttok.Text = "添加";
        }
        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void buttRe_Click(object sender, EventArgs e)
        {
            InitEmpInfo();
        }

        /// <summary>
        /// 批量删除、恢复、移除员工信息（0 恢复 1删除 2移除）
        /// </summary>
        /// <param name="isDeleted"></param>
        private void DeleteEmps(int isDeleted)
        {
            string actName = FormUtility.GetDelTypeName(isDeleted);
            string msgTitle = $"{actName}员工";
            if (selectItems.Count > 0)
            {
                if (MessageHelper.Confirm(msgTitle, $"你确定要{actName}选择的员工信息吗？") == DialogResult.OK)
                {
                    bool bl = false;//执行结果
                    List<int> delIds = selectItems.Select(s => s.EmpId).ToList();//员工编号集合
                    switch (isDeleted)
                    {
                        case 1:
                            string reStr = empBLL.DeleteEmp(selectItems);//删除方法
                            string[] reArr = reStr.Split(';');
                            if (reArr[0] == "1")
                            {
                                if (reArr.Length == 1)
                                {
                                    //删除成功，没有不能删除的员工
                                    MessageHelper.Info(msgTitle, "选择的员工删除成功！");
                                    dgvEmpList.UpdateDgv(selectItems);
                                }
                                else
                                {
                                    MessageHelper.Info(msgTitle, $"选择的员工中，{reArr[1]}为特殊人群，不能删除！其余的员工删除成功！");
                                    //刷新  筛选出能删除员工
                                    var delList = selectItems.Where(s => s.IsOn == false).ToList();
                                    dgvEmpList.UpdateDgv(delList);
                                }
                                selectItems.Clear();//清空
                            }
                            else if (reArr[0] == "0")
                            {
                                MessageHelper.Error(msgTitle, "选择的员工删除失败！");
                                return;
                            }
                            else
                            {
                                MessageHelper.Error(msgTitle, "选择的员工都在运营中，不能删除！");
                                return;
                            }
                            break;
                        case 0:
                            bl = empBLL.Recoveremps(delIds);
                            break;
                        case 2:
                            bl = empBLL.Removeemps(delIds);
                            break;
                    }
                    if (isDeleted != 1)
                    {
                        if (bl)
                        {
                            MessageHelper.Info(msgTitle, $"选择的员工{actName}成功！");
                            dgvEmpList.UpdateDgv(selectItems);
                            selectItems.Clear();
                        }
                        else
                        {
                            MessageHelper.Error(msgTitle, $"选择的员工{actName}失败！");
                            return;
                        }
                    }
                }
            }
            else
            {
                MessageHelper.Error(msgTitle, $"请选择要{actName}的员工信息");
                return;
            }
        }
        /// <summary>
        /// 行选择、行内按钮单击操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvEmpList_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //当前单元格
            DataGridViewCell cell = dgvEmpList.Rows[e.RowIndex].Cells[e.ColumnIndex];
            EmployeeInfo empInfo = dgvEmpList.Rows[e.RowIndex].DataBoundItem as EmployeeInfo;
            //选择行
            if (cell is DataGridViewCheckBoxCell)
            {
                if (cell.FormattedValue.ToString() == "True")
                {
                    selectItems.Add(empInfo);
                }
                else
                {
                    selectItems.Remove(empInfo);
                }
            }
            else if (cell is DataGridViewLinkCell)
            {
                string cellValue = cell.FormattedValue.ToString();
                switch (cellValue)
                {
                    case "修改":
                        InitEditEmpInfo(empInfo);
                        break;
                    case "删除":
                        DeleteEmp(empInfo, 1);
                        break;
                    case "恢复":
                        DeleteEmp(empInfo, 0);
                        break;
                    case "移除":
                        DeleteEmp
(empInfo, 2);
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
