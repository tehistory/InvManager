using Microsoft.AspNetCore.Mvc;
using InvManager.Models;
using InvManager.Data;

namespace InvManager.Controllers
{
    public class InvViewController : Controller
    {
        private IInventoryRepository _invRepository;

        public InvViewController()
        {
            this._invRepository = new InventoryRespository(new DBContext());
        }

        public InvViewController(IInventoryRepository inventoryRepository)
        {
            this._invRepository = inventoryRepository;
        }
        public IActionResult InvPage()
        {
            return View();
        }

        public IActionResult AddContainer()
        {
            return View();
        }

        public IActionResult AddItem()
        {
            return View();
        }
    }
}
