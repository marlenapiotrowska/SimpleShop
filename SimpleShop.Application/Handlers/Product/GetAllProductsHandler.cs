using SimpleShop.Application.Abstractions;
using SimpleShop.Application.ApplicationUser;
using SimpleShop.Application.Factories.Interfaces;
using SimpleShop.Application.Features.Product;
using SimpleShop.Domain.Repositories;

namespace SimpleShop.Application.Handlers.Product
{
    public interface IGetAllProductsHandler : IHandler
    {
        Task<IEnumerable<ProductDto>> Handle(CancellationToken cancellationToken);
    }

    internal class GetAllProductsHandler(
        IUserContext userContext, 
        IProductRepository repository, 
        IProductDtoFactory factory) 
        : IGetAllProductsHandler
    {
        public async Task<IEnumerable<ProductDto>> Handle(CancellationToken cancellationToken)
        {
            var currentUser = userContext.GetCurrentUser();

            var products = await repository.GetAllAsync();

            return products.Select(p => factory.Create(p, currentUser?.Id));
        }
    }
}
