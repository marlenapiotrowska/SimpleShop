using MediatR;
using SimpleShop.Application.Features.Shop;

namespace SimpleShop.Application.Shop.Queries.GetAll
{
    public record GetAllShopsQuery : IRequest<IEnumerable<ShopDto>>
    {
    }
}
