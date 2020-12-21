using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ViewSalesPromProducts
{
    public partial class frmSetting : Form
    {
        public frmSetting()
        {
            InitializeComponent();
        }

        private void frmSetting_Load(object sender, EventArgs e)
        {
            DataTable dtData = Config.connectMain.getSettings("pfu1");
            if (dtData != null && dtData.Rows.Count > 0 && dtData.Rows[0]["value"] != null)
            {
                bool valueDec;
                if (bool.TryParse(dtData.Rows[0]["value"].ToString(), out valueDec))
                {
                    checkBox1.Checked = valueDec;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            Config.connectMain.setSettings("pfu1", checkBox1.Checked.ToString());

            MessageBox.Show("Данные сохранены.", "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
        }
    }
}
