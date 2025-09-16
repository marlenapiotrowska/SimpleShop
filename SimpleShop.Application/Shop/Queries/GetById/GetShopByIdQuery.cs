using MediatR;

namespace SimpleShop.Application.Shop.Queries.GetById
{
    public record GetShopByIdQuery : IRequest<ShopDto>
    {
        public GetShopByIdQuery(Guid shopId)
        {
            ShopId = shopId;
        }

        public Guid ShopId { get; }
    }
}
