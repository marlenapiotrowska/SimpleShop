using SimpleShop.Application.Features.Shop;
using SimpleShop.Application.Features.Shop.Edit;

namespace SimpleShop.MVC.Factories.Interfaces
{
    public interface IEditShopCommandFactory
    {
        EditShopRequest Create(ShopDto shop);
    }
}
