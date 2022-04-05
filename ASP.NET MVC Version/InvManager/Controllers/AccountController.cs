using Microsoft.AspNetCore.Mvc;
using InvManager.Models;
using InvManager.Data;

namespace InvManager.Controllers
{
    public class AccountController : Controller
    {
        private IInventoryRepository _invRepository;

        //public AccountController(DBContext _context)
        //{
        //    this._invRepository = new InventoryRespository(_context);
        //}

        public AccountController(IInventoryRepository inventoryRepository)
        {
            this._invRepository = inventoryRepository;
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
