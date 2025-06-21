namespace SimpleShop.Infrastructure.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }
        public string UserCreatedId { get; set; }
        public ApplicationUser? UserCreated { get; set; }

        public virtual ICollection<ProductShop>? ShopProducts { get; set; }
    }
}
