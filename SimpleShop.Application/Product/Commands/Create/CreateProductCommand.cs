using MediatR;

namespace SimpleShop.Application.Product.Commands.Create
{
    public class CreateProductCommand : IRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
