using SimpleShop.Domain.Entities;
using ShopProductDb = SimpleShop.Infrastructure.Models.ProductShop;
using ProductDb = SimpleShop.Infrastructure.Models.Product;

namespace SimpleShop.Infrastructure.Factories.Interfaces
{
    internal interface IShopProductFactory
    {
        ShopProduct Create(ShopProductDb shopProduct);
        ShopProduct CreateNew(ProductDb product, Guid shopId, string userCreatedId);
    }
}
