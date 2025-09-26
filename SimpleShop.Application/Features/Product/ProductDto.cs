namespace SimpleShop.Application.Features.Product
{
    public class ProductDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public bool IsEditable { get; init; }
        public DateTime DateCreated { get; init; }
    }
}
