using SimpleShop.Domain.Entities;
using SimpleShop.Infrastructure.Factories.Interfaces;
using ShopDb = SimpleShop.Infrastructure.Models.Shop;

namespace SimpleShop.Infrastructure.Factories
{
    internal class ShopFactory : IShopFactory
    {
        public Shop Create(ShopDb shop)
        {
            return new Shop(
                shop.Id,
                shop.Name,
                shop.Description,
                shop.DateCreated,
                shop.UserCreatedId);
        }
    }
}
