using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xPosRealiz;

namespace xPosRealiz_sprav_shues
{
    public partial class frmSetting : Form
    {
        private bool isEditData = false;
        public frmSetting()
        {
            InitializeComponent();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            SQL.setSettings("kmgs", checkBox1.Checked.ToString());
            MessageBox.Show("Данные сохранены.", "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
            isEditData = false;
            this.DialogResult = DialogResult.OK;
        }

        private void frmSetting_Load(object sender, EventArgs e)
        {
            bool defaultValue = false;
            DataTable dtTmp = SQL.getSettings("kmgs");

            if (dtTmp != null && dtTmp.Rows.Count > 0)
                try
                {
                    defaultValue = bool.Parse(dtTmp.Rows[0]["value"].ToString());
                }
                catch { defaultValue = false; }

            checkBox1.Checked = defaultValue;
        }

        private void frmSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = isEditData && DialogResult.No == MessageBox.Show("На форме есть не сохранённые данные.\nЗакрыть форму без сохранения данных?\n", "Закрытие формы", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            isEditData = true;
        }
    }
}
