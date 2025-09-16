using SimpleShop.Application.Extensions;
using SimpleShop.Infrastructure.Extensions;
using SimpleShop.MVC.Factories;
using SimpleShop.MVC.Factories.Interfaces;
using SimpleShop.MVC.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddScoped<IEditShopCommandFactory, EditShopCommandFactory>();
builder.Services.AddScoped<IDeleteShopCommandFactory, DeleteShopCommandFactory>();
builder.Services.AddScoped<IDeleteProductCommandFactory, DeleteProductCommandFactory>();
builder.Services.AddScoped<IEditProductCommandFactory, EditProductCommandFactory>();
builder.Services.AddTransient<UserNotFoundMiddleware>();
builder.Services.AddTransient<UserNotInManagingRoleMiddleware>();
builder.Services.AddTransient<ErrorHandlingMiddleware>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = "/Home/NoAccessForNotManagingRole";
    options.LoginPath = "/Identity/Account/Login";
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseMiddleware<UserNotFoundMiddleware>();
app.UseMiddleware<UserNotInManagingRoleMiddleware>();
app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages();

app.Run();
