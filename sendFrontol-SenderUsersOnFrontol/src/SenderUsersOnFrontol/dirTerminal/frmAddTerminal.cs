using Nwuram.Framework.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace SenderUsersOnFrontol
{
    public partial class frmAddTerminal : Form
    {
        private int id = -1;
        private bool isEdit = false;

        private DataRowView row = null;

        public void setRow(DataRowView _row)
        {
            this.row = _row;
            id = int.Parse(row["id"].ToString());
            tbNumberTerminal.Text = row["Number"].ToString();
            tbPath.Text = row["Path"].ToString();
            tbIP.Text = row["IP"].ToString();            
            isEdit = false;
        }
        public frmAddTerminal()
        {
            InitializeComponent();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
           

            if (tbNumberTerminal.Text.Trim().Length == 0)
            {
                MessageBox.Show("Необходимо номер кассы!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            IPAddress tmpIP;
            if (tbIP.Text.Trim().Length == 0 || !IPAddress.TryParse(tbIP.Text, out tmpIP) || tmpIP==null)
            {
                MessageBox.Show("Необходимо IP-адресс!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tbPath.Text.Trim().Length == 0)
            {
                MessageBox.Show("Необходимо путь обмена!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dtResult = Config.hCntMain.setTerminal(id, int.Parse(tbNumberTerminal.Text), tbIP.Text, tbPath.Text, 1);
            if (dtResult == null || dtResult.Rows.Count == 0 || dtResult.Rows[0]["id"].ToString().Equals("-1"))
            {
                MessageBox.Show("Не удалось сохранить данные", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (dtResult.Rows[0]["id"].ToString().Equals("-2"))
            {
                MessageBox.Show("Дублирование одного из полей!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (id == -1)
            {
                Logging.StartFirstLevel(720);
                Logging.Comment("Добавление кассы");

                Logging.Comment("Номер кассы: " + tbNumberTerminal.Text);
                Logging.Comment("Путь канала обмена: "+ tbPath.Text);
                Logging.Comment("IP-адресс: "+ tbIP.Text);

                Logging.Comment("Операцию выполнил: ID:" + Nwuram.Framework.Settings.User.UserSettings.User.Id
                                + " ; ФИО:" + Nwuram.Framework.Settings.User.UserSettings.User.FullUsername);
                Logging.StopFirstLevel();

            }
            else
            {
                Logging.StartFirstLevel(721);
                Logging.Comment("Редактирование кассы");

                Logging.Comment("ID кассы: " + id);
                Logging.VariableChange("Номер кассы: ", tbNumberTerminal.Text, row["Number"].ToString(), typeLog._string);
                Logging.VariableChange("Путь канала обмена: ", tbPath.Text, row["Path"].ToString());
                Logging.VariableChange("IP-адресс: ", tbIP.Text , row["IP"].ToString());

                Logging.Comment("Операцию выполнил: ID:" + Nwuram.Framework.Settings.User.UserSettings.User.Id
                                + " ; ФИО:" + Nwuram.Framework.Settings.User.UserSettings.User.FullUsername);
                Logging.StopFirstLevel();
            }

            MessageBox.Show("Данные сохранены!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
            isEdit = false;
            this.DialogResult = DialogResult.OK;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            isEdit = true;
        }

        private void frmAddTypeComponents_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = (isEdit && MessageBox.Show("Закрыть форму без сохранения?", "Инфомирование", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No);
        }

        private void tbNumberTerminal_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!Char.IsNumber(e.KeyChar) && (e.KeyChar != '\b'));
        }
    }
}
