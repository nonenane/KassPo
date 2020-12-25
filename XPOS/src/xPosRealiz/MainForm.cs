using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Configuration;
using System.Threading.Tasks;
using Newtonsoft.Json;
using xPosRealiz_sprav_shues;

namespace xPosRealiz
{
    public partial class MainForm : Form
    {
        private static List<string> path = new List<string>();
        private static List<int> terminals = new List<int>();
        private static List<long> ids = new List<long>();
        private static List<long> oldids = new List<long>();
        public static bool можно = true;
        public static bool spravYes = true;
        public static long lastID = 0;
        public static string[] sterms;
        public static bool use;

        private DataTable dtSpravTerminal;
        private Nwuram.Framework.UI.Service.EnableControlsServiceInProg blocker = new Nwuram.Framework.UI.Service.EnableControlsServiceInProg();
        private Nwuram.Framework.UI.Forms.frmLoad fLoad;

        public MainForm()
        {
            //isStartApplication = true;
            InitializeComponent();
            

            use = bool.Parse(ConfigurationManager.AppSettings["use"].ToString());
            sterms = ConfigurationManager.AppSettings["terminals"].Split(',');
            DataTable dt = SQL.getLastId();
            foreach (DataRow dr in dt.Rows)
            {
                if (use && sterms.Contains(dr["number"].ToString()))
                {
                    path.Add(dr["path"].ToString());
                    terminals.Add(Convert.ToInt32(dr["number"].ToString()));
                    ids.Add(Convert.ToInt64(dr["lastID"].ToString()));
                    oldids.Add(Convert.ToInt64(dr["lastID"].ToString()));
                }
                else lastID = Convert.ToInt64(dr["lastID"].ToString());
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {            
            setTimeToTimer();
            GetTerminalType();
            GetSpravTerminal();
            TimeTickUpdate();
            //isStartApplication = false;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void DoOnUIThread(MethodInvoker d)
        {
            if (this.InvokeRequired) { this.Invoke(d); } else { d(); }
        }

        #region Sprav

        private void bwSparv_DoWork(object sender, DoWorkEventArgs e)
        {
            DoOnUIThread(delegate ()
            { rtbSprav.Text = ""; });
            string spravPath = string.Empty;
            if (File.Exists(@"sprav\AinT"))
                File.Delete(@"sprav\AinT");
            if (File.Exists(@"sprav\Ain"))
                File.Delete(@"sprav\Ain");
            long newID = SQL.getLastIdSprav();
            if (lastID < newID)
            {
                DoOnUIThread(delegate ()
                {
                    rtbSprav.Text += DateTime.Now.TimeOfDay.ToString().Substring(0, 8) + ": Создание изменений справочника;\n";
                    rtbSprav.SelectionStart = rtbSprav.Text.Length;
                });
            }

            EnumerableRowCollection<DataRow> rowCollect = dtSpravTerminal.AsEnumerable().Where(r => r.Field<bool>("isSelect"));
            if (rowCollect.Count() == 0) return;

            //Использование только товаров МКО и ГСТ на кассах этих отделов
            bool isMkoAndGastr = false;
            DataTable dtTmp = SQL.getSettings("kmgs");

            if (dtTmp != null && dtTmp.Rows.Count > 0)
                try
                {
                    isMkoAndGastr = bool.Parse(dtTmp.Rows[0]["value"].ToString());
                }
                catch { isMkoAndGastr = false; }

            // Получить список аквтиных товаров
            Sprav.initListGrpSettings();
            Sprav.initPromoGoods();

            DataTable GoodsDbase1 = Config.hCntMain.getListGoodsDbase1(false);
            DataTable GoodsVvoDbase1 = Config.hCntSecond.getListGoodsDbase1(true);
            if (GoodsVvoDbase1 != null) { GoodsDbase1.Merge(GoodsVvoDbase1); GoodsVvoDbase1 = null; }
            DataTable GooodUpdates = Config.hCntMainKassRealiz.getListGoodsKassRealiz();

            DataTable dtGoodsToFile = new DataTable();
            dtGoodsToFile.Columns.Add("ean", typeof(string));
            dtGoodsToFile.Columns.Add("r_time", typeof(DateTime));
            dtGoodsToFile.Columns.Add("name", typeof(string));
            dtGoodsToFile.Columns.Add("price", typeof(decimal));
            dtGoodsToFile.Columns.Add("grp", typeof(int));
            dtGoodsToFile.Columns.Add("tax", typeof(int));
            dtGoodsToFile.Columns.Add("id_tovar", typeof(string));
            dtGoodsToFile.Columns.Add("kodVVO", typeof(string));
            dtGoodsToFile.Columns.Add("firm", typeof(string));
            dtGoodsToFile.Columns.Add("id_post", typeof(int));
            dtGoodsToFile.Columns.Add("id_departments", typeof(int));
            dtGoodsToFile.Columns.Add("id_goodsUpdate", typeof(int));
            dtGoodsToFile.AcceptChanges();

            dtTmp = dtGoodsToFile.Clone();


            var query = from g in GoodsDbase1.AsEnumerable()
                            //join k in GooodUpdates.AsEnumerable() on new { Q = g.Field<int>("id"), Z = g.Field<int>("id_otdel") } equals new { Q = k.Field<int>("id_tovar"), Z = k.Field<int>("id_department") }
                        join k in GooodUpdates.AsEnumerable() on new { Q = g.Field<string>("ean").Trim() } equals new { Q = k.Field<string>("ean").Trim() }// into tempJoin
                        //from kJoin in tempJoin.DefaultIfEmpty()
                        select dtTmp.LoadDataRow(new object[]
                                                       {

                                                               g.Field<string>("ean"),
                                                               k.Field<DateTime>("r_time"),
                                                               k.Field<string>("name"),
                                                               k.Field<decimal>("price"),
                                                               k.Field<int>("grp"),
                                                               k.Field<int>("tax"),
                                                               g.Field<string>("id_tovar"),
                                                               g.Field<string>("kodVVO"),
                                                               g.Field<string>("firm"),
                                                               g.Field<int?>("id_post"),
                                                               k.Field<int>("id_departments"),
                                                               k.Field<int>("id")
                                                       }, false);

            dtGoodsToFile = query.CopyToDataTable();
            List<int> lVvo = new List<int>(new int[] { 3, 4 });
            List<int> lMKO = new List<int>(new int[] { 1 });
            List<int> lGst = new List<int>(new int[] { 2 });



            foreach (DataRow row in rowCollect)
            {
                int id_gu = (int)row["id_gu"];
                int id_TerminalType = (int)row["id_TerminalType"];
                EnumerableRowCollection<DataRow> rowToFile;

                if (isMkoAndGastr)
                {
                    if (lMKO.Contains(id_TerminalType))
                    {
                        rowToFile = dtGoodsToFile.AsEnumerable().Where(r => r.Field<int>("id_departments") == 1 && r.Field<int>("id_goodsUpdate") > id_gu);
                    }
                    if (lGst.Contains(id_TerminalType))
                    {
                        rowToFile = dtGoodsToFile.AsEnumerable().Where(r => r.Field<int>("id_departments") == 2 && r.Field<int>("id_goodsUpdate") > id_gu);
                    }
                    if (lVvo.Contains(id_TerminalType))
                    {
                        rowToFile = dtGoodsToFile.AsEnumerable().Where(r => r.Field<int>("id_departments") == 6 && r.Field<int>("id_goodsUpdate") > id_gu);
                    }
                    else
                    {
                        rowToFile = dtGoodsToFile.AsEnumerable().Where(r => r.Field<int>("id_departments") != 6 && r.Field<int>("id_goodsUpdate") > id_gu);
                    }
                }
                else
                {
                    if (lVvo.Contains(id_TerminalType))
                    {
                        rowToFile = dtGoodsToFile.AsEnumerable().Where(r => r.Field<int>("id_departments") == 6 && r.Field<int>("id_goodsUpdate") > id_gu);
                    }
                    else
                    {
                        rowToFile = dtGoodsToFile.AsEnumerable().Where(r => r.Field<int>("id_departments") != 6 && r.Field<int>("id_goodsUpdate") > id_gu);
                    }
                }

                //Создание файла
                Sprav.createSprav(rowToFile);

                int maxValueGoodsUpdate = rowToFile.AsEnumerable().Max(r => r.Field<int>("id_goodsUpdate"));
                //Отправка на кассу
                string _pathToSend = "\\\\" + (string)row["IP"] + (string)row["Path"];
                try
                {

                    bool exists = true;
                    try
                    {
                        bool completedIN = false;
                        Thread t = new Thread(new ThreadStart(delegate ()
                        {
                            Directory.Exists(_pathToSend);
                        }));
                        t.Start();
                        completedIN = t.Join(3000); //half a sec of timeout
                        if (!completedIN) { exists = false; t.Abort(); }
                        t = null;
                    }
                    catch { exists = false; }


                    //if (File.Exists(_pathToSend + @"AIn"))
                    //{
                    //    if (File.Exists(path[i].ToString() + @"atol\AIn\AIn" + ids[i])) File.Delete(path[i].ToString() + @"atol\AIn\AIn" + ids[i]);
                    //    File.Move(path[i].ToString() + @"atol\AIn\AIn", path[i].ToString() + @"atol\AIn\AIn" + ids[i]);
                    //}
                    Console.WriteLine(@_pathToSend + "AIn");

                    File.Copy(@"sprav\AInT", _pathToSend + "AIn",true);
                    File.Copy(@"sprav\sprav.txt", _pathToSend + "sprav.txt", true);
                    SQL.setLastId((int)row["Number"], maxValueGoodsUpdate, true);

                    //SQL.setLastId(terminals[i], newID);
                    //oldids[i] = ids[i];

                    DoOnUIThread(delegate ()
                    {
                        //rtbSprav.Text += $"{DateTime.Now.TimeOfDay.ToString().Substring(0, 8)} Касса {row["Number"]} + ": Справочник" + ids[i] + " отправлен;\n";
                        rtbSprav.SelectionStart = rtbSprav.Text.Length;
                    });
                }
                catch(Exception ex)
                {
                    DoOnUIThread(delegate ()
                    {
                        SQL.setLastId((int)row["Number"], maxValueGoodsUpdate, false);
                        rtbSprav.Text += DateTime.Now.TimeOfDay.ToString().Substring(0, 8) + ": Ошибка при отправке файлов;\n";
                        rtbSprav.Text += ex.Message + ";";
                        //writeLog(DateTime.Now.TimeOfDay.ToString().Substring(0, 8) + " " + terminals[i].ToString() + " : Ошибка при отправке файлов\n");
                        writeLog(ex.Message);
                        rtbSprav.SelectionStart = rtbSprav.Text.Length;                       
                    });
                }
            }

            /*
            return;

            DataTable dt = SQL.getLastId();
            ids.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                if (use && sterms.Contains(dr["number"].ToString())) ids.Add(Convert.ToInt64(dr["lastID"].ToString()));
            }



            for (int i = 0; i < path.Count(); i++)
            {
                bool exists = true;
                try
                {
                    bool completedIN = false;
                    Thread t = new Thread(new ThreadStart(delegate ()
                    { Directory.Exists(path[i].ToString() + @"atol\AIn"); }));
                    t.Start();
                    completedIN = t.Join(3000); //half a sec of timeout
                    if (!completedIN) { exists = false; t.Abort(); }
                    t = null;
                }
                catch { exists = false; }

                if (exists && !File.Exists(path[i].ToString() + @"atol\AIn\sprav.txt"))
                {
                    try
                    {
                        #region с 6 утра до 8ми утра
                        int res = Sprav.checkItsAll(path[i], terminals[i]);
                        if (res == 1)
                        {
                            if (SQL.getJSprav(terminals[i]) != ids[i].ToString())
                            {
                                for (long j = oldids[i]; j <= ids[i]; j++) SQL.setJSprav(terminals[i], j);
                            }
                            if (ids[i] < newID)
                            {
                                Sprav.createSprav(ids[i], true);

                                if (File.Exists(path[i].ToString() + @"atol\AIn\AIn"))
                                {
                                    if (File.Exists(path[i].ToString() + @"atol\AIn\AIn" + ids[i])) File.Delete(path[i].ToString() + @"atol\AIn\AIn" + ids[i]);
                                    File.Move(path[i].ToString() + @"atol\AIn\AIn", path[i].ToString() + @"atol\AIn\AIn" + ids[i]);
                                }
                                File.Copy(@"sprav\AInT", path[i].ToString() + @"atol\AIn\AIn");
                                File.Copy(@"sprav\sprav.txt", path[i].ToString() + @"atol\AIn\sprav.txt");

                                SQL.setLastId(terminals[i], newID);
                                oldids[i] = ids[i];

                                DoOnUIThread(delegate ()
                                {
                                    rtbSprav.Text += DateTime.Now.TimeOfDay.ToString().Substring(0, 8) + " Касса " + terminals[i] + ": Справочник" + ids[i] + " отправлен;\n";
                                    rtbSprav.SelectionStart = rtbSprav.Text.Length;
                                });
                            }
                        }
                        else if (res == 2)
                        {
                            Sprav.createSprav(oldids[i], true);

                            if (File.Exists(path[i].ToString() + @"atol\AIn\AIn"))
                            {
                                if (File.Exists(path[i].ToString() + @"atol\AIn\AIn" + ids[i])) File.Delete(path[i].ToString() + @"atol\AIn\AIn" + ids[i]);
                                File.Move(path[i].ToString() + @"atol\AIn\AIn", path[i].ToString() + @"atol\AIn\AIn" + ids[i]);
                            }
                            File.Copy(@"sprav\AInT", path[i].ToString() + @"atol\AIn\AIn");
                            File.Copy(@"sprav\sprav.txt", path[i].ToString() + @"atol\AIn\sprav.txt");

                            DoOnUIThread(delegate ()
                            {
                                rtbSprav.Text += DateTime.Now.TimeOfDay.ToString().Substring(0, 8) + " Касса " + terminals[i] + ": Справочник" + ids[i] + " отправлен;\n";
                                rtbSprav.SelectionStart = rtbSprav.Text.Length;
                            });
                        }
                        #endregion
                    }
                    catch (Exception ex)
                    {
                        DoOnUIThread(delegate ()
                        {
                            rtbSprav.Text += DateTime.Now.TimeOfDay.ToString().Substring(0, 8) + ": Ошибка при отправке файлов;\n";
                            rtbSprav.Text += ex.Message + ";";
                            writeLog(DateTime.Now.TimeOfDay.ToString().Substring(0, 8) + " " + terminals[i].ToString() + " : Ошибка при отправке файлов\n");
                            writeLog(ex.Message);
                            rtbSprav.SelectionStart = rtbSprav.Text.Length;
                        });

                    }
                }
                else
                {
                    rtbSprav.Text += terminals[i].ToString() + " Нет соединения с кассой, либо сетевая папка недоступна\n";
                    writeLog(DateTime.Now.TimeOfDay.ToString().Substring(0, 8) + " " + terminals[i].ToString() + " Нет соединения с кассой, либо сетевая папка недоступна\n");
                }
            }
            if (lastID < newID) lastID++;
            SQL.setLastId(0, lastID);*/
        }

        private void bwSparv_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (fLoad != null)
                fLoad.Dispose();            
            blocker.RestoreControlEnabledState(this);
            setTimeToTimer();
        }

        private void writeLog(string message)
        {
            if (!File.Exists(DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + ".txt"))
                using (FileStream fs = File.Create(DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + ".txt"))
                {
                    fs.Close();
                }

            using (StreamWriter sw = new StreamWriter(DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + ".txt", true))
            {
                sw.WriteLine(message);
                sw.Close();
            }
        }

        #endregion
       
        #region "Таймер обновления"
        long timer = 60;
        private bool TimeStoper = false, UpdateTime = false;
        Task task1;
        private CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        
        private void setTimeToTimer()
        {
            long defaultValue = 60;
            DataTable dtTmp = SQL.getSettings("grpt");

            if (dtTmp != null && dtTmp.Rows.Count > 0)
                try
                {
                    defaultValue = long.Parse(dtTmp.Rows[0]["value"].ToString());
                }
                catch { defaultValue = 60; }

            //defaultValue = 5;

            timer = defaultValue;
            tbDelay.Text = timer.ToString();
            TimeStoper = false;
        }
          
        private void TimeTickUpdate()
        {
            CancellationToken token = cancelTokenSource.Token;
            task1 = new Task(() =>
            {
                TimeSpan time = TimeSpan.FromSeconds(timer);
                while (true)
                {
                    if (token.IsCancellationRequested)
                    {
                        return;
                    }

                    if (UpdateTime)
                    {
                        time = TimeSpan.FromSeconds(timer);
                        AppendText(time.ToString());
                        UpdateTime = false;
                    }

                    if (!TimeStoper)
                    {
                        //AppendText($"{time.TotalHours}:{time.TotalMinutes % 60}:{time.TotalSeconds % 60}");
                        AppendText(string.Format("{0:d2}:{1:d2}:{2:d2}", time.Hours, time.Minutes, time.Seconds));
                        //AppendText(time.ToString());
                        if (time.TotalSeconds == 0)
                        {
                            DoOnUIThread(delegate ()
                            {

                                if (!bwSparv.IsBusy)
                                {
                                    TimeStoper = true;
                                    blocker.SaveControlsEnabledState(this);
                                    blocker.SetControlsEnabled(this, false);
                                    fLoad = new Nwuram.Framework.UI.Forms.frmLoad();
                                    fLoad.TextWait = "Грузим данные.";
                                    fLoad.TopMost = false;
                                    fLoad.Owner = this;
                                    fLoad.Show();
                                    bwSparv.RunWorkerAsync();
                                }
                                else
                                {
                                    setTimeToTimer();
                                }
                            });
                            time = TimeSpan.FromSeconds(timer);
                        }

                        Thread.Sleep(100);
                        time = time.Add(-TimeSpan.FromMilliseconds(100));
                    }                                       
                }
            });

            task1.Start();
        }
        
        private delegate void AppendListHandler(string sLog);
        private void AppendText(string sLog)
        {
            if (lTimeTickUpdate.InvokeRequired)
                lTimeTickUpdate.Invoke(new AppendListHandler(AppendText),
                                    new object[] { sLog });
            else
                lTimeTickUpdate.Text = $"До обновления:\r\n{sLog}";
        }
      
        private void btStopTimer_Click(object sender, EventArgs e)
        {
            btStartTimer.Enabled = true;
            btStopTimer.Enabled = false;
            TimeStoper = true;
        }

        private void btStartTimer_Click(object sender, EventArgs e)
        {
            btStartTimer.Enabled = false;
            btStopTimer.Enabled = true;
            TimeStoper = false;
        }
        
        private void tbDelay_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Modified)
            {
                tb.BackColor = Color.Yellow;
            }
        }

