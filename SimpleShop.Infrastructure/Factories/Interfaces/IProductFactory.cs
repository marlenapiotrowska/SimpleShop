using SimpleShop.Domain.Entities;
using ProductDb = SimpleShop.Infrastructure.Models.Product;

namespace SimpleShop.Infrastructure.Factories.Interfaces;

internal interface IProductFactory
{
    Product Create(ProductDb productDb);
}
