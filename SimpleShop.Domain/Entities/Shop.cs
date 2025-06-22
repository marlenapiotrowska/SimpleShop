namespace SimpleShop.Domain.Entities
{
    public class Shop
    {
        public Shop(string name, string description, string userCreatedId)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            DateCreated = DateTime.Now;
            UserCreatedId = userCreatedId;
            AssignedProducts = [];
            AvailableProducts = [];
        }

        public Shop(Guid id, string name, string description, DateTime dateCreated, string userCreatedId)
        {
            Id = id;
            Name = name;
            Description = description;
            DateCreated = dateCreated;
            UserCreatedId = userCreatedId;
        }

        public Guid Id { get; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime DateCreated { get; }
        public string UserCreatedId { get; }

        public IEnumerable<ShopProduct> AssignedProducts { get; private set; }
        public IEnumerable<ShopProduct> AvailableProducts { get; private set; }

        public void EditName(string name)
        {
            Name = name;
        }

        public void EditDescription(string description)
        {
            Description = description;
        }

        public void AddAssignedProducts(IEnumerable<ShopProduct> products)
        {
            AssignedProducts = products;
        }

        public void AddAvailableProducts(IEnumerable<ShopProduct> products)
        {
            AvailableProducts = products;
        }
    }
}
