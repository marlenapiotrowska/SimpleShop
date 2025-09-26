using SimpleShop.Application.Features.Shop;
using SimpleShop.Application.Features.Shop.Delete;
using SimpleShop.MVC.Factories.Interfaces;

namespace SimpleShop.MVC.Factories
{
    internal class DeleteShopCommandFactory : IDeleteShopCommandFactory
    {
        public DeleteShopRequest Create(ShopDto shop)
        {
            return new DeleteShopRequest
            {
                Id = shop.Id,
                Name = shop.Name,
                Description = shop.Description
            };
        }
    }
}
