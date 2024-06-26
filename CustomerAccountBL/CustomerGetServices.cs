using System.Reflection.Metadata;
using System.Collections.Generic;
using System.Linq;
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
            User FoundCostumer = new User();

            foreach (var user in GetAllUser())
            {
                if (user.accountnumber == accountnumber)
                {
                    FoundCostumer = user;
                }
            }
            return FoundCostumer;
        }
        public User GetUser(string accountnumber, string pin)
        {
            User FoundCostumer = new User();
            foreach (var user in GetAllUser())
            {
                if (user.accountnumber == accountnumber && user.pin == pin)
                {
                    FoundCostumer = user;
                }
            }
            return FoundCostumer;
        }
    }
}
