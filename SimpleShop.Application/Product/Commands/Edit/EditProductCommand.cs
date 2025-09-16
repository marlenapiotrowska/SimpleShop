using MediatR;
using SimpleShop.Application.Handlers.Product.Create;

namespace SimpleShop.Application.Product.Commands.Edit
{
    public class EditProductCommand : CreateProductRequest, IRequest
    {
        public Guid Id { get; set; }
    }
}
