using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleShop.Infrastructure.Models;

namespace SimpleShop.Infrastructure.Configurations;

public class ShopConfiguration : IEntityTypeConfiguration<Shop>
{
    public void Configure(EntityTypeBuilder<Shop> builder)
    {
        builder
            .Property(s => s.Name)
            .IsRequired();
    }
}
