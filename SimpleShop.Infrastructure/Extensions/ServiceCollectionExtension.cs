using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleShop.Domain.Repositories;
using SimpleShop.Infrastructure.Factories;
using SimpleShop.Infrastructure.Factories.Interfaces;
using SimpleShop.Infrastructure.Models;
using SimpleShop.Infrastructure.Repositories;

namespace SimpleShop.Infrastructure.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connection = configuration.GetConnectionString("DBConnection");

        services
            .AddDbContext<SimpleShopDbContext>(opt => opt.UseSqlServer(connection));

        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<SimpleShopDbContext>()
            .AddDefaultTokenProviders()
            .AddDefaultUI();

        services.AddScoped<IShopRepository, ShopRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IShopProductRepository, ShopProductRepository>();
        services.AddTransient<IShopDbFactory, ShopDbFactory>();
        services.AddTransient<IShopFactory, ShopFactory>();
        services.AddTransient<IProductFactory, ProductFactory>();
        services.AddTransient<IProductDbFactory, ProductDbFactory>();
        services.AddTransient<IShopProductFactory, ShopProductFactory>();
        services.AddTransient<IShopProductDbFactory, ShopProductDbFactory>();
    }
}
