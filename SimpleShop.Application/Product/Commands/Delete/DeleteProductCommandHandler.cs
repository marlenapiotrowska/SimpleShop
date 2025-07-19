using MediatR;
using SimpleShop.Application.ApplicationUser;
using SimpleShop.Application.Exceptions;
using SimpleShop.Domain.Repositories;

namespace SimpleShop.Application.Product.Commands.Delete
{
    internal class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductAccessValidator _accessValidator;
        private readonly IProductRepository _productRepository;
        private readonly IShopRepository _shopRepository;

        public DeleteProductCommandHandler(IProductAccessValidator accessValidator, IProductRepository productRepository, IShopRepository shopRepository)
        {
            _accessValidator = accessValidator;
            _productRepository = productRepository;
            _shopRepository = shopRepository;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            _accessValidator.Validate();

            var shopsWithAssignedProduct = await _shopRepository.GetWithProductAssignedAsync(request.Id);

            if (shopsWithAssignedProduct != null && shopsWithAssignedProduct.Any())
            {
                var shopNames = shopsWithAssignedProduct
                    .Select(s => s.Name)
                    .ToList();

                throw new ProductAssignedToShopException(shopNames);
            }

            await _productRepository.DeleteAsync(request.Id);

            return Unit.Value;
        }
    }
}
