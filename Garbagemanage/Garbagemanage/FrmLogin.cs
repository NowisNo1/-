using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Garbagemanage.Utility;
using Garbagemanage.BLL;
using Garbagemanage.Models;

namespace Garbagemanage
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        UserBLL userBLL = new UserBLL();
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtUserPwd.Clear();
            lblerr.Visible = false;
        }
        /// <summary>
        /// 登陆实现
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //接收信息
            string userName = txtUserName.Text.Trim();
            string userPwd = txtUserPwd.Text.Trim();
            //非空检查
            if (string.IsNullOrEmpty(userName))
            {
                lblerr.SetErrorMsg("请输入账号！");

                txtUserName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(userPwd))
            {
                lblerr.SetErrorMsg("请输入密码！");
                txtUserPwd.Focus();
                return;
            }
            DLUser userInfo = new DLUser()
            {
                UserName = userName,
                UserPwd = userPwd
            };
            //登录操作及响应
            string reLoginStr = "";
            //登录
            reLoginStr = userBLL.Login(userInfo);
            if (reLoginStr == "1")
            {
                //登录成功
                frmMain frmMain = new frmMain();
                frmMain.Tag = userName;
                frmMain.Show();
                this.Hide();
            }
            else
            {
                //失败
                lblerr.SetErrorMsg(reLoginStr);
                return;
            }
        }

        private void txtUserName_MouseDown(object sender, MouseEventArgs e)
        {
            lblerr.Visible = false;
        }

        private void txtUserPwd_MouseDown(object sender, MouseEventArgs e)
        {
            lblerr.Visible = false;
        }
    }
}
