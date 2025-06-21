using SimpleShop.Application.Factories.Interfaces;
using SimpleShop.Application.Product.Commands.Create;
using ProductEntity = SimpleShop.Domain.Entities.Product;

namespace SimpleShop.Application.Factories
{
    internal class ProductFactory : IProductFactory
    {
        public ProductEntity CreateNew(CreateProductCommand command, string userId)
        {
            return new ProductEntity(
                command.Name,
                command.Description,
                userId);
        }
    }
}
