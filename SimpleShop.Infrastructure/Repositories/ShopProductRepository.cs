using Microsoft.EntityFrameworkCore;
using SimpleShop.Domain.Entities;
using SimpleShop.Domain.Repositories;
using SimpleShop.Infrastructure.Factories.Interfaces;

namespace SimpleShop.Infrastructure.Repositories
{
    internal class ShopProductRepository : IShopProductRepository
    {
        private readonly SimpleShopDbContext _context;
        private readonly IShopProductFactory _factory;

        public ShopProductRepository(SimpleShopDbContext context, IShopProductFactory factory)
        {
            _context = context;
            _factory = factory;
        }

        public async Task<IEnumerable<ShopProduct>> GetAssignedToShopAsync(Guid shopId)
        {
            var shopProductsDb = await _context.ShopProducts
                .Include(sp => sp.Product)
                .Where(sp => sp.ShopId == shopId)
                .ToListAsync();

            return shopProductsDb.Select(_factory.Create);
        }

        public async Task<IEnumerable<ShopProduct>> GetNotAssignedToShopAsync(Guid shopId, string userCreatedId)
        {
            var assignedIds = await _context.ShopProducts
                .Where(sp => sp.ShopId == shopId)
                .Select(sp => sp.ProductId)
                .ToListAsync();

            var notAssigned = await _context.Products
                .Where(p => !assignedIds.Contains(p.Id))
                .ToListAsync();

            return notAssigned.Select(ps => _factory.CreateNew(ps, shopId, userCreatedId));
        }
    }
}
