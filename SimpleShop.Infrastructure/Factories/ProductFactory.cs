using SimpleShop.Domain.Entities;
using SimpleShop.Infrastructure.Factories.Interfaces;
using ProductDb = SimpleShop.Infrastructure.Models.Product;

namespace SimpleShop.Infrastructure.Factories;

internal class ProductFactory : IProductFactory
{
    public Product Create(ProductDb productDb)
    {
        return new(
            productDb.Id,
            productDb.Name,
            productDb.Description,
            productDb.DateCreated,
            productDb.UserCreatedId);
    }
}
