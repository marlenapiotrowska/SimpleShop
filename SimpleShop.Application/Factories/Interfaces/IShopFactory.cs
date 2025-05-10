using SimpleShop.Application.Shop;
using SimpleShop.Application.Shop.Commands.Create;
using ShopEntity = SimpleShop.Domain.Entities.Shop;

namespace SimpleShop.Application.Factories.Interfaces
{
    public interface IShopFactory
    {
        ShopEntity Create(ShopDto shop, string userId);
        ShopEntity CreateNew(CreateShopCommand command, string userId);
    }
}
