using SimpleShop.Domain.Entities;
using SimpleShop.Infrastructure.Factories.Interfaces;
using ProductDb = SimpleShop.Infrastructure.Models.Product;

namespace SimpleShop.Infrastructure.Factories
{
    internal class ProductDbFactory : IProductDbFactory
    {
        public ProductDb Create(Product product)
        {
            return new ProductDb
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                DateCreated = product.DateCreated,
                UserCreatedId = product.UserCreatedId
            };
        }
    }
}
