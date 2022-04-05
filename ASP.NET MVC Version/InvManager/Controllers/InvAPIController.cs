using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using InvManager.Data;
using InvManager.Models;
using System.Linq;

namespace InvManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvAPIController : ControllerBase
    {
        private IInventoryRepository _invRepository;

        public InvAPIController(IInventoryRepository inventoryRepository)
        {
            this._invRepository = inventoryRepository;
        }


        //changes container of an item or adds it to the database if not present
        [HttpPut("{accountID}")]
        public async Task<IActionResult> CheckItem(int accountID, ItemModel inItem)
        {
            IEnumerable<ContainerModel> conList = _invRepository.GetContainersByAccount(accountID);
            ContainerModel testModel = new ContainerModel();
            testModel.containerID = inItem.containerID;
            if (conList.Contains<Models.ContainerModel>(testModel))
            {
                //container exists

                IEnumerable<ItemModel> itemList = _invRepository.GetItemsByConID(inItem.containerID);
                
                if (itemList.Contains<ItemModel>(inItem))
                {
                    //item exists

                    _invRepository.EditItem(inItem);

                    //Item edited

                    return Ok();
                }
                else
                {
                    //item doesn't exist

                    _invRepository.InsertItem(inItem);

                    //item added

                    return Ok();
                }
            }
            else
            {
                //container doesn't exist

                return BadRequest();
            }
        }

        //creates a new container if container doesn't exist
        [HttpPut("{accountID}")]
        public async Task<IActionResult> CheckContainer(int accountID, ContainerModel inCon)
        {
            IEnumerable<ContainerModel> conList = _invRepository.GetContainersByAccount(accountID);
            if (conList.Contains<ContainerModel>(inCon))
            {
                //container exists

                return BadRequest();
            }
            else
            {
                //container doesn't exist

                _invRepository.InsertContainer(inCon);

                return Ok();
            }
        }
    }
}
