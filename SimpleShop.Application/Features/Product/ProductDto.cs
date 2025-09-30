using ProductEntity = SimpleShop.Domain.Entities.Product;

namespace SimpleShop.Application.Features.Product;

public class ProductDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public bool IsEditable { get; init; }
    public DateTime DateCreated { get; init; }

    public static ProductDto CreateFromEntity(ProductEntity product, string? currentUserId)
    {
        var isEditable = !string.IsNullOrEmpty(currentUserId);

        return new()
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            IsEditable = isEditable,
            DateCreated = product.DateCreated
        };
    }
}
