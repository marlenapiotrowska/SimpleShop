using SimpleShop.Application.Shop;
using SimpleShop.Application.Shop.Commands.DeleteShop;

namespace SimpleShop.MVC.Factories
{
    public interface IDeleteShopCommandFactory
    {
        DeleteShopCommand Create(ShopDto shop);
    }
}
