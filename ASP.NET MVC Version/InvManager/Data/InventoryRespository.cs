using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using InvManager.Models;

namespace InvManager.Data
{
    public class InventoryRespository : IInventoryRepository, IDisposable
    {
        private DBContext _context;

        public InventoryRespository(DBContext context)
        {
            this._context = context;
            
        }

        public IEnumerable<ContainerModel> GetContainers()
        {
            IEnumerable<ContainerModel> ReturnContainers = from e in _context.Containers select e;

            return ReturnContainers;
        }

        public IEnumerable<ContainerModel> GetContainersByAccount(int id)
        {
            IEnumerable<ContainerModel> ReturnContainers = from e in _context.Containers where e.accountID == id select e;

            return ReturnContainers;
        }

        public void InsertContainer(ContainerModel con)
        {
            _context.Add(con);
        }

        public void DeleteContainer(int conID)
        {
            ContainerModel container = _context.Containers.Find(conID);
            if (container != null)
            {
                _context.Remove<ContainerModel>(container);
            }
            else
            {
                //error handle for null container
            }                
        }

        public IEnumerable<ItemModel> GetItems()
        {
            IEnumerable<ItemModel> ReturnItems = from e in _context.Items select e;

            return ReturnItems;
        }

        public IEnumerable<ItemModel> GetItemsByConID(int conID)
        {
            IEnumerable<ItemModel> ReturnItems = from e in _context.Items where e.containerID == conID select e;

            return ReturnItems;
        }

        public void InsertItem(ItemModel item)
        {
            _context.Add(item);
        }

        public void EditItem(ItemModel item)
        {
            _context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void DeleteItem(int itemID)
        {
            ItemModel item = _context.Items.Find(itemID);
            if (item != null)
            {
                _context.Remove<ItemModel>(item);
            }
            else
            {
                //error handle for null container
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
