using MediatR;
using SimpleShop.Application.ApplicationUser;
using SimpleShop.Application.Exceptions;
using SimpleShop.Application.Factories.Interfaces;
using SimpleShop.Domain.Repositories;

namespace SimpleShop.Application.Shop.Queries.GetAllShops
{
    internal class GetAllShopsQueryHandler : IRequestHandler<GetAllShopsQuery, IEnumerable<ShopDto>>
    {
        private readonly IShopRepository _repository;
        private readonly IShopDtoFactory _factory;
        private readonly IUserContext _userContext;

        public GetAllShopsQueryHandler(IShopRepository repository, IShopDtoFactory factory, IUserContext userContext)
        {
            _repository = repository;
            _factory = factory;
            _userContext = userContext;
        }

        public async Task<IEnumerable<ShopDto>> Handle(GetAllShopsQuery request, CancellationToken cancellationToken)
        {
            var currentUser = _userContext.GetCurrentUser()
                ?? throw new UserNotFoundException();

            var shops = await _repository.GetAllAsync();

            return shops.Select(shop => _factory.Create(shop, currentUser.Id));
        }
    }
}
