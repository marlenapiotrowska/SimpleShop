namespace SimpleShop.Application.Features.Shop.Delete
{
    public class DeleteShopRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
