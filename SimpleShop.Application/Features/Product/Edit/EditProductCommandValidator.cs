using FluentValidation;
using SimpleShop.Application.Features.Product.Create;

namespace SimpleShop.Application.Features.Product.Edit
{
    public class EditProductCommandValidator : AbstractValidator<EditProductRequest>
    {
        public EditProductCommandValidator()
        {
            Include(new CreateProductValidator());
        }
    }
}
