using Nwuram.Framework.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SenderUsersOnFrontol
{
    public partial class frmAddPost : Form
    {
        private int id = -1;
        private bool isEdit = false;

        private DataRowView row = null;

        public void setRow(DataRowView _row)
        {
            this.row = _row;
            id = int.Parse(row["id"].ToString());
            tbName.Text = row["cName"].ToString();
            tbCode.Text = row["codeFrontol"].ToString();
            isEdit = false;
        }
        public frmAddPost()
        {
            InitializeComponent();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (tbName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Необходимо ввести наименование должности!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                int i = Convert.ToInt32(tbCode.Text);
            }
            catch
            {
                MessageBox.Show("Код Frontol должен состоять только из цифр");
                return;
            }
            if (tbCode.Text.Trim().Length == 0)
            {

                MessageBox.Show("Необходимо ввести Код Frontol!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // добавляем по коннектам в транзации
            DataTable dtTrCnt1 = Config.trCntK21dbase1.setPost(id, tbName.Text.Trim(), tbCode.Text.Trim(), 1, true);
            if (dtTrCnt1 == null || dtTrCnt1.Rows.Count == 0 || dtTrCnt1.Rows[0]["id"].ToString().Equals("-1"))
            {
                MessageBox.Show("Не удалось сохранить данные", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Config.trCntK21dbase1.RollbackTransaction();
                return;
            }
            if (dtTrCnt1.Rows[0]["id"].ToString().Equals("-2"))
            {
                Config.trCntK21dbase1.RollbackTransaction();
                MessageBox.Show("Такое наименование присутствует в базе", "Добавление должности", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataTable dtTrCnt2 = Config.trCntX14dbase1.setPost(id, tbName.Text.Trim(), tbCode.Text.Trim(), 1, true);
            if (dtTrCnt2 == null || dtTrCnt2.Rows.Count == 0 || dtTrCnt2.Rows[0]["id"].ToString().Equals("-1"))
            {
                MessageBox.Show("Не удалось сохранить данные", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Config.trCntK21dbase1.RollbackTransaction();
                Config.trCntX14dbase1.RollbackTransaction();
                return;
            }
            if (dtTrCnt2.Rows[0]["id"].ToString().Equals("-2"))
            {
                Config.trCntK21dbase1.RollbackTransaction();
                Config.trCntX14dbase1.RollbackTransaction();
                MessageBox.Show("Такое наименование присутствует в базе", "Добавление должности", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //еще проверка на случай разных добавленных записей
            if ((int)dtTrCnt1.Rows[0]["id"]!=(int)dtTrCnt2.Rows[0]["id"])
            {
                MessageBox.Show(Config.centralText("Попытка добавления записей с неправильными id\nОбратитесь в ОЭЭС.\n"), "Добавление должности", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Config.trCntK21dbase1.RollbackTransaction();
                Config.trCntX14dbase1.RollbackTransaction();
                return;
            }
            Config.trCntK21dbase1.CommitTransaction();
            Config.trCntX14dbase1.CommitTransaction();


            if (id == -1)
            {
                Logging.StartFirstLevel(512);
                Logging.Comment("Добавление должности");

                Logging.Comment("Наименование должности:" + tbName.Text);
                Logging.Comment("Код Frontol:" + tbCode.Text);

                Logging.Comment("Операцию выполнил: ID:" + Nwuram.Framework.Settings.User.UserSettings.User.Id
                                + " ; ФИО:" + Nwuram.Framework.Settings.User.UserSettings.User.FullUsername);
                Logging.StopFirstLevel();

            }
            else
            {
                Logging.StartFirstLevel(513);
                Logging.Comment("Редактирование должности");

                Logging.Comment("ID должности:" + id);
                Logging.VariableChange("Наименование должности:", tbName.Text, row["cName"].ToString());
                Logging.VariableChange("Код Frontol:"," "+ tbCode.Text ,  " "+row["codeFrontol"].ToString(),typeLog._string);

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

        private void tbCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!Char.IsNumber(e.KeyChar) && (e.KeyChar != '\b'));

        }
    }
}
