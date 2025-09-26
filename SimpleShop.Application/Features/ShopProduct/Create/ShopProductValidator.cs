using FluentValidation;

namespace SimpleShop.Application.Features.ShopProduct.Create
{
    public class ShopProductValidator : AbstractValidator<ShopProductDto>
    {
        public ShopProductValidator()
        {
            RuleFor(sp => sp.Price)
               .GreaterThan(0)
               .WithMessage("Price should be greater than 0");
        }
    }
}
