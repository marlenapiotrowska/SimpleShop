using SimpleShop.Application.Shop;
using SimpleShop.Application.Shop.Commands.Edit;

namespace SimpleShop.MVC.Factories.Interfaces
{
    public interface IEditShopCommandFactory
    {
        EditShopCommand Create(ShopDto shop);
    }
}
