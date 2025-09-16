using MediatR;

namespace SimpleShop.Application.Product.Queries.GetAll
{
    public record GetAllProductsQuery : IRequest<IEnumerable<ProductDto>>
    {
    }
}
