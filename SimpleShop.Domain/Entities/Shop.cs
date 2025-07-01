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
        }

        public Shop(Guid id, string name, string description, DateTime dateCreated, string userCreatedId)
        {
            Id = id;
            Name = name;
            Description = description;
            DateCreated = dateCreated;
            UserCreatedId = userCreatedId;
            AssignedProducts = [];
        }

        public Guid Id { get; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime DateCreated { get; }
        public string UserCreatedId { get; }

        public List<ShopProduct> AssignedProducts { get; private set; }

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
            AssignedProducts.AddRange(products);
        }

        public void DeleteProducts(IEnumerable<ShopProduct> products)
        {
            foreach (var product in products)
            {
                AssignedProducts.Remove(product);
            }
        }
    }
}
