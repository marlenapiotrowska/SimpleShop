using MediatR;
using SimpleShop.Application.Factories.Interfaces;
using SimpleShop.Domain.Repositories;

namespace SimpleShop.Application.Product.Queries.GetAll
{
    internal class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDto>>
    {
        private readonly IProductRepository _repository;
        private readonly IProductDtoFactory _factory;

        public GetAllProductsQueryHandler(IProductRepository repository, IProductDtoFactory factory)
        {
            _repository = repository;
            _factory = factory;
        }

        public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetAllAsync();

            return products.Select(_factory.Create);
        }
    }
}
