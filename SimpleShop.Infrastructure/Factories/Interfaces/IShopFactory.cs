using SimpleShop.Domain.Entities;
using ShopDb = SimpleShop.Infrastructure.Models.Shop;

namespace SimpleShop.Infrastructure.Factories.Interfaces;

internal interface IShopFactory
{
    Shop Create(ShopDb shop);
}
