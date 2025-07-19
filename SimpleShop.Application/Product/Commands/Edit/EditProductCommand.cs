using MediatR;
using SimpleShop.Application.Product.Commands.Create;

namespace SimpleShop.Application.Product.Commands.Edit
{
    public class EditProductCommand : CreateProductCommand, IRequest
    {
        public Guid Id { get; set; }
    }
}
