using System.Text;
using System.Collections;
using Nwuram.Framework.Data;
using Nwuram.Framework.Settings.Connection;
using System.Data;
using System;
using Nwuram.Framework.Settings.User;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using System.Windows.Forms;

namespace xPosRealiz_sprav_shues
{
    class Config
    {
        public static readonly string PathFile = Application.StartupPath;

        public static Settings ProgSettngs;

        public static Procedures hCntMain { get; set; } //осн. коннект


        public static Procedures hCntMainKassRealiz { get; set; } //осн. коннект

        public static Procedures hCntSecond { get; set; } //осн. коннект
    }

    public class Settings
    {
        public List<int> IdTerminal { set; get; }
    }

    class Procedures : SqlProvider
    {
        public Procedures(string server, string database, string username, string password, string appName)
              : base(server, database, username, password, appName)
        {
        }
        ArrayList ap = new ArrayList();

        public DataTable getListGoodsDbase1(bool isVOO)
        {
            ap.Clear();
            ap.Add(isVOO);

            DataTable dtResult = executeProcedure("[sendFrontol].[getListGoodsDbase1]",
                 new string[1] {"@isVOO" },
                 new DbType[1] {DbType.Boolean }, ap);

            return dtResult;
        }
        public DataTable getListGoodsKassRealiz()
        {
            ap.Clear();

            DataTable dtResult = executeProcedure("[sendFrontol].[getListGoodsKassRealiz]",
                 new string[0] { },
                 new DbType[0] { }, ap);

            return dtResult;
        }
    }


}
