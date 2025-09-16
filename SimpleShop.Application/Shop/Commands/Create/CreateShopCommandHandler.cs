using SimpleShop.Application.Abstractions;
using SimpleShop.Application.ApplicationUser;
using SimpleShop.Application.Factories.Interfaces;
using SimpleShop.Domain.Repositories;

namespace SimpleShop.Application.Shop.Commands.Create
{
    internal interface ICreateShopCommandHandler : IHandler
    {
        Task Handle(CreateShopCommand request, CancellationToken cancellationToken);
    }

    internal class CreateShopCommandHandler(
        IShopFactory factory,
        IShopRepository repository,
        IUserContext userContext) 
        : ICreateShopCommandHandler
    {
        public async Task Handle(CreateShopCommand request, CancellationToken cancellationToken)
        {
            var currentUser = userContext.GetCurrentUser(true);

            var shop = factory.CreateNew(request, currentUser.Id);
            await repository.AddAsync(shop);
        }
    }
}
