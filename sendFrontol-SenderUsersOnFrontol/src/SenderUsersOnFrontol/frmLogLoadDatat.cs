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
    public partial class frmLogLoadData : Form
    {
        public frmLogLoadData()
        {
            InitializeComponent();            
        }

        private void FrmLogLoadData_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true;
        }

        public void clearList()
        {
            listView1.Items.Clear();
        }

        public void add(string name, string IP, string status)
        {
            listView1.Items.Add(new ListViewItem(new string[] { name, IP, status }));
        }
    }
}
