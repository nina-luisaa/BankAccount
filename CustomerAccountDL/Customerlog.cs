using System.Reflection.Metadata;

using BankAccountModel;

namespace CustomerAccountDL
{
    public class Customerlog
    {
        private List<User> dummyUsers = new List<User>();

        public List<User> GetDummyUsers()
        {
            dummyUsers.Add(CreateDummyUser("Nina", "nina11", "20"));
            dummyUsers.Add(CreateDummyUser("Luisa", "isang04", "34"));

            return dummyUsers;
        }

        private User CreateDummyUser(string accountnumber, string pin, string balance)
        {
            User user = new User
            {
                accountnumber = accountnumber,
                pin = pin,
                balance = balance
            };

            return user;
        }
    }
}
