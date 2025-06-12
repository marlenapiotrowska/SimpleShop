using MediatR;

namespace SimpleShop.Application.Shop.Commands.EditShop
{
    public record EditShopCommand : IRequest
    {
        public Guid Id { get; set; }
        public bool IsEditable { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
