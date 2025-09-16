using MediatR;

namespace SimpleShop.Application.Shop.Queries.GetAll
{
    public record GetAllShopsQuery : IRequest<IEnumerable<ShopDto>>
    {
    }
}
