using SimpleShop.Application.Features.Shop;
using SimpleShop.Application.Features.Shop.Delete;

namespace SimpleShop.MVC.Factories.Interfaces
{
    public interface IDeleteShopCommandFactory
    {
        DeleteShopRequest Create(ShopDto shop);
    }
}
