using SimpleShop.Application.Abstractions;
using SimpleShop.Application.ApplicationUser;
using SimpleShop.Application.Factories.Interfaces;
using SimpleShop.Application.Features.Shop;
using SimpleShop.Domain.Repositories;

namespace SimpleShop.Application.Handlers.Shop
{
    public interface IGetShopByIdHandler : IHandler
    {
        Task<ShopDto> Handle(Guid shopId, CancellationToken cancellationToken);
    }

    public class GetShopByIdHandler(
        IShopRepository shopRepository, 
        IShopProductRepository shopProductsRepository, 
        IShopDtoFactory factory, 
        IUserContext userContext) 
        : IGetShopByIdHandler
    {
        public async Task<ShopDto> Handle(Guid shopId, CancellationToken cancellationToken)
        {
            var currentUser = userContext.GetCurrentUser(false);

            var shop = await shopRepository.GetByIdAsync(shopId);

            var productsAssigned = await shopProductsRepository.GetAssignedToShopAsync(shopId);
            var availableProducts = await shopProductsRepository.GetNotAssignedToShopAsync(shopId, currentUser.Id);

            shop.AddAssignedProducts(productsAssigned);

            return factory.Create(shop, currentUser.Id, availableProducts);
        }
    }
}
