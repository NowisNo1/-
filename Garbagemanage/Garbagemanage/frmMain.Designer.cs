using System;

namespace Garbagemanage
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLoginInfo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabPages = new System.Windows.Forms.TabControl();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.综合信息查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.站点信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.居民信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.员工信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(16, 9);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 71);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(103, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(614, 50);
            this.label1.TabIndex = 1;
            this.label1.Text = "智慧城市生活垃圾分类系统管控平台";
            // 
            // lblLoginInfo
            // 
            this.lblLoginInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLoginInfo.AutoSize = true;
            this.lblLoginInfo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLoginInfo.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.lblLoginInfo.Location = new System.Drawing.Point(1323, 49);
            this.lblLoginInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLoginInfo.Name = "lblLoginInfo";
            this.lblLoginInfo.Size = new System.Drawing.Size(162, 19);
            this.lblLoginInfo.TabIndex = 2;
            this.lblLoginInfo.Text = "admin，欢迎使用系统";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel1.Controls.Add(this.lblLoginInfo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1527, 86);
            this.panel1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4});
            this.statusStrip1.Location = new System.Drawing.Point(0, 741);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1527, 25);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.DimGray;
            this.toolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(84, 20);
            this.toolStripStatusLabel1.Text = "登录时间：";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.Blue;
            this.toolStripStatusLabel2.Margin = new System.Windows.Forms.Padding(5, 3, 0, 2);
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(141, 20);
            this.toolStripStatusLabel2.Text = "2023-3-14 8:55:49";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.ForeColor = System.Drawing.Color.DimGray;
            this.toolStripStatusLabel3.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(84, 20);
            this.toolStripStatusLabel3.Text = "当前操作：";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.ForeColor = System.Drawing.Color.Purple;
            this.toolStripStatusLabel4.Margin = new System.Windows.Forms.Padding(5, 3, 0, 2);
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(39, 20);
            this.toolStripStatusLabel4.Text = "首页";
            // 
            // tabPages
            // 
            this.tabPages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabPages.Location = new System.Drawing.Point(3, 139);
            this.tabPages.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPages.Name = "tabPages";
            this.tabPages.SelectedIndex = 0;
            this.tabPages.Size = new System.Drawing.Size(1521, 596);
            this.tabPages.TabIndex = 4;
            this.tabPages.SelectedIndexChanged += new System.EventHandler(this.tabPages_SelectedIndexChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1481, 136);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(35, 28);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            this.pictureBox2.MouseLeave += new System.EventHandler(this.pictureBox2_MouseLeave);
            this.pictureBox2.MouseHover += new System.EventHandler(this.pictureBox2_MouseHover);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(189)))), ((int)(((byte)(240)))));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.综合信息查询ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 86);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1527, 50);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 综合信息查询ToolStripMenuItem
            // 
            this.综合信息查询ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.站点信息ToolStripMenuItem,
            this.居民信息ToolStripMenuItem,
            this.员工信息ToolStripMenuItem});
            this.综合信息查询ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.综合信息查询ToolStripMenuItem.ForeColor = System.Drawing.Color.Navy;
            this.综合信息查询ToolStripMenuItem.Name = "综合信息查询ToolStripMenuItem";
            this.综合信息查询ToolStripMenuItem.Size = new System.Drawing.Size(146, 46);
            this.综合信息查询ToolStripMenuItem.Text = "综合信息查询";
            // 
            // 站点信息ToolStripMenuItem
            // 
            this.站点信息ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.站点信息ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.站点信息ToolStripMenuItem.ForeColor = System.Drawing.Color.Blue;
            this.站点信息ToolStripMenuItem.Name = "站点信息ToolStripMenuItem";
            this.站点信息ToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
            this.站点信息ToolStripMenuItem.Text = "站点信息";
            // 
            // 居民信息ToolStripMenuItem
            // 
            this.居民信息ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.居民信息ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.居民信息ToolStripMenuItem.ForeColor = System.Drawing.Color.Blue;
            this.居民信息ToolStripMenuItem.Name = "居民信息ToolStripMenuItem";
            this.居民信息ToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
            this.居民信息ToolStripMenuItem.Text = "居民信息";
            // 
            // 员工信息ToolStripMenuItem
            // 
            this.员工信息ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.员工信息ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.员工信息ToolStripMenuItem.ForeColor = System.Drawing.Color.Blue;
            this.员工信息ToolStripMenuItem.Name = "员工信息ToolStripMenuItem";
            this.员工信息ToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
            this.员工信息ToolStripMenuItem.Text = "员工信息";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1527, 766);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.tabPages);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmMain";
            this.Text = "智慧城市生活垃圾分类系统管控平台";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.SizeChanged += new System.EventHandler(this.frmMain_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLoginInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.TabControl tabPages;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 综合信息查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 站点信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 居民信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 员工信息ToolStripMenuItem;
    }
}