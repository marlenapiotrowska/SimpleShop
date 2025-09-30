using ErrorOr;
using SimpleShop.Application.Abstractions;
using SimpleShop.Application.ApplicationUser;
using SimpleShop.Application.Features.Shop.Create;
using SimpleShop.Domain.Repositories;
using ShopModel = SimpleShop.Domain.Entities.Shop;

namespace SimpleShop.Application.Handlers.Shop;

public interface ICreateShopHandler : IHandler
{
    Task<ErrorOr<Success>> HandleAsync(CreateShopRequest request, CancellationToken cancellationToken);
}

internal class CreateShopHandler(
    IShopRepository repository,
    IUserContext userContext)
    : ICreateShopHandler
{
    public async Task<ErrorOr<Success>> HandleAsync(CreateShopRequest request, CancellationToken cancellationToken)
    {
        var currentUser = userContext.GetCurrentUser(true);

        var shop = ShopModel.Create(request.Id, request.Name, request.Description, currentUser.Id);
        await repository.AddAsync(shop);

        return Result.Success;
    }
}
