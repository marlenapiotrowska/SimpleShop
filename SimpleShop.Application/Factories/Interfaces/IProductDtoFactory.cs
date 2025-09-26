using SimpleShop.Application.Features.Product;
using ProductEntity = SimpleShop.Domain.Entities.Product;

namespace SimpleShop.Application.Factories.Interfaces
{
    internal interface IProductDtoFactory
    {
        ProductDto Create(ProductEntity product, string? currentUserId);
    }
}
