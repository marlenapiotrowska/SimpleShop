using Microsoft.EntityFrameworkCore;
using SimpleShop.Domain.Entities;
using SimpleShop.Domain.Repositories;
using SimpleShop.Infrastructure.Exceptions;
using SimpleShop.Infrastructure.Factories.Interfaces;
using ShopDb = SimpleShop.Infrastructure.Models.Shop;

namespace SimpleShop.Infrastructure.Repositories;

internal class ShopRepository : IShopRepository
{
    private readonly SimpleShopDbContext _context;
    private readonly IShopDbFactory _dbFactory;
    private readonly IShopFactory _factory;
    private readonly IShopProductDbFactory _shopProductDbFactory;

    public ShopRepository(SimpleShopDbContext context, IShopDbFactory dbFactory, IShopFactory factory, IShopProductDbFactory shopProductDbFactory)
    {
        _context = context;
        _dbFactory = dbFactory;
        _factory = factory;
        _shopProductDbFactory = shopProductDbFactory;
    }

    public async Task AddAsync(Shop shop)
    {
        var shopDb = _dbFactory.Create(shop);

        _context.Shops.Add(shopDb);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Shop>> GetAllAsync()
    {
        var shopsDb = await _context.Shops.ToListAsync();

        return shopsDb.Select(_factory.Create);
    }

    public async Task<Shop> GetByIdAsync(Guid shopId)
    {
        var shopDb = await _context.Shops.SingleOrDefaultAsync(s => s.Id == shopId)
            ?? throw new EntityNotFoundException($"There is no shop with id {shopId}");

        return _factory.Create(shopDb);
    }

    public async Task<Shop?> GetByNameAsync(string name, Guid id)
    {
        var shopDb = await _context.Shops
            .SingleOrDefaultAsync(s => s.Name.ToLower() == name.ToLower() && s.Id != id);

        return shopDb == null
            ? null
            : _factory.Create(shopDb);
    }

    public async Task<Shop?> GetByDescriptionAsync(string description, Guid id)
    {
        var shopDb = await _context.Shops
            .SingleOrDefaultAsync(s => s.Description.ToLower() == description.ToLower() && s.Id != id);

        return shopDb == null
            ? null
            : _factory.Create(shopDb);
    }

    public async Task<IEnumerable<Shop>?> GetWithProductAssignedAsync(Guid productId)
    {
        var shopsWithProducts = await _context.Shops
            .Include(s => s.ShopProducts)
            .Where(s => s.ShopProducts != null && s.ShopProducts.Any(sp => sp.ProductId == productId))
            .ToListAsync();

        return shopsWithProducts
            .Select(_factory.Create);
    }

    public async Task UpdateAsync(Shop shop)
    {
        var shopDb = await _context.Shops
            .Include(s => s.ShopProducts)
            .SingleOrDefaultAsync(s => s.Id == shop.Id)
            ?? throw new EntityNotFoundException($"There is no shop with id {shop.Id}");

        shopDb.Name = shop.Name;
        shopDb.Description = shop.Description;
        UpdateProducts(shopDb, shop.AssignedProducts);
    }

    public async Task DeleteAsync(Shop shop)
    {
        var shopDb = await _context.Shops
            .Include(s => s.ShopProducts)
            .SingleOrDefaultAsync(s => s.Id == shop.Id)
            ?? throw new EntityNotFoundException($"There is no shop with id {shop.Id}");

        foreach (var product in shopDb.ShopProducts ?? [])
        {
            _context.ShopProducts.Remove(product);
        }

        _context.Remove(shopDb);

        await _context.SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    private void UpdateProducts(ShopDb shopDb, List<ShopProduct> assignedProducts)
    {
        var productsToDelete = shopDb.ShopProducts
            ?.Where(p => assignedProducts == null || !assignedProducts.Any(assigned => assigned.Id == p.Id))
            ?? [];

        foreach (var product in productsToDelete)
        {
            shopDb.ShopProducts?.Remove(product);
            _context.ShopProducts.Remove(product);
        }

        var productsToAdd = assignedProducts
            .Where(p => shopDb.ShopProducts == null || !shopDb.ShopProducts.Any(sp => sp.Id == p.Id))
            ?? [];

        foreach (var product in productsToAdd)
        {
            var shopProdcutDb = _shopProductDbFactory.Create(product);
            shopDb.ShopProducts?.Add(shopProdcutDb);
            _context.ShopProducts.Add(shopProdcutDb);
        }

        var productsToUpdate = assignedProducts
            .Where(p => shopDb.ShopProducts == null || shopDb.ShopProducts.Any(sp => sp.Id == p.Id && sp.Price != p.Price))
            ?? [];

        foreach (var product in productsToUpdate)
        {
            var productToUpdate = shopDb.ShopProducts
                ?.SingleOrDefault(sp => sp?.Id == product.Id);

            if (productToUpdate != null)
            {
                productToUpdate.Price = product.Price;
                _context.ShopProducts.Update(productToUpdate);
            }
        }
    }
}
