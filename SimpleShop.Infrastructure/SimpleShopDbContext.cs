using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleShop.Infrastructure.Configurations;
using SimpleShop.Infrastructure.Models;

namespace SimpleShop.Infrastructure;

internal class SimpleShopDbContext : IdentityDbContext<ApplicationUser>
{
    public SimpleShopDbContext(DbContextOptions<SimpleShopDbContext> options)
        : base(options)
    {
    }

    public DbSet<Shop> Shops { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductShop> ShopProducts { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder
            .ApplyConfiguration(new ShopConfiguration())
            .ApplyConfiguration(new ProductConfiguration())
            .ApplyConfiguration(new ProductShopConfiguration())
            ;
    }
}
