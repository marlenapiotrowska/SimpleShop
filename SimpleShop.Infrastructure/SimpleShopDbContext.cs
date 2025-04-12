using Microsoft.EntityFrameworkCore;
using SimpleShop.Infrastructure.Configurations;
using SimpleShop.Infrastructure.Models;

namespace SimpleShop.Infrastructure
{
    public class SimpleShopDbContext : DbContext
    {
        public SimpleShopDbContext(DbContextOptions<SimpleShopDbContext> options)
            : base(options)
        {
        }

        public DbSet<Shop> Shops { get; set; }
        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new ShopConfiguration())
                .ApplyConfiguration(new PersonConfiguration())
                ;
        }
    }
}
