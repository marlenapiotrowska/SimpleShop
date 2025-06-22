using MediatR;
using SimpleShop.Application.ShopProduct;

namespace SimpleShop.Application.Shop.Commands.CreateShop
{
    public record CreateShopCommand : IRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<ShopProductDto> AssignedShopProducts { get; set; }
        public List<ShopProductDto> AvailableShopProducts { get; set; }
    }
}
