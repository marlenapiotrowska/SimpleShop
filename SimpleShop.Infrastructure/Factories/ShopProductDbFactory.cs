using SimpleShop.Domain.Entities;
using SimpleShop.Infrastructure.Factories.Interfaces;
using ShopProductDb = SimpleShop.Infrastructure.Models.ProductShop;

namespace SimpleShop.Infrastructure.Factories
{
    internal class ShopProductDbFactory : IShopProductDbFactory
    {
        public ShopProductDb Create(ShopProduct shopProduct)
        {
            return new ShopProductDb
            {
                Id = shopProduct.Id,
                ShopId = shopProduct.ShopId,
                ProductId = shopProduct.ProductId,
                Price = shopProduct.Price,
            };
        }
    }
}
