using Microsoft.EntityFrameworkCore;
using SimpleShop.Domain.Entities;
using SimpleShop.Domain.Repositories;
using SimpleShop.Infrastructure.Exceptions;
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

        public async Task<Shop> GetByIdAsync(Guid shopId)
        {
            var shopDb = await _context.Shops.SingleOrDefaultAsync(s => s.Id == shopId)
                ?? throw new EntityNotFoundException($"There is no shop with id {shopId}");

            return _factory.Create(shopDb);
        }

        public async Task<Shop?> GetByNameAsync(string name)
        {
            var shopDb = await _context.Shops
                .SingleOrDefaultAsync(s => s.Name.ToLower() == name.ToLower());

            return shopDb == null 
                ? null
                : _factory.Create(shopDb);
        }

        public async Task<Shop?> GetByDescriptionAsync(string description)
        {
            var shopDb = await _context.Shops
                .SingleOrDefaultAsync(s => s.Description.ToLower() == description.ToLower());

            return shopDb == null
                ? null
                : _factory.Create(shopDb);
        }

        public async Task UpdateAsync(Shop shop)
        {
            var shopDb = await _context.Shops.SingleOrDefaultAsync(s => s.Id == shop.Id)
                ?? throw new EntityNotFoundException($"There is no shop with id {shop.Id}");

            shopDb.Name = shop.Name;
            shopDb.Description = shop.Description;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Shop shop)
        {
            var shopDb = await _context.Shops.SingleOrDefaultAsync(s => s.Id == shop.Id)
                ?? throw new EntityNotFoundException($"There is no shop with id {shop.Id}");
        
            _context.Remove(shopDb);

            await _context.SaveChangesAsync();
        }
    }
}
