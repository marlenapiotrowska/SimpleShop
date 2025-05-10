using SimpleShop.Application.Factories.Interfaces;
using SimpleShop.Application.Shop;
using ShopEntity = SimpleShop.Domain.Entities.Shop;

namespace SimpleShop.Application.Factories
{
    internal class ShopDtoFactory : IShopDtoFactory
    {
        public ShopDto Create(ShopEntity shop, string currentUserId)
        {
            var isEditable = shop.UserCreatedId == currentUserId;

            return new ShopDto
            {
                Id = shop.Id,
                Name = shop.Name,
                Description = shop.Description,
                DateCreated = shop.DateCreated,
                IsEditable = isEditable
            };
        }
    }
}
