namespace SimpleShop.Infrastructure.Models
{
    public class ProductShop
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid ShopId { get; set; }
        public decimal Price { get; set; }
        public DateTime DateCreated { get; set; }
        public string UserCreatedId { get; set; }
        public ApplicationUser? UserCreated { get; set; }


        public virtual Product Product { get; set; }
        public virtual Shop Shop { get; set; }
    }
}
