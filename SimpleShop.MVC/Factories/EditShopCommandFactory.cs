using SimpleShop.Application.Features.Shop;
using SimpleShop.Application.Features.Shop.Edit;
using SimpleShop.MVC.Factories.Interfaces;

namespace SimpleShop.MVC.Factories
{
    internal class EditShopCommandFactory : IEditShopCommandFactory
    {
        public EditShopRequest Create(ShopDto shop)
        {
            return new EditShopRequest
            {
                Id = shop.Id,
                Name = shop.Name,
                Description = shop.Description,
                IsEditable = shop.IsEditable,
                AssignedShopProducts = [.. shop.AssignedProducts],
                AvailableShopProducts = [.. shop.AvailableProducts]
            };
        }
    }
}
