using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAccountModel;



using CustomerAccountDL;


namespace CustomerAccountBL
{
    public class CustomerTransaction
    {
        private CustomerValidation validationServices = new CustomerValidation();
        private UserData userData = new UserData();

        public bool CreateUser(User user)
        {
            bool result = false;

            if (!validationServices.CheckIfUserNameExists(user.accountnumber))
            {
                result = userData.AddUser(user) > 0;
            }

            return result;
        }

        public bool CreateUser(string accountnumber, string pin)
        {
            User user = new User { accountnumber = accountnumber, pin = pin };

            return CreateUser(user);
        }

        public bool UpdateUser(User user)
        {
            bool result = false;

            if (validationServices.CheckIfUserNameExists(user.accountnumber))
            {
                result = userData.UpdateUser(user) > 0;
            }

            return result;
        }

        public bool UpdateUser(string accountnumber, string pin)
        {
            User user = new User { accountnumber = accountnumber, pin = pin };

            return UpdateUser(user);
        }

        public bool DeleteUser(User user)
        {
            bool result = false;

            if (validationServices.CheckIfUserNameExists(user.accountnumber))
            {
                result = userData.DeleteUser(user) > 0;
            }

            return result;
        }

        public bool DeleteUser(string accountnumber, string pin)
        {
            User user = new User { accountnumber = accountnumber, pin = pin };

            return DeleteUser(user);
        }
    }


    public class CustomerValidation
    {
        public bool CheckIfUserNameExists(string accountnumber)
        {

            return false;
        }
    }

    public class UserData
    {
        public int AddUser(User user)
        {

            return 1;
        }

        public int UpdateUser(User user)
        {

            return 1;
        }

        public int DeleteUser(User user)
        {

            return 1;
        }
    }
}
