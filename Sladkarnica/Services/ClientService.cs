﻿using System.Data;
using System.Data.SqlClient;
using Sladkarnica.DataBase;
using Sladkarnica.DataBase.Contracts;
using Sladkarnica.Services.Contracts;

namespace Sladkarnica.Services
{
    public class ClientService : IClientService
    {
        private IDataBaseHelper dbHelper;

        public ClientService()
        {
            this.dbHelper = new DatabaseHelper();
        }

        //Insert method for Client
        public void AddClient(string name, string adress, string phoneNumber)
        {
            string query = "INSERT INTO [dbo].[Client] (ClientName, Adress, Phone) VALUES (@ClientName, @Adress, @Phone)";
            SqlParameter[] parameters = {
                new SqlParameter("@ClientName", SqlDbType.VarChar,50) { Value = name},
                new SqlParameter("@Adress", SqlDbType.VarChar,50) { Value = adress},
                new SqlParameter("@Phone", SqlDbType.VarChar,50) { Value = phoneNumber},
            };

            this.dbHelper.ExecuteNonQuery(query, parameters);
        }

        // Method for updating group by GroupID
        public bool UpdateClientByID(int clientID, string name, string adress, string phoneNumber)
        {
            string query = "UPDATE [dbo].[Client] SET ClientName = @ClientName," +
                "Adress = @Adress," +
                "Phone = @Phone WHERE ClientID = @ClientID";

            SqlParameter[] parameters = {
                  new SqlParameter("@ClientName", SqlDbType.VarChar,50) { Value = name},
                  new SqlParameter("@Adress", SqlDbType.VarChar,50) { Value = adress},
                  new SqlParameter("@Phone", SqlDbType.VarChar,50) { Value = phoneNumber},
                  new SqlParameter("@ClientID", SqlDbType.Int) { Value = clientID }
            };

            int rowsAffected = this.dbHelper.ExecuteNonQuery(query, parameters);

            return rowsAffected > 0;
        }

        // Method for deleting group by GroupID
        public bool DeleteClientByID(int clientID)
        {
            string query = "DELETE FROM [dbo].[Client] WHERE ClientID = @ClientID";

            SqlParameter[] parameters = {
            new SqlParameter("@ClientID", SqlDbType.Int) { Value = clientID }
        };

            int rowsAffected = this.dbHelper.ExecuteNonQuery(query, parameters);

            return rowsAffected > 0;
        }
    }
}