using MediatR;

namespace SimpleShop.Application.Shop.Queries.GetAllShops
{
    public record GetAllShopsQuery : IRequest<IEnumerable<ShopDto>>
    {
    }
}
