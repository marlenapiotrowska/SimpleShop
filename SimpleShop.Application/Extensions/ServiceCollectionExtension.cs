﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SimpleShop.Application.Factories;
using SimpleShop.Application.Factories.Interfaces;
using SimpleShop.Application.Shop.Commands.Create;

namespace SimpleShop.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateShopCommand));
            //services.AddScoped<IUserContext, UserContext>();
            services.AddTransient<IShopFactory, ShopFactory>();
            services.AddTransient<IShopDtoFactory, ShopDtoFactory>();
        }
    }
}
