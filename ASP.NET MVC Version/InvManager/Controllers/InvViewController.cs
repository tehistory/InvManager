using Microsoft.AspNetCore.Mvc;
using InvManager.Models;
using InvManager.Data;

namespace InvManager.Controllers
{
    public class InvViewController : Controller
    {
        private IInventoryRepository _invRepository;

        //public InvViewController(DBContext _context)
        //{
        //    this._invRepository = new InventoryRespository(_context);
        //}

        public InvViewController(IInventoryRepository inventoryRepository)
        {
            this._invRepository = inventoryRepository;
        }
        public IActionResult InvPage()
        {
            CombinedModel tempMod = new CombinedModel();
            tempMod.Containers = _invRepository.GetContainers();
            tempMod.Items = _invRepository.GetItems();
            return View(tempMod);
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
