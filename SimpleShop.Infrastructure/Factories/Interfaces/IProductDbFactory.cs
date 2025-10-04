using SimpleShop.Domain.Entities;
using ProductDb = SimpleShop.Infrastructure.Models.Product;

namespace SimpleShop.Infrastructure.Factories.Interfaces;

internal interface IProductDbFactory
{
    ProductDb Create(Product product);
}
