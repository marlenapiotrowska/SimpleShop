using ErrorOr;
using SimpleShop.Application.Abstractions;
using SimpleShop.Application.ApplicationUser;
using SimpleShop.Application.Features.Product.Edit;
using SimpleShop.Domain.Repositories;

namespace SimpleShop.Application.Handlers.Product
{
    public interface IEditProductHandler : IHandler
    {
        Task<ErrorOr<Success>> Handle(EditProductRequest request, CancellationToken cancellationToken);
    }

    internal class EditProductHandler(
        IProductAccessValidator accessValidator, 
        IProductRepository repository) 
        : IEditProductHandler
    {
        public async Task<ErrorOr<Success>> Handle(EditProductRequest request, CancellationToken cancellationToken)
        {
            accessValidator.Validate();

            var product = await repository.GetByIdAsync(request.Id);

            product.UpdateName(request.Name);
            product.UpdateDescription(request.Description);

            await repository.UpdateProductAsync(product);

            return Result.Success;
        }
    }
}
