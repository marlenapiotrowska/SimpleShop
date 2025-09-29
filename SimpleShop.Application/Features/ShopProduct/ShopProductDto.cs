namespace SimpleShop.Application.Features.ShopProduct
{
    public class ShopProductDto
    {
        public Guid Id { get; init; }
        public Guid ProductId { get; init; }
        public Guid ShopId { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public decimal Price { get; set; }
        public bool IsSelected { get; set; }
    }
}
