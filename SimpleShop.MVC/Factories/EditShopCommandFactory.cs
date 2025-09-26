using SimpleShop.Application.Features.Shop;
using SimpleShop.Application.Shop.Commands.Edit;
using SimpleShop.MVC.Factories.Interfaces;

namespace SimpleShop.MVC.Factories
{
    internal class EditShopCommandFactory : IEditShopCommandFactory
    {
        public EditShopCommand Create(ShopDto shop)
        {
            return new EditShopCommand
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
