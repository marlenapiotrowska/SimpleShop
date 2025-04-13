using Microsoft.EntityFrameworkCore;
using SimpleShop.Domain.Entities;
using SimpleShop.Domain.Repositories;
using SimpleShop.Infrastructure.Factories.Interfaces;

namespace SimpleShop.Infrastructure.Repositories
{
    internal class ShopRepository : IShopRepository
    {
        private readonly SimpleShopDbContext _context;
        private readonly IShopDbFactory _dbFactory;
        private readonly IShopFactory _factory;

        public ShopRepository(SimpleShopDbContext context, IShopDbFactory dbFactory, IShopFactory factory)
        {
            _context = context;
            _dbFactory = dbFactory;
            _factory = factory;
        }

        public async Task AddAsync(Shop shop)
        {
            var shopDb = _dbFactory.Create(shop);

            _context.Shops.Add(shopDb);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Shop>> GetAll()
        {
            var shopsDb = await _context.Shops.ToListAsync();

            return shopsDb.Select(_factory.Create);
        }
    }
}
