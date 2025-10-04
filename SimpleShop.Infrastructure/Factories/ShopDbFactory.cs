using SimpleShop.Domain.Entities;
using SimpleShop.Infrastructure.Factories.Interfaces;
using ShopDb = SimpleShop.Infrastructure.Models.Shop;

namespace SimpleShop.Infrastructure.Factories;

internal class ShopDbFactory : IShopDbFactory
{
    public ShopDb Create(Shop shop)
    {
        return new()
        {
            Id = shop.Id,
            Name = shop.Name,
            Description = shop.Description,
            DateCreated = shop.DateCreated,
            UserCreatedId = shop.UserCreatedId
        };
    }
}
