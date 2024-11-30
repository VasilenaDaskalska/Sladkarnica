using System;
using System.Data;
using System.Data.SqlClient;

namespace Sladkarnica
{
    public class SqlCommandsHelper
    {
        //Insert method for Orders
        public void AddOrder(DateTime date, string assortmentID, bool isReady, int quantity)
        {
            DatabaseHelper dbHelper = new DatabaseHelper();

            string query = "INSERT INTO [dbo].[Order] (OrderDate, AssortmentID, Crafting, Quantity) VALUES (@OrderDate, @AssortmentID, @Crafting, @Quantity)";
            SqlParameter[] parameters = {
            new SqlParameter("@OrderDate", SqlDbType.Date) { Value = date },
            new SqlParameter("@AssortmentID", SqlDbType.NVarChar, 10) { Value = assortmentID },
            new SqlParameter("@Crafting", SqlDbType.Bit) { Value = isReady },
            new SqlParameter("@Quantity", SqlDbType.Int) { Value = quantity },
        };
            dbHelper.ExecuteNonQuery(query, parameters);
        }

        //Insert method for Assortments
        public void AddAssortment(string assortmentNumber, string assortmentName, int gruopID, string recipe, decimal sweetsWeight, decimal price)
        {
            DatabaseHelper dbHelper = new DatabaseHelper();

            string query = "INSERT INTO [dbo].[Assortment] (AssortmentNumber, AssortmentName, GroupID, Recipe, SweetsWeight, Price) VALUES (@AssortmentNumber, @AssortmentName, @GroupID, @Recipe, @SweetsWeight, @Price)";
            SqlParameter[] parameters = {
            new SqlParameter("@AssortmentNumber", SqlDbType.NVarChar, 10) { Value = assortmentNumber },
            new SqlParameter("@AssortmentName", SqlDbType.NVarChar, 100) { Value = assortmentName },
            new SqlParameter("@GroupID", SqlDbType.Int) { Value = gruopID },
            new SqlParameter("@Recipe", SqlDbType.NVarChar, 200) { Value = recipe },
            new SqlParameter("@SweetsWeight", SqlDbType.Decimal) { Value = sweetsWeight },
            new SqlParameter("@Price", SqlDbType.Decimal) { Value = price },
        };
            dbHelper.ExecuteNonQuery(query, parameters);
        }

        //Insert method for ProductGroups
        public void AddProductGroup(string groupName)
        {
            DatabaseHelper dbHelper = new DatabaseHelper();

            string query = "INSERT INTO [dbo].[ProductGroup] (GroupName) VALUES (@GroupName)";
            SqlParameter[] parameters = {
                new SqlParameter("@GroupName", SqlDbType.VarChar,50) { Value = groupName},
            };

            dbHelper.ExecuteNonQuery(query, parameters);
        }
    }
}
