using FluentValidation;

namespace SimpleShop.Application.Features.Product.Create;

public class CreateProductValidator : AbstractValidator<CreateProductRequest>
{
    private const int _minLength = 3;
    private const int _maxNameLength = 30;
    private const int _maxDescriptionLength = 100;

    public CreateProductValidator()
    {
        RuleFor(s => s.Name)
            .NotEmpty()
            .MinimumLength(_minLength).WithMessage($"Name should have at least {_minLength} characters")
            .MaximumLength(_maxNameLength).WithMessage($"Name should have maximum of {_maxNameLength} characters")
            ;

        RuleFor(s => s.Description)
            .NotEmpty()
            .MinimumLength(_minLength).WithMessage($"Description should have at least {_minLength} characters")
            .MaximumLength(_maxDescriptionLength).WithMessage($"Description should have maximum of {_maxDescriptionLength} characters")
            ;
    }
}
