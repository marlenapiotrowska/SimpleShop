using SimpleShop.Application.Features.ShopProduct;
using ShopEntity = SimpleShop.Domain.Entities.Shop;
using ShopProductEntity = SimpleShop.Domain.Entities.ShopProduct;

namespace SimpleShop.Application.Features.Shop;

public class ShopDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public DateTime DateCreated { get; init; }
    public bool IsEditable { get; init; }

    public IEnumerable<ShopProductDto> AssignedProducts { get; init; }
    public IEnumerable<ShopProductDto> AvailableProducts { get; init; }

    public static ShopDto Create(ShopEntity shop, string currentUserId, IEnumerable<ShopProductEntity>? availableProducts = null)
    {
        var isEditable = shop.UserCreatedId == currentUserId;

        return new()
        {
            Id = shop.Id,
            Name = shop.Name,
            Description = shop.Description,
            DateCreated = shop.DateCreated,
            IsEditable = isEditable,
            AssignedProducts = CreateShopProducts(shop.AssignedProducts),
            AvailableProducts = CreateShopProducts(availableProducts)
        };
    }

    private static IEnumerable<ShopProductDto> CreateShopProducts(IEnumerable<ShopProductEntity>? shopProducts)
    {
        return shopProducts == null || !shopProducts.Any()
            ? []
            : ShopProductDto.CreateFromEntities(shopProducts);
    }
}
