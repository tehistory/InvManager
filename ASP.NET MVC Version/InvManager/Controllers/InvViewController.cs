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

        [HttpGet]
        public IActionResult InvPage(int conID)
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
                tempMod.Items = _invRepository.GetItemsByConID(conID);
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
        public IActionResult AddContainer(string conName)
        {
            ContainerModel newCon = new ContainerModel();
            newCon.accountID = _userManager.GetUserId(User);
            newCon.containerName = conName;
            _invRepository.InsertContainer(newCon);
            return InvPage();
        }

        public IActionResult AddItem()
        {
            return View();
        }
    }
}
