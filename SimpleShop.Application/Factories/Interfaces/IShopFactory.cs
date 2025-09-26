using SimpleShop.Application.Features.Shop.Create;
using ShopEntity = SimpleShop.Domain.Entities.Shop;

namespace SimpleShop.Application.Factories.Interfaces
{
    public interface IShopFactory
    {
        ShopEntity CreateNew(CreateShopRequest command, string userId);
    }
}
