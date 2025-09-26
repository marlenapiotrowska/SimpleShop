using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using SimpleShop.Application.Features.ShopProduct;

namespace SimpleShop.Application.Shop.Commands.Create
{
    public class CreateShopCommand : IRequest
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }

        public List<ShopProductDto> AssignedShopProducts { get; set; } = [];
        
        [ValidateNever]
        public List<ShopProductDto> AvailableShopProducts { get; set; } = [];
    }
}
