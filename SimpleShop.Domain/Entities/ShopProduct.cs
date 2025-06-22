namespace SimpleShop.Domain.Entities
{
    public class ShopProduct
    {
        public ShopProduct(Guid productId, Guid shopId, string name, string description)
        {
            Id = Guid.NewGuid();
            ProductId = productId;
            ShopId = shopId;
            Name = name;
            Description = description;
            Price = 0;
        }

        public ShopProduct(Guid id, Guid productId, Guid shopId, string name, string description, decimal price)
        {
            Id = id;
            ProductId = productId;
            ShopId = shopId;
            Name = name;
            Description = description;
            Price = price;
        }

        public Guid Id { get; }
        public Guid ProductId { get; }
        public Guid ShopId { get; }
        public string Name { get; }
        public string Description { get; }
        public decimal Price { get; }
    }
}