        private void btSetDelay_Click(object sender, EventArgs e)
        {
            tbDelay.BackColor = Color.White;
            
            SQL.setSettings("grpt", tbDelay.Text);
            timer = int.Parse(tbDelay.Text);

            tbDelay.Modified = false;
            UpdateTime = true;
            //cancelTokenSource.Cancel();
            //TimeTickUpdate();
        }

        private void GetTerminalType()
        {
            DataTable dtTerminalType = SQL.GetTerminalType(true);
            cmbTerminalType.DataSource = dtTerminalType;
            cmbTerminalType.ValueMember = "id";
            cmbTerminalType.DisplayMember = "NameTerminalType";            
        }

        #endregion

        #region ""
        private bool _TimeStoperTmp=false;
        private void GetSpravTerminal()
        {
            dtSpravTerminal = SQL.GetSpravTerminal();
            dgvGoods.AutoGenerateColumns = false;
            getSaveData();
            dgvGoods.DataSource = dtSpravTerminal;
        }

        private void dgvGoods_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (cV.Index == e.ColumnIndex)
            {
                if (dtSpravTerminal != null)
                {
                    EnumerableRowCollection<DataRow> rowCollect = dtSpravTerminal.AsEnumerable().Where(r => r.Field<bool>("isSelect"));
                    if (rowCollect.Count() > 0)
                    {
                        foreach (DataRow row in rowCollect)
                        {
                            row["isSelect"] = false;
                        }
                        dtSpravTerminal.AcceptChanges();
                    }
                    else
                    {
                        foreach (DataRow row in dtSpravTerminal.Rows)
                        {
                            row["isSelect"] = true;
                        }
                        dtSpravTerminal.AcceptChanges();
                    }
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {

            Task task2 = new Task(() =>
            {
                DoOnUIThread(delegate ()
                {
                    blocker.SaveControlsEnabledState(this);
                    blocker.SetControlsEnabled(this, false);
                    fLoad = new Nwuram.Framework.UI.Forms.frmLoad();
                    fLoad.TextWait = "Грузим данные.";
                    fLoad.TopMost = false;
                    fLoad.Owner = this;
                    fLoad.Show();
                    _TimeStoperTmp = TimeStoper;
                    TimeStoper = true;
                });

                Sprav.createSpravFull();

                DoOnUIThread(delegate ()
                {
                    if (fLoad != null)
                        fLoad.Dispose();
                    //TimeStoper = false;
                    TimeStoper = _TimeStoperTmp;
                    blocker.RestoreControlEnabledState(this);
                });
            });
            task2.Start();
        }

        private void cmbTerminalType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FilterTerminal();
        }

        private void dgvGoods_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            Color rColor = Color.White;
            try
            {
                if (dtSpravTerminal != null && dtSpravTerminal.Rows.Count > 0 && dtSpravTerminal.DefaultView.Count > 0)
                {
                    DataRowView row = dtSpravTerminal.DefaultView[e.RowIndex];
                    if (row["id_gu"] != DBNull.Value && row["last_id_gu"] != DBNull.Value)
                        if ((int)row["id_gu"] != (int)row["last_id_gu"]) rColor = panel2.BackColor;
                }
            }
            catch { }

            dgvGoods.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvGoods.Rows[e.RowIndex].DefaultCellStyle.BackColor =
                dgvGoods.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = rColor;


        }

