using SimpleShop.Application.Factories.Interfaces;
using SimpleShop.Application.Product;
using ProductEntity = SimpleShop.Domain.Entities.Product;

namespace SimpleShop.Application.Factories
{
    internal class ProductDtoFactory : IProductDtoFactory
    {
        public ProductDto Create(ProductEntity product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                DateCreated = product.DateCreated
            };
        }
    }
}
