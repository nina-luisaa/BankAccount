using BankAccountModel;
using System;

namespace CustomerAccountBL
{
    public class CustomerValidation
    {
        private readonly CustomerGetServices _getServices;

        public CustomerValidation()
        {
            _getServices = new CustomerGetServices();
        }

        public bool CheckIfAccountNumberExists(string accountNumber)
        {
           
            return _getServices.GetUser(accountNumber) != null;
        }

      
        public bool CheckIfUserExists(string accountNumber, string pin)
        {
            
            return _getServices.GetUser(accountNumber, pin) != null;
        }
    }
}
