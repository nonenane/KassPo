using System.Text;
using System.Collections;
using Nwuram.Framework.Data;
using Nwuram.Framework.Settings.Connection;
using System.Data;
using System;
using Nwuram.Framework.Settings.User;

namespace SenderUsersOnFrontol
{
    public class Procedures : SqlProvider
    {
        public Procedures(string server, string database, string username, string password, string appName)
            : base(server, database, username, password, appName)
        {
        }
        ArrayList ap = new ArrayList();


        #region "Справочник должностей"
        public  DataTable getPost()
        {
            ap.Clear();
            return executeProcedure("[sendFrontol].[getPost]",
                 new string[] { },
                 new DbType[] { }, ap);
        }

        public  DataTable setPost(int id, string cName,string code, int type, bool isActive)
        {
            ap.Clear();
            ap.Add(id);
            ap.Add(cName);
            ap.Add(code);
            ap.Add(type);
            ap.Add(isActive);
            ap.Add(Nwuram.Framework.Settings.User.UserSettings.User.Id);
            return executeProcedure("[sendFrontol].[setPost]",
                 new string[] { "@id", "@cName","@codeFrontol", "@type", "@isActive", "@idUser" },
                 new DbType[] { DbType.Int32, DbType.String, DbType.String, DbType.Int32, DbType.Boolean, DbType.Int32 }, ap);
        }
        #endregion
        
        #region "Справочник Касс"
        public  DataTable getTerminal()
        {
            ap.Clear();
            return executeProcedure("[sendFrontol].[getTerminal]",
                 new string[] { },
                 new DbType[] { }, ap);
        }

        public  DataTable setTerminal(int id, int Number, string IP, string Path, int type,int idTerminalType)
        {
            ap.Clear();
            ap.Add(id);
            ap.Add(Number);
            ap.Add(IP);
            ap.Add(Path);
            ap.Add(type);
            ap.Add(Nwuram.Framework.Settings.User.UserSettings.User.Id);
            ap.Add(idTerminalType);


            return executeProcedure("[sendFrontol].[setTerminal]",
                 new string[] { "@id", "@Number", "@IP", "@Path", "@type", "@idUser", "@idTerminalType" },
                 new DbType[] { DbType.Int32, DbType.Int32, DbType.String, DbType.String, DbType.Int32, DbType.Int32, DbType.Int32 }, ap);
        }
        #endregion

        public  DataTable getUser()
        {
            ap.Clear();
            return executeProcedure("[sendFrontol].[getUser]",
                 new string[] { },
                 new DbType[] { }, ap);
        }

