using SimpleShop.Application.Factories.Interfaces;
using SimpleShop.Application.Features.ShopProduct;
using ShopProductEntity = SimpleShop.Domain.Entities.ShopProduct;

namespace SimpleShop.Application.Factories
{
    internal class ShopProductFactory : IShopProductFactory
    {
        public ShopProductEntity CreateNew(ShopProductDto shopProduct, string userCreatedId)
        {
            return new ShopProductEntity(
                shopProduct.ProductId,
                shopProduct.ShopId,
                shopProduct.Name,
                shopProduct.Description,
                shopProduct.Price,
                userCreatedId);
        }
    }
}
