using SimpleShop.Application.Shop;
using SimpleShop.Application.Shop.Commands.EditShop;

namespace SimpleShop.MVC.Factories
{
    public interface IEditShopCommandFactory
    {
        EditShopCommand Create(ShopDto shop);
    }
}
