using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using Nwuram.Framework.Data;
using Nwuram.Framework.Settings.Connection;

namespace MonitoringGoodsUpdates
{
    class Procedures
    {
        private static ArrayList parameters = new ArrayList();
        private static SqlProvider sql = new SqlProvider(ConnectionSettings.GetServer(), ConnectionSettings.GetDatabase(), ConnectionSettings.GetUsername(), ConnectionSettings.GetPassword(), ConnectionSettings.ProgramName);

        public static DataTable GetGoodsUpdates(DateTime date)
        {
            parameters.Clear();
            parameters.Add(date);
            return sql.executeProcedure("dbo.GetGoodsUpdates", new string[] { "@date" }, new DbType[] { DbType.DateTime }, parameters);
        }

        public static DataTable GetGoodsUpdatesTerminals(int id_goods_updates, DateTime time_send)
        {
            parameters.Clear();
            parameters.AddRange(new object[] { id_goods_updates, time_send });
            return sql.executeProcedure("dbo.GetGoodsUpdatesTerminals", new string[] { "@id_goods_updates", "@time_send" }, new DbType[] { DbType.Int32, DbType.DateTime }, parameters);
        }

        public static int GetUpdateIntervalSettings()
        {
            parameters.Clear();
            DataTable dt = sql.executeProcedure("dbo.GetUpdateIntervalSettings", new string[] { }, new DbType[] { }, parameters);
            return dt != null && dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0][0]) : 15;
        }
    }
}
