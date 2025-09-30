using SimpleShop.Application.Abstractions;
using SimpleShop.Application.ApplicationUser;
using SimpleShop.Application.Factories.Interfaces;
using SimpleShop.Application.Features.Product;
using SimpleShop.Domain.Repositories;

namespace SimpleShop.Application.Handlers.Product
{
    public interface IGetAllProductsHandler : IHandler
    {
        Task<IEnumerable<ProductDto>> HandleAsync(CancellationToken cancellationToken);
    }

    internal class GetAllProductsHandler(
        IUserContext userContext,
        IProductRepository repository)
        : IGetAllProductsHandler
    {
        public async Task<IEnumerable<ProductDto>> HandleAsync(CancellationToken cancellationToken)
        {
            var currentUser = userContext.GetCurrentUser();

            var products = await repository.GetAllAsync();

            return products.Select(p => ProductDto.CreateFromEntity(p, currentUser?.Id));
        }
    }
}
