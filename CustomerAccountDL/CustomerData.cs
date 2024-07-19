using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BankAccountModel;

namespace CustomerAccountDL
{
    public  class CustomerData
    {
        List<User> users;
        SqlDbData sqlData;
        public CustomerData()
        {
            users = new List<User>();
            sqlData = new SqlDbData();

        }
        public List<User> GetUsers()
        {
            users = sqlData.GetUsers();
            return users;

        }
        public int DeleteUser(User user)
        {
            return sqlData.DeleteUser(user.accountnumber);
        }
        public int AddUser(User user)
        {
            return sqlData.AddUser(user.accountnumber, user.pin);
        }
        public int UpdateUser(User user)
        {
            return sqlData.UpdateUser(user.accountnumber, user.pin);

        }
    }
}
