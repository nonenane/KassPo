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
    public partial class frmSendData : Form
    {
        public bool GetDelUsers()
        {
            return chbDelOldUser.Checked;
        }
        public DataTable setData()
        {
            DataTable dtTmp = dtData.Copy();
           // if (rbSelected.Checked)
           // {
                dtTmp.DefaultView.RowFilter = "isUsed = 1";
                dtTmp = dtTmp.DefaultView.ToTable();
            //}
            return dtTmp;
        }
      
        public frmSendData()
        {
            InitializeComponent();
            GetTerminalType();
            dgvTerminal.AutoGenerateColumns = false;
            getData();
            //rbSelected_CheckedChanged(null, null);
        }

        private DataTable dtData;
        private int count_row = 0;
        private void getData()
        {
            dtData = Config.hCntMain.getTerminal();
            if (!dtData.Columns.Contains("isUsed"))
            {
                DataColumn col = new DataColumn("isUsed", typeof(Boolean));
                col.DefaultValue = false;
                dtData.Columns.Add(col);
            }
            dgvTerminal.DataSource = dtData;
            count_row = dtData.Rows.Count;
        }

        private void rbSelected_CheckedChanged(object sender, EventArgs e)
        {
            dgvTerminal.Enabled = rbSelected.Checked;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btSend_MouseClick(object sender, EventArgs e)
        {
            if (dtData == null || dtData.Rows.Count == 0)
            {
                MessageBox.Show("Необходимо завести кассы!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool check = false;
            for (int i = 0; i < dtData.Rows.Count; i++)
            {
                if (bool.Parse(dtData.DefaultView[i]["isUsed"].ToString()) == true)
                { check = true; break; }
            }

            //if (!(check) && rbSelected.Checked)
            if (!check)
            {
                MessageBox.Show("Необходимо выбрать кассы!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            dtData.AcceptChanges();
            this.DialogResult = DialogResult.OK;
        }

        private void dgvTerminal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && dgvTerminal.Columns[e.ColumnIndex].Name == "cSelected")
            {
                bool _isControl = false;
                if (dtData.DefaultView[e.RowIndex]["isUsed"] != DBNull.Value)
                    _isControl = bool.Parse(dtData.DefaultView[e.RowIndex]["isUsed"].ToString());

                dtData.DefaultView[e.RowIndex]["isUsed"] = !_isControl;

                dgvTerminal.Refresh();
                update_status_checkbox();
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

        private void CheckBox1_CheckStateChanged(object sender, EventArgs e)
        {

        }

        private void update_status_checkbox()
        {
            if (dtData.DefaultView.ToTable().Select("isUsed = 1").Count() == count_row) checkBox1.CheckState = CheckState.Checked;
            else if (dtData.DefaultView.ToTable().Select("isUsed = 0").Count() == count_row) checkBox1.CheckState = CheckState.Unchecked;
            else checkBox1.CheckState = CheckState.Indeterminate;

        }

        private void CheckBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                foreach (DataRowView r in dtData.DefaultView)
                {
                    r["isUsed"] = true;
                }
            }
            else
             if (checkBox1.CheckState == CheckState.Unchecked)
            {
                foreach (DataRowView r in dtData.DefaultView)
                {
                    r["isUsed"] = false;
                }
            }
            else
            {

            }
            dtData.AcceptChanges();
        }

        private void GetTerminalType()
        {
            DataTable dtTerminalType = Config.hCntMain.GetTerminalType(true);
            cmbTerminalType.DataSource = dtTerminalType;
            cmbTerminalType.ValueMember = "id";
            cmbTerminalType.DisplayMember = "NameTerminalType";
        }

        private void cmbTerminalType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FilterTerminal();
        }

        private void FilterTerminal()
        {
            try
            {
                string str = "";

                if ((byte)cmbTerminalType.SelectedValue != 0)
                    str += (str.Trim().Length == 0 ? "" : " and ") + $"id_TerminalType = {cmbTerminalType.SelectedValue}";

                dtData.DefaultView.RowFilter = str;
                //dtData.DefaultView.Count != 0;
            }
            catch
            {
                dtData.DefaultView.RowFilter = "id = -9999";
                //dtData.DefaultView.Count != 0;
            }
            //dgvTerminal_SelectionChanged(null, null);
        }

        private void chbDelOldUser_Click(object sender, EventArgs e)
        {
            if (chbDelOldUser.Checked)
            {
                frmPassWord fPass = new frmPassWord();
                if (DialogResult.Cancel == fPass.ShowDialog())
                {
                    chbDelOldUser.Checked = false;
                    return;
                }
            }
        }
    }
}
