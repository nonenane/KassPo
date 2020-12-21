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
    public partial class frmTerminal : Form
    {
        public bool newData = false;
        public frmTerminal()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            get_data();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            frmAddTerminal frm = new frmAddTerminal();
            frm.Text = "Добавить кассу";
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
                frmAddTerminal frm = new frmAddTerminal();
                frm.Text = "Редактировать кассу";
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
                    string cName = dtData.DefaultView[dgvData.CurrentRow.Index]["IP"].ToString();                    
                    DataTable dtResult = Config.hCntMain.setTerminal(id, -1, "", "", 2,0);
                    if (dtResult != null && dtResult.Rows.Count != 0)
                        if (dtResult.Rows[0]["id"].ToString().Equals("-1"))
                        {MessageBox.Show("Не удалось удалить данные!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);}
                        //else if (dtResult.Rows[0]["id"].ToString().Equals("-3"))
                        //{ MessageBox.Show("Запись переведена в " + (isActiveStatus ? "Недействующие" : "Активные") + "!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                        else
                        {
                            Logging.StartFirstLevel(722);
                            Logging.Comment("Удаление кассы");

                            Logging.Comment("ID кассы:" + id);
                            Logging.Comment("Номер кассы: "+ dtData.DefaultView[dgvData.CurrentRow.Index]["Number"].ToString());
                            Logging.Comment("Путь канала обмена: "+ dtData.DefaultView[dgvData.CurrentRow.Index]["Path"].ToString());
                            Logging.Comment("IP-адресс: "+ dtData.DefaultView[dgvData.CurrentRow.Index]["IP"].ToString());

                            Logging.Comment("Операцию выполнил: ID:" + Nwuram.Framework.Settings.User.UserSettings.User.Id
                                            + " ; ФИО:" + Nwuram.Framework.Settings.User.UserSettings.User.FullUsername);
                            Logging.StopFirstLevel();
                            MessageBox.Show("Запись удалена!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information); 
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
            dtData = Config.hCntMain.getTerminal();
            filter();
            dgvData.DataSource = dtData;
        }

        private void filter()
        {
            try
            {
                string str = "";

                str += string.Format("IP like '%{0}%'", tbName.Text.Trim());

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

                //if (!(bool)dtData.DefaultView[e.RowIndex]["isActive"])
                //    rColor = pIsActive.BackColor;

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
