using FluentValidation;
using SimpleShop.Application.Features.Shop.Create;
using SimpleShop.Domain.Repositories;

namespace SimpleShop.Application.Features.Shop.Edit;

public class EditShopValidator: AbstractValidator<EditShopRequest>
{
    public EditShopValidator(IShopRepository repository)
    {
        Include(new CreateShopValidator(repository));
    }
}
