


using CefSharp;
using CefSharp.WinForms;
using Newtonsoft.Json.Linq;
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
            this.chromiumWebBrowser1.Location = new System.Drawing.Point(0, 0);
            this.chromiumWebBrowser1.Name = "chromiumWebBrowser1";
            this.chromiumWebBrowser1.Size = new System.Drawing.Size(805, 450);
            this.chromiumWebBrowser1.TabIndex = 0;
            // 
            // FrmStatisicList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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