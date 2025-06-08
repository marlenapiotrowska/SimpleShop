using SimpleShop.Application.Factories.Interfaces;
using SimpleShop.Application.Shop;
using SimpleShop.Application.Shop.Commands.Create;
using ShopEntity = SimpleShop.Domain.Entities.Shop;

namespace SimpleShop.Application.Factories
{
    internal class ShopFactory : IShopFactory
    {
        public ShopEntity Create(ShopDto shop, string userId)
        {
            return new ShopEntity(
                shop.Id,
                shop.Name,
                shop.Description,
                shop.DateCreated,
                userId);
        }

        public ShopEntity CreateNew(CreateShopCommand shop, string userId)
        {
            return new ShopEntity(
                shop.Name,
                shop.Description,
                userId);
        }
    }
}
