namespace SenderUsersOnFrontol
{
    partial class frmAddTerminal
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.btSave = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbNumberTerminal = new System.Windows.Forms.TextBox();
            this.tbIP = new IPAddressControlLib.IPAddressControl();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Путь канала обмена:";
            // 
            // tbPath
            // 
            this.tbPath.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPath.Location = new System.Drawing.Point(138, 59);
            this.tbPath.MaxLength = 150;
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(239, 20);
            this.tbPath.TabIndex = 10;
            this.tbPath.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave.Image = global::SenderUsersOnFrontol.Properties.Resources.save_edit;
            this.btSave.Location = new System.Drawing.Point(307, 94);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(32, 32);
            this.btSave.TabIndex = 8;
            this.toolTip1.SetToolTip(this.btSave, "Сохранить");
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.Image = global::SenderUsersOnFrontol.Properties.Resources.door_out;
            this.btClose.Location = new System.Drawing.Point(345, 94);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(32, 32);
            this.btClose.TabIndex = 9;
            this.toolTip1.SetToolTip(this.btClose, "Выход");
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Номер кассы:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(73, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "IP-адресс:";
            // 
            // tbNumberTerminal
            // 
            this.tbNumberTerminal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNumberTerminal.Location = new System.Drawing.Point(138, 7);
            this.tbNumberTerminal.MaxLength = 150;
            this.tbNumberTerminal.Name = "tbNumberTerminal";
            this.tbNumberTerminal.Size = new System.Drawing.Size(239, 20);
            this.tbNumberTerminal.TabIndex = 10;
            this.tbNumberTerminal.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            this.tbNumberTerminal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNumberTerminal_KeyPress);
            // 
            // tbIP
            // 
            this.tbIP.AllowInternalTab = false;
            this.tbIP.AutoHeight = true;
            this.tbIP.BackColor = System.Drawing.SystemColors.Window;
            this.tbIP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbIP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbIP.Location = new System.Drawing.Point(138, 33);
            this.tbIP.MinimumSize = new System.Drawing.Size(87, 20);
            this.tbIP.Name = "tbIP";
            this.tbIP.ReadOnly = false;
            this.tbIP.Size = new System.Drawing.Size(87, 20);
            this.tbIP.TabIndex = 12;
            this.tbIP.Text = "...";
            this.tbIP.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // frmAddTerminal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 134);
            this.ControlBox = false;
            this.Controls.Add(this.tbIP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbNumberTerminal);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddTerminal";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddTypeComponents";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAddTypeComponents_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbNumberTerminal;
        private IPAddressControlLib.IPAddressControl tbIP;
    }
}