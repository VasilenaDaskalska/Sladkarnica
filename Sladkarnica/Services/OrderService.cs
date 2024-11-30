using System;
using System.Data;
using System.Data.SqlClient;
using Sladkarnica.DataBase;
using Sladkarnica.DataBase.Contracts;
using Sladkarnica.Services.Contracts;

namespace Sladkarnica.Services
{
    public class OrderService : IOrdersService
    {
        protected IDataBaseHelper dbHelper;

        public OrderService()
        {
            this.dbHelper = new DatabaseHelper();
        }

        //Insert method for Orders
        public void AddOrder(DateTime date, string assortmentID, bool isReady, int quantity)
        {
            string query = "INSERT INTO [dbo].[Order] (OrderDate, AssortmentID, Crafting, Quantity) VALUES (@OrderDate, @AssortmentID, @Crafting, @Quantity)";
            SqlParameter[] parameters = {
            new SqlParameter("@OrderDate", SqlDbType.Date) { Value = date },
            new SqlParameter("@AssortmentID", SqlDbType.NVarChar, 10) { Value = assortmentID },
            new SqlParameter("@Crafting", SqlDbType.Bit) { Value = isReady },
            new SqlParameter("@Quantity", SqlDbType.Int) { Value = quantity },
        };
            this.dbHelper.ExecuteNonQuery(query, parameters);
        }

    }
}
