using SimpleShop.Application.Factories.Interfaces;
using SimpleShop.Application.Features.ShopProduct;
using ShopProductEntity = SimpleShop.Domain.Entities.ShopProduct;

namespace SimpleShop.Application.Factories
{
    internal class ShopProductFactory : IShopProductFactory
    {
        public ShopProductEntity Create(ShopProductDto shopProduct)
        {
            return new ShopProductEntity(
                shopProduct.Id,
                shopProduct.ProductId,
                shopProduct.ShopId,
                shopProduct.Name,
                shopProduct.Description,
                shopProduct.Price);
        }
    }
}
