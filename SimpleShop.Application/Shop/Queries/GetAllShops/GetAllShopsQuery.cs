using MediatR;

namespace SimpleShop.Application.Shop.Queries.GetAllShops
{
    public class GetAllShopsQuery : IRequest<IEnumerable<ShopDto>>
    {
    }
}
