using SimpleShop.Application.Abstractions;
using SimpleShop.Application.ApplicationUser;
using SimpleShop.Application.Features.Shop;
using SimpleShop.Domain.Repositories;

namespace SimpleShop.Application.Handlers.Shop;

public interface IGetAllShopsHandler : IHandler
{
    Task<IEnumerable<ShopDto>> HandleAsync(CancellationToken cancellationToken);
}

internal class GetAllShopsHandler(
    IShopRepository repository,
    IUserContext userContext)
    : IGetAllShopsHandler
{
    public async Task<IEnumerable<ShopDto>> HandleAsync(CancellationToken cancellationToken)
    {
        var currentUser = userContext.GetCurrentUser(false);

        var shops = await repository.GetAllAsync();

        return shops.Select(shop => ShopDto.Create(shop, currentUser.Id));
    }
}
