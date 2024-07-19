
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAccountModel;

namespace CustomerAccountDL
{
    public class SqlDbData
    {
        string connectionString
        = "Server = tcp:20.189.78.204,1433; Database = BankAccount; User Id = sa; Password = LuisaNina123!";

        SqlConnection sqlConnection;

        public SqlDbData()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public List<User> GetUsers()
        {
            string selectStatement = "SELECT accountnumber, pin FROM [Users]";
            ;


            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            List<User> users = new List<User>();

            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                string accountnumber = reader["accountnumber"].ToString();
                string pin = reader["Pin"].ToString();

                User readUser = new User();
                readUser.accountnumber = accountnumber;
                readUser.pin = pin;
                users.Add(readUser);
            }

            sqlConnection.Close();

            return users;
        }

        public int AddUser(string accountnumber, string pin)
        {
            int success;

            string insertStatement = "INSERT INTO Users VALUES (@accountnumber, @pin)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@accountnumber", accountnumber);
            insertCommand.Parameters.AddWithValue("@pin", pin);
            sqlConnection.Open();

            success = insertCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }

        public int UpdateUser(string accountnumber, string pin)
        {
            ;
            int success;

            string updateStatement = $"UPDATE Users SET Pin = @Pin WHERE accountnumber = @accountnumber";
            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);
            sqlConnection.Open();

            updateCommand.Parameters.AddWithValue("accountnumber", accountnumber);
            updateCommand.Parameters.AddWithValue("@pin", pin);

            success = updateCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }

        public int DeleteUser(string accountnumber)
        {
            int success = 0;

            string deleteStatement = "DELETE FROM Users WHERE accountnumber = @accountnumber";
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