﻿namespace SimpleShop.Application.Shop
{
    public record ShopDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public DateTime DateCreated { get; init; }
        public bool IsEditable { get; init; }
    }
}
