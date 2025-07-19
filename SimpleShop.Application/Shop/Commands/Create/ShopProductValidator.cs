using FluentValidation;
using SimpleShop.Application.ShopProduct;

namespace SimpleShop.Application.Shop.Commands.Create
{
    public class ShopProductValidator : AbstractValidator<ShopProductDto>
    {
        public ShopProductValidator()
        {
            RuleFor(sp => sp.Price)
                .GreaterThan(0)
                .When(sp => sp.IsSelected)
                .WithMessage("Price should be greater than 0");
        }
    }
}
