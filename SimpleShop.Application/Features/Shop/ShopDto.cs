using SimpleShop.Application.Features.ShopProduct;

namespace SimpleShop.Application.Features.Shop
{
    public record ShopDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public DateTime DateCreated { get; init; }
        public bool IsEditable { get; init; }

        public IEnumerable<ShopProductDto> AssignedProducts { get; init; }
        public IEnumerable<ShopProductDto> AvailableProducts { get; init; }
    }
}
