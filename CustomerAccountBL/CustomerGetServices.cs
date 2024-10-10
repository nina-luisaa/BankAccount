using System.Collections.Generic;
using CustomerAccountDL;
using BankAccountModel;

namespace CustomerAccountBL
{
    public class CustomerGetServices
    {
        public List<User> GetAllUser()
        {
            CustomerData userData = new CustomerData();
            return userData.GetUsers();
        }

        public User GetUser(string accountnumber)
        {
            User foundCustomer = null;

            foreach (var user in GetAllUser())
            {
                if (user.accountnumber == accountnumber)
                {
                    foundCustomer = user;
                    break;
                }
            }
            return foundCustomer;
        }

        public User GetUser(string accountnumber, string pin)
        {
            User foundCustomer = null;

            foreach (var user in GetAllUser())
            {
                if (user.accountnumber == accountnumber && user.pin == pin)
                {
                    foundCustomer = user;
                    break;
                } 
            }
            return foundCustomer;
        }
    }
}
