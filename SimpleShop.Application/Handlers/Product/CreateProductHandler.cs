using ErrorOr;
using SimpleShop.Application.Abstractions;
using SimpleShop.Application.ApplicationUser;
using SimpleShop.Application.Factories.Interfaces;
using SimpleShop.Application.Features.Product.Create;
using SimpleShop.Domain.Repositories;

namespace SimpleShop.Application.Handlers.Product
{
    public interface ICreateProductHandler : IHandler
    {
        Task<ErrorOr<Success>> Handle(CreateProductRequest request, CancellationToken cancellationToken);
    }

    internal sealed class CreateProductHandler(
        IUserContext userContext,
        IProductRepository repository,
        IProductFactory factory) 
        : ICreateProductHandler
    {
        public async Task<ErrorOr<Success>> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var currentUser = userContext.GetCurrentUser(true);

            var product = factory.CreateNew(request, currentUser.Id);
            await repository.AddAsync(product);

            return Result.Success;
        }
    }
}
