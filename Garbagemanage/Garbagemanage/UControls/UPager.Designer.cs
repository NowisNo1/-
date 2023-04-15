namespace Garbagemanage.UControls
{
    partial class UPager
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtPage = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.AutoSize = true;
            this.lblPageInfo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPageInfo.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblPageInfo.Location = new System.Drawing.Point(14, 14);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(192, 17);
            this.lblPageInfo.TabIndex = 0;
            this.lblPageInfo.Text = "共40条记录，共4页，当前是第2页";
            // 
            // btnFirst
            // 
            this.btnFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFirst.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnFirst.FlatAppearance.BorderSize = 0;
            this.btnFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFirst.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFirst.ForeColor = System.Drawing.Color.White;
            this.btnFirst.Location = new System.Drawing.Point(314, 8);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(48, 30);
            this.btnFirst.TabIndex = 1;
            this.btnFirst.Text = "<<";
            this.btnFirst.UseVisualStyleBackColor = false;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrev.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnPrev.FlatAppearance.BorderSize = 0;
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrev.ForeColor = System.Drawing.Color.White;
            this.btnPrev.Location = new System.Drawing.Point(381, 8);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(48, 30);
            this.btnPrev.TabIndex = 1;
            this.btnPrev.Text = "<";
            this.btnPrev.UseVisualStyleBackColor = false;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(446, 8);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(48, 30);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnLast
            // 
            this.btnLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLast.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnLast.FlatAppearance.BorderSize = 0;
            this.btnLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLast.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLast.ForeColor = System.Drawing.Color.White;
            this.btnLast.Location = new System.Drawing.Point(514, 8);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(48, 30);
            this.btnLast.TabIndex = 1;
            this.btnLast.Text = ">>";
            this.btnLast.UseVisualStyleBackColor = false;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnGo.FlatAppearance.BorderSize = 0;
            this.btnGo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnGo.ForeColor = System.Drawing.Color.White;
            this.btnGo.Location = new System.Drawing.Point(733, 8);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(71, 30);
            this.btnGo.TabIndex = 1;
            this.btnGo.Text = "转到";
            this.btnGo.UseVisualStyleBackColor = false;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtPage
            // 
            this.txtPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPage.Location = new System.Drawing.Point(610, 11);
            this.txtPage.Name = "txtPage";
            this.txtPage.Size = new System.Drawing.Size(100, 23);
            this.txtPage.TabIndex = 2;
            // 
            // UPager
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.txtPage);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.lblPageInfo);
            this.Name = "UPager";
            this.Size = new System.Drawing.Size(834, 46);
            this.Load += new System.EventHandler(this.UPager_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPageInfo;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtPage;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
