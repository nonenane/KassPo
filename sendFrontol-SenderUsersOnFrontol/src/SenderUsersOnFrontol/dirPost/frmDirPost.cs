using Nwuram.Framework.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SenderUsersOnFrontol
{
    public partial class frmDirPost : Form
    {
        public bool newData = false;
        public frmDirPost()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            get_data();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            frmAddPost frm = new frmAddPost();
            frm.Text = "Добавить должность";
            if (DialogResult.OK == frm.ShowDialog())
            {
                get_data();
                newData = true;
            }
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null && dgvData.CurrentRow.Index != -1 && dtData != null && dtData.DefaultView.Count != 0)
            {
                frmAddPost frm = new frmAddPost();
                frm.Text = "Редактировать должность";
                frm.setRow(dtData.DefaultView[dgvData.CurrentRow.Index]);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    get_data();
                    newData = true;
                }
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null && dgvData.CurrentRow.Index != -1 && dtData != null && dtData.DefaultView.Count != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Удалить запись?", "Запрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    int id = int.Parse(dtData.DefaultView[dgvData.CurrentRow.Index]["id"].ToString());
                    string cName = dtData.DefaultView[dgvData.CurrentRow.Index]["id"].ToString();
                    bool isActiveStatus = bool.Parse(dtData.DefaultView[dgvData.CurrentRow.Index]["isActive"].ToString());
                    DataTable dtCnt1 = Config.trCntK21dbase1.setPost(id, "", "", 2, true);
                    if (dtCnt1!=null && dtCnt1.Rows.Count!=0 && dtCnt1.Rows[0]["id"].ToString()=="-1")
                    {
                        MessageBox.Show("Не удалось удалить данные!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Config.trCntK21dbase1.RollbackTransaction();
                        return;
                    }
                    DataTable dtCnt2 = Config.trCntX14dbase1.setPost(id, "", "", 2, true);
                    if (dtCnt2 != null && dtCnt2.Rows.Count != 0 && dtCnt2.Rows[0]["id"].ToString() == "-1")
                    {
                        MessageBox.Show("Не удалось удалить данные!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Config.trCntK21dbase1.RollbackTransaction();
                        Config.trCntX14dbase1.RollbackTransaction();
                        return;
                    }

                    Config.trCntK21dbase1.CommitTransaction();
                    Config.trCntX14dbase1.CommitTransaction();

                    if (dtCnt1.Rows[0]["id"].ToString().Equals("-3"))
                    {
                        MessageBox.Show("Запись переведена в " + (isActiveStatus ? "Недействующие" : "Активные") + "!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Logging.StartFirstLevel(513);
                        Logging.Comment("Редактирование должности");

                        Logging.Comment("ID должности:" + id);
                        Logging.Comment("Наименование должности:" + dtData.DefaultView[dgvData.CurrentRow.Index]["cName"].ToString());
                        Logging.Comment("Код Frontol:" + dtData.DefaultView[dgvData.CurrentRow.Index]["codeFrontol"].ToString());
                        Logging.Comment("Запись переведена в " + (isActiveStatus ? "Недействующие" : "Активные"));

                        Logging.Comment("Операцию выполнил: ID:" + Nwuram.Framework.Settings.User.UserSettings.User.Id
                                        + " ; ФИО:" + Nwuram.Framework.Settings.User.UserSettings.User.FullUsername);
                        Logging.StopFirstLevel();
                    }
                    else
                    {
                        MessageBox.Show("Запись удалена!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Logging.StartFirstLevel(514);
                        Logging.Comment("Удаление должности");

                        Logging.Comment("ID должности:" + id);
                        Logging.Comment("Наименование должности:" + dtData.DefaultView[dgvData.CurrentRow.Index]["cName"].ToString());
                        Logging.Comment("Код Frontol:" + dtData.DefaultView[dgvData.CurrentRow.Index]["codeFrontol"].ToString());

                        Logging.Comment("Операцию выполнил: ID:" + Nwuram.Framework.Settings.User.UserSettings.User.Id
                                        + " ; ФИО:" + Nwuram.Framework.Settings.User.UserSettings.User.FullUsername);
                        Logging.StopFirstLevel();
                    }

                    newData = true;
                    get_data();
                    
                }
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private DataTable dtData;
        private void get_data()
        {
            dtData = Config.hCntMain.getPost();
            filter();
            dgvData.DataSource = dtData;
        }

        private void filter()
        {
            try
            {
                string str = "";

                str += string.Format("cName like '%{0}%'", tbName.Text.Trim());

                if (!chbIsActive.Checked)
                    str += " AND isActive = 1";

                dtData.DefaultView.RowFilter = str;
                btDelete.Enabled = btEdit.Enabled = dtData.DefaultView.Count != 0;
            }
            catch
            {
                dtData.DefaultView.RowFilter = "id = -9999";
                btDelete.Enabled = btEdit.Enabled = dtData.DefaultView.Count != 0;
            }
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            filter();
        }

        private void dgvData_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex != -1 && dtData != null && dtData.DefaultView.Count != 0)
            {
                Color rColor = Color.White;

                if (!(bool)dtData.DefaultView[e.RowIndex]["isActive"])
                    rColor = pIsActive.BackColor;

                dgvData.Rows[e.RowIndex].DefaultCellStyle.BackColor = rColor;
                dgvData.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = rColor;
            }
        }

        private void dgvData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            //Рисуем рамку для выделеной строки
            if (dgv.Rows[e.RowIndex].Selected)
            {
                int width = dgv.Width;
                Rectangle r = dgv.GetRowDisplayRectangle(e.RowIndex, false);
                Rectangle rect = new Rectangle(r.X, r.Y, width - 1, r.Height - 1);

                ControlPaint.DrawBorder(e.Graphics, rect,
                    SystemColors.Highlight, 2, ButtonBorderStyle.Solid,
                    SystemColors.Highlight, 2, ButtonBorderStyle.Solid,
                    SystemColors.Highlight, 2, ButtonBorderStyle.Solid,
                    SystemColors.Highlight, 2, ButtonBorderStyle.Solid);
            }
        }

        private void chbIsActive_CheckedChanged(object sender, EventArgs e)
        {
            filter();
        }
    }
}
