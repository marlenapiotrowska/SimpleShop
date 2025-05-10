using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace SimpleShop.Application.Shop.Commands.EditShop
{
    public record EditShopCommand : IRequest
    {
        [ValidateNever]
        public Guid Id { get; set; }

        [ValidateNever]
        public bool IsEditable { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
