using System;
using BankAccountModel;
using CustomerAccountDL;

namespace CustomerAccountBL
{
    public class CustomerTransaction
    {
        private readonly CustomerValidation _validationServices;
        private readonly CustomerData _userData;

        public CustomerTransaction()
        {
            _validationServices = new CustomerValidation();
            _userData = new CustomerData();
        }

       
        public bool CreateUser(User user)
        {
           
            if (!_validationServices.CheckIfAccountNumberExists(user.accountnumber))
            {
                
                return _userData.AddUser(user) > 0;
            }
            return false;
        }

       
        public bool CreateUser(string accountnumber, string pin, string balance)
        {
            User user = new User { accountnumber = accountnumber, pin = pin, balance = balance };
            return CreateUser(user);
        }

       
        public bool UpdateUser(User user)
        {
            
            if (_validationServices.CheckIfAccountNumberExists(user.accountnumber))
            {
                return _userData.UpdateUser(user) > 0;
            }
            return false;
        }

    
        public bool UpdateUser(string accountnumber, string pin, string  balance)
        {
            User user = new User { accountnumber = accountnumber, pin = pin, balance = balance };
            return UpdateUser(user);
        }

       
        public bool DeleteUser(User user)
        {
            
            if (_validationServices.CheckIfAccountNumberExists(user.accountnumber))
            {
              
                return _userData.DeleteUser(user) > 0;
            }
            return false;
        }

        
        public bool DeleteUser(string accountnumber, string pin, string balance)
        {
            User user = new User { accountnumber = accountnumber, pin = pin, balance = balance };
            return DeleteUser(user);
        }
    }
}


