using MediatR;
using SimpleShop.Application.ApplicationUser;
using SimpleShop.Application.Factories.Interfaces;
using SimpleShop.Domain.Repositories;

namespace SimpleShop.Application.Product.Queries.GetById
{
    internal class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly IUserContext _userContext;
        private readonly IProductRepository _repository;
        private readonly IProductDtoFactory _factory;

        public GetProductByIdQueryHandler(IUserContext userContext, IProductRepository repository, IProductDtoFactory factory)
        {
            _userContext = userContext;
            _repository = repository;
            _factory = factory;
        }

        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var currentUser = _userContext.GetCurrentUser();

            var product = await _repository.GetByIdAsync(request.ProductId);

            return _factory.Create(product, currentUser?.Id);
        }
    }
}
