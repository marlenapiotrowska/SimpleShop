using MediatR;

namespace SimpleShop.Application.Shop.Queries.GetShopById
{
    public record class GetShopByIdQuery : IRequest<ShopDto>
    {
        public GetShopByIdQuery(Guid shopId)
        {
            ShopId = shopId;
        }

        public Guid ShopId { get; }
    }
}
