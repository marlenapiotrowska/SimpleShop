using SimpleShop.Application.Abstractions;
using SimpleShop.Application.ApplicationUser;
using SimpleShop.Application.Features.Product;
using SimpleShop.Domain.Repositories;

namespace SimpleShop.Application.Handlers.Product;

public interface IGetProductByIdHandler : IHandler
{
    Task<ProductDto> HandleAsync(Guid productId, CancellationToken cancellationToken);
}

internal class GetProductByIdHandler(
    IUserContext userContext,
    IProductRepository repository)
    : IGetProductByIdHandler
{
    public async Task<ProductDto> HandleAsync(Guid productId, CancellationToken cancellationToken)
    {
        var currentUser = userContext.GetCurrentUser();

        var product = await repository.GetByIdAsync(productId);

        return ProductDto.CreateFromEntity(product, currentUser?.Id);
    }
}
