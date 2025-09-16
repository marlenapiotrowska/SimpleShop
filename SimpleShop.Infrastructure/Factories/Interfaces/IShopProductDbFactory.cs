using SimpleShop.Domain.Entities;
using ShopProductDb = SimpleShop.Infrastructure.Models.ProductShop;

namespace SimpleShop.Infrastructure.Factories.Interfaces
{
    internal interface IShopProductDbFactory
    {
        ShopProductDb Create(ShopProduct shopProduct);
    }
}
