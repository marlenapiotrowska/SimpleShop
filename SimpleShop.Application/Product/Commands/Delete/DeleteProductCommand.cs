using MediatR;
using SimpleShop.Application.Handlers.Product.Create;

namespace SimpleShop.Application.Product.Commands.Delete
{
    public class DeleteProductCommand : CreateProductRequest, IRequest
    {
        public Guid Id { get; set; }
    }
}
