using BankAccountModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAccountBL
{
    public class CostumerValidation
    {
        CustomerGetServices getservices = new CustomerGetServices();


        public bool CheckIfaccountnumberExists(string accountnumber)
        {
            bool result = getservices.GetUser(accountnumber) != null;
            return result;
        }
        public bool CheckifUserExsist(string accountnumber, string pin)
        {
            bool result = getservices.GetUser(accountnumber, pin) != null;
            return result;

        }
    }
}
