using MediatR;

namespace SimpleShop.Application.Shop.Commands.Create
{
    public record CreateShopCommand : IRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
