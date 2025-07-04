using SimpleShop.Application.Factories.Interfaces;
using SimpleShop.Application.Shop.Commands.CreateShop;
using ShopEntity = SimpleShop.Domain.Entities.Shop;

namespace SimpleShop.Application.Factories
{
    internal class ShopFactory : IShopFactory
    {
        public ShopEntity CreateNew(CreateShopCommand shop, string userId)
        {
            return new ShopEntity(
                shop.Id,
                shop.Name,
                shop.Description,
                userId);
        }
    }
}
