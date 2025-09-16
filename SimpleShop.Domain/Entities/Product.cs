using SimpleShop.Domain.Exceptions;

namespace SimpleShop.Domain.Entities
{
    public class Product
    {
        public Product(string name, string description, string userCreatedId)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            DateCreated = DateTime.Now;
            UserCreatedId = userCreatedId;
        }

        public Product(Guid id, string name, string description, DateTime dateCreated, string userCreatedId)
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

        public void UpdateDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                throw new EmptyValueException("description");
            }

            Description = description;
        }

        public void UpdateName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new EmptyValueException("name");
            }

            Name = name;
        }
    }
}
