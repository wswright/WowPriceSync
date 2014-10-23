using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scott.WoWAPI
{
    public interface IDBLayer
    {
        /// <summary>
        /// Executes a bulk insert of the given table into the given tablename.
        /// </summary>
        /// <param name="tbl">The data to insert.</param>
        /// <param name="tableName">The table to insert the data into.</param>
        /// <returns>True if successful, otherwise false.</returns>
        Task<bool> BulkInsert(DataTable tbl, string tableName);

        /// <summary>
        /// Executes a query and returns a scalar int?. Fails if the scalar value is not an integer.
        /// </summary>
        /// <param name="cmd">The command to execute.</param>
        /// <returns>Returns the integer in the first row of the first column. If it fails, or the scalar value is not an integer, null is retured.</returns>
        Task<int?> ExecuteQuery_ScalarInt(SqlCommand cmd);

        /// <summary>
        /// Executes the given command as a non-query.
        /// </summary>
        /// <param name="cmd">The command to execute.</param>
        /// <param name="checkRowsAreAffected">If true, ExecuteNonQuery only returns true if 1 or more rows were affected.</param>
        /// <returns>True if successful, otherwise false. Also returns false if checkRowsAreAffected is true and no rows were affected.</returns>
        Task<bool> ExecuteNonQuery(SqlCommand cmd, bool checkRowsAreAffected);

        Task<DataTable> ExecuteQuery(SqlCommand cmd);

        DataTable ExecuteQuerySynchronous(SqlCommand cmd);
    }
}
