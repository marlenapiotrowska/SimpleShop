using ErrorOr;
using SimpleShop.Application.Abstractions;
using SimpleShop.Application.ApplicationUser;
using SimpleShop.Application.Features.Product.Create;
using SimpleShop.Domain.Repositories;
using ProductModel = SimpleShop.Domain.Entities.Product;

namespace SimpleShop.Application.Handlers.Product;

public interface ICreateProductHandler : IHandler
{
    Task<ErrorOr<Success>> HandleAsync(CreateProductRequest request, CancellationToken cancellationToken);
}

internal sealed class CreateProductHandler(
    IUserContext userContext,
    IProductRepository repository)
    : ICreateProductHandler
{
    public async Task<ErrorOr<Success>> HandleAsync(CreateProductRequest request, CancellationToken cancellationToken)
    {
        var currentUser = userContext.GetCurrentUser(true);

        var product = ProductModel.Create(request.Name, request.Description, currentUser.Id);
        await repository.AddAsync(product);

        return Result.Success;
    }
}
