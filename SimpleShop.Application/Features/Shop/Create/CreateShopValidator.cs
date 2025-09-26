using FluentValidation;
using SimpleShop.Application.Features.ShopProduct.Create;
using SimpleShop.Domain.Repositories;

namespace SimpleShop.Application.Features.Shop.Create
{
    public class CreateShopValidator : AbstractValidator<CreateShopRequest>
    {
        private const int _minLength = 3;
        private const int _maxNameLength = 30;
        private const int _maxDescriptionLength = 100;

        public CreateShopValidator(IShopRepository repository)
        {
            RuleFor(s => s.Name)
                .NotEmpty()
                .MinimumLength(_minLength).WithMessage($"Name should have at least {_minLength} characters")
                .MaximumLength(_maxNameLength).WithMessage($"Name should have maximum of {_maxNameLength} characters")
                .Custom((value, context) =>
                {
                    var model = context.InstanceToValidate;

                    var existsingShop = repository.GetByNameAsync(value, model.Id).GetAwaiter().GetResult();
                    if (existsingShop != null)
                    {
                        context.AddFailure($"{value} is not unique name for shop");
                    }
                });

            RuleFor(s => s.Description)
                .NotEmpty()
                .MinimumLength(_minLength).WithMessage($"Description should have at least {_minLength} characters")
                .MaximumLength(_maxDescriptionLength).WithMessage($"Description should have maximum of {_maxDescriptionLength} characters")
                .Custom((value, context) =>
                {
                    var model = context.InstanceToValidate;

                    var existsingShop = repository.GetByDescriptionAsync(value, model.Id).GetAwaiter().GetResult();
                    if (existsingShop != null)
                    {
                        context.AddFailure($"{value} is not unique description for shop");
                    }
                });

            RuleForEach(s => s.AssignedShopProducts)
                .SetValidator(new ShopProductValidator());
        }
    }
}
