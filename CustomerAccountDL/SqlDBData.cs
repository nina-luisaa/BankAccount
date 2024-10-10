
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BankAccountModel;

namespace CustomerAccountDL
{
    public class SqlDbData
    {
        string connectionString = "Data Source=LAPTOP-VSVG94EM;Initial Catalog=BankAccount;Integrated Security=True;";
        SqlConnection sqlConnection;

        public SqlDbData()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public List<User> GetUsers()
        {
            string selectStatement = "SELECT accountnumber, pin, balance FROM [User]";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            sqlConnection.Open();
            List<User> users = new List<User>();

            using (SqlDataReader reader = selectCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    string accountnumber = reader["accountnumber"].ToString();
                    string pin = reader["pin"].ToString();
                    string balance = reader["balance"].ToString();

                    User readUser = new User
                    {
                        accountnumber = accountnumber,
                        pin = pin,
                        balance = balance
                    };

                    users.Add(readUser);
                }
            }

            sqlConnection.Close();
            return users;
        }

        public int AddUser(string accountnumber, string pin, string balance)
        {
            int success;
            string insertStatement = "INSERT INTO [User] (accountnumber, pin, balance) VALUES (@accountnumber, @pin, @balance)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);
            insertCommand.Parameters.AddWithValue("@accountnumber", accountnumber);
            insertCommand.Parameters.AddWithValue("@pin", pin);
            insertCommand.Parameters.AddWithValue("@balance", balance);

            sqlConnection.Open();
            success = insertCommand.ExecuteNonQuery();
            sqlConnection.Close();

            return success;
        }

        public int UpdateUser(string accountnumber, string pin, string balance)
        {
            int success;
            string updateStatement = "UPDATE [User] SET pin = @pin, balance = @balance WHERE accountnumber = @accountnumber";
            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);

            updateCommand.Parameters.AddWithValue("@accountnumber", accountnumber);
            updateCommand.Parameters.AddWithValue("@pin", pin);
            updateCommand.Parameters.AddWithValue("@balance", balance);

            sqlConnection.Open();
            success = updateCommand.ExecuteNonQuery();
            sqlConnection.Close();

            return success;
        }

        public int DeleteUser(string accountnumber)
        {
            int success = 0;
            string deleteStatement = "DELETE FROM [User] WHERE accountnumber = @accountnumber";

            using (SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection))
            {
                deleteCommand.Parameters.AddWithValue("@accountnumber", accountnumber);

                sqlConnection.Open();
                success = deleteCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }

            return success;
        }
    }
}

