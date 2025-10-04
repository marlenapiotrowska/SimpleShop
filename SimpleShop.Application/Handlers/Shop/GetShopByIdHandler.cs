using SimpleShop.Application.Abstractions;
using SimpleShop.Application.ApplicationUser;
using SimpleShop.Application.Features.Shop;
using SimpleShop.Domain.Repositories;

namespace SimpleShop.Application.Handlers.Shop;

public interface IGetShopByIdHandler : IHandler
{
    Task<ShopDto> HandleAsync(Guid shopId, CancellationToken cancellationToken);
}

public class GetShopByIdHandler(
    IShopRepository shopRepository,
    IShopProductRepository shopProductsRepository,
    IUserContext userContext)
    : IGetShopByIdHandler
{
    public async Task<ShopDto> HandleAsync(Guid shopId, CancellationToken cancellationToken)
    {
        var currentUser = userContext.GetCurrentUser(false);

        var shop = await shopRepository.GetByIdAsync(shopId);

        var productsAssigned = await shopProductsRepository.GetAssignedToShopAsync(shopId);
        var availableProducts = await shopProductsRepository.GetNotAssignedToShopAsync(shopId, currentUser.Id);

        shop.AddAssignedProducts(productsAssigned);

        return ShopDto.Create(shop, currentUser.Id, availableProducts);
    }
}
