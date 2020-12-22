﻿namespace xPosRealiz
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.rtbSprav = new System.Windows.Forms.RichTextBox();
            this.lblSprav = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.bwSparv = new System.ComponentModel.BackgroundWorker();
            this.lTimeTickUpdate = new System.Windows.Forms.Label();
            this.btStartTimer = new System.Windows.Forms.Button();
            this.btStopTimer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDelay = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btSetDelay = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTerminalType = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvGoods = new System.Windows.Forms.DataGridView();
            this.cNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cLastId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDateGoodSend = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cLastIdInBase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cV = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoods)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rtbSprav);
            this.panel1.Controls.Add(this.lblSprav);
            this.panel1.Location = new System.Drawing.Point(16, 285);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(114, 206);
            this.panel1.TabIndex = 2;
            this.panel1.Visible = false;
            // 
            // rtbSprav
            // 
            this.rtbSprav.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbSprav.Location = new System.Drawing.Point(3, 74);
            this.rtbSprav.Name = "rtbSprav";
            this.rtbSprav.Size = new System.Drawing.Size(106, 118);
            this.rtbSprav.TabIndex = 8;
            this.rtbSprav.Text = "";
            // 
            // lblSprav
            // 
            this.lblSprav.AutoSize = true;
            this.lblSprav.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSprav.Location = new System.Drawing.Point(71, 6);
            this.lblSprav.Name = "lblSprav";
            this.lblSprav.Size = new System.Drawing.Size(168, 17);
            this.lblSprav.TabIndex = 6;
            this.lblSprav.Text = "Справочник с обувью";
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(16, 9);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(114, 42);
            this.btnCreate.TabIndex = 7;
            this.btnCreate.Text = "Выгрузить полный справочник";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // bwSparv
            // 
            this.bwSparv.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwSparv_DoWork);
            this.bwSparv.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwSparv_RunWorkerCompleted);
            // 
            // lTimeTickUpdate
            // 
            this.lTimeTickUpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lTimeTickUpdate.Location = new System.Drawing.Point(16, 56);
            this.lTimeTickUpdate.Name = "lTimeTickUpdate";
            this.lTimeTickUpdate.Size = new System.Drawing.Size(114, 30);
            this.lTimeTickUpdate.TabIndex = 11;
            this.lTimeTickUpdate.Text = "До обновления:\r\n11:11:11";
            this.lTimeTickUpdate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btStartTimer
            // 
            this.btStartTimer.Enabled = false;
            this.btStartTimer.Location = new System.Drawing.Point(33, 119);
            this.btStartTimer.Name = "btStartTimer";
            this.btStartTimer.Size = new System.Drawing.Size(81, 23);
            this.btStartTimer.TabIndex = 12;
            this.btStartTimer.Text = "Возобновить";
            this.btStartTimer.UseVisualStyleBackColor = true;
            this.btStartTimer.Click += new System.EventHandler(this.btStartTimer_Click);
            // 
            // btStopTimer
            // 
            this.btStopTimer.Location = new System.Drawing.Point(33, 91);
            this.btStopTimer.Name = "btStopTimer";
            this.btStopTimer.Size = new System.Drawing.Size(81, 23);
            this.btStopTimer.TabIndex = 11;
            this.btStopTimer.Text = "Остановить";
            this.btStopTimer.UseVisualStyleBackColor = true;
            this.btStopTimer.Click += new System.EventHandler(this.btStopTimer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(150, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Период обновления";
            // 
            // tbDelay
            // 
            this.tbDelay.Location = new System.Drawing.Point(150, 31);
            this.tbDelay.Name = "tbDelay";
            this.tbDelay.Size = new System.Drawing.Size(52, 20);
            this.tbDelay.TabIndex = 14;
            this.tbDelay.Text = "60";
            this.tbDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbDelay.TextChanged += new System.EventHandler(this.tbDelay_TextChanged);
            this.tbDelay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDelay_KeyPress);
            this.tbDelay.Leave += new System.EventHandler(this.tbDelay_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "сек.";
            // 
            // btSetDelay
            // 
            this.btSetDelay.Location = new System.Drawing.Point(261, 10);
            this.btSetDelay.Name = "btSetDelay";
            this.btSetDelay.Size = new System.Drawing.Size(99, 41);
            this.btSetDelay.TabIndex = 15;
            this.btSetDelay.Text = "Установить";
            this.btSetDelay.UseVisualStyleBackColor = true;
            this.btSetDelay.Click += new System.EventHandler(this.btSetDelay_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(471, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Тип кассы";
            // 
            // cmbTerminalType
            // 
            this.cmbTerminalType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTerminalType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTerminalType.FormattingEnabled = true;
            this.cmbTerminalType.Location = new System.Drawing.Point(538, 10);
            this.cmbTerminalType.Name = "cmbTerminalType";
            this.cmbTerminalType.Size = new System.Drawing.Size(239, 21);
            this.cmbTerminalType.TabIndex = 23;
            this.cmbTerminalType.SelectionChangeCommitted += new System.EventHandler(this.cmbTerminalType_SelectionChangeCommitted);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvGoods);
            this.groupBox1.Location = new System.Drawing.Point(152, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(623, 563);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Товары на кассах";
            // 
            // dgvGoods
            // 
            this.dgvGoods.AllowUserToAddRows = false;
            this.dgvGoods.AllowUserToDeleteRows = false;
            this.dgvGoods.AllowUserToResizeRows = false;
            this.dgvGoods.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGoods.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGoods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGoods.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cNum,
            this.cType,
            this.cLastId,
            this.cDateGoodSend,
            this.cLastIdInBase,
            this.cV});
            this.dgvGoods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGoods.Location = new System.Drawing.Point(3, 16);
            this.dgvGoods.MultiSelect = false;
            this.dgvGoods.Name = "dgvGoods";
            this.dgvGoods.RowHeadersVisible = false;
            this.dgvGoods.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGoods.Size = new System.Drawing.Size(617, 544);
            this.dgvGoods.TabIndex = 0;
            this.dgvGoods.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGoods_CellContentClick);
            this.dgvGoods.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGoods_CellEndEdit);
            this.dgvGoods.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGoods_CellValueChanged);
            this.dgvGoods.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvGoods_ColumnHeaderMouseDoubleClick);
            this.dgvGoods.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvGoods_RowPostPaint);
            this.dgvGoods.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvGoods_RowPrePaint);
            // 
            // cNum
            // 
            this.cNum.DataPropertyName = "Number";
            this.cNum.HeaderText = "Номер кассы";
            this.cNum.Name = "cNum";
            this.cNum.ReadOnly = true;
            // 
            // cType
            // 
            this.cType.DataPropertyName = "NameTerminalType";
            this.cType.HeaderText = "Тип касс";
            this.cType.Name = "cType";
            this.cType.ReadOnly = true;
            // 
            // cLastId
            // 
            this.cLastId.DataPropertyName = "id_gu";
            this.cLastId.HeaderText = "Id последнего товара на кассе";
            this.cLastId.Name = "cLastId";
            this.cLastId.ReadOnly = true;
            // 
            // cDateGoodSend
            // 
            this.cDateGoodSend.DataPropertyName = "DateGoodsSend";
            this.cDateGoodSend.HeaderText = "Дата последней успешной отправки";
            this.cDateGoodSend.Name = "cDateGoodSend";
            this.cDateGoodSend.ReadOnly = true;
            // 
            // cLastIdInBase
            // 
            this.cLastIdInBase.DataPropertyName = "last_id_gu";
            this.cLastIdInBase.HeaderText = "ID последнего товара в БД";
            this.cLastIdInBase.Name = "cLastIdInBase";
            this.cLastIdInBase.ReadOnly = true;
            // 
            // cV
            // 
            this.cV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cV.DataPropertyName = "isSelect";
            this.cV.HeaderText = "V";
            this.cV.MinimumWidth = 45;
            this.cV.Name = "cV";
            this.cV.Width = 45;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(8, 601);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(17, 17);
            this.panel2.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 603);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Не отправлено";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 635);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbTerminalType);
            this.Controls.Add(this.btSetDelay);
            this.Controls.Add(this.tbDelay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btStartTimer);
            this.Controls.Add(this.lTimeTickUpdate);
            this.Controls.Add(this.btStopTimer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCreate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(530, 10);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справочники";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoods)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSprav;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.RichTextBox rtbSprav;
        private System.ComponentModel.BackgroundWorker bwSparv;
        private System.Windows.Forms.Label lTimeTickUpdate;
        private System.Windows.Forms.Button btStartTimer;
        private System.Windows.Forms.Button btStopTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDelay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btSetDelay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTerminalType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvGoods;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn cType;
        private System.Windows.Forms.DataGridViewTextBoxColumn cLastId;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDateGoodSend;
        private System.Windows.Forms.DataGridViewTextBoxColumn cLastIdInBase;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cV;
    }
}

