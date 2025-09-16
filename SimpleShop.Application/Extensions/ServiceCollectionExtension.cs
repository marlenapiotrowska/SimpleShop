using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SimpleShop.Application.Abstractions;
using SimpleShop.Application.ApplicationUser;
using SimpleShop.Application.Factories;
using SimpleShop.Application.Factories.Interfaces;
using SimpleShop.Application.Handlers;
using SimpleShop.Application.Product.Commands.Create;
using SimpleShop.Application.Shop.Commands.Create;

namespace SimpleShop.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IEventPublisher, EventPublisher>();
            services.RegisterHandlersFromAssemblyContaining(typeof(ServiceCollectionExtension));
          
            services.AddMediatR(typeof(CreateShopCommand));
            services.AddScoped<IUserContext, UserContext>();
            services.AddScoped<IShopAccessValidator, ShopAccessValidator>();
            services.AddScoped<IProductAccessValidator, ProductAccessValidator>();
            services.AddTransient<IShopFactory, ShopFactory>();
            services.AddTransient<IShopDtoFactory, ShopDtoFactory>();
            services.AddTransient<IProductDtoFactory, ProductDtoFactory>();
            services.AddTransient<IProductFactory, ProductFactory>();
            services.AddTransient<IShopProductFactory, ShopProductFactory>();

            services.AddValidatorsFromAssemblyContaining<CreateShopCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

            services.AddValidatorsFromAssemblyContaining<CreateProductCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

            return services;
        }
    }
}
