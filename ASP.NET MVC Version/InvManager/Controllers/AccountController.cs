using Microsoft.AspNetCore.Mvc;
using InvManager.Models;

namespace InvManager.Controllers
{
    public class AccountController : Controller
    {
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
