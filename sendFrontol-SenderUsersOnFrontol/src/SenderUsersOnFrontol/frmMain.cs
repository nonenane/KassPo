using Nwuram.Framework.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;

namespace SenderUsersOnFrontol
{
    public partial class frmMain : Form
    {
        private DataTable dtData;
        private NetworkDrive dr = new NetworkDrive();
        public frmMain()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            dgvStatus.AutoGenerateColumns = false;
            get_data();
            getDateSend();
            this.Text = "\"" + Nwuram.Framework.Settings.Connection.ConnectionSettings.ProgramName + "\", \"" + Nwuram.Framework.Settings.User.UserSettings.User.Status + "\", " + Nwuram.Framework.Settings.User.UserSettings.User.FullUsername + "";
            tsLabel.Text = Nwuram.Framework.Settings.Connection.ConnectionSettings.GetServer() + " " +
              Nwuram.Framework.Settings.Connection.ConnectionSettings.GetDatabase();
        }

        private void get_data()
        {
            dtData = Config.hCntMain.getUser();
            filter_user();
            dgvData.DataSource = dtData;
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tsmiPost_Click(object sender, EventArgs e)
        {
            frmDirPost frm = new frmDirPost();
            frm.ShowDialog();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = MessageBox.Show("Выйти из программы?", "Запрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
        }

        private void tsmiTerminal_Click(object sender, EventArgs e)
        {
            frmTerminal frm = new frmTerminal();
            frm.ShowDialog();            
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            frmAddUser frm = new frmAddUser();
            frm.Text = "Добавить пользователя";
            if (DialogResult.OK == frm.ShowDialog())
            {
                Config.SendUserToTerminal(this);
                get_data();

                if (!createFile(chbDelOldUser.Checked))
                {
                    MessageBox.Show("Необходимо завести пользователей!", "Информирование =^_^=", MessageBoxButtons.OK, MessageBoxIcon.Information);                    
                }

               
                //newData = true;
            }
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null && dgvData.CurrentRow.Index != -1 && dtData != null && dtData.DefaultView.Count != 0)
            {
                frmAddUser frm = new frmAddUser();
                frm.Text = "Редактировать пользователя";
                frm.setRow(dtData.DefaultView[dgvData.CurrentRow.Index]);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    Config.SendUserToTerminal(this);
                    get_data();
                    if (!createFile(chbDelOldUser.Checked))
                    {
                        MessageBox.Show("Необходимо завести пользователей!", "Информирование =^_^=", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                  
                    //newData = true;
                }
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null && dgvData.CurrentRow.Index != -1 && dtData != null && dtData.DefaultView.Count != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Сменить статус?", "Запрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    string id = dtData.DefaultView[dgvData.CurrentRow.Index]["id"].ToString();
                    string INN_Code = dtData.DefaultView[dgvData.CurrentRow.Index]["INN_Code"].ToString();
                    bool isActive = (bool)dtData.DefaultView[dgvData.CurrentRow.Index]["isActive"];
                    //string cName = dtData.DefaultView[dgvData.CurrentRow.Index]["IP"].ToString();
                    //по 1 коннекту isActive = 0
                    DataTable dtTrFirst = Config.trCntK21dbase1.setUser(id, "", "", -1, "", "", INN_Code, 3, id);
                    if (dtTrFirst == null || (dtTrFirst.Rows.Count == 1 && dtTrFirst.Rows[0]["id"].ToString() == "-1"))
                    {
                        Config.trCntK21dbase1.RollbackTransaction();
                        MessageBox.Show("Ошибка смены статуса сотрудника", "Смена статуса", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    DataTable dtTrSecond = Config.trCntX14dbase1.setUser(id, "", "", -1, "", "", INN_Code, 3, id);
                    if (dtTrSecond == null || (dtTrSecond.Rows.Count == 1 && dtTrSecond.Rows[0]["id"].ToString() == "-1"))
                    {
                        Config.trCntK21dbase1.RollbackTransaction();
                        Config.trCntX14dbase1.RollbackTransaction();
                        MessageBox.Show("Ошибка смены статуса сотрудника", "Смена статуса", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    Config.trCntX14dbase1.CommitTransaction();
                    Config.trCntK21dbase1.CommitTransaction();
                    // DataTable dtResult = Config.hCntMain.setUser(id, "", "", -1, "", "", INN_Code, 3, id);

                    //if (dtResult != null && dtResult.Rows.Count != 0)
                    //   if (dtResult.Rows[0]["id"].ToString().Equals("-1"))
                    // { MessageBox.Show("Не удалось удалить данные!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    //else if (dtResult.Rows[0]["id"].ToString().Equals("-3"))
                    //{ MessageBox.Show("Запись переведена в " + (isActiveStatus ? "Недействующие" : "Активные") + "!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    // else
                    //{
                    /*
                    Config.hCntMain.setUserToKassRealiz(id,id, "", "", -1, "", "", 3);
                    Config.hCntSecond.setUserToKassRealiz(id,id, "", "", -1, "", "", 3);
                    */

                    //Config.hCntMain.setUserToKassRealiz(id, id, "", "", -1, "", "", 3);
                    //Config.hCntSecond.setUserToKassRealiz(id, id, "", "", -1, "", "", 3);

                    //Logging.StartFirstLevel(498);
                    Logging.StartFirstLevel(540);
                    Logging.Comment("Перевод пользователя в " + (isActive ? "Неактивные" : "Активные"));


                    Logging.Comment("Код записи: " + id);
                    Logging.Comment("Короткий номер: " + dtData.DefaultView[dgvData.CurrentRow.Index]["Number"].ToString());
                    Logging.Comment("Фамилия И.О.: " + dtData.DefaultView[dgvData.CurrentRow.Index]["FIO"].ToString());
                    Logging.Comment("Профиль: id: " + dtData.DefaultView[dgvData.CurrentRow.Index]["id_post"].ToString());
                    Logging.Comment("Профиль: Наименование: " + dtData.DefaultView[dgvData.CurrentRow.Index]["namePost"].ToString());
                    Logging.Comment("Пароль: " + dtData.DefaultView[dgvData.CurrentRow.Index]["password"].ToString());
                    Logging.Comment("Штрих-Код: " + dtData.DefaultView[dgvData.CurrentRow.Index]["code"].ToString());
                    Logging.Comment("ИНН: " + dtData.DefaultView[dgvData.CurrentRow.Index]["INN_code"].ToString());

                    try
                    {
                        Int64 id_user = id.Length == 0 ? -1 : Int64.Parse(id);
                        DataTable dtShops = Config.hCntMain.getUserShop(id_user);

                        foreach (DataRow rShop in dtShops.Select("isSelect = 1"))
                        {
                            Logging.Comment("Магазин работы: " + rShop["cName"].ToString());
                        }
                    }
                    catch
                    { }

                    Logging.Comment("Операцию выполнил: ID:" + Nwuram.Framework.Settings.User.UserSettings.User.Id
                                    + " ; ФИО:" + Nwuram.Framework.Settings.User.UserSettings.User.FullUsername);
                    Logging.StopFirstLevel();
                    //MessageBox.Show("Запись удалена!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                    //  }

                    //newData = true;
                    Config.SendUserToTerminal(this);
                    get_data();
                    if (!createFile(chbDelOldUser.Checked))
                    {
                        MessageBox.Show("Необходимо завести пользователей!", "Информирование =^_^=", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgvStatus.DataSource = null;

            Config.Login = "kass";
            Config.Password = "kass";
            Config.hCntMain.getLogAndPass();
            //Config.Time = int.Parse(dtConfig.Select("id_value = 'Tim'")[0]["value"].ToString());
            //File.Create("AIn");
            frmSendData frm = new frmSendData();
            if (DialogResult.OK == frm.ShowDialog())
            {
                if (!createFile(chbDelOldUser.Checked))
                {
                    MessageBox.Show("Необходимо завести пользователей!", "Информирование =^_^=", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                dtSendData = frm.setData();
                int countRowAll = dtSendData.Rows.Count;
                dtSendData.DefaultView.RowFilter = "isUsed = 1";
                dtSendData = dtSendData.DefaultView.ToTable();
                int countRowFinish = dtSendData.Rows.Count;

                object isWriteSendData = countRowFinish == countRowAll;

                if (!dtSendData.Columns.Contains("statusSend"))
                    dtSendData.Columns.Add("statusSend", typeof(string));

                Logging.StartFirstLevel(1139);
                Logging.Comment("Состояние передачи");

                Logging.Comment("Удалить старых пользователей :" + (chbDelUsers.Checked ? "Да" : "Нет"));

               // if (frm.setIsSelectedTerminal())
                //{
                    string _terminalList = "";

                    foreach (DataRow row in dtSendData.Rows)
                    {
                        _terminalList += "," + row["Number"].ToString();
                    }
                    _terminalList = _terminalList.Substring(1);

                    Logging.Comment("Выбраны кассы: " + _terminalList);
              //  }
              //  else
             //   {
                    //Logging.Comment("Выбраны все кассы");
             //   }

                if (!bwSend.IsBusy)
                {
                    cntOutEnb.SaveControlsEnabledState(this);
                    cntOutEnb.SetControlsEnabled(this, false);

                    frmLD.clearList();

                    frmOutLoad = new Nwuram.Framework.UI.Forms.frmLoad("Отправка данных...");
                    frmOutLoad.TopMost = false;
                    frmOutLoad.Show();
                    bwSend.RunWorkerAsync(isWriteSendData);
                }

                //foreach (DataRow row in dtSendData.Rows)
                //{
                //    Config.IP = row["IP"].ToString();
                //    Config.Folder = row["Path"].ToString();
                //    int status = connect();
                //    if (status == 0)
                //    {
                //        copy("AIn");
                //        copy("sprav.txt");
                //    }
                //    if (status == 0)
                //        row["statusSend"] = "Ok";
                //    else
                //        if (status == -100)
                //            row["statusSend"] = "Нет Пинга";
                //        else
                //            row["statusSend"] = "Папка недоступна";

                //    disconnect();
                //}
                //dgvStatus.DataSource = dtSendData;
            }
        }

        private int connect()
        {
            Ping pingSender = new Ping();
            PingReply reply = pingSender.Send(Config.IP);
            if (reply.Status != IPStatus.Success)
            {
                Console.WriteLine(-100);
                return -100;
            }

            int result;
            result = dr.MapNetworkDrive(@"\\" + Config.IP + @"\" + Config.Folder, @Config.Login, Config.Password);
            Console.WriteLine(result);

            //String host = System.Net.Dns.GetHostName();
            // Получение ip-адреса.
            //System.Net.IPAddress ip = System.Net.Dns.GetHostEntry(host).AddressList[0];
            // Показ адреса в label'е.
            //Console.WriteLine(ip.ToString());

            if (Directory.Exists(@"\\" + Config.IP + @"\" + Config.Folder))
            {
                return 0;
            }
            return -1;
            /*
            int result;
            result = dr.MapNetworkDrive(@"\\" + Config.IP + @"\" + Config.Folder, @Config.Login, Config.Password);            
            Console.WriteLine(result);

            return result;
             */
        }

        private void disconnect()
        {
            int result;
            result = dr.DeleteNetworkDrive();
        }

        private void copy(string _fileName)
        {
            string source = @"\\\\"+Config.IP + @"\" + Config.Folder;
            string ldest = System.Windows.Forms.Application.StartupPath + @"\Dictonary";
            string spattern = _fileName;//txtFile.Text.Substring(txtFile.Text.LastIndexOf('\\') + 1);

            if (Directory.Exists(source))
            {
                //if (!File.Exists(source + @"\" + spattern))
                //{
                    //CopyMethods.CopyByPattern(source, ldest, spattern);
                    CopyMethods.CopyByPattern(ldest,source, spattern);
                //}
            }
           
        }

        private bool createFile(bool isDelUser,bool isDateDel = false)
        {
            DataTable dtData = Config.hCntMain.getUserToSend();
            int count_to_delete = 0;

            //ConnectionSettings.GetServer().Trim().ToLower()

            if (dtData == null || dtData.Rows.Count == 0)
                return false;

            if (!Directory.Exists("Dictonary"))
                Directory.CreateDirectory("Dictonary");

            if (!File.Exists(@"Dictonary/user.txt"))
                File.Create(@"Dictonary/user.txt");

            System.IO.StreamWriter file = null;
            try
            {
                if (File.Exists(@"Dictonary/UIn"))
                    File.Delete(@"Dictonary/UIn");

                file = new System.IO.StreamWriter(@"Dictonary/UIn", false, Encoding.UTF8);

                file.WriteLine("##@@&&");
                file.WriteLine("#");

                if (isDelUser)
                    file.WriteLine("$$$DELETEALLUSERS");

                //if (chbDelUsers.Checked)
                //    file.WriteLine("$$$DELETEALLUSERS");
                else if(isDateDel)
                {
                    //ТУТ добавление пользователей которых надо удалить
                    DateTime? dateLastSend = Config.hCntMain.getLastDateAdd();
                    DataRow[] rowToDel = null;
                    if (dateLastSend == null)
                        rowToDel = dtData.Select("isActive = 0");
                    else
                        rowToDel = dtData.Select(String.Format("isActive = 0 and DateEdit > '{0}' ", dateLastSend));

                    if (rowToDel.Count() > 0)
                    {
                        count_to_delete = rowToDel.Count();
                        file.WriteLine("$$$DELETEUSERSBYCODE");
                        foreach (DataRow rDel in rowToDel)
                        {
                            file.WriteLine(rDel["id"].ToString());
                        }
                    }
                }

                file.WriteLine("$$$ADDUSERS");

                int i = 1;

                foreach (DataRow row in dtData.Select("isActive = 1"))
                {
                    file.WriteLine(row["id"].ToString()//.PadLeft(6,'0') 

                        + ";" + row["Number"].ToString()/*.PadLeft(4, '0')*/// + row["FIO"].ToString()
                        + " " + row["FIO"].ToString()
                        + ";" + row["FIO"].ToString()
                        + ";" + row["codeFrontol"].ToString()
                        //+ ";" + row["codeFrontol"].ToString()//.PadLeft(12, '0')
                        + ";" + row["password"].ToString()
                        + ";" + row["code"].ToString()
                        + ";" + row["INN_Code"].ToString());
                    i++;
                }

                Logging.StartFirstLevel(821);
                Logging.Comment("Выгрузка файла");

                if (chbDelUsers.Checked)
                {
                    Logging.Comment("Удаление всех пользователей");
                }
                else
                {
                    Logging.Comment("Пользователей на удаление " + count_to_delete);
                }

                Logging.Comment("Пользователей на добавление " + dtData.Select("isActive = 1").Count());


                Logging.Comment("Операцию выполнил: ID:" + Nwuram.Framework.Settings.User.UserSettings.User.Id
                                + " ; ФИО:" + Nwuram.Framework.Settings.User.UserSettings.User.FullUsername);
                Logging.StopFirstLevel();

            }
            catch (Exception ex)
            {
                //fileLog.WriteLine("Ошибка при формирование справочника: " + ex.Message);
                //fileLog.WriteLine("Файл справочника не сформирован: " + DateTime.Now.ToString());
                file.Close();
                File.Delete(@"Dictonary/UIn");
                return false;
            }
            finally
            {
                file.Close();
            }
            return true;
        }

        DataTable dtSendData;
        private Nwuram.Framework.UI.Service.EnableControlsServiceInProg cntOutEnb = new Nwuram.Framework.UI.Service.EnableControlsServiceInProg();
        private Nwuram.Framework.UI.Forms.frmLoad frmOutLoad = new Nwuram.Framework.UI.Forms.frmLoad();

        private void bwSend_DoWork(object sender, DoWorkEventArgs e)
        {
            bool isWriteSendData = (bool)e.Argument;
            //ТУТ формировать список кого надо удалить 

            //Запись времени заливки данных на кассу
            //Config.hCntMain.setDateSend();

           DataTable dtDataValidateTerminal = Config.hCntMain.getTerminal();
            bool isShowMsg = false;
            foreach (DataRow row in dtSendData.Rows)
            {

                if (dtDataValidateTerminal.AsEnumerable().Where(r => r.Field<int>("id") == (int)row["id"]).Count() == 0) isShowMsg = true;

                Config.IP = row["IP"].ToString();
                Config.Folder = row["Path"].ToString();
                int status = connect();
                if (status == 0)
                {
                    copy("UIn");
                    copy("user.txt");
                }

                if (status == 0)
                {
                    Logging.Comment("Касса №" + row["Number"].ToString() + " Статус передачи: Ok");
                    row["statusSend"] = "Ok";
                    Config.hCntMain.SetTerminalUserUpdate((int)row["id"]);
                }
                else
                    if (status == -100)
                    {
                        Logging.Comment("Касса №" + row["Number"].ToString() + " Статус передачи: Нет Пинга");
                        row["statusSend"] = "Нет Пинга";
                    }
                    else
                    {
                        Logging.Comment("Касса №" + row["Number"].ToString() + " Статус передачи: Папка недоступна");
                        row["statusSend"] = "Папка недоступна";
                    }

                Action action = () => frmLD.add(row["Number"].ToString(), row["IP"].ToString(), row["statusSend"].ToString());
                // Свойство InvokeRequired указывает, нeжно ли обращаться к контролу с помощью Invoke
                if (InvokeRequired)
                    Invoke(action);
                else
                    action();

                

                disconnect();
            }

            //Запись времени заливки данных на кассу
            if (isWriteSendData)
                Config.hCntMain.setDateSend();

            if (isShowMsg)
            {
                MessageBox.Show("Некоторые кассы были удалены", "Инфомирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bwSend_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Logging.Comment("Операцию выполнил: ID:" + Nwuram.Framework.Settings.User.UserSettings.User.Id
                   + " ; ФИО:" + Nwuram.Framework.Settings.User.UserSettings.User.FullUsername);
            Logging.StopFirstLevel();
            cntOutEnb.RestoreControlEnabledState(this);
            frmOutLoad.Dispose();
            dgvStatus.DataSource = dtSendData;
            getDateSend();
            GetDataTerminal();
        }

        private void tbFIO_TextChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn column in dgvData.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
                dtData.DefaultView.Sort = "FIO";
            }
            filter_user();
        }

        private void filter_user()
        {
            if (dtData != null)
            {
                string _filter = "";
                try
                {

                    if (tbFIO.Text.Trim().Length != 0)
                        _filter += (_filter.Trim().Length == 0 ? "" : " AND ") + string.Format("FIO like '%{0}%'", tbFIO.Text);

                    if(!chbUn.Checked)
                        _filter += (_filter.Trim().Length == 0 ? "" : " AND ") + string.Format("isActive = 1", "");

                }
                catch
                {
                    _filter = "terminal  = -1";
                }

                dtData.DefaultView.RowFilter = _filter;
                dtData.DefaultView.Sort = "id asc,namePost ASC,FIO ASC";
                btDelete.Enabled = btEdit.Enabled = dtData.DefaultView.Count != 0;                
            }

            dgvData_SelectionChanged(null, null);
        }

        private void dgvData_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvData.CurrentRow != null && dgvData.CurrentRow.Index != -1 && dtData != null && dtData.DefaultView.Count != 0)
                {
                    tbDateEdit.Text = dtData.DefaultView[dgvData.CurrentRow.Index]["dateEdit"].ToString();
                    btEdit.Enabled = (bool)dtData.DefaultView[dgvData.CurrentRow.Index]["isActive"];
                }
            }
            catch
            {
                tbDateEdit.Text = "";
                btEdit.Enabled = false;
            }
        }

        private void getDateSend()
        {
            DataTable dtSend = Config.hCntMain.getDateSend();
            if (dtSend != null && dtSend.Rows.Count > 0)
                tbDateSend.Text = (dtSend.Rows[0][0] == DBNull.Value ? "Не было отправок!" : dtSend.Rows[0][0].ToString());
        }

        private void tbLoadToFile_Click(object sender, EventArgs e)
        {
            if (!createFile(chbDelOldUser.Checked))
            {
                MessageBox.Show("Необходимо завести пользователей!", "Информирование =^_^=", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MessageBox.Show("Справочники созданы!", "Информирование =^_^=", MessageBoxButtons.OK, MessageBoxIcon.Information);

            string path = @"Dictonary";
            System.Diagnostics.Process.Start(path);

        }
        
        private void strageCheckBox1_Unchecked(object sender, EventArgs e)
        {
            if (chbDelUsers.Checked)
            {
                frmPassWord frmPas = new frmPassWord();
                if (DialogResult.Cancel == frmPas.ShowDialog())
                    chbDelUsers.Checked = false;
            }
        }

        private void dgvData_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvData.CurrentRow != null && e.RowIndex > -1 && dtData != null && dtData.DefaultView.Count != 0)
            {
                frmAddUser frm = new frmAddUser();
                frm.Text = "Редактировать пользователя";
                frm.setRow(dtData.DefaultView[dgvData.CurrentRow.Index]);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    get_data();
                    if (!createFile(chbDelOldUser.Checked))
                    {
                        MessageBox.Show("Необходимо завести пользователей!", "Информирование =^_^=", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    //newData = true;
                }
            }
        }

        private void ChbUn_CheckedChanged(object sender, EventArgs e)
        {
            filter_user();
        }

        private void DgvData_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            Color rColor = Color.White;
            try
            {

                if (!(bool)dtData.DefaultView[e.RowIndex]["isActive"]) rColor = Color.Yellow;
            }
            catch { }

            dgvData.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvData.Rows[e.RowIndex].DefaultCellStyle.BackColor =
                dgvData.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor= rColor;


        }

        private void DgvData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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


        private frmLogLoadData frmLD = new frmLogLoadData();

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.L && e.Modifiers == Keys.Control)
            {
                frmLD.Show();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            get_data();
        }

        private void dgvStatus_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            Color rColor = Color.White;

            dgvStatus.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvStatus.Rows[e.RowIndex].DefaultCellStyle.BackColor =
                dgvStatus.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = rColor;
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

        private void frmMain_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tbStatusSend);
            dgvTerminal.AutoGenerateColumns = false;
            GetTerminalType();
            GetDataTerminal();
        }

        #region "Кассы"
        private DataTable dtTerminal;

        private void GetDataTerminal()
        {
            dtTerminal = Config.hCntMain.getTerminal();
            FilterTerminal();
            dgvTerminal.DataSource = dtTerminal;
        }

        private void FilterTerminal()
        {
            try
            {
                string str = "";
                if (tbIP.Text.Trim().Length > 0)
                    str += (str.Trim().Length == 0 ? "" : " and ") + $"IP like '%{tbIP.Text.Trim()}%'";

                if (tbChannel.Text.Trim().Length > 0)
                    str += (str.Trim().Length == 0 ? "" : " and ") + $"Path like '%{tbChannel.Text.Trim()}%'";

                if ((byte)cmbTerminalType.SelectedValue != 0)
                    str += (str.Trim().Length == 0 ? "" : " and ") + $"id_TerminalType = {cmbTerminalType.SelectedValue}";

                if (chbIsActive.Checked) str += (str.Trim().Length == 0 ? "" : " and ") + $"isError = 1";

                dtTerminal.DefaultView.RowFilter = str;
                btTerminalDel.Enabled = btTerminalEdit.Enabled = dtTerminal.DefaultView.Count != 0;
            }
            catch
            {
                dtTerminal.DefaultView.RowFilter = "id = -9999";
                btTerminalDel.Enabled = btTerminalEdit.Enabled = dtTerminal.DefaultView.Count != 0;
            }
            dgvTerminal_SelectionChanged(null, null);
        }

        private void GetTerminalType()
        {
            DataTable dtTerminalType = Config.hCntMain.GetTerminalType(true);
            cmbTerminalType.DataSource = dtTerminalType;
            cmbTerminalType.ValueMember = "id";
            cmbTerminalType.DisplayMember = "NameTerminalType";
        }

        #endregion

        private void dgvTerminal_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex != -1 && dtTerminal != null && dtTerminal.DefaultView.Count != 0)
            {
                Color rColor = Color.White;

                if ((bool)dtTerminal.DefaultView[e.RowIndex]["isError"])
                    rColor = pIsActive.BackColor;

                dgvTerminal.Rows[e.RowIndex].DefaultCellStyle.BackColor = 
                dgvTerminal.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = rColor;
                dgvTerminal.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
            }
        }

        private void dgvTerminal_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            int width = 0;

            foreach (DataGridViewColumn col in dgvTerminal.Columns)
            {
                if (!col.Visible) continue;

                if (col.Name.Equals(cTerIP.Name)) {
                    tbIP.Location = new Point(dgvTerminal.Location.X + 1 + width, tbIP.Location.Y);
                    tbIP.Size = new Size(col.Width, tbIP.Size.Height);
                }

                if (col.Name.Equals(cTerChannel.Name))
                {
                    tbChannel.Location = new Point(dgvTerminal.Location.X + 1 + width, tbIP.Location.Y);
                    tbChannel.Size = new Size(col.Width, tbIP.Size.Height);
                }

                width += col.Width;
            }
        }

        private void dgvTerminal_SelectionChanged(object sender, EventArgs e)
        {
            if (dtTerminal == null || dtTerminal.Rows.Count == 0 || dtTerminal.DefaultView.Count == 0)
            {
                btTerminalEdit.Enabled = btTerminalDel.Enabled = false;
                return;
            }
            try
            {
                //btTerminalEdit.Enabled = 
            }
            catch
            {
                btTerminalEdit.Enabled = btTerminalDel.Enabled = false;
                return;
            }
        }

        private void btTerminalAdd_Click(object sender, EventArgs e)
        {
            frmAddTerminal frm = new frmAddTerminal();
            frm.Text = "Добавить кассу";
            if (DialogResult.OK == frm.ShowDialog())
            {
                GetDataTerminal();
            }
        }

        private void btTerminalEdit_Click(object sender, EventArgs e)
        {
            if (dgvTerminal.CurrentRow != null && dgvTerminal.CurrentRow.Index != -1 && dtTerminal != null && dtTerminal.DefaultView.Count != 0)
            {
                frmAddTerminal frm = new frmAddTerminal();
                frm.Text = "Редактировать кассу";
                frm.setRow(dtTerminal.DefaultView[dgvTerminal.CurrentRow.Index]);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    GetDataTerminal();
                }
            }
        }

        private void btTerminalDel_Click(object sender, EventArgs e)
        {
            if (dgvTerminal.CurrentRow != null && dgvTerminal.CurrentRow.Index != -1 && dtTerminal != null && dtTerminal.DefaultView.Count != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Удалить выбранную кассу из программы?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    int id = int.Parse(dtTerminal.DefaultView[dgvTerminal.CurrentRow.Index]["id"].ToString());
                    string cName = dtTerminal.DefaultView[dgvTerminal.CurrentRow.Index]["IP"].ToString();
                    DataTable dtResult = Config.hCntMain.setTerminal(id, -1, "", "", 2, 0);
                    if (dtResult != null && dtResult.Rows.Count != 0)
                        if (dtResult.Rows[0]["id"].ToString().Equals("-1"))
                        { MessageBox.Show("Не удалось удалить данные!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                        //else if (dtResult.Rows[0]["id"].ToString().Equals("-3"))
                        //{ MessageBox.Show("Запись переведена в " + (isActiveStatus ? "Недействующие" : "Активные") + "!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                        else
                        {
                            Logging.StartFirstLevel(722);
                            Logging.Comment("Удаление кассы");

                            Logging.Comment("ID кассы:" + id);
                            Logging.Comment("Номер кассы: " + dtTerminal.DefaultView[dgvTerminal.CurrentRow.Index]["Number"].ToString());
                            Logging.Comment("Путь канала обмена: " + dtTerminal.DefaultView[dgvTerminal.CurrentRow.Index]["Path"].ToString());
                            Logging.Comment("IP-адресс: " + dtTerminal.DefaultView[dgvTerminal.CurrentRow.Index]["IP"].ToString());

                            Logging.Comment("Операцию выполнил: ID:" + Nwuram.Framework.Settings.User.UserSettings.User.Id
                                            + " ; ФИО:" + Nwuram.Framework.Settings.User.UserSettings.User.FullUsername);
                            Logging.StopFirstLevel();
                            MessageBox.Show("Запись удалена!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    GetDataTerminal();

                }
            }
        }
             
        private void btTerminalUpdate_Click(object sender, EventArgs e)
        {
            GetDataTerminal();
        }

        private void cmbTerminalType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FilterTerminal();
        }

        private void chbIsActive_Click(object sender, EventArgs e)
        {
            FilterTerminal();
        }

        private void btTerminalSendUsers_Click(object sender, EventArgs e)
        {
            dgvStatus.DataSource = null;

            Config.Login = "kass";
            Config.Password = "kass";
            Config.hCntMain.getLogAndPass();
            NewSendUserToTerminal();
            return;
            //Config.Time = int.Parse(dtConfig.Select("id_value = 'Tim'")[0]["value"].ToString());
            //File.Create("AIn");
            frmSendData frm = new frmSendData();
            if (DialogResult.OK == frm.ShowDialog())
            {
                bool isDelUser = frm.GetDelUsers();

                if (!createFile(isDelUser, true))
                {
                    MessageBox.Show("Необходимо завести пользователей!", "Информирование =^_^=", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                dtSendData = frm.setData();
                int countRowAll = dtSendData.Rows.Count;
                dtSendData.DefaultView.RowFilter = "isUsed = 1";
                dtSendData = dtSendData.DefaultView.ToTable();
                int countRowFinish = dtSendData.Rows.Count;

                object isWriteSendData = countRowFinish == countRowAll;

                if (!dtSendData.Columns.Contains("statusSend"))
                    dtSendData.Columns.Add("statusSend", typeof(string));

                Logging.StartFirstLevel(1139);
                Logging.Comment("Состояние передачи");

                Logging.Comment("Удалить старых пользователей :" + (isDelUser ? "Да" : "Нет"));

                // if (frm.setIsSelectedTerminal())
                //{
                string _terminalList = "";

                foreach (DataRow row in dtSendData.Rows)
                {
                    _terminalList += "," + row["Number"].ToString();
                }
                _terminalList = _terminalList.Substring(1);

                Logging.Comment("Выбраны кассы: " + _terminalList);
                //  }
                //  else
                //   {
                //Logging.Comment("Выбраны все кассы");
                //   }

                if (!bwSend.IsBusy)
                {
                    cntOutEnb.SaveControlsEnabledState(this);
                    cntOutEnb.SetControlsEnabled(this, false);

                    frmLD.clearList();

                    frmOutLoad = new Nwuram.Framework.UI.Forms.frmLoad("Отправка данных...");
                    frmOutLoad.TopMost = false;
                    frmOutLoad.Show();
                    bwSend.RunWorkerAsync(isWriteSendData);
                }

                //foreach (DataRow row in dtSendData.Rows)
                //{
                //    Config.IP = row["IP"].ToString();
                //    Config.Folder = row["Path"].ToString();
                //    int status = connect();
                //    if (status == 0)
                //    {
                //        copy("AIn");
                //        copy("sprav.txt");
                //    }
                //    if (status == 0)
                //        row["statusSend"] = "Ok";
                //    else
                //        if (status == -100)
                //            row["statusSend"] = "Нет Пинга";
                //        else
                //            row["statusSend"] = "Папка недоступна";

                //    disconnect();
                //}
                //dgvStatus.DataSource = dtSendData;
            }
        }

        public void NewSendUserToTerminal()
        {
            frmSendData frm = new frmSendData();
            if (DialogResult.OK == frm.ShowDialog())
            {
                bool isDelUser = frm.GetDelUsers();

                if (!createFile(isDelUser, true))
                {
                    MessageBox.Show("Необходимо завести пользователей!", "Информирование =^_^=", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                dtSendData = frm.setData();
                int countRowAll = dtSendData.Rows.Count;
                dtSendData.DefaultView.RowFilter = "isUsed = 1";
                dtSendData = dtSendData.DefaultView.ToTable();
                int countRowFinish = dtSendData.Rows.Count;

                object isWriteSendData = countRowFinish == countRowAll;

                if (!dtSendData.Columns.Contains("statusSend"))
                    dtSendData.Columns.Add("statusSend", typeof(string));

                Logging.StartFirstLevel(1139);
                Logging.Comment("Состояние передачи");

                Logging.Comment("Удалить старых пользователей :" + (isDelUser ? "Да" : "Нет"));

                string _terminalList = "";

                foreach (DataRow row in dtSendData.Rows)
                {
                    _terminalList += "," + row["Number"].ToString();
                }
                _terminalList = _terminalList.Substring(1);

                Logging.Comment("Выбраны кассы: " + _terminalList);

                if (!bwSend.IsBusy)
                {
                    cntOutEnb.SaveControlsEnabledState(this);
                    cntOutEnb.SetControlsEnabled(this, false);

                    frmLD.clearList();

                    frmOutLoad = new Nwuram.Framework.UI.Forms.frmLoad("Отправка данных...");
                    frmOutLoad.TopMost = false;
                    frmOutLoad.Show();
                    bwSend.RunWorkerAsync(isWriteSendData);
                }               
            }
        }

        private void tbIP_TextChanged(object sender, EventArgs e)
        {
            FilterTerminal();
        }

        private void dgvData_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            int width = 0;
            foreach (DataGridViewColumn col in dgvData.Columns)
            {
                if (!col.Visible) continue;

                if (col.Name.Equals(cFIO.Name))
                {
                    tbFIO.Location = new Point(dgvData.Location.X + 1 + width, tbFIO.Location.Y);
                    tbFIO.Size = new Size(col.Width, tbFIO.Size.Height);
                }

                width += col.Width;
            }
        }
    }
}
