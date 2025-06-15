using SimpleShop.Application.Shop;
using SimpleShop.Application.Shop.Commands.EditShop;

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
                IsEditable = shop.IsEditable
            };
        }
    }
}
