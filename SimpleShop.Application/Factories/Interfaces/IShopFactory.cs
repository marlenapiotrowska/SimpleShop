using SimpleShop.Application.Shop;
using SimpleShop.Application.Shop.Commands.CreateShop;
using ShopEntity = SimpleShop.Domain.Entities.Shop;

namespace SimpleShop.Application.Factories.Interfaces
{
    public interface IShopFactory
    {
        ShopEntity CreateNew(CreateShopCommand command, string userId);
    }
}
