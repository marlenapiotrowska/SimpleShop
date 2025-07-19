using MediatR;
using SimpleShop.Application.Shop.Commands.Create;

namespace SimpleShop.Application.Shop.Commands.Edit
{
    public class EditShopCommand : CreateShopCommand, IRequest
    {
        public bool IsEditable { get; set; }
    }
}
