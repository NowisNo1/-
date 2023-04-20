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
using System.Threading;
using Websocket.Client;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using WebSocket4Net;
using System.IO;
using System.Collections.Concurrent;

namespace Garbagemanage
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        MenuBLL menuBLL = new MenuBLL();
        string loginName = "";//登录名
        System.Timers.Timer timerDT = null;//定时器
        private void frmMain_Load(object sender, EventArgs e)
        {
            //初始化处理
            initMainPageInfo();
            WSocketClient("ws://49.233.5.44:8080");
            Start();
            Delivery_show.Delivery_show.get_parent(this);

        }
        public bool _ping()
        {
            try
            {
                System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
                System.Net.NetworkInformation.PingReply pr;
                pr = ping.Send("www.baidu.com");
                if (pr.Status != System.Net.NetworkInformation.IPStatus.Success)
                {
                    return false;
                } 
            }
            catch
            {
                return false;
            }
            return true;
        }

        private void initMainPageInfo()
        {   
            //tabPages.DrawMode = TabDrawMode.OwnerDrawFixed;
            //加载登录信息
            if (this.Tag !=null)
            {
                loginName = this.Tag.ToString();
            }
            if (!string.IsNullOrEmpty(loginName))
                lblLoginInfo.Text = loginName + "，欢迎使用系统";
            else
            {
                MessageHelper.Error("系统加载","你没有登录系统！");
                return;
            }
            toolStripStatusLabel4.Text = "系统导航页";
            //动态时间
            timerDT = new System.Timers.Timer();
            timerDT.Interval = 1000;
            timerDT.AutoReset = true;
            timerDT.Elapsed += TimerDT_Elapsed;
            toolStripStatusLabel2.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            timerDT.Start();
            //加载菜单栏
            menuStrip1.Items.Clear();
            //获取菜单项数据
            List<MenuInfo> allMenuList = menuBLL.GetMenuList();
            //加载菜单项到菜单栏中
            CreateMenuItems(allMenuList, null, 0);
            //默认显示系统导航子页
            //tabPages.AddTabFormPage(new Frm)
        }
        private void TimerDT_Elapsed(object sender,System.Timers.ElapsedEventArgs e)
        {
            if(this.IsHandleCreated)
            {
                this.Invoke(new Action(() =>
                {
                    toolStripStatusLabel2.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                }));
            }
        }
        /// <summary>
        /// 动态添加菜单项
        /// </summary>
        /// <param name="allMenus"></param>
        /// <param name="pMenu"></param>
        /// <param name="parentId"></param>
        private void CreateMenuItems(List<MenuInfo> allMenus, ToolStripMenuItem pMenu, int parentId)
        {
            //子菜单列表
            var subItems = allMenus.Where(m => m.Parentld == parentId);
            foreach (MenuInfo menuInfo in subItems)
            {
                //创建菜单项
                ToolStripMenuItem mItem = new ToolStripMenuItem();
                mItem.Name = menuInfo.Menuld.ToString();
                mItem.Text = menuInfo.MenuName;
                if (parentId == 0)
                {
                    //一级菜单
                    mItem.Font = new Font("微软雅黑", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
                    mItem.ForeColor = Color.Navy;
                }
                else
                {
                    //二级菜单
                    mItem.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
                    mItem.ForeColor = Color.Blue;
                }
                
                //页面地址
                if (!string.IsNullOrEmpty(menuInfo.FrmURL))
                {
                    mItem.Tag = menuInfo.FrmURL;//传递页面地址
                }
                //单击事件订阅---无子菜单的项
                if (allMenus.Where(m => m.Parentld == menuInfo.Menuld).Count() == 0)
                {
                    mItem.Click += MItem_Click;
                }
                //菜单项添加在哪一级
                if (pMenu != null)
                    pMenu.DropDownItems.Add(mItem);
                else
                    menuStrip1.Items.Add(mItem);
                CreateMenuItems(allMenus, mItem, menuInfo.Menuld);//创建当前菜单项的子菜单
            }
        }
        /// <summary>
        /// 菜单响应事件处理程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            if (menuItem.Tag != null)
            {
                string url = menuItem.Tag.ToString();//获取页面名称
                string frmName = url.Split('.')[1];//Form名称
                Form form = FormUtility.GetOpenForm(frmName);//获取当前要打开的窗体是否已经打开
                if (form == null)
                {
                    while (!_ping())
                    {
                        MessageBox.Show("请检查网络");
                    }
                    //创建窗体
                    string spaceName = GetType().Namespace;//命名空间名
                    string fullName = spaceName + "." + url;//完整名称
                    Type type = Type.GetType(fullName);//窗体的Type对象
                    form = (Form)Activator.CreateInstance(type);//窗体对象
                    
                }
                //Form对象添加到TabControl中
                tabPages.AddTabFormPage(form);
                CheckPage();
            }
            else
            {
                //退出系统
                if (menuItem.Text.Contains("退出系统"))
                {
                    Application.Exit();//退出应用程序
                }
            }
        }
        /// <summary>
        /// 退出系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageHelper.Confirm("退出系统","你确定要退出智慧城市生活垃圾分类系统管控平台吗？")==DialogResult.OK)
            {
                //确定要退出
                timerDT.Stop();
                Application.ExitThread();
            }
            else
            {
                e.Cancel = true;
            }
        }
        /// <summary>
        /// 子页自适应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            if (tabPages.TabPages.Count > 0)
            {
                Size size = tabPages.SelectedTab.Size;//子页的尺寸          
                foreach (TabPage tabPage in tabPages.TabPages)
                {
                    Control c = tabPage.Controls[0];
                    if (c is Form)
                    {
                        Form form = (Form)c;
                        form.WindowState = FormWindowState.Normal;
                        form.SuspendLayout();//挂起布局
                        form.Size = size;
                        form.ResumeLayout(true);//恢复布局
                        form.WindowState = FormWindowState.Maximized;
                    }
                }
            }
        }
        /// <summary>
        /// 关闭页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            TabPage tabPage = tabPages.SelectedTab;
            Form frm = (Form)tabPage.Controls[0];
            frm.Close();
            tabPages.TabPages.Remove(tabPage);
            CheckPage();
        }
        private void CheckPage()
        {
            if (tabPages.TabPages.Count == 0)
                pictureBox2.Visible = false;
            else
                pictureBox2.Visible = true;
        }

        private void tabPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabPages.SelectedTab!=null)
            toolStripStatusLabel4.Text = tabPages.SelectedTab.Text;//当前操作页
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BorderStyle = BorderStyle.None;
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        public static byte[] ByteCut(byte[] b, byte cut)
        {
            var list = new List<byte>();

            list.AddRange(b);

            for (var i = list.Count - 1; i >= 0; i--)
            {
                if (list[i] == cut)
                    list.RemoveAt(i);
            }
            var lastbyte = new byte[list.Count];
            for (var i = 0; i < list.Count; i++)
            {
                lastbyte[i] = list[i];
            }
            return lastbyte;
        }
        public void sendMessage(string message, string origin)
        {
            JObject json = new JObject();
            json["message"] = message;
            json["origin"] = origin;
            _webSocket.Send(json.ToString());

        }

        public Action<string> MessageReceived;

        private WebSocket4Net.WebSocket _webSocket;

        /// <summary>
        /// 检查重连线程
        /// </summary>
        Thread _thread;
        bool _isRunning = false;

        public string ServerPath { get; set; }
        public void WSocketClient(string url)
        {
            ServerPath = url;
            _webSocket = new WebSocket4Net.WebSocket(url);
            _webSocket.Opened += WebSocket_Opened;
            _webSocket.Error += WebSocket_Error;
            _webSocket.Closed += WebSocket_Closed;
            _webSocket.MessageReceived += WebSocket_MessageReceived;
        }


        /// <summary>
        /// 连接方法
        /// <returns></returns>
        public bool Start()
        {
            bool result = true;
            try
            {
                _webSocket.Open();
                _isRunning = true;
                _thread = new Thread(new ThreadStart(CheckConnection));
                _thread.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                result = false;
                _isRunning = false;
            }
            return result;
        }

        /// <summary>
        /// 消息收到事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebSocket_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            Console.WriteLine("Received:" + e.Message);
            JObject json = JObject.Parse(e.Message);

            if ("wechat".Equals(json["origin"].ToString()) && "new Client".Equals(json["type"].ToString()) && !users.ContainsKey(json["clientId"].ToString()))
            {
                users.TryAdd(json["clientId"].ToString(), json["clientId"].ToString());
            }
            if (MessageReceived != null)
                MessageReceived(e.Message);
        }

        /// <summary>
        /// Socket关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebSocket_Closed(object sender, EventArgs e)
        {
            Console.WriteLine("websocket_Closed");
        }

        /// <summary>
        /// Socket报错事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebSocket_Error(object sender, EventArgs e)
        {
            Console.WriteLine("websocket_Error:" + e.ToString());
        }

        /// <summary>
        /// Socket打开事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebSocket_Opened(object sender, EventArgs e)
        {
            Console.WriteLine("websocket_Opened");
           
            sendMessage("hello", "platform");
        }

        /// <summary>
        /// 检查重连线程
        /// </summary>
        private void CheckConnection()
        {
            do
            {
                try
                {
                    if (_webSocket.State != WebSocketState.Open && _webSocket.State != WebSocketState.Connecting)
                    {
                        Console.WriteLine("Reconnect websocket WebSocketState:" + _webSocket.State);

                        _webSocket.Close();
                        _webSocket.Open();

                        Console.WriteLine("正在重连");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                Thread.Sleep(5000);
            } while (_isRunning);
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="Message"></param>
        public string SendMessage(string str, string id)
        {
            JObject json = JObject.Parse(str);
            foreach(var item in users)
            {
                json["receiverId"] = item.Value;
                break;
            }
            
            Console.WriteLine(json.ToString());
            Task.Factory.StartNew(() =>
            {
                if (_webSocket != null && _webSocket.State == WebSocketState.Open)
                {
                    _webSocket.Send(json.ToString());
                }
            });
            return "ret";
        }
        delegate string Delegate(string str, string org);

        public void FunStartmain(object obj, object origin)
        {

            Delegate funDelegate = new Delegate(SendMessage);

            IAsyncResult aResult = BeginInvoke(funDelegate, obj.ToString(), origin.ToString());

            aResult.AsyncWaitHandle.WaitOne(1);
        
            string str = (string)EndInvoke(aResult);
        }
        
        public static ConcurrentDictionary<string, string> users = new ConcurrentDictionary<string, string>();
    }

}
