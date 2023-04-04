namespace Garbagemanage.User
{
    partial class FrmSpecialList
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
            this.txtmiaoshu = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.buttRe = new System.Windows.Forms.Button();
            this.buttok = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtStationAddress = new System.Windows.Forms.TextBox();
            this.txtStationName = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtManager = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtStationNumber = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblerr = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvStationList = new System.Windows.Forms.DataGridView();
            this.ColChk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colSpeNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSPeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSpeIDnumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colphone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSpecialVillage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSpeAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNewThrow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colDel = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colRecover = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colRemove = new System.Windows.Forms.DataGridViewLinkColumn();
            this.buttDel = new System.Windows.Forms.Button();
            this.chkShowDel = new System.Windows.Forms.CheckBox();
            this.buttRemove = new System.Windows.Forms.Button();
            this.buttRecover = new System.Windows.Forms.Button();
            this.buttfind = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStationList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtmiaoshu);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.buttRe);
            this.groupBox1.Controls.Add(this.buttok);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.txtStationAddress);
            this.groupBox1.Controls.Add(this.txtStationName);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.txtTime);
            this.groupBox1.Controls.Add(this.txtPhone);
            this.groupBox1.Controls.Add(this.txtManager);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtStationNumber);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblerr);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(12, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1107, 176);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "特殊人群信息";
            // 
            // txtmiaoshu
            // 
            this.txtmiaoshu.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtmiaoshu.Location = new System.Drawing.Point(368, 108);
            this.txtmiaoshu.Multiline = true;
            this.txtmiaoshu.Name = "txtmiaoshu";
            this.txtmiaoshu.Size = new System.Drawing.Size(432, 54);
            this.txtmiaoshu.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(282, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 17);
            this.label7.TabIndex = 4;
            this.label7.Text = "垃圾站点描述";
            // 
            // buttRe
            // 
            this.buttRe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttRe.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttRe.FlatAppearance.BorderSize = 0;
            this.buttRe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttRe.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttRe.ForeColor = System.Drawing.Color.White;
            this.buttRe.Location = new System.Drawing.Point(973, 91);
            this.buttRe.Name = "buttRe";
            this.buttRe.Size = new System.Drawing.Size(62, 27);
            this.buttRe.TabIndex = 3;
            this.buttRe.Text = "重置";
            this.buttRe.UseVisualStyleBackColor = false;
            // 
            // buttok
            // 
            this.buttok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttok.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttok.FlatAppearance.BorderSize = 0;
            this.buttok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttok.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttok.ForeColor = System.Drawing.Color.White;
            this.buttok.Location = new System.Drawing.Point(973, 35);
            this.buttok.Name = "buttok";
            this.buttok.Size = new System.Drawing.Size(62, 30);
            this.buttok.TabIndex = 3;
            this.buttok.Text = "添加";
            this.buttok.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(605, 66);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(53, 23);
            this.textBox1.TabIndex = 1;
            // 
            // txtStationAddress
            // 
            this.txtStationAddress.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtStationAddress.Location = new System.Drawing.Point(605, 27);
            this.txtStationAddress.Name = "txtStationAddress";
            this.txtStationAddress.Size = new System.Drawing.Size(53, 23);
            this.txtStationAddress.TabIndex = 1;
            // 
            // txtStationName
            // 
            this.txtStationName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtStationName.Location = new System.Drawing.Point(368, 27);
            this.txtStationName.Name = "txtStationName";
            this.txtStationName.Size = new System.Drawing.Size(187, 23);
            this.txtStationName.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox2.Location = new System.Drawing.Point(735, 24);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(140, 23);
            this.textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox3.Location = new System.Drawing.Point(123, 108);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(140, 23);
            this.textBox3.TabIndex = 1;
            // 
            // txtTime
            // 
            this.txtTime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTime.Location = new System.Drawing.Point(735, 66);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(140, 23);
            this.txtTime.TabIndex = 1;
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPhone.Location = new System.Drawing.Point(368, 66);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(187, 23);
            this.txtPhone.TabIndex = 1;
            // 
            // txtManager
            // 
            this.txtManager.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtManager.Location = new System.Drawing.Point(123, 66);
            this.txtManager.Name = "txtManager";
            this.txtManager.Size = new System.Drawing.Size(140, 23);
            this.txtManager.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label10.Location = new System.Drawing.Point(673, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 17);
            this.label10.TabIndex = 0;
            this.label10.Text = "所在小区";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(35, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "最新投放时间";
            // 
            // txtStationNumber
            // 
            this.txtStationNumber.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtStationNumber.Location = new System.Drawing.Point(123, 24);
            this.txtStationNumber.Name = "txtStationNumber";
            this.txtStationNumber.Size = new System.Drawing.Size(140, 23);
            this.txtStationNumber.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(697, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "住址";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(306, 69);
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
            this.lblerr.Location = new System.Drawing.Point(816, 125);
            this.lblerr.Name = "lblerr";
            this.lblerr.Size = new System.Drawing.Size(116, 17);
            this.lblerr.TabIndex = 0;
            this.lblerr.Text = "请设置垃圾站点编码";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(59, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "身份证号";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(567, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 17);
            this.label9.TabIndex = 0;
            this.label9.Text = "年龄";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(330, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "姓名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(567, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "性别";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(45, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "人员标签ID";
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
            this.colSpeNo,
            this.colSPeName,
            this.colSex,
            this.colAge,
            this.colSpeIDnumber,
            this.colphone,
            this.colSpecialVillage,
            this.colSpeAddress,
            this.colNewThrow,
            this.colRemark,
            this.colEdit,
            this.colDel,
            this.colRecover,
            this.colRemove});
            this.dgvStationList.EnableHeadersVisualStyles = false;
            this.dgvStationList.GridColor = System.Drawing.Color.LightGray;
            this.dgvStationList.Location = new System.Drawing.Point(12, 227);
            this.dgvStationList.MultiSelect = false;
            this.dgvStationList.Name = "dgvStationList";
            this.dgvStationList.RowHeadersWidth = 30;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            this.dgvStationList.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvStationList.RowTemplate.Height = 23;
            this.dgvStationList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStationList.Size = new System.Drawing.Size(1107, 299);
            this.dgvStationList.TabIndex = 7;
            // 
            // ColChk
            // 
            this.ColChk.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColChk.HeaderText = "选择";
            this.ColChk.Name = "ColChk";
            this.ColChk.Width = 44;
            // 
            // colSpeNo
            // 
            this.colSpeNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colSpeNo.HeaderText = "人员标签ID";
            this.colSpeNo.Name = "colSpeNo";
            this.colSpeNo.ReadOnly = true;
            this.colSpeNo.Width = 89;
            // 
            // colSPeName
            // 
            this.colSPeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colSPeName.HeaderText = "姓名";
            this.colSPeName.Name = "colSPeName";
            this.colSPeName.ReadOnly = true;
            this.colSPeName.Width = 60;
            // 
            // colSex
            // 
            this.colSex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colSex.FillWeight = 200F;
            this.colSex.HeaderText = "性别";
            this.colSex.Name = "colSex";
            this.colSex.ReadOnly = true;
            this.colSex.Width = 50;
            // 
            // colAge
            // 
            this.colAge.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colAge.FillWeight = 200F;
            this.colAge.HeaderText = "年龄";
            this.colAge.Name = "colAge";
            this.colAge.ReadOnly = true;
            this.colAge.Width = 50;
            // 
            // colSpeIDnumber
            // 
            this.colSpeIDnumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colSpeIDnumber.HeaderText = "身份证号";
            this.colSpeIDnumber.Name = "colSpeIDnumber";
            this.colSpeIDnumber.ReadOnly = true;
            // 
            // colphone
            // 
            this.colphone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colphone.HeaderText = "联系电话";
            this.colphone.Name = "colphone";
            this.colphone.ReadOnly = true;
            // 
            // colSpecialVillage
            // 
            this.colSpecialVillage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colSpecialVillage.HeaderText = "所在小区";
            this.colSpecialVillage.Name = "colSpecialVillage";
            // 
            // colSpeAddress
            // 
            this.colSpeAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colSpeAddress.HeaderText = "住址";
            this.colSpeAddress.Name = "colSpeAddress";
            // 
            // colNewThrow
            // 
            this.colNewThrow.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colNewThrow.HeaderText = "最新投放时间";
            this.colNewThrow.Name = "colNewThrow";
            this.colNewThrow.ReadOnly = true;
            // 
            // colRemark
            // 
            this.colRemark.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colRemark.HeaderText = "描述";
            this.colRemark.Name = "colRemark";
            // 
            // colEdit
            // 
            this.colEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colEdit.FillWeight = 50F;
            this.colEdit.HeaderText = "修改";
            this.colEdit.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.colEdit.Name = "colEdit";
            this.colEdit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colEdit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colEdit.Text = "修改";
            this.colEdit.TrackVisitedState = false;
            this.colEdit.UseColumnTextForLinkValue = true;
            this.colEdit.Width = 45;
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
            // buttDel
            // 
            this.buttDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttDel.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttDel.FlatAppearance.BorderSize = 0;
            this.buttDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttDel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttDel.ForeColor = System.Drawing.Color.White;
            this.buttDel.Location = new System.Drawing.Point(932, 196);
            this.buttDel.Name = "buttDel";
            this.buttDel.Size = new System.Drawing.Size(62, 23);
            this.buttDel.TabIndex = 9;
            this.buttDel.Text = "删除";
            this.buttDel.UseVisualStyleBackColor = false;
            // 
            // chkShowDel
            // 
            this.chkShowDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkShowDel.AutoSize = true;
            this.chkShowDel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkShowDel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.chkShowDel.Location = new System.Drawing.Point(1056, 198);
            this.chkShowDel.Name = "chkShowDel";
            this.chkShowDel.Size = new System.Drawing.Size(63, 21);
            this.chkShowDel.TabIndex = 8;
            this.chkShowDel.Text = "已删除";
            this.chkShowDel.UseVisualStyleBackColor = true;
            // 
            // buttRemove
            // 
            this.buttRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttRemove.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttRemove.FlatAppearance.BorderSize = 0;
            this.buttRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttRemove.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttRemove.ForeColor = System.Drawing.Color.White;
            this.buttRemove.Location = new System.Drawing.Point(851, 196);
            this.buttRemove.Name = "buttRemove";
            this.buttRemove.Size = new System.Drawing.Size(62, 23);
            this.buttRemove.TabIndex = 10;
            this.buttRemove.Text = "移除";
            this.buttRemove.UseVisualStyleBackColor = false;
            // 
            // buttRecover
            // 
            this.buttRecover.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttRecover.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttRecover.FlatAppearance.BorderSize = 0;
            this.buttRecover.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttRecover.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttRecover.ForeColor = System.Drawing.Color.White;
            this.buttRecover.Location = new System.Drawing.Point(769, 196);
            this.buttRecover.Name = "buttRecover";
            this.buttRecover.Size = new System.Drawing.Size(62, 23);
            this.buttRecover.TabIndex = 11;
            this.buttRecover.Text = "恢复";
            this.buttRecover.UseVisualStyleBackColor = false;
            // 
            // buttfind
            // 
            this.buttfind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttfind.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttfind.FlatAppearance.BorderSize = 0;
            this.buttfind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttfind.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttfind.ForeColor = System.Drawing.Color.White;
            this.buttfind.Location = new System.Drawing.Point(619, 196);
            this.buttfind.Name = "buttfind";
            this.buttfind.Size = new System.Drawing.Size(62, 23);
            this.buttfind.TabIndex = 12;
            this.buttfind.Text = "查询";
            this.buttfind.UseVisualStyleBackColor = false;
            // 
            // textBox6
            // 
            this.textBox6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox6.Location = new System.Drawing.Point(284, 196);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(288, 23);
            this.textBox6.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.Navy;
            this.label11.Location = new System.Drawing.Point(24, 197);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(121, 19);
            this.label11.TabIndex = 4;
            this.label11.Text = "特殊人群信息列表";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label12.Location = new System.Drawing.Point(206, 199);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 17);
            this.label12.TabIndex = 5;
            this.label12.Text = "查询关键词";
            
            
            // 
            // FrmSpecialList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 581);
            this.Controls.Add(this.dgvStationList);
            this.Controls.Add(this.buttDel);
            this.Controls.Add(this.chkShowDel);
            this.Controls.Add(this.buttRemove);
            this.Controls.Add(this.buttRecover);
            this.Controls.Add(this.buttfind);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmSpecialList";
            this.Text = "特殊人群信息";
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtStationAddress;
        private System.Windows.Forms.TextBox txtStationName;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtManager;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtStationNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblerr;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtmiaoshu;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvStationList;
        private System.Windows.Forms.Button buttDel;
        private System.Windows.Forms.CheckBox chkShowDel;
        private System.Windows.Forms.Button buttRemove;
        private System.Windows.Forms.Button buttRecover;
        private System.Windows.Forms.Button buttfind;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColChk;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSpeNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSPeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSex;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAge;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSpeIDnumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colphone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSpecialVillage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSpeAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNewThrow;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemark;
        private System.Windows.Forms.DataGridViewLinkColumn colEdit;
        private System.Windows.Forms.DataGridViewLinkColumn colDel;
        private System.Windows.Forms.DataGridViewLinkColumn colRecover;
        private System.Windows.Forms.DataGridViewLinkColumn colRemove;
    }
}