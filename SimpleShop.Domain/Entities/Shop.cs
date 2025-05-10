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
        public string Name { get; }
        public string Description { get; }
        public DateTime DateCreated { get; }
        public string UserCreatedId { get; }
    }
}
