
using CustomerAccountBL;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
            {
                CustomerGetServices getServices = new CustomerGetServices();

                var users = getServices.GetAllUser();

                foreach (var item in users)
                {
                    Console.WriteLine(item.accountnumber);
                    Console.WriteLine(item.pin);
                }

            }
        }
    }

