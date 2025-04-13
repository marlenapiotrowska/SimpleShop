using MediatR;
using SimpleShop.Application.Factories.Interfaces;
using SimpleShop.Domain.Repositories;

namespace SimpleShop.Application.Shop.Queries.GetAllShops
{
    internal class GetAllShopsQueryHandler : IRequestHandler<GetAllShopsQuery, IEnumerable<ShopDto>>
    {
        private readonly IShopRepository _repository;
        private readonly IShopDtoFactory _factory;

        public GetAllShopsQueryHandler(IShopRepository repository, IShopDtoFactory factory)
        {
            _repository = repository;
            _factory = factory;
        }

        public async Task<IEnumerable<ShopDto>> Handle(GetAllShopsQuery request, CancellationToken cancellationToken)
        {
            var shops = await _repository.GetAll();

            return shops.Select(_factory.Create);
        }
    }
}
