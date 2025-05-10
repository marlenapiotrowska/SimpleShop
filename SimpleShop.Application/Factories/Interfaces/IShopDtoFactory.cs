using SimpleShop.Application.Shop;
using ShopEntity = SimpleShop.Domain.Entities.Shop;

namespace SimpleShop.Application.Factories.Interfaces
{
    public interface IShopDtoFactory
    {
        ShopDto Create(ShopEntity shop, string currentUserId);
    }
}