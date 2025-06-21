using MediatR;

namespace SimpleShop.Application.Product.Commands.Create
{
    public record CreateProductCommand : IRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
