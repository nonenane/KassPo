using Nwuram.Framework.Data;
using Nwuram.Framework.Logging;
using Nwuram.Framework.Settings.Connection;
using Nwuram.Framework.Settings.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SenderUsersOnFrontol
{
    public partial class frmAddUser : Form
    {
        private string id = "";
        private bool isEdit = false;
        private DataTable dtShops, dtShops_old;
        ContextMenu blah = new ContextMenu();

        private DataRowView row = null;

        public void setRow(DataRowView _row)
        {
            this.row = _row;
            id = row["id"].ToString();
            tbIdUser.Text = row["id"].ToString();
            tbNumber.Text = row["Number"].ToString();
            tbFIO.Text = row["FIO"].ToString();
            cbPost.SelectedValue = row["id_post"].ToString();
            tbPassWord.Text = row["password"].ToString();
            tbCode.Text = row["code"].ToString();
            tbCode_Inn.Text = row["INN_Code"].ToString();
            isEdit = true;
        }
        public frmAddUser()
        {
            InitializeComponent();
            init_post();


        }

        private DataTable dtPost;

        private void init_post()
        {
            dtPost = Config.hCntMain.getPost();

            dtPost.DefaultView.RowFilter = "isActive = 1";

            cbPost.DataSource = dtPost;
            cbPost.ValueMember = "id";
            cbPost.DisplayMember = "cName";
            cbPost.SelectedIndex = -1;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            
            try
            {
                int i = Convert.ToInt32(tbIdUser.Text);
            }
            catch
            {
                MessageBox.Show("ID пользователя должно состоять только из цифр");
                return;
            }
            if (tbIdUser.Text.Trim().Length == 0)
            {
                MessageBox.Show("Необходимо ввести ID пользователя!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                int i = Convert.ToInt32(tbNumber.Text);
            }
            catch
            {
                MessageBox.Show("Короткий номер должен состоять только из цифр");
                return;
            }
            if (tbNumber.Text.Trim().Length == 0)
            {
                MessageBox.Show("Необходимо ввести короткий номер!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tbFIO.Text.Trim().Length == 0)
            {
                MessageBox.Show("Необходимо ввести Фамилию И.О.!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbPost.SelectedIndex == -1)
            {
                MessageBox.Show("Необходимо выбрать профиль!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tbPassWord.Text.Trim().Length == 0)
            {
                MessageBox.Show("Необходимо ввести пароль!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //if(tbCode_Inn.Text.Trim().Length==0 || tbCode_Inn.Text.Trim().Length != 12)
            if (tbCode_Inn.Text.Trim().Length != 0 && tbCode_Inn.Text.Trim().Length != 12)
            {
                MessageBox.Show("ИНН кассира должен состоять из 12 цифр! Сохранение невозможно!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tbCode_Inn.Text.Trim().Length == 12)
                if (!checkInn(tbCode_Inn.Text.Trim()) || Int64.Parse(tbCode_Inn.Text.Trim()) == 0)
                {
                    MessageBox.Show("Не корректный ИНН", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            if (dtShops.Select("isSelect = 1").Count() == 0)
            {
                MessageBox.Show("Необходимо выбрать магазин работы сотрудника!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            /*if (tbNN_Code.Text.Trim().Length == 0)
            */

            //if (tbCode.Text.Trim().Length == 0)
            //{
            //    MessageBox.Show("Необходимо ввести Штрих-код!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            string number = tbNumber.Text;
            string INN_Code = tbCode_Inn.Text;
            int id_post = int.Parse(cbPost.SelectedValue.ToString());
            string newId = tbIdUser.Text.Trim();

            //dtResult = Config.hCntMain.setUser(id, number, tbFIO.Text, id_post, tbPassWord.Text, tbCode.Text, INN_Code, isEdit ? 2 : 1, newId);
            // у нас два коннекта, при недобавлении на один, не добавляем на другой (выполнение переписано в новый класс)

            DataTable dtTemp = Config.trCntK21dbase1.setUser(id, number, tbFIO.Text, id_post, tbPassWord.Text, tbCode.Text, INN_Code, isEdit ? 2 : 1, newId);

            //dtResult = Config.hCntMain.setUser(id, number, tbFIO.Text, id_post, tbPassWord.Text, tbCode.Text, INN_Code, isEdit ? 2 : 1, newId);
            if (dtTemp == null || dtTemp.Rows.Count == 0 || dtTemp.Rows[0]["id"].ToString().Equals("-1"))
            {
                MessageBox.Show("Не удалось сохранить данные", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Config.trCntK21dbase1.RollbackTransaction();              
                return;
            }
            else if (dtTemp.Rows[0]["id"].ToString().Equals("-2"))
            {
                MessageBox.Show("Есть дублирования полей в Базе!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Config.trCntK21dbase1.RollbackTransaction();
                return;
            }
            else if (dtTemp.Rows[0]["id"].ToString().Equals("-3"))
            {
                MessageBox.Show("ID пользователя уже используется!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Config.trCntK21dbase1.RollbackTransaction();
                return;
            }
            //добавление на x14.dbase1

            DataTable dtTempX14 = Config.trCntX14dbase1.setUser(id, number, tbFIO.Text, id_post, tbPassWord.Text, tbCode.Text, INN_Code, isEdit ? 2 : 1, newId);


            //DataTable dtResultx14 = Config.hCntSecond.setUser(id, number, tbFIO.Text, id_post, tbPassWord.Text, tbCode.Text, INN_Code, isEdit ? 2 : 1, newId);
            if (dtTempX14 == null || dtTempX14.Rows.Count == 0 || new string[] {"-1","-2","-3" }.Contains(dtTempX14.Rows[0]["id"].ToString()))
            {
                MessageBox.Show(Config.centralText("Ошибка добавления по второму подключению\nоткат изменений\n"), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Config.trCntK21dbase1.RollbackTransaction();
                Config.trCntX14dbase1.RollbackTransaction();
                return;
            }

            // если мы дошли до сюда, то все ок, dbase1 записался, коммитим все     
           // Config.trCntK21dbase1.CommitTransaction();
           // Config.trCntX14dbase1.CommitTransaction();
            newId = dtTemp.Rows[0]["id"].ToString();
            string newPost = dtTemp.Rows[0]["codeFrontol"].ToString();

            if (id.Trim().Length == 0)
            {
                DataTable dtKRK21 = Config.trCntK21KassRealiz.setUserToKassRealiz(id, newId, number, tbFIO.Text, newPost, tbPassWord.Text, tbCode.Text, 1);
                // если нул, то отменяем все предыдущие транзакции
                if (dtKRK21 == null || int.Parse(dtKRK21.Rows[0][0].ToString())<=0 )
                {
                    Config.trCntK21dbase1.RollbackTransaction();
                    Config.trCntX14dbase1.RollbackTransaction();
                    Config.trCntK21KassRealiz.RollbackTransaction();
                    MessageBox.Show(Config.centralText("Ошибка добавления пользователя\nпо дополнительному соединению 1\n"), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DataTable dtKRX14 = Config.trCntX14KassRealiz.setUserToKassRealiz(id, newId, number, tbFIO.Text, newPost, tbPassWord.Text, tbCode.Text, 1);
                //если нул, отменяем все предыдущие транзакции
                if (dtKRX14 == null || int.Parse(dtKRX14.Rows[0][0].ToString()) <= 0 )
                {
                    Config.trCntK21dbase1.RollbackTransaction();
                    Config.trCntX14dbase1.RollbackTransaction();
                    Config.trCntK21KassRealiz.RollbackTransaction();
                    Config.trCntX14KassRealiz.RollbackTransaction();
                    MessageBox.Show(Config.centralText("Ошибка добавления пользователя\nпо дополнительному соединению 2\n"), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Config.trCntK21dbase1.CommitTransaction();
                Config.trCntX14dbase1.CommitTransaction();
                Config.trCntK21KassRealiz.CommitTransaction();
                Config.trCntX14KassRealiz.CommitTransaction();

                Logging.StartFirstLevel(496);
                Logging.Comment("Добавление пользователя");

                Logging.Comment("ID пользователя: " + tbIdUser.Text);
                Logging.Comment("Короткий номер: " + tbNumber.Text);
                Logging.Comment("Фамилия И.О.: " + tbFIO.Text);
                Logging.Comment("Профиль: id: " + cbPost.SelectedValue.ToString() + "; Наименование: " + cbPost.Text.ToString());
                Logging.Comment("Пароль: " + tbPassWord.Text);
                Logging.Comment("Штрих-Код: " + tbCode.Text);
                Logging.Comment("ИНН: " + tbCode_Inn.Text);

                foreach (DataRow rShop in dtShops.Select("isSelect = 1"))
                {
                    Logging.Comment("Магазин работы: " + rShop["cName"].ToString());
                }

                Logging.Comment("Операцию выполнил: ID:" + Nwuram.Framework.Settings.User.UserSettings.User.Id
                            + " ; ФИО:" + Nwuram.Framework.Settings.User.UserSettings.User.FullUsername);
                Logging.StopFirstLevel();
            }
            else
            {

                DataTable dtKRK21 = Config.trCntK21KassRealiz.setUserToKassRealiz(id, newId, number, tbFIO.Text, newPost, tbPassWord.Text, tbCode.Text, 2);
                // если нул, то отменяем все предыдущие транзакции
                if (dtKRK21 == null)
                {
                    Config.trCntK21dbase1.RollbackTransaction();
                    Config.trCntX14dbase1.RollbackTransaction();
                    Config.trCntK21KassRealiz.RollbackTransaction();
                    MessageBox.Show(Config.centralText("Ошибка редактирования пользователя\nпо дополнительному соединению\n"), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DataTable dtKRX14 = Config.trCntX14KassRealiz.setUserToKassRealiz(id, newId, number, tbFIO.Text, newPost, tbPassWord.Text, tbCode.Text, 2);
                //если нул, отменяем все предыдущие транзакции
                if (dtKRX14 == null)
                {
                    Config.trCntK21dbase1.RollbackTransaction();
                    Config.trCntX14dbase1.RollbackTransaction();
                    Config.trCntK21KassRealiz.RollbackTransaction();
                    Config.trCntX14KassRealiz.RollbackTransaction();
                    MessageBox.Show(Config.centralText("Ошибка редактирования пользователя\nпо дополнительному соединению\n"), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // когда все отредактировали
                Config.trCntK21dbase1.CommitTransaction();
                Config.trCntX14dbase1.CommitTransaction();
                Config.trCntK21KassRealiz.CommitTransaction();
                Config.trCntX14KassRealiz.CommitTransaction();
                Logging.StartFirstLevel(497);
                Logging.Comment("Редактирование пользователя");

                Logging.Comment("Код записи: " + id);
                Logging.VariableChange("ID пользователя: ", tbIdUser.Text, id, typeLog._string);
                Logging.VariableChange("Короткий номер: ", tbNumber.Text, row["Number"].ToString(), typeLog._string);
                Logging.VariableChange("Фамилия И.О.: ", tbFIO.Text, row["FIO"].ToString());
                Logging.VariableChange("Профиль: id: ", cbPost.SelectedValue.ToString(), row["id_post"].ToString(), typeLog._string);
                Logging.VariableChange("Профиль: Наименование: ", cbPost.Text.ToString(), row["namePost"].ToString());
                Logging.VariableChange("Пароль: ", tbPassWord.Text, row["password"].ToString());
                Logging.VariableChange("Штрих-Код: ", tbCode.Text, row["code"].ToString());
                Logging.VariableChange("ИНН: ", tbCode_Inn.Text, row["INN_Code"].ToString());

                var differences =
                                dtShops.AsEnumerable().Except(dtShops_old.AsEnumerable(),
                                            DataRowComparer.Default);

                if (differences.Count() > 0)
                {
                    foreach (DataRow rShop in differences)
                    {
                        EnumerableRowCollection<DataRow> meRow = dtShops_old.AsEnumerable().Where(r => r.Field<int>("id") == (int)rShop["id"]
                        && r.Field<bool>("isSelect") != (bool)rShop["isSelect"]);
                        //if(meRow.Count()>0)
                        Logging.VariableChange("Магазин работы: " + rShop["cName"].ToString(),
                            ((bool)rShop["isSelect"] ? "Да" : "Нет"),
                            ((bool)meRow.First()["isSelect"] ? "Да" : "Нет"));
                    }
                }

                Logging.Comment("Операцию выполнил: ID:" + Nwuram.Framework.Settings.User.UserSettings.User.Id
                                + " ; ФИО:" + Nwuram.Framework.Settings.User.UserSettings.User.FullUsername);
                Logging.StopFirstLevel();
            }

            Int64 id_user = newId.Length == 0 ? -1 : Int64.Parse(newId);

            dtShops.AcceptChanges();
            Config.hCntMain.setUserShop(id_user, -1);
            Config.hCntSecond.setUserShop(id_user, -1);
            foreach (DataRow rShop in dtShops.Select("isSelect = 1"))
            {
                Config.hCntMain.setUserShop(id_user, (int)rShop["id"]);
                Config.hCntSecond.setUserShop(id_user, (int)rShop["id"]);
                string prefix = (string)rShop["prefix"];
                /*     
                //if (prefix.ToLower().Equals("k21"))
                if (ConnectionSettings.GetServer().Trim().ToLower().Contains(prefix.ToLower()))
                {
                    if (id.Trim().Length == 0)
                        Config.hCntMain.setUserToKassRealiz(id, newId, number, tbFIO.Text, id_post, tbPassWord.Text, tbCode.Text, 1);
                    else
                        Config.hCntMain.setUserToKassRealiz(id, newId, number, tbFIO.Text, id_post, tbPassWord.Text, tbCode.Text, 2);
                }
                else
                //if (prefix.ToLower().Equals("x14"))
                {
                    if (id.Trim().Length == 0)
                        Config.hCntSecond.setUserToKassRealiz(id, newId, number, tbFIO.Text, id_post, tbPassWord.Text, tbCode.Text, 1);
                    else
                        Config.hCntSecond.setUserToKassRealiz(id, newId, number, tbFIO.Text, id_post, tbPassWord.Text, tbCode.Text, 2);
                }
                */
            }


            MessageBox.Show("Данные сохранены!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
            isEdit = false;
            this.DialogResult = DialogResult.OK;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            //  isEdit = true;
        }

        private void frmAddTypeComponents_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = (isEdit && MessageBox.Show("Закрыть форму без сохранения?", "Инфомирование", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No);
        }

        private void tbName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!Char.IsNumber(e.KeyChar) && (e.KeyChar != '\b'));
        }

        private void cbPost_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // isEdit = true;
        }

        private void frmAddUser_Load(object sender, EventArgs e)
        {
            tbCode.ContextMenu = blah;
            tbCode.ShortcutsEnabled = false;
            Int64 id_user = id.Length == 0 ? -1 : Int64.Parse(id);
            dtShops = Config.hCntMain.getUserShop(id_user);
            dtShops_old = dtShops.Copy();
            dgvShops.AutoGenerateColumns = false;
            dgvShops.DataSource = dtShops;
        }

        private void txtINN_Code_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        //Проверка ИНН
        private int [] MULT_N1 = {7, 2, 4, 10, 3, 5, 9, 4, 6, 8};
        private int [] MULT_N2 = {3, 7, 2, 4, 10, 3, 5, 9, 4, 6, 8};
        private int [] MULT_N =  {2, 4, 10, 3, 5, 9, 4, 6, 8};

        private bool checkInn(String innStr)
        {
            Boolean valid;
            int[] inn = stringToIntArray(innStr);

            int innSize = inn.Length;

            switch (innSize)
            {
                case 12:
                    int N1 = getChecksum(inn, MULT_N1);
                    int N2 = getChecksum(inn, MULT_N2);

                    valid = (inn[inn.Length - 1].Equals(N2) && inn[inn.Length - 2].Equals(N1));
                    break;
                case 10:
                    int N = getChecksum(inn, MULT_N);
                    valid = (inn[inn.Length - 1].Equals(N));
                    break;
                default:
                    valid = false;
                    break;
            }
            return valid;
        }

        private int[] stringToIntArray(String src)
        {
            char[] chars = src.ToArray();
            List<int> digits = new List<int>();
            //for (char aChar : chars)
            foreach(char aChar in chars)
            {
                digits.Add(int.Parse(char.GetNumericValue(aChar).ToString()));
            }
            return digits.ToArray(); // (new int[digits.Count()]);
        }

        private int getChecksum(int[] digits, int[] multipliers)
        {
            int checksum = 0;
            for (int i = 0; i < multipliers.Length; i++)
            {
                checksum += (digits[i] * multipliers[i]);
            }
            return (checksum % 11) % 10;
        }
    }
}
