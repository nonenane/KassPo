using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using Nwuram.Framework.Settings.User;
using System.Threading.Tasks;

namespace SenderUsersOnFrontol
{
    public class TransactionProcedures : TransactionConnect
    {
        public TransactionProcedures(string server, string database, string username, string password, string programName) : base(server, database, username, password, programName)
        {
            
        }
        ArrayList ap = new ArrayList();
        /// <summary>
        /// добавление на dbase1
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Number"></param>
        /// <param name="FIO"></param>
        /// <param name="id_post"></param>
        /// <param name="password"></param>
        /// <param name="code"></param>
        /// <param name="INN_Code"></param>
        /// <param name="type"></param>
        /// <param name="newId"></param>
        /// <returns></returns>
        public DataTable setUser(string id, string Number, string FIO, int id_post, string password, string code, string INN_Code, int type, string newId)
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
                     new DbType[10] { DbType.String, DbType.String, DbType.String, DbType.String, DbType.Int32, DbType.String, DbType.String, DbType.String, DbType.Int32, DbType.Int32 }, ap);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }
        /// <summary>
        /// добавление на KassRealiz
        /// </summary>
        /// <param name="oldid"></param>
        /// <param name="newid"></param>
        /// <param name="Number"></param>
        /// <param name="FIO"></param>
        /// <param name="codeFrontol"></param>
        /// <param name="password"></param>
        /// <param name="code"></param>
        /// <param name="type"></param>
        /// <returns></returns>
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
                 new DbType[] { DbType.String, DbType.String, DbType.String, DbType.String, DbType.String, DbType.String, DbType.String, DbType.Int32 }, ap);
        }

        public DataTable setPost(int id, string cName, string code, int type, bool isActive)
        {
            ap.Clear();
            ap.Add(id);
            ap.Add(cName);
            ap.Add(code);
            ap.Add(type);
            ap.Add(isActive);
            ap.Add(Nwuram.Framework.Settings.User.UserSettings.User.Id);
            return executeProcedure("[sendFrontol].[setPost]",
                 new string[] { "@id", "@cName", "@codeFrontol", "@type", "@isActive", "@idUser" },
                 new DbType[] { DbType.Int32, DbType.String, DbType.String, DbType.Int32, DbType.Boolean, DbType.Int32 }, ap);
        }


    }
}
