using SimpleShop.Application.Factories.Interfaces;
using SimpleShop.Application.Features.Product;
using ProductEntity = SimpleShop.Domain.Entities.Product;

namespace SimpleShop.Application.Factories
{
    internal class ProductDtoFactory : IProductDtoFactory
    {
        public ProductDto Create(ProductEntity product, string? currentUserId)
        {
            var isEditable = !string.IsNullOrEmpty(currentUserId);

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                IsEditable = isEditable,
                DateCreated = product.DateCreated
            };
        }
    }
}
