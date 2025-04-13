namespace SimpleShop.Domain.Entities
{
    public class Shop
    {
        public Shop(string name, string description)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            DateCreated = DateTime.Now;
        }

        public Shop(Guid id, string name, string description, DateTime dateCreated)
        {
            Id = id;
            Name = name;
            Description = description;
            DateCreated = dateCreated;
        }

        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
        public DateTime DateCreated { get; }
    }
}
