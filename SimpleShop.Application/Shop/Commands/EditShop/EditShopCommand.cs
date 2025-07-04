using MediatR;
using SimpleShop.Application.Shop.Commands.CreateShop;

namespace SimpleShop.Application.Shop.Commands.EditShop
{
    public record EditShopCommand : CreateShopCommand, IRequest
    {
        public bool IsEditable { get; set; }
    }
}
