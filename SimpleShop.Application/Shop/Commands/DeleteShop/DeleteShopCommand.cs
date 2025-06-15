using MediatR;

namespace SimpleShop.Application.Shop.Commands.DeleteShop
{
    public record DeleteShopCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
