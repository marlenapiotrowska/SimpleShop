using SimpleShop.Application.Abstractions;
using SimpleShop.Application.ApplicationUser;
using SimpleShop.Application.Factories.Interfaces;
using SimpleShop.Application.Features.Shop;
using SimpleShop.Domain.Repositories;

namespace SimpleShop.Application.Handlers.Shop
{
    public interface IGetAllShopsHandler : IHandler
    {
        Task<IEnumerable<ShopDto>> Handle(CancellationToken cancellationToken);
    }

    internal class GetAllShopsHandler(
        IShopRepository repository, 
        IShopDtoFactory factory, 
        IUserContext userContext) 
        : IGetAllShopsHandler
    {
        public async Task<IEnumerable<ShopDto>> Handle(CancellationToken cancellationToken)
        {
            var currentUser = userContext.GetCurrentUser(false);

            var shops = await repository.GetAllAsync();

            return shops.Select(shop => factory.Create(shop, currentUser.Id));
        }
    }
}
