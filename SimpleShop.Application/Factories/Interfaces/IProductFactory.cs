using SimpleShop.Application.Features.Product.Create;
using ProductEntity = SimpleShop.Domain.Entities.Product;

namespace SimpleShop.Application.Factories.Interfaces
{
    internal interface IProductFactory
    {
        ProductEntity CreateNew(CreateProductRequest command, string userId);
    }
}
