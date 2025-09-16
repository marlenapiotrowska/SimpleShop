using FluentValidation;
using SimpleShop.Application.Product.Commands.Create;

namespace SimpleShop.Application.Product.Commands.Edit
{
    public class EditProductCommandValidator : AbstractValidator<EditProductCommand>
    {
        public EditProductCommandValidator()
        {
            Include(new CreateProductCommandValidator());
        }
    }
}
