using Microsoft.AspNetCore.Mvc;
using InvManager.Models;
using InvManager.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace InvManager.Controllers
{
    public class InvViewController : Controller
    {
        private IInventoryRepository _invRepository;
        private UserManager<IdentityUser> _userManager;

        //public InvViewController(DBContext _context)
        //{
        //    this._invRepository = new InventoryRespository(_context);
        //}

        public InvViewController(IInventoryRepository inventoryRepository, UserManager<IdentityUser> userManager)
        {
            this._invRepository = inventoryRepository;
            this._userManager = userManager;
        }

        [Authorize()]
        [HttpGet]
        public IActionResult InvPage()
        {
            CombinedModel tempMod = new CombinedModel();
            try
            {
                tempMod.Containers = _invRepository.GetContainersByAccount(_userManager.GetUserId(User));
            }catch(Exception e)
            {
                tempMod.Containers = null;
            }
            try
            {
                tempMod.Items = _invRepository.GetItemsByConID(tempMod.Containers.First<ContainerModel>().containerID);
            }catch(Exception e)
            {
                tempMod.Items = null;
            }
            return View(tempMod);
        }

        [Authorize()]
        [HttpGet("{Controller}/{Action}/{id}")]
        public IActionResult InvPage(int id)
        {
            CombinedModel tempMod = new CombinedModel();
            try
            {
                tempMod.Containers = _invRepository.GetContainersByAccount(_userManager.GetUserId(User));
            }
            catch (Exception e)
            {
                tempMod.Containers = null;
            }
            try
            {
                tempMod.Items = _invRepository.GetItemsByConID(id);
            }
            catch (Exception e)
            {
                tempMod.Items = null;
            }
            tempMod.conMod = new ContainerModel();
            tempMod.itemMod = new ItemModel();
            return View(tempMod);
        }

        [HttpPost]
        public IActionResult AddContainer(string containerName)
        {
            ContainerModel newCon = new ContainerModel();
            newCon.accountID = _userManager.GetUserId(User);
            newCon.containerName = containerName;
            _invRepository.InsertContainer(newCon);
            return RedirectToAction("InvPage");
        }

        [HttpPost]
        public IActionResult AddItem(int containerID, string itemName)
        {
            ItemModel newItem = new ItemModel();
            newItem.containerID = containerID;
            newItem.itemName = itemName;
            _invRepository.InsertItem(newItem);
            return RedirectToAction("InvPage");
        }

        public IActionResult DeleteItem(int id)
        {
            _invRepository.DeleteItem(id);

            return RedirectToAction("InvPage");
        }

        public IActionResult DeleteCon(int id)
        {
            _invRepository.DeleteContainer(id);

            return RedirectToAction("InvPage");
        }

        [HttpPost]
        public IActionResult EditContainer(ContainerModel conMod)
        {
            _invRepository.EditContainer(conMod);

            return RedirectToAction("InvPage");
        }

        [HttpPost]
        public IActionResult EditItem(ItemModel itemMod)
        {
            _invRepository.EditItem(itemMod);

            return RedirectToAction("InvPage");
        }

    }
}
