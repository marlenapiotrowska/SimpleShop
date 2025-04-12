﻿namespace SimpleShop.Infrastructure.Models
{
    public class Shop
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }
        public Guid PersonCreatedId { get; set; }
    }
}
