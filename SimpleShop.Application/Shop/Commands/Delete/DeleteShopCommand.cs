using MediatR;

namespace SimpleShop.Application.Shop.Commands.Delete
{
    public class DeleteShopCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
