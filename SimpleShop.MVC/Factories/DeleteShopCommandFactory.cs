﻿using SimpleShop.Application.Shop;
using SimpleShop.Application.Shop.Commands.DeleteShop;

namespace SimpleShop.MVC.Factories
{
    internal class DeleteShopCommandFactory : IDeleteShopCommandFactory
    {
        public DeleteShopCommand Create(ShopDto shop)
        {
            return new DeleteShopCommand
            {
                Id = shop.Id,
                Name = shop.Name,
                Description = shop.Description
            };
        }
    }
}
