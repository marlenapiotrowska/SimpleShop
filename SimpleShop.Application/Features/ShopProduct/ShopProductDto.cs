using ShopProductEntity = SimpleShop.Domain.Entities.ShopProduct;

namespace SimpleShop.Application.Features.ShopProduct;

public class ShopProductDto
{
    public Guid Id { get; init; }
    public Guid ProductId { get; init; }
    public Guid ShopId { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public decimal Price { get; set; }
    public bool IsSelected { get; set; }

    public static IEnumerable<ShopProductDto> CreateFromEntities(IEnumerable<ShopProductEntity> shopProducts)
    {
        return shopProducts
            .Select(sp => new ShopProductDto
            {
                Id = sp.Id,
                ProductId = sp.ProductId,
                ShopId = sp.ShopId,
                Name = sp.Name,
                Description = sp.Description,
                Price = sp.Price,
                IsSelected = false
            });
    }
}
