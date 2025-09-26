using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SimpleShop.Application.Abstractions;
using SimpleShop.Application.ApplicationUser;
using SimpleShop.Application.Factories;
using SimpleShop.Application.Factories.Interfaces;
using SimpleShop.Application.Features.Product.Create;
using SimpleShop.Application.Features.Shop.Create;
using SimpleShop.Application.Handlers;

namespace SimpleShop.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IEventPublisher, EventPublisher>();
            services.RegisterHandlersFromAssemblyContaining(typeof(ServiceCollectionExtension));
          
            services.AddMediatR(typeof(CreateShopRequest));
            services.AddScoped<IUserContext, UserContext>();
            services.AddScoped<IShopAccessValidator, ShopAccessValidator>();
            services.AddScoped<IProductAccessValidator, ProductAccessValidator>();
            services.AddTransient<IShopFactory, ShopFactory>();
            services.AddTransient<IShopDtoFactory, ShopDtoFactory>();
            services.AddTransient<IProductDtoFactory, ProductDtoFactory>();
            services.AddTransient<IProductFactory, ProductFactory>();
            services.AddTransient<IShopProductFactory, ShopProductFactory>();

            services.AddValidatorsFromAssemblyContaining<CreateShopValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

            services.AddValidatorsFromAssemblyContaining<CreateProductValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

            return services;
        }
    }
}
