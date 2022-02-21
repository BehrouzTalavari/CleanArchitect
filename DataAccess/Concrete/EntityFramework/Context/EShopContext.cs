using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Context
{
    public class EShopContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-T7CKRLM;Database=ShopDb;Trusted_Connection=True");

            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Product> Products { get; set; }
    }
}
