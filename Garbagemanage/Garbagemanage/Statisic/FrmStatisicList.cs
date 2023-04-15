using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Garbagemanage.Statisic
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public partial class FrmStatisicList : Form
    {
        string str = System.Environment.CurrentDirectory +"\\myEcharts";
        Dictionary<string, bool> files = new Dictionary<string, bool>();

        public FrmStatisicList()
        {
            InitializeComponent();
            getAllHtmlFile();
           
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void initWebBrowser()
        {
            
            //chromiumWebBrowser AllowWebBrowserDrop = false;
            //chromiumWebBrowser1.IsWebBrowserContextMenuEnabled = false;
            //chromiumWebBrowser1.WebBrowserShortcutsEnabled = false;
            ////webBrowser1.ScriptErrorsSuppressed = true;
            //chromiumWebBrowser1.ObjectForScripting = this;
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmStatisicList_Load(object sender, EventArgs e)
        {
            initWebBrowser();

            accessPage("index.html");
        }
        public string WinFormRetustr()
        {
            JObject json = new JObject();
            json["width"] = Width;
            json["height"] = Height;
           
            return json.ToString();
        }

        public void accessPage(string filename)
        {
            if (files.ContainsKey(filename))
            {
               
                //this.Controls.Remove();
                Controls.Remove(chromiumWebBrowser1);
                chromiumWebBrowser1 = new ChromiumWebBrowser(str + "\\" + filename);
                initBrowser();
                Controls.Add(chromiumWebBrowser1);
                return;
            }
            throw new Exception("错误的路径");
        }
        private void getAllHtmlFile()
        {
            string[] paths = Directory.GetFiles(str);
            foreach(var item in paths)
            {
                string extension = Path.GetExtension(item).ToLower();
                
                if (extension == ".html")
                {
                    files[Path.GetFileName(item)] = true;
                }
            }
        }
    }
}
