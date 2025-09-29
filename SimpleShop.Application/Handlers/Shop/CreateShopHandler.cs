using ErrorOr;
using SimpleShop.Application.Abstractions;
using SimpleShop.Application.ApplicationUser;
using SimpleShop.Application.Factories.Interfaces;
using SimpleShop.Application.Features.Shop.Create;
using SimpleShop.Domain.Repositories;

namespace SimpleShop.Application.Handlers.Shop
{
    public interface ICreateShopHandler : IHandler
    {
        Task<ErrorOr<Success>> Handle(CreateShopRequest request, CancellationToken cancellationToken);
    }

    internal class CreateShopHandler(
        IShopFactory factory,
        IShopRepository repository,
        IUserContext userContext) 
        : ICreateShopHandler
    {
        public async Task<ErrorOr<Success>> Handle(CreateShopRequest request, CancellationToken cancellationToken)
        {
            var currentUser = userContext.GetCurrentUser(true);

            var shop = factory.CreateNew(request, currentUser.Id);
            await repository.AddAsync(shop);

            return Result.Success;
        }
    }
}
