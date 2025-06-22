using SimpleShop.Application.ShopProduct;
using ShopProductEntity = SimpleShop.Domain.Entities.ShopProduct;

namespace SimpleShop.Application.Factories.Interfaces
{
    internal interface IShopProductFactory
    {
        ShopProductEntity Create(ShopProductDto shopProduct);
    }
}
