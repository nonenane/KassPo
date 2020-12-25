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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPost = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTerminal = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpUsers = new System.Windows.Forms.TabPage();
            this.chbDelOldUser = new System.Windows.Forms.CheckBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.chbUn = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbLoadToFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDateEdit = new System.Windows.Forms.TextBox();
            this.tbFIO = new System.Windows.Forms.TextBox();
            this.btAdd = new System.Windows.Forms.Button();
            this.btEdit = new System.Windows.Forms.Button();
            this.btDelete = new System.Windows.Forms.Button();
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
            this.tbTerminals = new System.Windows.Forms.TabPage();
            this.btTerminalSendUsers = new System.Windows.Forms.Button();
            this.pIsActive = new System.Windows.Forms.Panel();
            this.chbIsActive = new System.Windows.Forms.CheckBox();
            this.btTerminalUpdate = new System.Windows.Forms.Button();
            this.tbChannel = new System.Windows.Forms.TextBox();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTerminalType = new System.Windows.Forms.ComboBox();
            this.btTerminalAdd = new System.Windows.Forms.Button();
            this.btTerminalEdit = new System.Windows.Forms.Button();
            this.btTerminalDel = new System.Windows.Forms.Button();
            this.dgvTerminal = new System.Windows.Forms.DataGridView();
            this.cTerNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTerType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTerIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTerChannel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTerDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.bwSend = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.chbDelUsers = new StrageCheckBox();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.tbStatusSend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatus)).BeginInit();
            this.tbTerminals.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTerminal)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.tsmiExit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(997, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiPost,
            this.tsmiTerminal});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // tsmiPost
            // 
            this.tsmiPost.Name = "tsmiPost";
            this.tsmiPost.Size = new System.Drawing.Size(209, 22);
            this.tsmiPost.Text = "Справочник \"Должностей\"";
            this.tsmiPost.Click += new System.EventHandler(this.tsmiPost_Click);
            // 
            // tsmiTerminal
            // 
            this.tsmiTerminal.Name = "tsmiTerminal";
            this.tsmiTerminal.Size = new System.Drawing.Size(209, 22);
            this.tsmiTerminal.Text = "Справочник \"Касс\"";
            this.tsmiTerminal.Visible = false;
            this.tsmiTerminal.Click += new System.EventHandler(this.tsmiTerminal_Click);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(52, 20);
            this.tsmiExit.Text = "Выход";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpUsers);
            this.tabControl1.Controls.Add(this.tbStatusSend);
            this.tabControl1.Controls.Add(this.tbTerminals);
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(997, 493);
            this.tabControl1.TabIndex = 1;
            // 
            // tpUsers
            // 
            this.tpUsers.Controls.Add(this.chbDelOldUser);
            this.tpUsers.Controls.Add(this.btnUpdate);
            this.tpUsers.Controls.Add(this.chbUn);
            this.tpUsers.Controls.Add(this.panel1);
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
            this.tpUsers.Size = new System.Drawing.Size(989, 467);
            this.tpUsers.TabIndex = 0;
            this.tpUsers.Text = "Пользователи";
            this.tpUsers.UseVisualStyleBackColor = true;
            // 
            // chbDelOldUser
            // 
            this.chbDelOldUser.AutoSize = true;
            this.chbDelOldUser.Location = new System.Drawing.Point(553, 432);
            this.chbDelOldUser.Name = "chbDelOldUser";
            this.chbDelOldUser.Size = new System.Drawing.Size(188, 17);
            this.chbDelOldUser.TabIndex = 19;
            this.chbDelOldUser.Text = "Удалить старых пользователей";
            this.chbDelOldUser.UseVisualStyleBackColor = true;
            this.chbDelOldUser.Click += new System.EventHandler(this.chbDelOldUser_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Image = global::SenderUsersOnFrontol.Properties.Resources.update;
            this.btnUpdate.Location = new System.Drawing.Point(949, 2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(32, 32);
            this.btnUpdate.TabIndex = 18;
            this.toolTip1.SetToolTip(this.btnUpdate, "Обновить");
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // chbUn
            // 
            this.chbUn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chbUn.AutoSize = true;
            this.chbUn.Location = new System.Drawing.Point(31, 432);
            this.chbUn.Name = "chbUn";
            this.chbUn.Size = new System.Drawing.Size(84, 17);
            this.chbUn.TabIndex = 17;
            this.chbUn.Text = "Уволенные";
            this.chbUn.UseVisualStyleBackColor = true;
            this.chbUn.CheckedChanged += new System.EventHandler(this.ChbUn_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.Yellow;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(4, 432);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(17, 17);
            this.panel1.TabIndex = 16;
            // 
            // tbLoadToFile
            // 
            this.tbLoadToFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLoadToFile.Location = new System.Drawing.Point(747, 424);
            this.tbLoadToFile.Name = "tbLoadToFile";
            this.tbLoadToFile.Size = new System.Drawing.Size(120, 32);
            this.tbLoadToFile.TabIndex = 14;
            this.tbLoadToFile.Text = "Выгрузить в файл";
            this.tbLoadToFile.UseVisualStyleBackColor = true;
            this.tbLoadToFile.Click += new System.EventHandler(this.tbLoadToFile_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(166, 434);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Дата изменения:";
            // 
            // tbDateEdit
            // 
            this.tbDateEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbDateEdit.Location = new System.Drawing.Point(267, 430);
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
            // btAdd
            // 
            this.btAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btAdd.Image = global::SenderUsersOnFrontol.Properties.Resources.document_add;
            this.btAdd.Location = new System.Drawing.Point(873, 424);
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
            this.btEdit.Location = new System.Drawing.Point(911, 424);
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
            this.btDelete.Location = new System.Drawing.Point(949, 424);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(32, 32);
            this.btDelete.TabIndex = 11;
            this.toolTip1.SetToolTip(this.btDelete, "Сменить статус");
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToResizeRows = false;
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.dgvData.Size = new System.Drawing.Size(983, 379);
            this.dgvData.TabIndex = 0;
            this.dgvData.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellContentDoubleClick);
            this.dgvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellDoubleClick);
            this.dgvData.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvData_ColumnWidthChanged);
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
            this.tbStatusSend.Size = new System.Drawing.Size(989, 467);
            this.tbStatusSend.TabIndex = 1;
            this.tbStatusSend.Text = "Отправка на кассы";
            this.tbStatusSend.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 432);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Дата последней отправки на все кассы:";
            // 
            // tbDateSend
            // 
            this.tbDateSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbDateSend.Location = new System.Drawing.Point(236, 428);
            this.tbDateSend.MaxLength = 150;
            this.tbDateSend.Name = "tbDateSend";
            this.tbDateSend.ReadOnly = true;
            this.tbDateSend.Size = new System.Drawing.Size(206, 20);
            this.tbDateSend.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(861, 420);
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
            this.dgvStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.dgvStatus.Location = new System.Drawing.Point(3, 3);
            this.dgvStatus.Name = "dgvStatus";
            this.dgvStatus.RowHeadersVisible = false;
            this.dgvStatus.Size = new System.Drawing.Size(983, 411);
            this.dgvStatus.TabIndex = 0;
            this.dgvStatus.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.DgvData_RowPostPaint);
            this.dgvStatus.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvStatus_RowPrePaint);
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
            // tbTerminals
            // 
            this.tbTerminals.Controls.Add(this.btTerminalSendUsers);
            this.tbTerminals.Controls.Add(this.pIsActive);
            this.tbTerminals.Controls.Add(this.chbIsActive);
            this.tbTerminals.Controls.Add(this.btTerminalUpdate);
            this.tbTerminals.Controls.Add(this.tbChannel);
            this.tbTerminals.Controls.Add(this.tbIP);
            this.tbTerminals.Controls.Add(this.label3);
            this.tbTerminals.Controls.Add(this.cmbTerminalType);
            this.tbTerminals.Controls.Add(this.btTerminalAdd);
            this.tbTerminals.Controls.Add(this.btTerminalEdit);
            this.tbTerminals.Controls.Add(this.btTerminalDel);
            this.tbTerminals.Controls.Add(this.dgvTerminal);
            this.tbTerminals.Location = new System.Drawing.Point(4, 22);
            this.tbTerminals.Name = "tbTerminals";
            this.tbTerminals.Padding = new System.Windows.Forms.Padding(3);
            this.tbTerminals.Size = new System.Drawing.Size(989, 467);
            this.tbTerminals.TabIndex = 2;
            this.tbTerminals.Text = "Кассы";
            this.tbTerminals.UseVisualStyleBackColor = true;
            // 
            // btTerminalSendUsers
            // 
            this.btTerminalSendUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btTerminalSendUsers.Location = new System.Drawing.Point(861, 408);
            this.btTerminalSendUsers.Name = "btTerminalSendUsers";
            this.btTerminalSendUsers.Size = new System.Drawing.Size(120, 36);
            this.btTerminalSendUsers.TabIndex = 23;
            this.btTerminalSendUsers.Text = "Отправить пользователей";
            this.btTerminalSendUsers.UseVisualStyleBackColor = true;
            this.btTerminalSendUsers.Click += new System.EventHandler(this.btTerminalSendUsers_Click);
            // 
            // pIsActive
            // 
            this.pIsActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pIsActive.BackColor = System.Drawing.Color.Moccasin;
            this.pIsActive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pIsActive.Location = new System.Drawing.Point(8, 416);
            this.pIsActive.Name = "pIsActive";
            this.pIsActive.Size = new System.Drawing.Size(21, 21);
            this.pIsActive.TabIndex = 22;
            // 
            // chbIsActive
            // 
            this.chbIsActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chbIsActive.AutoSize = true;
            this.chbIsActive.Location = new System.Drawing.Point(35, 418);
            this.chbIsActive.Name = "chbIsActive";
            this.chbIsActive.Size = new System.Drawing.Size(102, 17);
            this.chbIsActive.TabIndex = 21;
            this.chbIsActive.Text = "Не отправлено";
            this.chbIsActive.UseVisualStyleBackColor = true;
            this.chbIsActive.Click += new System.EventHandler(this.chbIsActive_Click);
            // 
            // btTerminalUpdate
            // 
            this.btTerminalUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btTerminalUpdate.Image = global::SenderUsersOnFrontol.Properties.Resources.update;
            this.btTerminalUpdate.Location = new System.Drawing.Point(949, 6);
            this.btTerminalUpdate.Name = "btTerminalUpdate";
            this.btTerminalUpdate.Size = new System.Drawing.Size(32, 32);
            this.btTerminalUpdate.TabIndex = 20;
            this.toolTip1.SetToolTip(this.btTerminalUpdate, "Обновить");
            this.btTerminalUpdate.UseVisualStyleBackColor = true;
            this.btTerminalUpdate.Click += new System.EventHandler(this.btTerminalUpdate_Click);
            // 
            // tbChannel
            // 
            this.tbChannel.Location = new System.Drawing.Point(381, 33);
            this.tbChannel.Name = "tbChannel";
            this.tbChannel.Size = new System.Drawing.Size(100, 20);
            this.tbChannel.TabIndex = 19;
            this.tbChannel.TextChanged += new System.EventHandler(this.tbIP_TextChanged);
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(275, 33);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(100, 20);
            this.tbIP.TabIndex = 19;
            this.tbIP.TextChanged += new System.EventHandler(this.tbIP_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Тип кассы";
            // 
            // cmbTerminalType
            // 
            this.cmbTerminalType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTerminalType.FormattingEnabled = true;
            this.cmbTerminalType.Location = new System.Drawing.Point(78, 6);
            this.cmbTerminalType.Name = "cmbTerminalType";
            this.cmbTerminalType.Size = new System.Drawing.Size(240, 21);
            this.cmbTerminalType.TabIndex = 17;
            this.cmbTerminalType.SelectionChangeCommitted += new System.EventHandler(this.cmbTerminalType_SelectionChangeCommitted);
            // 
            // btTerminalAdd
            // 
            this.btTerminalAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btTerminalAdd.Image = global::SenderUsersOnFrontol.Properties.Resources.document_add;
            this.btTerminalAdd.Location = new System.Drawing.Point(747, 410);
            this.btTerminalAdd.Name = "btTerminalAdd";
            this.btTerminalAdd.Size = new System.Drawing.Size(32, 32);
            this.btTerminalAdd.TabIndex = 14;
            this.toolTip1.SetToolTip(this.btTerminalAdd, "Создать");
            this.btTerminalAdd.UseVisualStyleBackColor = true;
            this.btTerminalAdd.Click += new System.EventHandler(this.btTerminalAdd_Click);
            // 
            // btTerminalEdit
            // 
            this.btTerminalEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btTerminalEdit.Image = global::SenderUsersOnFrontol.Properties.Resources.edit;
            this.btTerminalEdit.Location = new System.Drawing.Point(785, 410);
            this.btTerminalEdit.Name = "btTerminalEdit";
            this.btTerminalEdit.Size = new System.Drawing.Size(32, 32);
            this.btTerminalEdit.TabIndex = 15;
            this.toolTip1.SetToolTip(this.btTerminalEdit, "Редактировать");
            this.btTerminalEdit.UseVisualStyleBackColor = true;
            this.btTerminalEdit.Click += new System.EventHandler(this.btTerminalEdit_Click);
            // 
            // btTerminalDel
            // 
            this.btTerminalDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btTerminalDel.Image = global::SenderUsersOnFrontol.Properties.Resources.document_delete;
            this.btTerminalDel.Location = new System.Drawing.Point(823, 410);
            this.btTerminalDel.Name = "btTerminalDel";
            this.btTerminalDel.Size = new System.Drawing.Size(32, 32);
            this.btTerminalDel.TabIndex = 16;
            this.toolTip1.SetToolTip(this.btTerminalDel, "Удалить");
            this.btTerminalDel.UseVisualStyleBackColor = true;
            this.btTerminalDel.Click += new System.EventHandler(this.btTerminalDel_Click);
            // 
            // dgvTerminal
            // 
            this.dgvTerminal.AllowUserToAddRows = false;
            this.dgvTerminal.AllowUserToDeleteRows = false;
            this.dgvTerminal.AllowUserToResizeRows = false;
            this.dgvTerminal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTerminal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTerminal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTerminal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTerminal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cTerNum,
            this.cTerType,
            this.cTerIP,
            this.cTerChannel,
            this.cTerDate});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTerminal.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvTerminal.Location = new System.Drawing.Point(6, 55);
            this.dgvTerminal.MultiSelect = false;
            this.dgvTerminal.Name = "dgvTerminal";
            this.dgvTerminal.ReadOnly = true;
            this.dgvTerminal.RowHeadersVisible = false;
            this.dgvTerminal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTerminal.Size = new System.Drawing.Size(975, 332);
            this.dgvTerminal.TabIndex = 13;
            this.dgvTerminal.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvTerminal_ColumnWidthChanged);
            this.dgvTerminal.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.DgvData_RowPostPaint);
            this.dgvTerminal.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvTerminal_RowPrePaint);
            this.dgvTerminal.SelectionChanged += new System.EventHandler(this.dgvTerminal_SelectionChanged);
            // 
            // cTerNum
            // 
            this.cTerNum.DataPropertyName = "Number";
            this.cTerNum.HeaderText = "Номер кассы";
            this.cTerNum.Name = "cTerNum";
            this.cTerNum.ReadOnly = true;
            // 
            // cTerType
            // 
            this.cTerType.DataPropertyName = "NameTerminalType";
            this.cTerType.HeaderText = "Тип кассы";
            this.cTerType.Name = "cTerType";
            this.cTerType.ReadOnly = true;
            // 
            // cTerIP
            // 
            this.cTerIP.DataPropertyName = "IP";
            this.cTerIP.HeaderText = "IP-адрес";
            this.cTerIP.Name = "cTerIP";
            this.cTerIP.ReadOnly = true;
            // 
            // cTerChannel
            // 
            this.cTerChannel.DataPropertyName = "Path";
            this.cTerChannel.HeaderText = "Канал обмена";
            this.cTerChannel.Name = "cTerChannel";
            this.cTerChannel.ReadOnly = true;
            // 
            // cTerDate
            // 
            this.cTerDate.DataPropertyName = "DateUserSend";
            this.cTerDate.HeaderText = "Дата отправки пользователей";
            this.cTerDate.Name = "cTerDate";
            this.cTerDate.ReadOnly = true;
            // 
            // bwSend
            // 
            this.bwSend.WorkerReportsProgress = true;
            this.bwSend.WorkerSupportsCancellation = true;
            this.bwSend.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwSend_DoWork);
            this.bwSend.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwSend_RunWorkerCompleted);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 520);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(997, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsLabel
            // 
            this.tsLabel.Name = "tsLabel";
            this.tsLabel.Size = new System.Drawing.Size(109, 17);
            this.tsLabel.Text = "toolStripStatusLabel1";
            // 
            // chbDelUsers
            // 
            this.chbDelUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chbDelUsers.AutoSize = true;
            this.chbDelUsers.Location = new System.Drawing.Point(493, 430);
            this.chbDelUsers.Name = "chbDelUsers";
            this.chbDelUsers.Size = new System.Drawing.Size(188, 17);
            this.chbDelUsers.TabIndex = 17;
            this.chbDelUsers.Text = "Удалить старых пользователей";
            this.chbDelUsers.UseVisualStyleBackColor = true;
            this.chbDelUsers.Unchecked += new System.EventHandler(this.strageCheckBox1_Unchecked);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 542);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(516, 494);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
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
            this.tbTerminals.ResumeLayout(false);
            this.tbTerminals.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTerminal)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
        private System.Windows.Forms.DataGridViewTextBoxColumn cId;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn cFIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPostName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn INN_Code;
        private System.Windows.Forms.CheckBox chbUn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsLabel;
        private System.Windows.Forms.CheckBox chbDelOldUser;
        private System.Windows.Forms.TabPage tbTerminals;
        private System.Windows.Forms.DataGridView dgvTerminal;
        private System.Windows.Forms.Button btTerminalAdd;
        private System.Windows.Forms.Button btTerminalEdit;
        private System.Windows.Forms.Button btTerminalDel;
        private System.Windows.Forms.TextBox tbChannel;
        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbTerminalType;
        private System.Windows.Forms.Button btTerminalUpdate;
        private System.Windows.Forms.Panel pIsActive;
        private System.Windows.Forms.CheckBox chbIsActive;
        private System.Windows.Forms.Button btTerminalSendUsers;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTerNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTerType;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTerIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTerChannel;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTerDate;
    }
}

