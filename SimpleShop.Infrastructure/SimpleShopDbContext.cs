using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleShop.Infrastructure.Configurations;
using SimpleShop.Infrastructure.Models;

namespace SimpleShop.Infrastructure
{
    internal class SimpleShopDbContext : IdentityDbContext<ApplicationUser>
    {
        public SimpleShopDbContext(DbContextOptions<SimpleShopDbContext> options)
            : base(options)
        {
        }

        public DbSet<Shop> Shops { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .ApplyConfiguration(new ShopConfiguration())
                ;
        }
    }
}
