namespace SenderUsersOnFrontol
{
    partial class frmSendData
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btClose = new System.Windows.Forms.Button();
            this.btSend = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.rbSelected = new System.Windows.Forms.RadioButton();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.dgvTerminal = new System.Windows.Forms.DataGridView();
            this.chbDelOldUser = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTerminalType = new System.Windows.Forms.ComboBox();
            this.cIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTerminal)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.Image = global::SenderUsersOnFrontol.Properties.Resources.door_out;
            this.btClose.Location = new System.Drawing.Point(500, 441);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(32, 32);
            this.btClose.TabIndex = 10;
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btSend
            // 
            this.btSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSend.Image = global::SenderUsersOnFrontol.Properties.Resources.Select;
            this.btSend.Location = new System.Drawing.Point(462, 441);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(32, 32);
            this.btSend.TabIndex = 10;
            this.btSend.UseVisualStyleBackColor = true;
            this.btSend.Click += new System.EventHandler(this.btSend_MouseClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.rbSelected);
            this.groupBox1.Controls.Add(this.rbAll);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(103, 52);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Тип передачи";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(19, 24);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(61, 17);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "На все";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckStateChanged += new System.EventHandler(this.CheckBox1_CheckStateChanged);
            this.checkBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CheckBox1_MouseClick);
            // 
            // rbSelected
            // 
            this.rbSelected.AutoSize = true;
            this.rbSelected.Location = new System.Drawing.Point(307, 31);
            this.rbSelected.Name = "rbSelected";
            this.rbSelected.Size = new System.Drawing.Size(100, 17);
            this.rbSelected.TabIndex = 0;
            this.rbSelected.Text = "На выбранные";
            this.rbSelected.UseVisualStyleBackColor = true;
            this.rbSelected.Visible = false;
            this.rbSelected.CheckedChanged += new System.EventHandler(this.rbSelected_CheckedChanged);
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Checked = true;
            this.rbAll.Location = new System.Drawing.Point(197, 31);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(95, 17);
            this.rbAll.TabIndex = 0;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "На все кассы";
            this.rbAll.UseVisualStyleBackColor = true;
            this.rbAll.Visible = false;
            // 
            // dgvTerminal
            // 
            this.dgvTerminal.AllowUserToAddRows = false;
            this.dgvTerminal.AllowUserToDeleteRows = false;
            this.dgvTerminal.AllowUserToResizeRows = false;
            this.dgvTerminal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTerminal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTerminal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTerminal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cIP,
            this.cNumber,
            this.cType,
            this.cSelected});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTerminal.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTerminal.Location = new System.Drawing.Point(12, 105);
            this.dgvTerminal.MultiSelect = false;
            this.dgvTerminal.Name = "dgvTerminal";
            this.dgvTerminal.ReadOnly = true;
            this.dgvTerminal.RowHeadersVisible = false;
            this.dgvTerminal.Size = new System.Drawing.Size(520, 323);
            this.dgvTerminal.TabIndex = 12;
            this.dgvTerminal.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTerminal_CellContentClick);
            // 
            // chbDelOldUser
            // 
            this.chbDelOldUser.AutoSize = true;
            this.chbDelOldUser.Location = new System.Drawing.Point(6, 24);
            this.chbDelOldUser.Name = "chbDelOldUser";
            this.chbDelOldUser.Size = new System.Drawing.Size(188, 17);
            this.chbDelOldUser.TabIndex = 20;
            this.chbDelOldUser.Text = "Удалить старых пользователей";
            this.chbDelOldUser.UseVisualStyleBackColor = true;
            this.chbDelOldUser.Click += new System.EventHandler(this.chbDelOldUser_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chbDelOldUser);
            this.groupBox2.Location = new System.Drawing.Point(121, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(210, 52);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Опции";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Тип кассы";
            // 
            // cmbTerminalType
            // 
            this.cmbTerminalType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTerminalType.FormattingEnabled = true;
            this.cmbTerminalType.Location = new System.Drawing.Point(121, 72);
            this.cmbTerminalType.Name = "cmbTerminalType";
            this.cmbTerminalType.Size = new System.Drawing.Size(210, 21);
            this.cmbTerminalType.TabIndex = 19;
            this.cmbTerminalType.SelectionChangeCommitted += new System.EventHandler(this.cmbTerminalType_SelectionChangeCommitted);
            // 
            // cIP
            // 
            this.cIP.DataPropertyName = "IP";
            this.cIP.HeaderText = "IP-адресс";
            this.cIP.Name = "cIP";
            this.cIP.ReadOnly = true;
            // 
            // cNumber
            // 
            this.cNumber.DataPropertyName = "Number";
            this.cNumber.HeaderText = "Номер кассы";
            this.cNumber.Name = "cNumber";
            this.cNumber.ReadOnly = true;
            // 
            // cType
            // 
            this.cType.DataPropertyName = "NameTerminalType";
            this.cType.HeaderText = "Тип кассы";
            this.cType.Name = "cType";
            this.cType.ReadOnly = true;
            // 
            // cSelected
            // 
            this.cSelected.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cSelected.DataPropertyName = "isUsed";
            this.cSelected.HeaderText = "V";
            this.cSelected.MinimumWidth = 45;
            this.cSelected.Name = "cSelected";
            this.cSelected.ReadOnly = true;
            this.cSelected.ThreeState = true;
            this.cSelected.Width = 45;
            // 
            // frmSendData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 485);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbTerminalType);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgvTerminal);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btSend);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSendData";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отправка пользователей";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTerminal)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btSend;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbSelected;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.DataGridView dgvTerminal;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox chbDelOldUser;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbTerminalType;
        private System.Windows.Forms.DataGridViewTextBoxColumn cIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn cType;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cSelected;
    }
}