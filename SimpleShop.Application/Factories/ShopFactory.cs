using SimpleShop.Application.Factories.Interfaces;
using SimpleShop.Application.Features.Shop.Create;
using ShopEntity = SimpleShop.Domain.Entities.Shop;

namespace SimpleShop.Application.Factories
{
    internal class ShopFactory : IShopFactory
    {
        public ShopEntity CreateNew(CreateShopRequest shop, string userId)
        {
            return new ShopEntity(
                shop.Id,
                shop.Name,
                shop.Description,
                userId);
        }
    }
}
