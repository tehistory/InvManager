using InvManager.Models;
using Microsoft.EntityFrameworkCore;

namespace InvManager.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

        public DbSet<AccountModel> Accounts { get; set; }
        public DbSet<ContainerModel> Containers { get; set; }
        public DbSet<ItemModel> Items { get; set; }
    }
}