        public  DataTable setUser(string id, string Number, string FIO, int id_post, string password, string code, string INN_Code, int type, string newId)
        {
           
            ap.Clear();
            ap.Add(id);
            ap.Add(newId);
            ap.Add(Number);
            ap.Add(FIO);
            ap.Add(id_post);
            ap.Add(password);
            ap.Add(code);
            ap.Add(INN_Code);
            ap.Add(type);
            ap.Add(UserSettings.User.Id);
            try
            {
                return executeProcedure("[sendFrontol].[setUser]",
                     new string[10] { "@oldid", "@newid", "@Number", "@FIO", "@id_post", "@password", "@code", "@INN_Code", "@type", "@user_id" },
                     new DbType[10] { DbType.String, DbType.String, DbType.String, DbType.String, DbType.Int32, DbType.String, DbType.String, DbType.String, DbType.Int32, DbType.Int32}, ap);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            
        }

        public  DataTable setDateSend()
        {
            ap.Clear();
            return executeProcedure("[sendFrontol].[setDateSend]",
                 new string[] { },
                 new DbType[] { }, ap);
        }

        public string getPassWord()
        {
            ap.Clear();
            ap.Add(Nwuram.Framework.Settings.Connection.ConnectionSettings.GetIdProgram());
            DataTable dtPas =  executeProcedure("[sendFrontol].[getPassWord]",
                 new string[] {"@id_prog" },
                 new DbType[] { DbType.Int32 }, ap);

            if(dtPas == null || dtPas.Rows.Count ==0 || dtPas.Rows[0]["value"]==null)
            return "";
            else
                return dtPas.Rows[0]["value"].ToString();
        }

        public  DataTable getDateSend()
        {
            ap.Clear();
            return executeProcedure("[sendFrontol].[getDateSend]",
                 new string[] { },
                 new DbType[] { }, ap);
        }

        public DataTable setUserToKassRealiz(string oldid, string newid, string Number, string FIO, string codeFrontol, string password, string code, int type)
        {
            ap.Clear();
            ap.Add(oldid);
            ap.Add(newid);
            ap.Add(Number);
            ap.Add(FIO);
            ap.Add(codeFrontol);
            ap.Add(password);
            ap.Add(code);
            ap.Add(type);

            return executeProcedure("[sendFrontol].[setUserToKassRealiz]",
                 new string[] { "@oldid", "@newid", "@Number", "@FIO", "@codeFrontol", "@password", "@code", "@type" },
                 new DbType[] { DbType.String, DbType.String, DbType.String, DbType.String, DbType.String, DbType.String, DbType.String, DbType.Int32}, ap);
        }

        public void getLogAndPass()
        {
            ap.Clear();
            ap.Add(Nwuram.Framework.Settings.Connection.ConnectionSettings.GetIdProgram());
            DataTable dtResult =  executeProcedure("[sendFrontol].[getProgConfig]",
                 new string[] { "@id_prog" },
                 new DbType[] {DbType.Int32 }, ap);

            if (dtResult == null || dtResult.Rows.Count == 0) return;

            EnumerableRowCollection<DataRow> rowCollection = dtResult.AsEnumerable().Where(r=> r.Field<string>("id_value").Equals("klog"));
            foreach (DataRow r in rowCollection)
            {
                Config.Login = r["value"].ToString();
            }

            rowCollection = dtResult.AsEnumerable().Where(r => r.Field<string>("id_value").Equals("kpas"));
            foreach (DataRow r in rowCollection)
            {
                Config.Password = r["value"].ToString();
            }
        }

        public DateTime? getLastDateAdd()
        {
            ap.Clear();           
            DataTable dtPas = executeProcedure("[sendFrontol].[getLastDateAdd]",
                 new string[] { },
                 new DbType[] { }, ap);

            if (dtPas == null || dtPas.Rows.Count == 0 || dtPas.Rows[0]["DateSend"] == null)
                return null;
            else
                return (DateTime)dtPas.Rows[0]["DateSend"];
        }

        public DataTable getUserShop(Int64 id_user)
        {
            ap.Clear();
            ap.Add(id_user);
            return executeProcedure("[sendFrontol].[getUserShop]",
                 new string[] { "@id_user" },
                 new DbType[] {DbType.Int64 }, ap);
        }

        public DataTable setUserShop(Int64 id_user,int id_shop)
        {
            ap.Clear();
            ap.Add(id_user);
            ap.Add(id_shop);
            return executeProcedure("[sendFrontol].[setUserShop]",
                 new string[] { "@id_user","@id_shop" },
                 new DbType[] { DbType.Int64, DbType.Int32 }, ap);
        }

        public DataTable getUserToSend()
        {
            ap.Clear();
            string prefixShop = "";
            string sss = ConnectionSettings.GetServer().Trim().ToLower();

            int index = sss.LastIndexOf("\\");
            prefixShop = sss.Substring(index+1);

            ap.Add(prefixShop);

            return executeProcedure("[sendFrontol].[getUserToSend]",
                 new string[1] {"@prefixShop" },
                 new DbType[1] { DbType.String }, ap);
        }

        public DataTable  GetTerminalType(bool withAllDeps = false)
        {
            ap.Clear();

            DataTable dtResult = executeProcedure("[sendFrontol].[getTerminalType]",
                 new string[0] { },
                 new DbType[0] { }, ap);

            if (withAllDeps)
            {
                if (dtResult != null)
                {
                    if (!dtResult.Columns.Contains("isMain"))
                    {
                        DataColumn col = new DataColumn("isMain", typeof(int));
                        col.DefaultValue = 1;
                        dtResult.Columns.Add(col);
                        dtResult.AcceptChanges();
                    }

                    DataRow row = dtResult.NewRow();

                    row["NameTerminalType"] = "Все Типы";
                    row["id"] = 0;
                    row["isMain"] = 0;
                    dtResult.Rows.Add(row);
                    dtResult.AcceptChanges();
                    dtResult.DefaultView.Sort = "isMain asc, NameTerminalType asc";
                    dtResult = dtResult.DefaultView.ToTable().Copy();
                }
            }
            else
            {
                dtResult.DefaultView.Sort = "NameTerminalType asc";
                dtResult = dtResult.DefaultView.ToTable().Copy();
            }

            return dtResult;
        }

        public DataTable SetTerminalUserUpdate(int id_Terminal)
        {
            ap.Clear();
            ap.Add(id_Terminal);
            ap.Add(Nwuram.Framework.Settings.User.UserSettings.User.Id);

            return executeProcedure("[sendFrontol].[SetTerminalUserUpdate]",
                 new string[2] { "@id_Ternimal", "@id_user" },
                 new DbType[2] { DbType.Int32, DbType.Int32 }, ap);
        }

    }   
}
