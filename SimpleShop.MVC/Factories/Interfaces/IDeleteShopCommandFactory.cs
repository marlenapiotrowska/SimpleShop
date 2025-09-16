using SimpleShop.Application.Shop;
using SimpleShop.Application.Shop.Commands.Delete;

namespace SimpleShop.MVC.Factories.Interfaces
{
    public interface IDeleteShopCommandFactory
    {
        DeleteShopCommand Create(ShopDto shop);
    }
}
