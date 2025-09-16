using MediatR;

namespace SimpleShop.Application.Product.Queries.GetById
{
    public record GetProductByIdQuery : IRequest<ProductDto>
    {
        public GetProductByIdQuery(Guid productId)
        {
            ProductId = productId;
        }

        public Guid ProductId { get; }
    }
}
