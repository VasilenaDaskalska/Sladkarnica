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
        public void AddOrder(DateTime date, string assortmentID, bool isReady, int quantity, int clientID)
        {
            string query = "INSERT INTO [dbo].[Order] (OrderDate, AssortmentID, Crafting, Quantity) VALUES (@OrderDate, @AssortmentID, @Crafting, @Quantity)";
            SqlParameter[] parameters = {
            new SqlParameter("@OrderDate", SqlDbType.Date) { Value = date },
            new SqlParameter("@AssortmentID", SqlDbType.NVarChar, 10) { Value = assortmentID },
            new SqlParameter("@Crafting", SqlDbType.Bit) { Value = isReady },
            new SqlParameter("@Quantity", SqlDbType.Int) { Value = quantity },
        };
            int rowsAffected = this.dbHelper.ExecuteNonQuery(query, parameters);

            if (rowsAffected > 0)
            {
                // Get ID on last order
                string selectLastOrderQuery = "select [Order].OrderID from [Order] order by OrderID DESC;";
                var lastInsertedID = this.dbHelper.ExecuteScalar(selectLastOrderQuery);

                //Insert into ClientOrder
                string insertClientOrderQuery = "INSERT INTO ClientOrder (ClientID, OrderID) " +
                                                "VALUES (@ClientID, @OrderID);";

                SqlParameter[] clientOrderParameters = {
                new SqlParameter("@ClientID", SqlDbType.Int) { Value = clientID },
                new SqlParameter("@OrderID", SqlDbType.Int) { Value = lastInsertedID }
            };

                this.dbHelper.ExecuteNonQuery(insertClientOrderQuery, clientOrderParameters);
            }
        }

        //Update method for Orders by ID
        public void UpdateOrderByID(int orderID, DateTime date, string assortmentID, bool isReady, int quantity)
        {
            string query = "UPDATE [dbo].[Order] SET OrderDate = @OrderDate," +
                "AssortmentID = @AssortmentID," +
                "Crafting = @Crafting," +
                "Quantity = @Quantity WHERE OrderID = @OrderID";
            SqlParameter[] parameters = {
            new SqlParameter("@OrderDate", SqlDbType.Date) { Value = date },
            new SqlParameter("@AssortmentID", SqlDbType.NVarChar, 10) { Value = assortmentID },
            new SqlParameter("@Crafting", SqlDbType.Bit) { Value = isReady },
            new SqlParameter("@Quantity", SqlDbType.Int) { Value = quantity },
            new SqlParameter("@OrderID", SqlDbType.Int) { Value = orderID },
        };
            this.dbHelper.ExecuteNonQuery(query, parameters);
        }

        // Method for deleting orders by ID
        public bool DeleteOrderByID(int groupId)
        {
            string query = "DELETE FROM [dbo].[Order] WHERE OrderID = @OrderID";

            SqlParameter[] parameters = {
            new SqlParameter("@OrderID", SqlDbType.Int) { Value = groupId }
        };

            int rowsAffected = this.dbHelper.ExecuteNonQuery(query, parameters);

            return rowsAffected > 0;
        }

        //Get orders by date
        public DataTable GetOrdersByDate(DateTime date)
        {
            string query = "SELECT [dbo].[Order].OrderID, [dbo].[Order].OrderDate, [dbo].[Assortment].AssortmentName " +
                           "AS Assortment, [dbo].[Order].Quantity, [dbo].[Order].FinalPrice " +
                           "FROM [dbo].[Order] " +
                           "JOIN [dbo].[Assortment] ON [dbo].[Order].AssortmentID = [dbo].[Assortment].AssortmentNumber " +
                           "WHERE [dbo].[Order].OrderDate = @OrderDate " +
                           "ORDER BY [dbo].[Order].OrderID";

            SqlParameter[] parameters = {
            new SqlParameter("@OrderDate", SqlDbType.Date) { Value = date }
        };

            return this.dbHelper.ExecuteQuery(query, parameters);
        }

        //Get revenue for period
        public DataTable GetRevenueByPeriod(DateTime startDate, DateTime endDate)
        {
            string query = "SELECT [dbo].[ProductGroup].GroupName AS ProductGroup," +
                           "[dbo].[Assortment].AssortmentName AS Assortment, " +
                           "SUM([dbo].[Order].FinalPrice) AS Revenue " +
                           "FROM [dbo].[Order] " +
                           "JOIN [dbo].[Assortment] ON [dbo].[Order].AssortmentID = [dbo].[Assortment].AssortmentNumber " +
                           "JOIN [dbo].[ProductGroup] ON [dbo].[Assortment].GroupID = [dbo].[ProductGroup].GroupNumber " +
                           "WHERE [dbo].[Order].OrderDate BETWEEN @startDate AND @endDate " +
                           "GROUP BY [dbo].[ProductGroup].GroupName, [dbo].[Assortment].AssortmentName " +
                           "ORDER BY [dbo].[ProductGroup].GroupName, [dbo].[Assortment].AssortmentName";

            SqlParameter[] parameters = {
            new SqlParameter("@startDate", SqlDbType.Date) { Value = startDate },
            new SqlParameter("@endDate", SqlDbType.Date) { Value = endDate }
        };

            return this.dbHelper.ExecuteQuery(query, parameters);
        }

        //Get all orders
        public DataTable GetAllOrders()
        {
            string query = "SELECT * FROM [dbo].[Order]";

            return this.dbHelper.ExecuteQuery(query);
        }
    }
}
