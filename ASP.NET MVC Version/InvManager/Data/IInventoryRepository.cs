using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using InvManager.Models;

namespace InvManager.Data
{
    public interface IInventoryRepository : IDisposable
    {
        IEnumerable<ContainerModel> GetContainers();
        IEnumerable<ContainerModel> GetContainersByAccount(int accountID);
        void InsertContainer(ContainerModel container);
        void DeleteContainer(int conID);
        IEnumerable<ItemModel> GetItems();
        IEnumerable<ItemModel> GetItemsByConID(int containerID);
        void InsertItem(ItemModel item);
        void EditItem(ItemModel item);
        void DeleteItem(int itemID);
        void Save();
    }
}
