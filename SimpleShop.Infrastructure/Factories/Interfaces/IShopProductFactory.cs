using SimpleShop.Domain.Entities;
using ProductDb = SimpleShop.Infrastructure.Models.Product;
using ShopProductDb = SimpleShop.Infrastructure.Models.ProductShop;

namespace SimpleShop.Infrastructure.Factories.Interfaces;

internal interface IShopProductFactory
{
    ShopProduct Create(ShopProductDb shopProduct);
    ShopProduct CreateNew(ProductDb product, Guid shopId, string userCreatedId);
}
