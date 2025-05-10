using SimpleShop.Application.Shop;
using ShopEntity = SimpleShop.Domain.Entities.Shop;

namespace SimpleShop.Application.Factories.Interfaces
{
    internal interface IShopDtoFactory
    {
        ShopDto Create(ShopEntity shop, string currentUserId);
    }
}