using MediatR;
using SimpleShop.Application.Factories.Interfaces;
using SimpleShop.Domain.Repositories;

namespace SimpleShop.Application.Product.Queries.GetById
{
    internal class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly IProductRepository _repository;
        private readonly IProductDtoFactory _factory;

        public GetProductByIdQueryHandler(IProductRepository repository, IProductDtoFactory factory)
        {
            _repository = repository;
            _factory = factory;
        }

        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.ProductId);

            return _factory.Create(product);
        }
    }
}
