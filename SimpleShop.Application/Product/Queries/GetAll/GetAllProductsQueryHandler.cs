using MediatR;
using SimpleShop.Application.ApplicationUser;
using SimpleShop.Application.Factories.Interfaces;
using SimpleShop.Domain.Repositories;

namespace SimpleShop.Application.Product.Queries.GetAll
{
    internal class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDto>>
    {
        private readonly IUserContext _userContext;
        private readonly IProductRepository _repository;
        private readonly IProductDtoFactory _factory;

        public GetAllProductsQueryHandler(IUserContext userContext, IProductRepository repository, IProductDtoFactory factory)
        {
            _userContext = userContext;
            _repository = repository;
            _factory = factory;
        }

        public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var currentUser = _userContext.GetCurrentUser();

            var products = await _repository.GetAllAsync();

            return products.Select(p => _factory.Create(p, currentUser?.Id));
        }
    }
}
