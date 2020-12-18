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
    public partial class frmPassWord : Form
    {
        private string password = "";

        public frmPassWord()
        {
            InitializeComponent();
            password = Config.hCntMain.getPassWord();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            Logging.StartFirstLevel(162);
            Logging.Comment("Операцию выполнил: ID:" + Nwuram.Framework.Settings.User.UserSettings.User.Id
                            + " ; ФИО:" + Nwuram.Framework.Settings.User.UserSettings.User.FullUsername);
            Logging.StopFirstLevel();  

            if (!tbPassWord.Text.Equals(password))
            {
                
                MessageBox.Show("Неверный пароль!","Информирование",MessageBoxButtons.OK,MessageBoxIcon.Information);

                Logging.StartFirstLevel(328);
                Logging.Comment("Операцию выполнил: ID:" + Nwuram.Framework.Settings.User.UserSettings.User.Id
                                + " ; ФИО:" + Nwuram.Framework.Settings.User.UserSettings.User.FullUsername);
                Logging.StopFirstLevel();  

                tbPassWord.Clear();
                return;
            }


            Logging.StartFirstLevel(327);                      
            Logging.Comment("Операцию выполнил: ID:" + Nwuram.Framework.Settings.User.UserSettings.User.Id
                            + " ; ФИО:" + Nwuram.Framework.Settings.User.UserSettings.User.FullUsername);
            Logging.StopFirstLevel();  

            this.DialogResult = DialogResult.OK;
        }
    }
}

