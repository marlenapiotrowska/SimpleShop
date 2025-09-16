using MediatR;
using SimpleShop.Application.ApplicationUser;
using SimpleShop.Application.Factories.Interfaces;
using SimpleShop.Domain.Repositories;

namespace SimpleShop.Application.Shop.Queries.GetById
{
    public class GetShopByIdQueryHandler : IRequestHandler<GetShopByIdQuery, ShopDto>
    {
        private readonly IShopRepository _shopRepository;
        private readonly IShopProductRepository _shopProductsRepository;
        private readonly IShopDtoFactory _factory;
        private readonly IUserContext _userContext;

        public GetShopByIdQueryHandler(IShopRepository shopRepository, IShopProductRepository shopProductsRepository, IShopDtoFactory factory, IUserContext userContext)
        {
            _shopRepository = shopRepository;
            _shopProductsRepository = shopProductsRepository;
            _factory = factory;
            _userContext = userContext;
        }

        public async Task<ShopDto> Handle(GetShopByIdQuery request, CancellationToken cancellationToken)
        {
            var currentUser = _userContext.GetCurrentUser(false);

            var shop = await _shopRepository.GetByIdAsync(request.ShopId);

            var productsAssigned = await _shopProductsRepository.GetAssignedToShopAsync(request.ShopId);
            var availableProducts = await _shopProductsRepository.GetNotAssignedToShopAsync(request.ShopId);

            shop.AddAssignedProducts(productsAssigned);

            return _factory.Create(shop, currentUser.Id, availableProducts);
        }
    }
}
