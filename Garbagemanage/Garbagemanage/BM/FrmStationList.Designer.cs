namespace Garbagemanage.BM
{
    partial class FrmStationList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttRe = new System.Windows.Forms.Button();
            this.buttok = new System.Windows.Forms.Button();
            this.chkState = new System.Windows.Forms.CheckBox();
            this.txtStationAddress = new System.Windows.Forms.TextBox();
            this.txtStationName = new System.Windows.Forms.TextBox();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtmiaoshu = new System.Windows.Forms.TextBox();
            this.txtManager = new System.Windows.Forms.TextBox();
            this.txtStationNumber = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblerr = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dgvStationList = new System.Windows.Forms.DataGridView();
            this.ColChk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colStationid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coladdress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colManager = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colphone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApplyTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colState = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colDel = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colRecover = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colRemove = new System.Windows.Forms.DataGridViewLinkColumn();
            this.buttfind = new System.Windows.Forms.Button();
            this.buttRecover = new System.Windows.Forms.Button();
            this.buttRemove = new System.Windows.Forms.Button();
            this.buttDel = new System.Windows.Forms.Button();
            this.chkShowDel = new System.Windows.Forms.CheckBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.uPager1 = new Garbagemanage.UControls.UPager();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStationList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.buttRe);
            this.groupBox1.Controls.Add(this.buttok);
            this.groupBox1.Controls.Add(this.chkState);
            this.groupBox1.Controls.Add(this.txtStationAddress);
            this.groupBox1.Controls.Add(this.txtStationName);
            this.groupBox1.Controls.Add(this.txtTime);
            this.groupBox1.Controls.Add(this.txtPhone);
            this.groupBox1.Controls.Add(this.txtmiaoshu);
            this.groupBox1.Controls.Add(this.txtManager);
            this.groupBox1.Controls.Add(this.txtStationNumber);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblerr);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(12, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1107, 175);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "垃圾站点信息";
            // 
            // buttRe
            // 
            this.buttRe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttRe.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttRe.FlatAppearance.BorderSize = 0;
            this.buttRe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttRe.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttRe.ForeColor = System.Drawing.Color.White;
            this.buttRe.Location = new System.Drawing.Point(1004, 104);
            this.buttRe.Name = "buttRe";
            this.buttRe.Size = new System.Drawing.Size(62, 27);
            this.buttRe.TabIndex = 3;
            this.buttRe.Text = "重置";
            this.buttRe.UseVisualStyleBackColor = false;
            this.buttRe.Click += new System.EventHandler(this.buttRe_Click);
            // 
            // buttok
            // 
            this.buttok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttok.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttok.FlatAppearance.BorderSize = 0;
            this.buttok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttok.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttok.ForeColor = System.Drawing.Color.White;
            this.buttok.Location = new System.Drawing.Point(1004, 48);
            this.buttok.Name = "buttok";
            this.buttok.Size = new System.Drawing.Size(62, 30);
            this.buttok.TabIndex = 3;
            this.buttok.Text = "添加";
            this.buttok.UseVisualStyleBackColor = false;
            this.buttok.Click += new System.EventHandler(this.buttok_Click);
            // 
            // chkState
            // 
            this.chkState.AutoSize = true;
            this.chkState.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.chkState.Location = new System.Drawing.Point(879, 70);
            this.chkState.Name = "chkState";
            this.chkState.Size = new System.Drawing.Size(63, 21);
            this.chkState.TabIndex = 2;
            this.chkState.Text = "运行中";
            this.chkState.UseVisualStyleBackColor = true;
            // 
            // txtStationAddress
            // 
            this.txtStationAddress.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtStationAddress.Location = new System.Drawing.Point(660, 28);
            this.txtStationAddress.Name = "txtStationAddress";
            this.txtStationAddress.Size = new System.Drawing.Size(282, 23);
            this.txtStationAddress.TabIndex = 1;
            this.txtStationAddress.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TextBox_MouseDown);
            // 
            // txtStationName
            // 
            this.txtStationName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtStationName.Location = new System.Drawing.Point(368, 28);
            this.txtStationName.Name = "txtStationName";
            this.txtStationName.Size = new System.Drawing.Size(187, 23);
            this.txtStationName.TabIndex = 1;
            this.txtStationName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TextBox_MouseDown);
            // 
            // txtTime
            // 
            this.txtTime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTime.Location = new System.Drawing.Point(660, 68);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(140, 23);
            this.txtTime.TabIndex = 1;
            this.txtTime.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TextBox_MouseDown);
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPhone.Location = new System.Drawing.Point(368, 68);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(187, 23);
            this.txtPhone.TabIndex = 1;
            this.txtPhone.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TextBox_MouseDown);
            // 
            // txtmiaoshu
            // 
            this.txtmiaoshu.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtmiaoshu.Location = new System.Drawing.Point(123, 106);
            this.txtmiaoshu.Multiline = true;
            this.txtmiaoshu.Name = "txtmiaoshu";
            this.txtmiaoshu.Size = new System.Drawing.Size(432, 54);
            this.txtmiaoshu.TabIndex = 1;
            // 
            // txtManager
            // 
            this.txtManager.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtManager.Location = new System.Drawing.Point(123, 68);
            this.txtManager.Name = "txtManager";
            this.txtManager.Size = new System.Drawing.Size(140, 23);
            this.txtManager.TabIndex = 1;
            this.txtManager.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TextBox_MouseDown);
            // 
            // txtStationNumber
            // 
            this.txtStationNumber.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtStationNumber.Location = new System.Drawing.Point(123, 28);
            this.txtStationNumber.Name = "txtStationNumber";
            this.txtStationNumber.Size = new System.Drawing.Size(140, 23);
            this.txtStationNumber.TabIndex = 1;
            this.txtStationNumber.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TextBox_MouseDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(585, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "应用时间";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(817, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "当前状态";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(293, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "联系电话";
            // 
            // lblerr
            // 
            this.lblerr.AutoSize = true;
            this.lblerr.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblerr.ForeColor = System.Drawing.Color.Red;
            this.lblerr.Location = new System.Drawing.Point(646, 130);
            this.lblerr.Name = "lblerr";
            this.lblerr.Size = new System.Drawing.Size(116, 17);
            this.lblerr.TabIndex = 0;
            this.lblerr.Text = "请设置垃圾站点编码";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(23, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "垃圾站点描述";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(59, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "负责人";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(269, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "垃圾站点名称";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(561, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "垃圾站点地址";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(23, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "垃圾站点编码";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label10.Location = new System.Drawing.Point(206, 197);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 17);
            this.label10.TabIndex = 0;
            this.label10.Text = "查询关键词";
            // 
            // textBox6
            // 
            this.textBox6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox6.Location = new System.Drawing.Point(284, 194);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(288, 23);
            this.textBox6.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.Navy;
            this.label11.Location = new System.Drawing.Point(24, 195);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 19);
            this.label11.TabIndex = 0;
            this.label11.Text = "垃圾站点列表";
            // 
            // dgvStationList
            // 
            this.dgvStationList.AllowUserToAddRows = false;
            this.dgvStationList.AllowUserToDeleteRows = false;
            this.dgvStationList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStationList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStationList.BackgroundColor = System.Drawing.Color.White;
            this.dgvStationList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvStationList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStationList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStationList.ColumnHeadersHeight = 35;
            this.dgvStationList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvStationList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColChk,
            this.colStationid,
            this.colStation,
            this.colStationName,
            this.coladdress,
            this.colManager,
            this.colphone,
            this.colApplyTime,
            this.colState,
            this.colEdit,
            this.colDel,
            this.colRecover,
            this.colRemove});
            this.dgvStationList.EnableHeadersVisualStyles = false;
            this.dgvStationList.GridColor = System.Drawing.Color.LightGray;
            this.dgvStationList.Location = new System.Drawing.Point(12, 223);
            this.dgvStationList.MultiSelect = false;
            this.dgvStationList.Name = "dgvStationList";
            this.dgvStationList.RowHeadersWidth = 30;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            this.dgvStationList.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvStationList.RowTemplate.Height = 23;
            this.dgvStationList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStationList.Size = new System.Drawing.Size(1107, 316);
            this.dgvStationList.TabIndex = 2;
            this.dgvStationList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStationList_CellContentClick_1);
            // 
            // ColChk
            // 
            this.ColChk.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColChk.FillWeight = 50F;
            this.ColChk.HeaderText = "选择";
            this.ColChk.Name = "ColChk";
            this.ColChk.Width = 44;
            // 
            // colStationid
            // 
            this.colStationid.DataPropertyName = "StationId";
            this.colStationid.HeaderText = "站点编号";
            this.colStationid.Name = "colStationid";
            this.colStationid.ReadOnly = true;
            // 
            // colStation
            // 
            this.colStation.DataPropertyName = "StationNo";
            this.colStation.HeaderText = "站点编码";
            this.colStation.Name = "colStation";
            this.colStation.ReadOnly = true;
            // 
            // colStationName
            // 
            this.colStationName.DataPropertyName = "StationName";
            this.colStationName.FillWeight = 200F;
            this.colStationName.HeaderText = "垃圾站点名称";
            this.colStationName.Name = "colStationName";
            this.colStationName.ReadOnly = true;
            // 
            // coladdress
            // 
            this.coladdress.DataPropertyName = "StationAddress";
            this.coladdress.FillWeight = 200F;
            this.coladdress.HeaderText = "垃圾站点地址";
            this.coladdress.Name = "coladdress";
            this.coladdress.ReadOnly = true;
            // 
            // colManager
            // 
            this.colManager.DataPropertyName = "Manager";
            this.colManager.HeaderText = "负责人";
            this.colManager.Name = "colManager";
            this.colManager.ReadOnly = true;
            // 
            // colphone
            // 
            this.colphone.DataPropertyName = "Phone";
            this.colphone.HeaderText = "联系电话";
            this.colphone.Name = "colphone";
            this.colphone.ReadOnly = true;
            // 
            // colApplyTime
            // 
            this.colApplyTime.DataPropertyName = "ApplyTime";
            this.colApplyTime.HeaderText = "应用时间";
            this.colApplyTime.Name = "colApplyTime";
            this.colApplyTime.ReadOnly = true;
            // 
            // colState
            // 
            this.colState.DataPropertyName = "IsRunning";
            this.colState.FillWeight = 50F;
            this.colState.HeaderText = "状态";
            this.colState.Name = "colState";
            // 
            // colEdit
            // 
            this.colEdit.FillWeight = 50F;
            this.colEdit.HeaderText = "修改";
            this.colEdit.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.colEdit.Name = "colEdit";
            this.colEdit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colEdit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colEdit.Text = "修改";
            this.colEdit.TrackVisitedState = false;
            this.colEdit.UseColumnTextForLinkValue = true;
            // 
            // colDel
            // 
            this.colDel.FillWeight = 50F;
            this.colDel.HeaderText = "删除";
            this.colDel.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.colDel.Name = "colDel";
            this.colDel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colDel.Text = "删除";
            this.colDel.TrackVisitedState = false;
            this.colDel.UseColumnTextForLinkValue = true;
            // 
            // colRecover
            // 
            this.colRecover.FillWeight = 50F;
            this.colRecover.HeaderText = "恢复";
            this.colRecover.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.colRecover.Name = "colRecover";
            this.colRecover.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colRecover.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colRecover.Text = "恢复";
            this.colRecover.TrackVisitedState = false;
            this.colRecover.UseColumnTextForLinkValue = true;
            // 
            // colRemove
            // 
            this.colRemove.FillWeight = 50F;
            this.colRemove.HeaderText = "移除";
            this.colRemove.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.colRemove.Name = "colRemove";
            this.colRemove.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colRemove.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colRemove.Text = "移除";
            this.colRemove.TrackVisitedState = false;
            this.colRemove.UseColumnTextForLinkValue = true;
            // 
            // buttfind
            // 
            this.buttfind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttfind.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttfind.FlatAppearance.BorderSize = 0;
            this.buttfind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttfind.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttfind.ForeColor = System.Drawing.Color.White;
            this.buttfind.Location = new System.Drawing.Point(619, 194);
            this.buttfind.Name = "buttfind";
            this.buttfind.Size = new System.Drawing.Size(62, 23);
            this.buttfind.TabIndex = 3;
            this.buttfind.Text = "查询";
            this.buttfind.UseVisualStyleBackColor = false;
            this.buttfind.Click += new System.EventHandler(this.buttfind_Click);
            // 
            // buttRecover
            // 
            this.buttRecover.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttRecover.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttRecover.FlatAppearance.BorderSize = 0;
            this.buttRecover.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttRecover.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttRecover.ForeColor = System.Drawing.Color.White;
            this.buttRecover.Location = new System.Drawing.Point(769, 194);
            this.buttRecover.Name = "buttRecover";
            this.buttRecover.Size = new System.Drawing.Size(62, 23);
            this.buttRecover.TabIndex = 3;
            this.buttRecover.Text = "恢复";
            this.buttRecover.UseVisualStyleBackColor = false;
            this.buttRecover.Click += new System.EventHandler(this.buttRecover_Click);
            // 
            // buttRemove
            // 
            this.buttRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttRemove.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttRemove.FlatAppearance.BorderSize = 0;
            this.buttRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttRemove.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttRemove.ForeColor = System.Drawing.Color.White;
            this.buttRemove.Location = new System.Drawing.Point(851, 194);
            this.buttRemove.Name = "buttRemove";
            this.buttRemove.Size = new System.Drawing.Size(62, 23);
            this.buttRemove.TabIndex = 3;
            this.buttRemove.Text = "移除";
            this.buttRemove.UseVisualStyleBackColor = false;
            this.buttRemove.Click += new System.EventHandler(this.buttRemove_Click);
            // 
            // buttDel
            // 
            this.buttDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttDel.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttDel.FlatAppearance.BorderSize = 0;
            this.buttDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttDel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttDel.ForeColor = System.Drawing.Color.White;
            this.buttDel.Location = new System.Drawing.Point(932, 194);
            this.buttDel.Name = "buttDel";
            this.buttDel.Size = new System.Drawing.Size(62, 23);
            this.buttDel.TabIndex = 3;
            this.buttDel.Text = "删除";
            this.buttDel.UseVisualStyleBackColor = false;
            this.buttDel.Click += new System.EventHandler(this.buttDel_Click);
            // 
            // chkShowDel
            // 
            this.chkShowDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkShowDel.AutoSize = true;
            this.chkShowDel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkShowDel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.chkShowDel.Location = new System.Drawing.Point(1056, 196);
            this.chkShowDel.Name = "chkShowDel";
            this.chkShowDel.Size = new System.Drawing.Size(63, 21);
            this.chkShowDel.TabIndex = 2;
            this.chkShowDel.Text = "已删除";
            this.chkShowDel.UseVisualStyleBackColor = true;
            // 
            // uPager1
            // 
            this.uPager1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uPager1.BackColor = System.Drawing.Color.White;
            this.uPager1.CurrentPage = 1;
            this.uPager1.Location = new System.Drawing.Point(12, 537);
            this.uPager1.Name = "uPager1";
            this.uPager1.PageSize = 10;
            this.uPager1.Record = 0;
            this.uPager1.Size = new System.Drawing.Size(1107, 46);
            this.uPager1.StartIndex = 1;
            this.uPager1.TabIndex = 4;
            // 
            // FrmStationList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 581);
            this.Controls.Add(this.uPager1);
            this.Controls.Add(this.dgvStationList);
            this.Controls.Add(this.buttDel);
            this.Controls.Add(this.chkShowDel);
            this.Controls.Add(this.buttRemove);
            this.Controls.Add(this.buttRecover);
            this.Controls.Add(this.buttfind);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Name = "FrmStationList";
            this.Text = "站点管理";
            this.Load += new System.EventHandler(this.FrmStationList_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStationList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttRe;
        private System.Windows.Forms.Button buttok;
        private System.Windows.Forms.CheckBox chkState;
        private System.Windows.Forms.TextBox txtStationAddress;
        private System.Windows.Forms.TextBox txtStationName;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtmiaoshu;
        private System.Windows.Forms.TextBox txtManager;
        private System.Windows.Forms.TextBox txtStationNumber;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblerr;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dgvStationList;
        private System.Windows.Forms.Button buttfind;
        private System.Windows.Forms.Button buttRecover;
        private System.Windows.Forms.Button buttRemove;
        private System.Windows.Forms.Button buttDel;
        private System.Windows.Forms.CheckBox chkShowDel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColChk;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStationid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn coladdress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colManager;
        private System.Windows.Forms.DataGridViewTextBoxColumn colphone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApplyTime;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colState;
        private System.Windows.Forms.DataGridViewLinkColumn colEdit;
        private System.Windows.Forms.DataGridViewLinkColumn colDel;
        private System.Windows.Forms.DataGridViewLinkColumn colRecover;
        private System.Windows.Forms.DataGridViewLinkColumn colRemove;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private UControls.UPager uPager1;
    }
}