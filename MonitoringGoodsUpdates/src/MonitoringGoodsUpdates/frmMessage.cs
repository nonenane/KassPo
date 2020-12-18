using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MonitoringGoodsUpdates
{
    public partial class frmMessage : Form
    {
        private string goods = "";
        public frmMessage(string goods)
        {
            this.goods = goods;
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMessage_Load(object sender, EventArgs e)
        {
            txtGoods.Text = goods;
        }
    }
}
