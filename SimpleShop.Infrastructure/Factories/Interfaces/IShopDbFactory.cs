using SimpleShop.Domain.Entities;
using ShopDb = SimpleShop.Infrastructure.Models.Shop;

namespace SimpleShop.Infrastructure.Factories.Interfaces;

internal interface IShopDbFactory
{
    ShopDb Create(Shop shop);
}
