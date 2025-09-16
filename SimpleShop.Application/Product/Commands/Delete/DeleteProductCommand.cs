using MediatR;
using SimpleShop.Application.Product.Commands.Create;

namespace SimpleShop.Application.Product.Commands.Delete
{
    public class DeleteProductCommand : CreateProductCommand, IRequest
    {
        public Guid Id { get; set; }
    }
}
