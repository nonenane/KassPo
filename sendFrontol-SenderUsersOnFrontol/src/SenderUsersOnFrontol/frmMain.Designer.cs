namespace SenderUsersOnFrontol
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPost = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTerminal = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpUsers = new System.Windows.Forms.TabPage();
            this.chbUn = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbSearch = new System.Windows.Forms.Label();
            this.tbLoadToFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDateEdit = new System.Windows.Forms.TextBox();
            this.tbFIO = new System.Windows.Forms.TextBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.cId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cFIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPostName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INN_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbStatusSend = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDateSend = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvStatus = new System.Windows.Forms.DataGridView();
            this.cSTerminal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.bwSend = new System.ComponentModel.BackgroundWorker();
            this.chbDelUsers = new StrageCheckBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.btEdit = new System.Windows.Forms.Button();
            this.btDelete = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.tbStatusSend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.tsmiExit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(833, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiPost,
            this.tsmiTerminal});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // tsmiPost
            // 
            this.tsmiPost.Name = "tsmiPost";
            this.tsmiPost.Size = new System.Drawing.Size(224, 22);
            this.tsmiPost.Text = "Справочник \"Должностей\"";
            this.tsmiPost.Click += new System.EventHandler(this.tsmiPost_Click);
            // 
            // tsmiTerminal
            // 
            this.tsmiTerminal.Name = "tsmiTerminal";
            this.tsmiTerminal.Size = new System.Drawing.Size(224, 22);
            this.tsmiTerminal.Text = "Справочник \"Касс\"";
            this.tsmiTerminal.Click += new System.EventHandler(this.tsmiTerminal_Click);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(54, 20);
            this.tsmiExit.Text = "Выход";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpUsers);
            this.tabControl1.Controls.Add(this.tbStatusSend);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(833, 445);
            this.tabControl1.TabIndex = 1;
            // 
            // tpUsers
            // 
            this.tpUsers.Controls.Add(this.btnUpdate);
            this.tpUsers.Controls.Add(this.chbUn);
            this.tpUsers.Controls.Add(this.panel1);
            this.tpUsers.Controls.Add(this.lbSearch);
            this.tpUsers.Controls.Add(this.tbLoadToFile);
            this.tpUsers.Controls.Add(this.label1);
            this.tpUsers.Controls.Add(this.tbDateEdit);
            this.tpUsers.Controls.Add(this.tbFIO);
            this.tpUsers.Controls.Add(this.btAdd);
            this.tpUsers.Controls.Add(this.btEdit);
            this.tpUsers.Controls.Add(this.btDelete);
            this.tpUsers.Controls.Add(this.dgvData);
            this.tpUsers.Location = new System.Drawing.Point(4, 22);
            this.tpUsers.Name = "tpUsers";
            this.tpUsers.Padding = new System.Windows.Forms.Padding(3);
            this.tpUsers.Size = new System.Drawing.Size(825, 419);
            this.tpUsers.TabIndex = 0;
            this.tpUsers.Text = "Пользователи";
            this.tpUsers.UseVisualStyleBackColor = true;
            // 
            // chbUn
            // 
            this.chbUn.AutoSize = true;
            this.chbUn.Location = new System.Drawing.Point(35, 383);
            this.chbUn.Name = "chbUn";
            this.chbUn.Size = new System.Drawing.Size(84, 17);
            this.chbUn.TabIndex = 17;
            this.chbUn.Text = "Уволенные";
            this.chbUn.UseVisualStyleBackColor = true;
            this.chbUn.CheckedChanged += new System.EventHandler(this.ChbUn_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Yellow;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(8, 381);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(21, 21);
            this.panel1.TabIndex = 16;
            // 
            // lbSearch
            // 
            this.lbSearch.AutoSize = true;
            this.lbSearch.Location = new System.Drawing.Point(167, 9);
            this.lbSearch.Name = "lbSearch";
            this.lbSearch.Size = new System.Drawing.Size(39, 13);
            this.lbSearch.TabIndex = 15;
            this.lbSearch.Text = "Поиск";
            // 
            // tbLoadToFile
            // 
            this.tbLoadToFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLoadToFile.Location = new System.Drawing.Point(583, 375);
            this.tbLoadToFile.Name = "tbLoadToFile";
            this.tbLoadToFile.Size = new System.Drawing.Size(120, 32);
            this.tbLoadToFile.TabIndex = 14;
            this.tbLoadToFile.Text = "Выгрузить в файл";
            this.tbLoadToFile.UseVisualStyleBackColor = true;
            this.tbLoadToFile.Click += new System.EventHandler(this.tbLoadToFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(202, 385);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Дата изменения:";
            // 
            // tbDateEdit
            // 
            this.tbDateEdit.Location = new System.Drawing.Point(303, 381);
            this.tbDateEdit.MaxLength = 150;
            this.tbDateEdit.Name = "tbDateEdit";
            this.tbDateEdit.ReadOnly = true;
            this.tbDateEdit.Size = new System.Drawing.Size(206, 20);
            this.tbDateEdit.TabIndex = 12;
            // 
            // tbFIO
            // 
            this.tbFIO.Location = new System.Drawing.Point(208, 6);
            this.tbFIO.MaxLength = 150;
            this.tbFIO.Name = "tbFIO";
            this.tbFIO.Size = new System.Drawing.Size(206, 20);
            this.tbFIO.TabIndex = 12;
            this.tbFIO.TextChanged += new System.EventHandler(this.tbFIO_TextChanged);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToResizeRows = false;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cId,
            this.cNumber,
            this.cFIO,
            this.cPostName,
            this.cCode,
            this.INN_Code});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvData.Location = new System.Drawing.Point(3, 38);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(819, 322);
            this.dgvData.TabIndex = 0;
            this.dgvData.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellContentDoubleClick);
            this.dgvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellDoubleClick);
            this.dgvData.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.DgvData_RowPostPaint);
            this.dgvData.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.DgvData_RowPrePaint);
            this.dgvData.SelectionChanged += new System.EventHandler(this.dgvData_SelectionChanged);
            // 
            // cId
            // 
            this.cId.DataPropertyName = "id";
            this.cId.HeaderText = "ID пользователя";
            this.cId.Name = "cId";
            this.cId.ReadOnly = true;
            // 
            // cNumber
            // 
            this.cNumber.DataPropertyName = "Number";
            this.cNumber.HeaderText = "Короткий номер";
            this.cNumber.Name = "cNumber";
            this.cNumber.ReadOnly = true;
            // 
            // cFIO
            // 
            this.cFIO.DataPropertyName = "FIO";
            this.cFIO.HeaderText = "Фамилия И.О.";
            this.cFIO.Name = "cFIO";
            this.cFIO.ReadOnly = true;
            // 
            // cPostName
            // 
            this.cPostName.DataPropertyName = "namePost";
            this.cPostName.HeaderText = "Профиль";
            this.cPostName.Name = "cPostName";
            this.cPostName.ReadOnly = true;
            // 
            // cCode
            // 
            this.cCode.DataPropertyName = "code";
            this.cCode.HeaderText = "Штрих-код";
            this.cCode.Name = "cCode";
            this.cCode.ReadOnly = true;
            // 
            // INN_Code
            // 
            this.INN_Code.DataPropertyName = "INN_Code";
            this.INN_Code.HeaderText = "ИНН";
            this.INN_Code.Name = "INN_Code";
            this.INN_Code.ReadOnly = true;
            // 
            // tbStatusSend
            // 
            this.tbStatusSend.Controls.Add(this.chbDelUsers);
            this.tbStatusSend.Controls.Add(this.label2);
            this.tbStatusSend.Controls.Add(this.tbDateSend);
            this.tbStatusSend.Controls.Add(this.button1);
            this.tbStatusSend.Controls.Add(this.dgvStatus);
            this.tbStatusSend.Location = new System.Drawing.Point(4, 22);
            this.tbStatusSend.Name = "tbStatusSend";
            this.tbStatusSend.Padding = new System.Windows.Forms.Padding(3);
            this.tbStatusSend.Size = new System.Drawing.Size(825, 419);
            this.tbStatusSend.TabIndex = 1;
            this.tbStatusSend.Text = "Отправка на кассы";
            this.tbStatusSend.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 384);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Дата последней отправки на все кассы:";
            // 
            // tbDateSend
            // 
            this.tbDateSend.Location = new System.Drawing.Point(236, 380);
            this.tbDateSend.MaxLength = 150;
            this.tbDateSend.Name = "tbDateSend";
            this.tbDateSend.ReadOnly = true;
            this.tbDateSend.Size = new System.Drawing.Size(206, 20);
            this.tbDateSend.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(699, 372);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 36);
            this.button1.TabIndex = 1;
            this.button1.Text = "Отправить данные на кассы";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvStatus
            // 
            this.dgvStatus.AllowUserToAddRows = false;
            this.dgvStatus.AllowUserToDeleteRows = false;
            this.dgvStatus.AllowUserToResizeRows = false;
            this.dgvStatus.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStatus.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStatus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cSTerminal,
            this.cSIP,
            this.cSPath,
            this.cSStatus});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStatus.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvStatus.Location = new System.Drawing.Point(3, 3);
            this.dgvStatus.Name = "dgvStatus";
            this.dgvStatus.RowHeadersVisible = false;
            this.dgvStatus.Size = new System.Drawing.Size(819, 353);
            this.dgvStatus.TabIndex = 0;
            // 
            // cSTerminal
            // 
            this.cSTerminal.DataPropertyName = "Number";
            this.cSTerminal.HeaderText = "Касса";
            this.cSTerminal.Name = "cSTerminal";
            this.cSTerminal.ReadOnly = true;
            // 
            // cSIP
            // 
            this.cSIP.DataPropertyName = "IP";
            this.cSIP.HeaderText = "IP-Адрес";
            this.cSIP.Name = "cSIP";
            this.cSIP.ReadOnly = true;
            // 
            // cSPath
            // 
            this.cSPath.DataPropertyName = "Path";
            this.cSPath.HeaderText = "Путь";
            this.cSPath.Name = "cSPath";
            this.cSPath.ReadOnly = true;
            // 
            // cSStatus
            // 
            this.cSStatus.DataPropertyName = "statusSend";
            this.cSStatus.HeaderText = "Статус заливки";
            this.cSStatus.Name = "cSStatus";
            this.cSStatus.ReadOnly = true;
            // 
            // bwSend
            // 
            this.bwSend.WorkerReportsProgress = true;
            this.bwSend.WorkerSupportsCancellation = true;
            this.bwSend.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwSend_DoWork);
            this.bwSend.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwSend_RunWorkerCompleted);
            // 
            // chbDelUsers
            // 
            this.chbDelUsers.AutoSize = true;
            this.chbDelUsers.Location = new System.Drawing.Point(493, 382);
            this.chbDelUsers.Name = "chbDelUsers";
            this.chbDelUsers.Size = new System.Drawing.Size(188, 17);
            this.chbDelUsers.TabIndex = 17;
            this.chbDelUsers.Text = "Удалить старых пользователей";
            this.chbDelUsers.UseVisualStyleBackColor = true;
            this.chbDelUsers.Unchecked += new System.EventHandler(this.strageCheckBox1_Unchecked);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Image = global::SenderUsersOnFrontol.Properties.Resources.update;
            this.btnUpdate.Location = new System.Drawing.Point(785, 2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(32, 32);
            this.btnUpdate.TabIndex = 18;
            this.toolTip1.SetToolTip(this.btnUpdate, "Обновить");
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btAdd
            // 
            this.btAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btAdd.Image = global::SenderUsersOnFrontol.Properties.Resources.document_add;
            this.btAdd.Location = new System.Drawing.Point(709, 375);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(32, 32);
            this.btAdd.TabIndex = 9;
            this.toolTip1.SetToolTip(this.btAdd, "Добавить");
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btEdit
            // 
            this.btEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btEdit.Image = global::SenderUsersOnFrontol.Properties.Resources.edit;
            this.btEdit.Location = new System.Drawing.Point(747, 375);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(32, 32);
            this.btEdit.TabIndex = 10;
            this.toolTip1.SetToolTip(this.btEdit, "Редактировать");
            this.btEdit.UseVisualStyleBackColor = true;
            this.btEdit.Click += new System.EventHandler(this.btEdit_Click);
            // 
            // btDelete
            // 
            this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btDelete.Image = global::SenderUsersOnFrontol.Properties.Resources.document_delete;
            this.btDelete.Location = new System.Drawing.Point(785, 375);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(32, 32);
            this.btDelete.TabIndex = 11;
            this.toolTip1.SetToolTip(this.btDelete, "Сменить статус");
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 469);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(516, 494);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMain_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tpUsers.ResumeLayout(false);
            this.tpUsers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.tbStatusSend.ResumeLayout(false);
            this.tbStatusSend.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpUsers;
        private System.Windows.Forms.TabPage tbStatusSend;
        private System.Windows.Forms.ToolStripMenuItem tsmiPost;
        private System.Windows.Forms.ToolStripMenuItem tsmiTerminal;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btEdit;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridView dgvStatus;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSTerminal;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSStatus;
        private System.ComponentModel.BackgroundWorker bwSend;
        private System.Windows.Forms.TextBox tbFIO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDateEdit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDateSend;
        private System.Windows.Forms.Button tbLoadToFile;
        private StrageCheckBox chbDelUsers;
        private System.Windows.Forms.Label lbSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn cId;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn cFIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPostName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn INN_Code;
        private System.Windows.Forms.CheckBox chbUn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnUpdate;
    }
}

