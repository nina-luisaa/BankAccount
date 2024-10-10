using Microsoft.AspNetCore.Mvc;
using CustomerAccountBL;

namespace BankAccountAPI.Controllers
{


    [ApiController]
    [Route("api/user")]
    public class UserController : Controller
    {
        CustomerGetServices _CustomerGetServices;
        CustomerTransaction _CustomerTransaction;

        public UserController()
        {
            _CustomerGetServices = new CustomerGetServices();
            _CustomerTransaction = new CustomerTransaction();
        }

        [HttpGet]
        public IEnumerable<BankAccountAPI.User> GetUsers()
        {
            var activeusers = _CustomerGetServices.GetAllUser();

            List<BankAccountAPI.User> users = new List<User>();

            foreach (var item in activeusers)
            {
                users.Add(new BankAccountAPI.User { accountnumber = item.accountnumber, pin = item.pin, balance = item.balance });
            }

            return users;
        }

        [HttpPost]
        public JsonResult AddUser(User request)
        {
            var result = _CustomerTransaction.CreateUser(request.accountnumber, request.pin, request.balance);

            return new JsonResult(result);
        }

        [HttpPatch]
        public JsonResult UpdateUser(User request)
        {
            var result = _CustomerTransaction.UpdateUser(request.accountnumber, request.pin, request.balance);

            return new JsonResult(result);
        }

            [HttpDelete]
            public JsonResult DeleteUser(User request)
            {
            var result = _CustomerTransaction.DeleteUser(request.accountnumber, request.pin, request.balance);

                return new JsonResult(result);
            }
        }
    }




       