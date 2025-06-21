using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleShop.Infrastructure.Models;

namespace SimpleShop.Infrastructure.Configurations
{
    public class ProductShopConfiguration : IEntityTypeConfiguration<ProductShop>
    {
        public void Configure(EntityTypeBuilder<ProductShop> builder)
        {
            builder
                .Property(ps => ps.Price)
                .IsRequired();

            builder
                .HasOne(sp => sp.Shop)
                .WithMany(s => s.ShopProducts)
                .HasForeignKey(sp => sp.ShopId);

            builder
                .HasOne(sp => sp.Product)
                .WithMany(p => p.ShopProducts)
                .HasForeignKey(sp => sp.ProductId);
        }
    }
}
