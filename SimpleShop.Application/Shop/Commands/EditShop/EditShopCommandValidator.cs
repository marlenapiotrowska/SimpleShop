﻿using FluentValidation;
using SimpleShop.Application.Shop.Commands.CreateShop;
using SimpleShop.Domain.Repositories;

namespace SimpleShop.Application.Shop.Commands.EditShop
{
    public class EditShopCommandValidator: AbstractValidator<EditShopCommand>
    {
        public EditShopCommandValidator(IShopRepository repository)
        {
            Include(new CreateShopCommandValidator(repository));
        }
    }
}
