namespace Garbagemanage.Delivery_show
{
    partial class Delivery_show
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.PBoxExport = new System.Windows.Forms.PictureBox();
            this.PBoxExit = new System.Windows.Forms.PictureBox();
            this.TimerData = new System.Windows.Forms.Timer(this.components);
            this.chromiumWebBrowser1 = new CefSharp.WinForms.ChromiumWebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.PBoxExport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBoxExit)).BeginInit();
            this.SuspendLayout();
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 200;
            this.toolTip1.ReshowDelay = 100;
            // 
            // PBoxExport
            // 
            this.PBoxExport.BackColor = System.Drawing.Color.Transparent;
            this.PBoxExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PBoxExport.Image = global::Garbagemanage.Properties.Resources.数据导出;
            this.PBoxExport.Location = new System.Drawing.Point(147, 1248);
            this.PBoxExport.Margin = new System.Windows.Forms.Padding(4);
            this.PBoxExport.Name = "PBoxExport";
            this.PBoxExport.Size = new System.Drawing.Size(53, 50);
            this.PBoxExport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PBoxExport.TabIndex = 1;
            this.PBoxExport.TabStop = false;
            this.toolTip1.SetToolTip(this.PBoxExport, "导出数据");
            this.PBoxExport.Click += new System.EventHandler(this.PBoxExport_Click);
            // 
            // PBoxExit
            // 
            this.PBoxExit.BackColor = System.Drawing.Color.Transparent;
            this.PBoxExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PBoxExit.Image = global::Garbagemanage.Properties.Resources.退出;
            this.PBoxExit.Location = new System.Drawing.Point(16, 1248);
            this.PBoxExit.Margin = new System.Windows.Forms.Padding(4);
            this.PBoxExit.Name = "PBoxExit";
            this.PBoxExit.Size = new System.Drawing.Size(53, 50);
            this.PBoxExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PBoxExit.TabIndex = 1;
            this.PBoxExit.TabStop = false;
            this.toolTip1.SetToolTip(this.PBoxExit, "退出系统");
            this.PBoxExit.Click += new System.EventHandler(this.PBoxExit_Click);
            // 
            // TimerData
            // 
            this.TimerData.Enabled = true;
            this.TimerData.Interval = 2000;
            this.TimerData.Tick += new System.EventHandler(this.TimerData_Tick);
            // 
            // chromiumWebBrowser1
            // 
            this.chromiumWebBrowser1.ActivateBrowserOnCreation = false;
            this.chromiumWebBrowser1.Location = new System.Drawing.Point(-1, 2);
            this.chromiumWebBrowser1.Name = "chromiumWebBrowser1";
            this.chromiumWebBrowser1.Size = new System.Drawing.Size(1526, 773);
            this.chromiumWebBrowser1.TabIndex = 2;
            // 
            // Delivery_show
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1526, 773);
            this.Controls.Add(this.chromiumWebBrowser1);
            this.Controls.Add(this.PBoxExport);
            this.Controls.Add(this.PBoxExit);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Delivery_show";
            this.Text = "投放信息显示";
            this.Load += new System.EventHandler(this.Delivery_show_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PBoxExport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBoxExit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PBoxExit;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox PBoxExport;
        private System.Windows.Forms.Timer TimerData;
        private CefSharp.WinForms.ChromiumWebBrowser chromiumWebBrowser1;
    }
}

