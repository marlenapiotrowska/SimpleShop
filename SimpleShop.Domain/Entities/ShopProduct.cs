namespace SimpleShop.Domain.Entities
{
    public class ShopProduct
    {
        public ShopProduct(Guid productId, Guid shopId, string name, string description, decimal price, string userCreatedId)
        {
            Id = Guid.NewGuid();
            ProductId = productId;
            ShopId = shopId;
            Name = name;
            Description = description;
            Price = price;
            DateCreated = DateTime.Now;
            UserCreatedId = userCreatedId;
        }

        public ShopProduct(Guid id, Guid productId, Guid shopId, string name, string description, decimal price, DateTime dateCreated, string userCreatedId)
        {
            Id = id;
            ProductId = productId;
            ShopId = shopId;
            Name = name;
            Description = description;
            Price = price;
            DateCreated = dateCreated;
            UserCreatedId = userCreatedId;
        }

        public Guid Id { get; }
        public Guid ProductId { get; }
        public Guid ShopId { get; }
        public string Name { get; }
        public string Description { get; }
        public decimal Price { get; private set; }
        public DateTime DateCreated { get; }
        public string UserCreatedId { get; }

        public void UpdatePrice(decimal price)
        {
            Price = price;
        }
    }
}
