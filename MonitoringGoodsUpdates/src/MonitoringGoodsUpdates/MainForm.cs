using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nwuram.Framework.ToExcel;
using Nwuram.Framework.Logging;

namespace MonitoringGoodsUpdates
{
    public partial class MainForm : Form
    {
        int update_interval_minute = 0;
        List<int> errors = new List<int>();
        int current_monitoring_index = 0;
        int current_terminal_index = 0;
        frmMessage frm = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvPrices_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            SetBorders(sender, e);
        }

        private void dgvPrices_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                PaintRow(dgvMonitoring.Rows[e.RowIndex], "id_status");
            }
        }

        private void PaintRow(DataGridViewRow row, string column_name)
        {
            Color color = Color.White;

            switch (Convert.ToInt32(row.Cells[column_name].Value))
            {
                case 1:
                    color = pnlSending.BackColor;
                    break;
                case 2:
                    color = pnlSent.BackColor;
                    break;
                case 3:
                    color = pnlError.BackColor;
                    break;
            }

            row.DefaultCellStyle.BackColor = row.DefaultCellStyle.SelectionBackColor = color;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshMonitoring();
        }

        private void RefreshMonitoring()
        {
            if (dgvMonitoring.CurrentRow != null && dgvTerminals.CurrentRow != null)
            {
                current_monitoring_index = dgvMonitoring.CurrentRow.Index;
                current_terminal_index = dgvTerminals.CurrentRow.Index;
            }
            
            dgvMonitoring.AutoGenerateColumns = false;
            dgvMonitoring.DataSource = Procedures.GetGoodsUpdates(dtpDate.Value.Date);
            
            if (current_monitoring_index != 0 && current_terminal_index != 0)
            {
                dgvMonitoring.CurrentCell = current_monitoring_index < dgvMonitoring.RowCount ? dgvMonitoring.Rows[current_monitoring_index].Cells["ean"] : dgvMonitoring.Rows[dgvMonitoring.RowCount - 1].Cells["ean"];
                dgvTerminals.CurrentCell = current_terminal_index < dgvTerminals.RowCount ? dgvTerminals.Rows[current_terminal_index].Cells["terminal"] : dgvTerminals.Rows[dgvTerminals.RowCount - 1].Cells["ean"];
            }

            CheckErrors();
        }

        private void CheckErrors()
        {
            if (dgvMonitoring.DataSource != null)
            {
                List<DataRow> error_rows = (dgvMonitoring.DataSource as DataTable).AsEnumerable().Where(r => Convert.ToInt32(r["id_status"]) == 3).ToList<DataRow>();
                if (error_rows.Count > 0)
                {
                    bool exist_new = false;
                    foreach (DataRow row in error_rows)
                    {
                        if (!errors.Contains(Convert.ToInt32(row["id_goods_updates"])))
                        {
                            errors.Add(Convert.ToInt32(row["id_goods_updates"]));
                            exist_new = true;
                        }
                    }

                    List<int> id_to_delete = errors.Where(i => error_rows.FirstOrDefault(r => Convert.ToInt32(r["id_goods_updates"]) == i) == null).ToList<int>();
                    id_to_delete.ForEach(i => errors.Remove(i));

                    if (exist_new)
                    {
                        ShowMessage();
                    }
                }
            }
        }

        private void ShowMessage()
        {
            if (errors.Count > 0)
            {
                string goods = "";
                DataTable dt = dgvMonitoring.DataSource as DataTable;
                foreach (int error_id in errors)
                {
                    DataRow row = dt.AsEnumerable().FirstOrDefault(r => Convert.ToInt32(r["id_goods_updates"]) == error_id);
                    if (row != null)
                    {
                        goods += (goods.Length > 0 ? "\r\n" : "") + row["ean"].ToString() + "     " + row["name"].ToString();
                    }
                }

                if (frm != null)
                {
                    frm.Close();
                }

                frm = new frmMessage(goods);
                frm.TopMost = true;
                frm.Show();
            }
        }

        private void dgvMonitoring_CurrentCellChanged(object sender, EventArgs e)
        {
            dgvTerminals_Load();
        }

        private void dgvTerminals_Load()
        {
            if (dgvMonitoring.CurrentRow == null)
            {
                dgvTerminals.DataSource = null;
            }
            else
            {
                dgvTerminals.AutoGenerateColumns = false;
                int id_departments = (int)dgvMonitoring.CurrentRow.Cells["id_departments"].Value;
                dgvTerminals.DataSource = Procedures.GetGoodsUpdatesTerminals(Convert.ToInt32(dgvMonitoring.CurrentRow.Cells["id_goods_updates"].Value), Convert.ToDateTime(dgvMonitoring.CurrentRow.Cells["time_send"].Value), id_departments);
            }
        }

        private void dgvTerminals_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            SetBorders(sender, e);
        }

        private void dgvTerminals_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                PaintRow(dgvTerminals.Rows[e.RowIndex], "id_status_terminal");
            }
        }

        private void SetBorders(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
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

        private void MainForm_Load(object sender, EventArgs e)
        {
            cbOnline.Checked = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            RefreshMonitoring();
        }

        private void cbOnline_CheckedChanged(object sender, EventArgs e)
        {
            dtpDate.Enabled = btnRefresh.Enabled = !cbOnline.Checked;
            if (cbOnline.Checked)
            {
                //timer.Interval = update_interval_minute * 60 * 1000;
                timer.Start();
                timer_message.Start();

                dtpDate.Value = DateTime.Today;
                //RefreshMonitoring();
            }
            else
            {
                timer.Stop();
                timer_message.Stop();
            }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            RefreshMonitoring();
        }

        private void timer_message_Tick(object sender, EventArgs e)
        {
            ShowMessage();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataTable data = (dgvMonitoring.DataSource as DataTable).Copy();
            DataRow[] rows = data.Select("len(not_sent_terminals) > 0");
            if (rows.Length > 0)
            {
                Report report = new Report();

                DataTable data_print = rows.CopyToDataTable();
                data_print.Columns.Remove("id_goods_updates");
                data_print.Columns.Remove("price");
                data_print.Columns.Remove("old_price");
                data_print.Columns.Remove("dep_name");
                data_print.Columns.Remove("id_status");

                report.AddSingleValue("{date}", DateTime.Now.ToString());
                report.AddMultiValues(data_print, "t");                

                if (!report.CreateTemplate(Application.StartupPath + "\\Templates\\report", Application.StartupPath + "\\report", null))
                {
                    Logger.NewMessage(report.ErrorMessage);
                }

                report.OpenFile(Application.StartupPath + "\\report");
            }
            else
            {
                MessageBox.Show("Нет данных для отчёта!");
            }
        }
    }
}
