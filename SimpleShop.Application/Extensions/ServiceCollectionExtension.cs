using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SimpleShop.Application.ApplicationUser;
using SimpleShop.Application.Factories;
using SimpleShop.Application.Factories.Interfaces;
using SimpleShop.Application.Product.Commands.Create;
using SimpleShop.Application.Shop.Commands.CreateShop;

namespace SimpleShop.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateShopCommand));
            services.AddScoped<IUserContext, UserContext>();
            services.AddTransient<IShopFactory, ShopFactory>();
            services.AddTransient<IShopDtoFactory, ShopDtoFactory>();
            services.AddTransient<IProductDtoFactory, ProductDtoFactory>();
            services.AddTransient<IProductFactory, ProductFactory>();

            services.AddValidatorsFromAssemblyContaining<CreateShopCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

            services.AddValidatorsFromAssemblyContaining<CreateProductCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}
