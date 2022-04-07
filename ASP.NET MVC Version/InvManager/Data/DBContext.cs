using InvManager.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InvManager.Data
{
    public class DBContext : IdentityDbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
            
        }

        public DbSet<AccountModel> Accounts { get; set; }
        public DbSet<ContainerModel> Containers { get; set; }
        public DbSet<ItemModel> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountModel>().HasData(new AccountModel { accountID = 2, email = "", password = "password", userName = "test" });
            modelBuilder.Entity<AccountModel>().HasData(new AccountModel { accountID = 1, email = "ftegelhoff@gmail.com", password = "adminpassword1", userName = "admin" });
            modelBuilder.Entity<ContainerModel>().HasData(new ContainerModel { accountID="1", containerID = 1, containerName = "TestCName"});
            modelBuilder.Entity<ItemModel>().HasData(new ItemModel { containerID = 1, itemID = 1, itemName = "test Item" });
            base.OnModelCreating(modelBuilder);
        }
    }
}
