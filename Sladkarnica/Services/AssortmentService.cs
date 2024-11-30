using System.Data;
using System.Data.SqlClient;
using Sladkarnica.DataBase;
using Sladkarnica.DataBase.Contracts;
using Sladkarnica.Services.Contracts;

namespace Sladkarnica.Services
{
    public class AssortmentService : IAssortmentService
    {
        protected IDataBaseHelper dbHelper;

        public AssortmentService()
        {
            this.dbHelper = new DatabaseHelper();
        }

        //Insert method for Assortments
        public void AddAssortment(string assortmentNumber, string assortmentName, int gruopID, string recipe, decimal sweetsWeight, decimal price)
        {
            string query = "INSERT INTO [dbo].[Assortment] (AssortmentNumber, AssortmentName, GroupID, Recipe, SweetsWeight, Price) VALUES (@AssortmentNumber, @AssortmentName, @GroupID, @Recipe, @SweetsWeight, @Price)";
            SqlParameter[] parameters = {
            new SqlParameter("@AssortmentNumber", SqlDbType.NVarChar, 10) { Value = assortmentNumber },
            new SqlParameter("@AssortmentName", SqlDbType.NVarChar, 100) { Value = assortmentName },
            new SqlParameter("@GroupID", SqlDbType.Int) { Value = gruopID },
            new SqlParameter("@Recipe", SqlDbType.NVarChar, 200) { Value = recipe },
            new SqlParameter("@SweetsWeight", SqlDbType.Decimal) { Value = sweetsWeight },
            new SqlParameter("@Price", SqlDbType.Decimal) { Value = price },
        };
            this.dbHelper.ExecuteNonQuery(query, parameters);
        }

        // Method for updating assortment by ID
        public bool UpdateAssortmentByID(string assortmentNumber, string assortmentName, int gruopID, string recipe, decimal sweetsWeight, decimal price)
        {
            string query = "UPDATE [dbo].[Assortment] SET AssortmentName = @AssortmentName," +
                "GroupID = @GroupID," +
                "Recipe = @Recipe," +
                "SweetsWeight = @SweetsWeight," +
                "Price = @Price WHERE AssortmentNumber = @AssortmentNumber";

            SqlParameter[] parameters = {
            new SqlParameter("@AssortmentName", SqlDbType.NVarChar, 100) { Value = assortmentName },
            new SqlParameter("@GroupID", SqlDbType.Int) { Value = gruopID },
            new SqlParameter("@Recipe", SqlDbType.NVarChar, 200) { Value = recipe },
            new SqlParameter("@SweetsWeight", SqlDbType.Decimal) { Value = sweetsWeight },
            new SqlParameter("@Price", SqlDbType.Decimal) { Value = price },
            new SqlParameter("@AssortmentNumber", SqlDbType.NVarChar, 10) { Value = assortmentNumber },
        };

            int rowsAffected = this.dbHelper.ExecuteNonQuery(query, parameters);

            return rowsAffected > 0;
        }

        // Method for deleting assortment by ID
        public bool DeleteAssortmentByID(string groupId)
        {
            string query = "DELETE FROM [dbo].[Assortment] WHERE AssortmentNumber = @AssortmentNumber";

            SqlParameter[] parameters = {
            new SqlParameter("@AssortmentNumber", SqlDbType.NVarChar, 10) { Value = groupId }
        };

            int rowsAffected = this.dbHelper.ExecuteNonQuery(query, parameters);

            return rowsAffected > 0;
        }
    }
}
