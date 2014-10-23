using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using Scott.WoWAPI;

namespace WoWPriceSyncUI
{
    public class DBManager : IDBLayer
    {
        private const string DEFAULT_DATABASE = "WOW";
        private static string ConnectionString;
        public static SqlConnection conn;
        public static readonly object DBManagerLock = new object();
        public bool IsWarmedUp = false;

        public DBManager()
        {
            var conString = ConfigurationManager.ConnectionStrings[DEFAULT_DATABASE];
            ConnectionString = conString.ConnectionString;
            conn = new SqlConnection(ConnectionString);
        }

        //Creates connection to DB
        public void Warmup()
        {
            Initialize();
            IsWarmedUp = true;
        }

        private void Initialize()
        {
            try
            {
                Logger.Log(string.Format("Connecting to [{0}] Database...", DEFAULT_DATABASE), Logger.Level.Info);
                conn.Open();
                Logger.Log(string.Format("Connected to [{0}] Database!", DEFAULT_DATABASE), Logger.Level.Info);
            }
            catch (Exception eX)
            {
                Logger.Log("Failed to connect to Database! Error: " + eX.Message, Logger.Level.Error);
            }
        }

        public DataTable ExecuteQuery(string query)
        {
            return ExecuteQuery(new SqlCommand(query, conn));
        }

        public DataTable ExecuteQuery(SqlCommand cmd)
        {
            if (cmd.Connection == null)
                cmd.Connection = conn;
            DataTable data = new DataTable();

            try
            {
                data.Load(cmd.ExecuteReader());
            }
            catch (Exception eX)
            {
                LogQueryException(cmd, eX);
            }
            return data;
        }

        public int ExecuteNonQuery(string qry)
        {
            return ExecuteNonQuery(new SqlCommand(qry, conn));
        }

        public int ExecuteNonQuery(SqlCommand cmd)
        {
            if (cmd.Connection == null)
                cmd.Connection = conn;
            return cmd.ExecuteNonQuery();
        }

        public object ExecuteNonQueryIdentity(SqlCommand cmd)
        {
            if (cmd.Connection == null)
                cmd.Connection = conn;
            object obj = null;
            try
            {
                cmd.CommandText += " SELECT SCOPE_IDENTITY();";
                obj = cmd.ExecuteScalar();
            }
            catch (Exception eX)
            {
                LogQueryException(cmd, eX);
            }
            return obj;
        }

        /// <summary>
        /// Executes a query intended to check if a single row exists.
        /// </summary>
        /// <param name="query"></param>
        /// <returns>True if the row exists, otherwise false.</returns>
        public bool ExecuteExistsQuery(string query)
        {
            return ExecuteExistsQuery(new SqlCommand(query, conn));
        }

        public bool ExecuteExistsQuery(SqlCommand cmd)
        {
            if (cmd.Connection == null)
                cmd.Connection = conn;
            DataTable data = new DataTable();

            try
            {
                data.Load(cmd.ExecuteReader());
            }
            catch (Exception eX)
            {
                LogQueryException(cmd, eX);
            }
            if (data == null || data.Rows.Count != 1)
                return false;
            return true;

        }

        private static void LogQueryException(SqlCommand cmd, Exception eX)
        {
            Logger.Log(string.Format("Failed to execute query! {2}Query: [{0}]{2}Error: [{1}]", cmd.CommandText, eX.Message, "\r\n\t"), Logger.Level.Error);
        }

