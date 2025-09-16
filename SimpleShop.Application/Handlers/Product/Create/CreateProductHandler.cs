using SimpleShop.Application.Abstractions;
using SimpleShop.Application.ApplicationUser;
using SimpleShop.Application.Factories.Interfaces;
using SimpleShop.Domain.Repositories;

namespace SimpleShop.Application.Handlers.Product.Create
{
    public interface ICreateProductHandler : IHandler
    {
        Task Handle(CreateProductRequest request, CancellationToken cancellationToken);
    }

    internal sealed class CreateProductHandler(
        IUserContext userContext,
        IProductRepository repository,
        IProductFactory factory) 
        : ICreateProductHandler
    {
        public async Task Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var currentUser = userContext.GetCurrentUser(true);

            var product = factory.CreateNew(request, currentUser.Id);
            await repository.AddAsync(product);
        }
    }
}
