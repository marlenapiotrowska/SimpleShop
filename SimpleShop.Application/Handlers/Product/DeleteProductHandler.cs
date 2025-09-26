using ErrorOr;
using SimpleShop.Application.Abstractions;
using SimpleShop.Application.ApplicationUser;
using SimpleShop.Application.Features.Product.Delete;
using SimpleShop.Domain.Repositories;

namespace SimpleShop.Application.Handlers.Product
{
    public interface IDeleteProductHandler : IHandler
    {
        Task<ErrorOr<Success>> Handle(DeleteProductRequest request, CancellationToken cancellationToken);
    }

    internal class DeleteProductHandler(
        IProductAccessValidator accessValidator, 
        IProductRepository productRepository, 
        IShopRepository shopRepository) 
        : IDeleteProductHandler
    {
        public async Task<ErrorOr<Success>> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            accessValidator.Validate();
            var productId = request.Id;

            var shopsWithAssignedProduct = await shopRepository.GetWithProductAssignedAsync(productId);

            if (shopsWithAssignedProduct != null && shopsWithAssignedProduct.Any())
            {
                var shopNames = shopsWithAssignedProduct
                    .Select(s => s.Name)
                    .ToList();

                return Error.Validation($"Cannot delete product that is assigned to the following shops: {string.Join(", ", shopNames)}");
            }

            await productRepository.DeleteAsync(request.Id);

            return Result.Success;
        }
    }
}
