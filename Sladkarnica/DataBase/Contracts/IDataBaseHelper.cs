using System.Data;
using System.Data.SqlClient;

namespace Sladkarnica.DataBase.Contracts
{
    public interface IDataBaseHelper
    {
        int ExecuteNonQuery(string query, SqlParameter[] parameters = null);

        DataTable ExecuteQuery(string query, SqlParameter[] parameters = null);
    }
}
