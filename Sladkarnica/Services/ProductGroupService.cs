using System.Data;
using System.Data.SqlClient;
using Sladkarnica.DataBase;
using Sladkarnica.DataBase.Contracts;
using Sladkarnica.Services.Contracts;

namespace Sladkarnica.Services
{
    public class ProductGroupService : IProductGroupService
    {
        protected IDataBaseHelper dbHelper;

        public ProductGroupService()
        {
            this.dbHelper = new DatabaseHelper();
        }

        //Insert method for ProductGroups
        public void AddProductGroup(string groupName)
        {
            string query = "INSERT INTO [dbo].[ProductGroup] (GroupName) VALUES (@GroupName)";
            SqlParameter[] parameters = {
                new SqlParameter("@GroupName", SqlDbType.VarChar,50) { Value = groupName},
            };

            this.dbHelper.ExecuteNonQuery(query, parameters);
        }

        // Method for updating group by GroupID
        public bool UpdateProductGroupByID(int groupId, string newName)
        {
            string query = "UPDATE [dbo].[ProductGroup] SET GroupName = @GroupName WHERE GroupNumber = @GroupNumber";

            SqlParameter[] parameters = {
            new SqlParameter("@GroupName", SqlDbType.NVarChar) { Value = newName },
            new SqlParameter("@GroupNumber", SqlDbType.Int) { Value = groupId }
        };

            int rowsAffected = this.dbHelper.ExecuteNonQuery(query, parameters);

            return rowsAffected > 0;
        }

        // Method for updating gruop by GroupName
        public bool UpdateProductGroupByName(string groupName, string newName)
        {
            string query = "UPDATE [dbo].[ProductGroup] SET GroupName = @GroupName WHERE GroupName = @OldGroupName";

            SqlParameter[] parameters = {
            new SqlParameter("@GroupName", SqlDbType.NVarChar) { Value = newName },
            new SqlParameter("@OldGroupName", SqlDbType.NVarChar) { Value = groupName }
        };

            int rowsAffected = this.dbHelper.ExecuteNonQuery(query, parameters);

            return rowsAffected > 0;
        }

        // Method for deleting group by GroupID
        public bool DeleteProductGroupByID(int groupId)
        {
            string query = "DELETE FROM [dbo].[ProductGroup] WHERE GroupNumber = @GroupNumber";

            SqlParameter[] parameters = {
            new SqlParameter("@GroupNumber", SqlDbType.Int) { Value = groupId }
        };

            int rowsAffected = this.dbHelper.ExecuteNonQuery(query, parameters);

            return rowsAffected > 0;
        }
    }
}
