using MediatR;
using SimpleShop.Application.ApplicationUser;
using SimpleShop.Application.Exceptions;
using SimpleShop.Application.Factories.Interfaces;
using SimpleShop.Domain.Repositories;

namespace SimpleShop.Application.Shop.Queries.GetShopById
{
    public class GetShopByIdQueryHandler : IRequestHandler<GetShopByIdQuery, ShopDto>
    {
        private readonly IShopRepository _repository;
        private readonly IShopDtoFactory _factory;
        private readonly IUserContext _userContext;

        public GetShopByIdQueryHandler(IShopRepository repository, IShopDtoFactory factory, IUserContext userContext)
        {
            _repository = repository;
            _factory = factory;
            _userContext = userContext;
        }

        public async Task<ShopDto> Handle(GetShopByIdQuery request, CancellationToken cancellationToken)
        {
            var currentUser = _userContext.GetCurrentUser()
                ?? throw new UserNotFoundException();

            var shop = await _repository.GetById(request.ShopId);

            return _factory.Create(shop, currentUser.Id);
        }
    }
}
