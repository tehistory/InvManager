using Microsoft.AspNetCore.Mvc;
using InvManager.Models;
using InvManager.Data;

namespace InvManager.Controllers
{
    public class AccountController : Controller
    {
        private DBContext _dbContext;

        public AccountController(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult SignInPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignInPage(AccountModel account)
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreateAccount()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAccount(AccountModel account)
        {
            return View();
        }
    }
}
