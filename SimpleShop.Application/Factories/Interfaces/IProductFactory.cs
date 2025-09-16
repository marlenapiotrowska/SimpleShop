using SimpleShop.Application.Product.Commands.Create;
using ProductEntity = SimpleShop.Domain.Entities.Product;

namespace SimpleShop.Application.Factories.Interfaces
{
    internal interface IProductFactory
    {
        ProductEntity CreateNew(CreateProductCommand command, string userId);
    }
}
