using SimpleShop.Domain.Entities;
using SimpleShop.Infrastructure.Factories.Interfaces;
using ProductShopDb = SimpleShop.Infrastructure.Models.ProductShop;
using ProductDb = SimpleShop.Infrastructure.Models.Product;

namespace SimpleShop.Infrastructure.Factories
{
    internal class ShopProductFactory : IShopProductFactory
    {
        public ShopProduct Create(ProductShopDb shopProduct)
        {
            return new ShopProduct(
                shopProduct.Id,
                shopProduct.ProductId,
                shopProduct.ShopId,
                shopProduct.Product.Name,
                shopProduct.Product.Description,
                shopProduct.Price,
                shopProduct.DateCreated,
                shopProduct.UserCreatedId);
        }

        public ShopProduct CreateNew(ProductDb product, Guid shopId, string userCreatedId)
        {
            return new ShopProduct(
                product.Id,
                shopId,
                product.Name,
                product.Description,
                0,
                userCreatedId);
        }
    }
}