        public async Task<bool> BulkInsert(DataTable tbl, string tableName)
        {
            if (conn == null || conn.State != ConnectionState.Open)
                return false;
            try
            {
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn))
                {
                    bulkCopy.DestinationTableName = tableName;
                    bulkCopy.BulkCopyTimeout = 60;
                    await bulkCopy.WriteToServerAsync(tbl);
                    return true;
                }
            }
            catch (Exception eX)
            {
                Logger.Log("Bulk Insert failed! Message: " + eX.Message, Logger.Level.Error);
                return false;
            }
        }


        /// <summary>
        /// Executes a sqlcommand and returns the first row of the first column as an integer.
        /// </summary>
        /// <param name="cmd">The command to execute.</param>
        /// <returns>An integer if successful, otherwise returns null.</returns>
        public async Task<int?> ExecuteQuery_ScalarInt(SqlCommand cmd)
        {
            if (cmd.Connection == null)
                cmd.Connection = conn;

            try
            {
                object objInt = await cmd.ExecuteScalarAsync();
                if (objInt is int)
                    return (int)objInt;
                else
                    return null;
            }
            catch (Exception eX)
            {
                LogQueryException(cmd, eX);
                return null;
            }
        }

        /// <summary>
        /// Executes a sqlcommand and returns the first row of the first column as an double.
        /// </summary>
        /// <param name="cmd">The command to execute.</param>
        /// <returns>An double if successful, otherwise returns null.</returns>
        public async Task<double?> ExecuteQuery_ScalarDouble(SqlCommand cmd)
        {
            if (cmd.Connection == null)
                cmd.Connection = conn;

            try
            {
                object objDbl = await cmd.ExecuteScalarAsync();
                if (objDbl is double)
                    return (double)objDbl;
                else
                    return null;
            }
            catch (Exception eX)
            {
                LogQueryException(cmd, eX);
                return null;
            }
        }

        /// <summary>
        /// Executes a sqlcommand and returns the first row of the first column as an double.
        /// </summary>
        /// <param name="cmd">The command to execute.</param>
        /// <returns>An double if successful, otherwise returns null.</returns>
        public double? ExecuteQuery_ScalarDoubleSynchronous(SqlCommand cmd)
        {
            if (cmd.Connection == null)
                cmd.Connection = conn;

            try
            {
                object objDbl = cmd.ExecuteScalar();
                if (objDbl is double)
                    return (double)objDbl;
                else
                    return null;
            }
            catch (Exception eX)
            {
                LogQueryException(cmd, eX);
                return null;
            }
        }

        /// <summary>
        /// Executes a non-query asynchronously..
        /// </summary>
        /// <param name="cmd">The command to execute.</param>
        /// <param name="checkRowsAreAffected">If true, ExecuteNonQuery only returns true if 1 or more rows were affected.</param>
        /// <returns>True if successful, otherwise false. Also returns false if checkRowsAreAffected is true and no rows were affected.</returns>
        async Task<bool> IDBLayer.ExecuteNonQuery(SqlCommand cmd, bool checkRowsAreAffected)
        {
            if (cmd.Connection == null)
                cmd.Connection = conn;
            try
            {
                int rows = await cmd.ExecuteNonQueryAsync();

                if (checkRowsAreAffected)
                    return (rows > 0);
                else return true;
            }
            catch (Exception eX)
            {
                LogQueryException(cmd, eX);
                return false;
            }
        }

        /// <summary>
        /// Executes a query asynchronously.
        /// </summary>
        /// <param name="cmd">The command to execute.</param>
        /// <returns>Datatable with query data if successful, otherwise returns empty datatable.</returns>
        async Task<DataTable> IDBLayer.ExecuteQuery(SqlCommand cmd)
        {
            StopWatch sWatch = new StopWatch();
            sWatch.Start();

            if (cmd.Connection == null)
                cmd.Connection = conn;
            try
            {
                DataTable tbl = new DataTable();
                using (SqlDataReader rdr = await cmd.ExecuteReaderAsync())
                {
                    tbl.Load(rdr);
                }
                sWatch.Stop();
                sWatch.LogLaps("ExecuteQuery");
                return tbl;
            }
            catch (Exception eX)
            {
                LogQueryException(cmd, eX);
                return new DataTable();
            }
        }


        public DataTable ExecuteQuerySynchronous(SqlCommand cmd)
        {
            if (cmd.Connection == null)
                cmd.Connection = conn;
            try
            {
                DataTable tbl = new DataTable();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    tbl.Load(rdr);
                }
                return tbl;
            }
            catch (Exception eX)
            {
                LogQueryException(cmd, eX);
                return new DataTable();
            }
        }
    }
}
