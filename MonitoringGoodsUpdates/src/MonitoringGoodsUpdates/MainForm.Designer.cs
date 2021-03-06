﻿namespace MonitoringGoodsUpdates
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.cbOnline = new System.Windows.Forms.CheckBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dgvMonitoring = new System.Windows.Forms.DataGridView();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlSending = new System.Windows.Forms.Panel();
            this.pnlSent = new System.Windows.Forms.Panel();
            this.pnlError = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvTerminals = new System.Windows.Forms.DataGridView();
            this.terminal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTypeTerminal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time_update = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_status_terminal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.timer_message = new System.Windows.Forms.Timer(this.components);
            this.btnPrint = new System.Windows.Forms.Button();
            this.id_goods_updates = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dep_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ean = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.old_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.not_sent_terminals = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time_send = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_departments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonitoring)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTerminals)).BeginInit();
            this.SuspendLayout();
            // 
            // cbOnline
            // 
            this.cbOnline.AutoSize = true;
            this.cbOnline.Location = new System.Drawing.Point(656, 9);
            this.cbOnline.Name = "cbOnline";
            this.cbOnline.Size = new System.Drawing.Size(250, 17);
            this.cbOnline.TabIndex = 45;
            this.cbOnline.Text = "обновлять автоматически каждые 10 минут";
            this.cbOnline.UseVisualStyleBackColor = true;
            this.cbOnline.CheckedChanged += new System.EventHandler(this.cbOnline_CheckedChanged);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(893, 595);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(108, 23);
            this.btnExit.TabIndex = 44;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(779, 595);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(108, 23);
            this.btnRefresh.TabIndex = 43;
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dgvMonitoring
            // 
            this.dgvMonitoring.AllowUserToAddRows = false;
            this.dgvMonitoring.AllowUserToDeleteRows = false;
            this.dgvMonitoring.AllowUserToResizeRows = false;
            this.dgvMonitoring.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMonitoring.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMonitoring.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMonitoring.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMonitoring.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_goods_updates,
            this.dep_name,
            this.ean,
            this.name,
            this.old_price,
            this.price,
            this.not_sent_terminals,
            this.time_send,
            this.id_status,
            this.id_departments});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMonitoring.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvMonitoring.Location = new System.Drawing.Point(8, 35);
            this.dgvMonitoring.Name = "dgvMonitoring";
            this.dgvMonitoring.ReadOnly = true;
            this.dgvMonitoring.RowHeadersVisible = false;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvMonitoring.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvMonitoring.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMonitoring.Size = new System.Drawing.Size(659, 549);
            this.dgvMonitoring.TabIndex = 42;
            this.dgvMonitoring.CurrentCellChanged += new System.EventHandler(this.dgvMonitoring_CurrentCellChanged);
            this.dgvMonitoring.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvPrices_RowPostPaint);
            this.dgvMonitoring.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvPrices_RowPrePaint);
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(47, 9);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(125, 20);
            this.dtpDate.TabIndex = 41;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "Дата:";
            // 
            // pnlSending
            // 
            this.pnlSending.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pnlSending.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSending.Location = new System.Drawing.Point(8, 599);
            this.pnlSending.Name = "pnlSending";
            this.pnlSending.Size = new System.Drawing.Size(14, 14);
            this.pnlSending.TabIndex = 46;
            // 
            // pnlSent
            // 
            this.pnlSent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pnlSent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSent.Location = new System.Drawing.Point(114, 599);
            this.pnlSent.Name = "pnlSent";
            this.pnlSent.Size = new System.Drawing.Size(14, 14);
            this.pnlSent.TabIndex = 47;
            // 
            // pnlError
            // 
            this.pnlError.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pnlError.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlError.Location = new System.Drawing.Point(279, 599);
            this.pnlError.Name = "pnlError";
            this.pnlError.Size = new System.Drawing.Size(14, 14);
            this.pnlError.TabIndex = 48;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 600);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "в процессе";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(134, 600);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 50;
            this.label3.Text = "отправлено на кассы";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(299, 600);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 51;
            this.label4.Text = "ошибка";
            // 
            // dgvTerminals
            // 
            this.dgvTerminals.AllowUserToAddRows = false;
            this.dgvTerminals.AllowUserToDeleteRows = false;
            this.dgvTerminals.AllowUserToResizeRows = false;
            this.dgvTerminals.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTerminals.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTerminals.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvTerminals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTerminals.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.terminal,
            this.cTypeTerminal,
            this.time_update,
            this.comment,
            this.id_status_terminal});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTerminals.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvTerminals.Location = new System.Drawing.Point(673, 35);
            this.dgvTerminals.Name = "dgvTerminals";
            this.dgvTerminals.ReadOnly = true;
            this.dgvTerminals.RowHeadersVisible = false;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvTerminals.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvTerminals.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTerminals.Size = new System.Drawing.Size(328, 549);
            this.dgvTerminals.TabIndex = 52;
            this.dgvTerminals.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvTerminals_RowPostPaint);
            this.dgvTerminals.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvTerminals_RowPrePaint);
            // 
            // terminal
            // 
            this.terminal.DataPropertyName = "terminal";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.terminal.DefaultCellStyle = dataGridViewCellStyle9;
            this.terminal.HeaderText = "Касса";
            this.terminal.Name = "terminal";
            this.terminal.ReadOnly = true;
            // 
            // cTypeTerminal
            // 
            this.cTypeTerminal.DataPropertyName = "NameType";
            this.cTypeTerminal.HeaderText = "Тип кассы";
            this.cTypeTerminal.Name = "cTypeTerminal";
            this.cTypeTerminal.ReadOnly = true;
            // 
            // time_update
            // 
            this.time_update.DataPropertyName = "time_update";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.time_update.DefaultCellStyle = dataGridViewCellStyle10;
            this.time_update.HeaderText = "Время получения данных";
            this.time_update.Name = "time_update";
            this.time_update.ReadOnly = true;
            // 
            // comment
            // 
            this.comment.DataPropertyName = "comment";
            this.comment.HeaderText = "Комментарий";
            this.comment.Name = "comment";
            this.comment.ReadOnly = true;
            this.comment.Visible = false;
            // 
            // id_status_terminal
            // 
            this.id_status_terminal.DataPropertyName = "id_status";
            this.id_status_terminal.HeaderText = "id_status_terminal";
            this.id_status_terminal.Name = "id_status_terminal";
            this.id_status_terminal.ReadOnly = true;
            this.id_status_terminal.Visible = false;
            // 
            // timer
            // 
            this.timer.Interval = 600000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // timer_message
            // 
            this.timer_message.Interval = 600000;
            this.timer_message.Tick += new System.EventHandler(this.timer_message_Tick);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(654, 595);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(108, 23);
            this.btnPrint.TabIndex = 53;
            this.btnPrint.Text = "В Excel";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // id_goods_updates
            // 
            this.id_goods_updates.DataPropertyName = "id_goods_updates";
            this.id_goods_updates.HeaderText = "id_goods_updates";
            this.id_goods_updates.Name = "id_goods_updates";
            this.id_goods_updates.ReadOnly = true;
            this.id_goods_updates.Visible = false;
            // 
            // dep_name
            // 
            this.dep_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dep_name.DataPropertyName = "dep_name";
            this.dep_name.HeaderText = "Отдел";
            this.dep_name.Name = "dep_name";
            this.dep_name.ReadOnly = true;
            this.dep_name.Width = 85;
            // 
            // ean
            // 
            this.ean.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ean.DataPropertyName = "ean";
            this.ean.HeaderText = "EAN";
            this.ean.Name = "ean";
            this.ean.ReadOnly = true;
            this.ean.Width = 90;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "Название";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // old_price
            // 
            this.old_price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.old_price.DataPropertyName = "old_price";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.old_price.DefaultCellStyle = dataGridViewCellStyle2;
            this.old_price.HeaderText = "Старая цена";
            this.old_price.Name = "old_price";
            this.old_price.ReadOnly = true;
            this.old_price.Width = 60;
            // 
            // price
            // 
            this.price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.price.DataPropertyName = "price";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.price.DefaultCellStyle = dataGridViewCellStyle3;
            this.price.HeaderText = "Новая цена";
            this.price.Name = "price";
            this.price.ReadOnly = true;
            this.price.Width = 60;
            // 
            // not_sent_terminals
            // 
            this.not_sent_terminals.DataPropertyName = "not_sent_terminals";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.not_sent_terminals.DefaultCellStyle = dataGridViewCellStyle4;
            this.not_sent_terminals.HeaderText = "Кассы, до которых не дошли цены";
            this.not_sent_terminals.Name = "not_sent_terminals";
            this.not_sent_terminals.ReadOnly = true;
            // 
            // time_send
            // 
            this.time_send.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.time_send.DataPropertyName = "time_send";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.time_send.DefaultCellStyle = dataGridViewCellStyle5;
            this.time_send.HeaderText = "Время отправки на кассы";
            this.time_send.Name = "time_send";
            this.time_send.ReadOnly = true;
            // 
            // id_status
            // 
            this.id_status.DataPropertyName = "id_status";
            this.id_status.HeaderText = "id_status";
            this.id_status.Name = "id_status";
            this.id_status.ReadOnly = true;
            this.id_status.Visible = false;
            // 
            // id_departments
            // 
            this.id_departments.DataPropertyName = "id_departments";
            this.id_departments.HeaderText = "id_departments";
            this.id_departments.Name = "id_departments";
            this.id_departments.ReadOnly = true;
            this.id_departments.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 625);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.dgvTerminals);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pnlError);
            this.Controls.Add(this.pnlSent);
            this.Controls.Add(this.pnlSending);
            this.Controls.Add(this.cbOnline);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvMonitoring);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Мониторинг отправки цен на кассы";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonitoring)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTerminals)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbOnline;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvMonitoring;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlSending;
        private System.Windows.Forms.Panel pnlSent;
        private System.Windows.Forms.Panel pnlError;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvTerminals;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Timer timer_message;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn terminal;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTypeTerminal;
        private System.Windows.Forms.DataGridViewTextBoxColumn time_update;
        private System.Windows.Forms.DataGridViewTextBoxColumn comment;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_status_terminal;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_goods_updates;
        private System.Windows.Forms.DataGridViewTextBoxColumn dep_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn ean;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn old_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn not_sent_terminals;
        private System.Windows.Forms.DataGridViewTextBoxColumn time_send;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_departments;
    }
}

