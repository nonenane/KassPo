using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace SenderUsersOnFrontol
{
    public class TransactionConnect
    {
        private SqlConnection connection;
        private SqlTransaction transaction;
        private SqlCommand procedure;
        /// <summary>
        /// Выполнение на двух коннектах в одной транзации, после завершения необходимо вызвать CommitTransaction() или RollbackTransaction()
        /// </summary>
        /// <param name="conn1"></param>
        /// <param name="conn2"></param>
        public TransactionConnect(string server, string database, string username, string password, string programName)
        {
            connection = new SqlConnection($"Data Source={server};Initial Catalog={database};" +
                $"Integrated Security=False;User ID={username};Password={password};Application Name={programName};");                                 
        }

        public DataTable executeProcedure(string name, string[] parameterNames, DbType[] parameterTypes, ArrayList parameterValues)
        {
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();
                procedure = new SqlCommand(name, connection, transaction);
                for (int i = 0; i < parameterNames.Length; ++i)
                {
                    SqlParameter param = procedure.CreateParameter();
                    param.ParameterName = parameterNames[i];
                    param.DbType = parameterTypes[i];
                    param.Direction = ParameterDirection.Input;
                    param.Value = parameterValues[i];
                    procedure.Parameters.Add(param);
                }
                procedure.CommandType = CommandType.StoredProcedure;
                SqlDataReader data = procedure.ExecuteReader();
                DataTable result = new DataTable();
                DataColumn dc;
                for (int i = 0; i < data.FieldCount; i++)
                {
                    dc = result.Columns.Add(data.GetName(i), data.GetFieldType(i));
                    dc.AllowDBNull = true;
                }
                while (data.Read())
                {
                    DataRow row = result.NewRow();
                    for (int i = 0; i < data.FieldCount; ++i)
                        row[i] = data[i];
                    result.Rows.Add(row);
                }
                data.Close();
                return result;
            }
            catch
            {
                return null;
            }
        }

        public void CommitTransaction()
        {
            transaction.Commit();
            connection.Close();
        }
        public void RollbackTransaction()
        {
            transaction.Rollback();
            connection.Close();
        }

    }

    public struct DbParameters
    {      
        public string paramName;
        public DbType dbType;
        public object value;
    }

}
