using FluentValidation;
using SimpleShop.Application.Shop.Commands.Create;
using SimpleShop.Domain.Repositories;

namespace SimpleShop.Application.Shop.Commands.Edit
{
    public class EditShopCommandValidator: AbstractValidator<EditShopCommand>
    {
        public EditShopCommandValidator(IShopRepository repository)
        {
            Include(new CreateShopCommandValidator(repository));
        }
    }
}
