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

        string connectionString = "Data Source =LAPTOP-VSVG94EM\\SQLEXPRESS; Initial Catalog = AccountManagement; Integrated Security = True;";


        SqlConnection sqlConnection;

        public SqlDbData()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public List<User> GetUsers()
        {
            string selectStatement = "SELECT accountnumber, pin, status FROM users";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            List<User> users = new List<User>();

            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                string accountnumber = reader["accountnumber"].ToString();
                string pin = reader["pin"].ToString();

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

            string insertStatement = "INSERT INTO users VALUES (@accountnumber, @pin)";

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
            int success;

            string updateStatement = $"UPDATE users SET pin = @Pin WHERE accountnumber = @Accountnumber";
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
            int success;

            string deleteStatement = $"DELETE FROM users WHERE accountnumber = @accountnumber";
            SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);
            sqlConnection.Open();

            deleteCommand.Parameters.AddWithValue("@accountnumber", accountnumber);

            success = deleteCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }
    }
}