        private void dgvGoods_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void tbDelay_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != '\b';
        }

        private void tbDelay_Leave(object sender, EventArgs e)
        {
            if (!tbDelay.Enabled) return;

            try
            {
                int tmp;
                if (int.TryParse(tbDelay.Text, out tmp))
                {
                    if (10 <= tmp && tmp <= 600)
                        tbDelay.Text = tmp.ToString();
                    else
                        tbDelay.Text = "10";
                }
                else
                    tbDelay.Text = "10";
            }
            catch
            {
                tbDelay.Text = "10";
            }
        }

        private void FilterTerminal()
        {
            try
            {
                string str = "";

                if ((byte)cmbTerminalType.SelectedValue != 0)
                    str += (str.Trim().Length == 0 ? "" : " and ") + $"id_TerminalType = {cmbTerminalType.SelectedValue}";

                dtSpravTerminal.DefaultView.RowFilter = str;
            }
            catch
            {
                dtSpravTerminal.DefaultView.RowFilter = "id = -9999";
            }
        }

        private void getSaveData()
        {
            try
            {
                if (!File.Exists(Config.PathFile + @"\settings.json")) return;

                string jsonString = File.ReadAllText(Config.PathFile + @"\settings.json");
                Config.ProgSettngs = JsonConvert.DeserializeObject<Settings>(jsonString);

                if (dtSpravTerminal != null && dtSpravTerminal.Rows.Count > 0)
                {
                    EnumerableRowCollection<DataRow> rowCollect = dtSpravTerminal.AsEnumerable().Where(r => Config.ProgSettngs.IdTerminal.Contains(r.Field<int>("id")));

                    foreach (DataRow row in rowCollect)
                        row["isSelect"] = true;

                    dtSpravTerminal.AcceptChanges();
                }
            }
            catch
            { }
        }
       
        private void dgvGoods_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvGoods.CommitEdit(DataGridViewDataErrorContexts.Commit);
            setSaveData();
        }

        private void btSetting_Click(object sender, EventArgs e)
        {
            new frmSetting().ShowDialog();
        }

        private void setSaveData()
        {
            if(Config.ProgSettngs==null) Config.ProgSettngs = new Settings();

            var tl = dtSpravTerminal.DefaultView.ToTable().AsEnumerable().Where(r => r.Field<bool>("isSelect")).Select(s => new { id = s.Field<int>("id") }).ToList();

            List<int> l = new List<int>();
            foreach (var id in tl)
            {
                l.Add(id.id);
            }

            Config.ProgSettngs.IdTerminal = l;

            File.WriteAllText(Config.PathFile + @"\settings.json", JsonConvert.SerializeObject(Config.ProgSettngs));
        }

        #endregion
    }

}
