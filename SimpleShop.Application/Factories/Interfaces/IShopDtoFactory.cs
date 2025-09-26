using SimpleShop.Application.Features.Shop;
using ShopEntity = SimpleShop.Domain.Entities.Shop;
using ShopProductEntity = SimpleShop.Domain.Entities.ShopProduct;

namespace SimpleShop.Application.Factories.Interfaces
{
    public interface IShopDtoFactory
    {
        ShopDto Create(ShopEntity shop, string currentUserId, IEnumerable<ShopProductEntity>? availableProducts = null);
    }
}