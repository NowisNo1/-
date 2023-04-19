


using CefSharp;
using CefSharp.WinForms;
using Garbagemanage.BLL;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Garbagemanage.Statisic
{
    partial class FrmStatisicList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chromiumWebBrowser1 = new CefSharp.WinForms.ChromiumWebBrowser();
            this.SuspendLayout();
            // 
            // chromiumWebBrowser1
            // 
            this.chromiumWebBrowser1.ActivateBrowserOnCreation = false;
            this.chromiumWebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chromiumWebBrowser1.Location = new System.Drawing.Point(0, 0);
            this.chromiumWebBrowser1.Name = "chromiumWebBrowser1";
            this.chromiumWebBrowser1.Size = new System.Drawing.Size(1508, 726);
            this.chromiumWebBrowser1.TabIndex = 0;
            // 
            // FrmStatisicList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1508, 726);
            this.Controls.Add(this.chromiumWebBrowser1);
            this.Name = "FrmStatisicList";
            this.Text = "信息统计";
            this.Load += new System.EventHandler(this.FrmStatisicList_Load);
            this.ResumeLayout(false);

        }

        private void initBrowser()
        {
            this.chromiumWebBrowser1.ActivateBrowserOnCreation = false;
            this.chromiumWebBrowser1.Location = new System.Drawing.Point(0, 0);
            this.chromiumWebBrowser1.Name = "chromiumWebBrowser1";
            this.chromiumWebBrowser1.Size = new System.Drawing.Size(800, 450);
            this.chromiumWebBrowser1.TabIndex = 0;
            chromiumWebBrowser1.Dock = DockStyle.Fill;
            chromiumWebBrowser1.JavascriptObjectRepository.Settings.LegacyBindingEnabled = true;
            chromiumWebBrowser1.JavascriptObjectRepository.Register("MessageWrapper", new MessageWrapper(chromiumWebBrowser1, this), isAsync: false, options: BindingOptions.DefaultBinder);

        }
        internal class MessageWrapper
        {
            private ChromiumWebBrowser chromeBrowser;
            private FrmStatisicList f;
            public MessageWrapper(ChromiumWebBrowser chromeBrowser, FrmStatisicList f)
            {
                this.f = f;
                this.chromeBrowser = chromeBrowser;
            }

            public string demo()
            {
                JObject json = new JObject();
                PutInfosBLL putInfosBLL = new PutInfosBLL();
           
                JObject resp = new JObject();
                JArray l = new JArray();
                List<string> list = new List<string>();
                JArray PutTime = new JArray();
                JArray RecyclableWaste = new JArray();
                JArray OtherWaste = new JArray();
                JArray HarmfulWaste = new JArray();
                JArray KitchenWaste = new JArray();
                JArray AllWeight = new JArray();
                foreach (var item in putInfosBLL.getRecordListByDay(""))
                {
                    PutTime.Add(item.PutTime);
                    RecyclableWaste.Add(item.RecyclableWaste);
                    OtherWaste.Add(item.OtherWaste);
                    HarmfulWaste.Add(item.HarmfulWaste);
                    KitchenWaste.Add(item.KitchenWaste);
                    AllWeight.Add(item.AllWeight);
 
                    string s = item.PutTime.ToString();
                    string[] arr = s.Split(' ')[0].Split('/');
                    l.Add(arr[1] + "/" + arr[2]);
                }
                System.Console.WriteLine(l.ToString());
                resp["xAxis"] = l.ToString();
                resp["KitchenWaste"] = KitchenWaste.ToString();
                resp["RecyclableWaste"] = RecyclableWaste.ToString();
                resp["OtherWaste"] = OtherWaste.ToString();
                resp["HarmfulWaste"] = HarmfulWaste.ToString();
                resp["AllWeight"] = AllWeight.ToString();


                return resp.ToString();
            }
            public string test()
            {
                JObject json = new JObject();
                json["width"] = f.Width;
                json["height"] = f.Height;
                return json.ToString();
            }
            public void isCreate(string pakId)
            {
                DialogResult result = MessageBox.Show("XXX？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.OK)
                {
                    // 调用JS函数
                    chromeBrowser.EvaluateScriptAsync("ve.test(" + pakId + ");");
                }
                else
                {
                    return;
                }
            }
        }
        #endregion

        private CefSharp.WinForms.ChromiumWebBrowser chromiumWebBrowser1;
    }
}