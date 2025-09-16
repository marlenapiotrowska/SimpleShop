using SimpleShop.Application.Factories.Interfaces;
using SimpleShop.Application.Handlers.Product.Create;
using ProductEntity = SimpleShop.Domain.Entities.Product;

namespace SimpleShop.Application.Factories
{
    internal class ProductFactory : IProductFactory
    {
        public ProductEntity CreateNew(CreateProductRequest command, string userId)
        {
            return new ProductEntity(
                command.Name,
                command.Description,
                userId);
        }
    }
}
