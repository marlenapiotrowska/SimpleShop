using ErrorOr;
using SimpleShop.Application.Abstractions;
using SimpleShop.Application.ApplicationUser;
using SimpleShop.Application.Features.Shop.Delete;
using SimpleShop.Domain.Repositories;

namespace SimpleShop.Application.Handlers.Shop;

public interface IDeleteShopHandler : IHandler
{
    Task<ErrorOr<Success>> HandleAsync(DeleteShopRequest request, CancellationToken cancellationToken);
}

internal class DeleteShopHandler(
    IShopRepository repository,
    IShopAccessValidator accessValidator)
    : IDeleteShopHandler
{
    public async Task<ErrorOr<Success>> HandleAsync(DeleteShopRequest request, CancellationToken cancellationToken)
    {
        var shop = await repository.GetByIdAsync(request.Id);
        accessValidator.Validate(shop);

        await repository.DeleteAsync(shop);

        return Result.Success;
    }
}
