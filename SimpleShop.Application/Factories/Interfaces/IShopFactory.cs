using SimpleShop.Application.Shop.Commands.Create;
using ShopEntity = SimpleShop.Domain.Entities.Shop;

namespace SimpleShop.Application.Factories.Interfaces
{
    public interface IShopFactory
    {
        ShopEntity CreateNew(CreateShopCommand command, string userId);
    }
}
