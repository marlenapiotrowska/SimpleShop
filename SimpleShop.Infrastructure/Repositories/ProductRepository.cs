using Microsoft.EntityFrameworkCore;
using SimpleShop.Domain.Entities;
using SimpleShop.Domain.Repositories;
using SimpleShop.Infrastructure.Factories.Interfaces;

namespace SimpleShop.Infrastructure.Repositories
{
    internal class ProductRepository : IProductRepository
    {
        private readonly SimpleShopDbContext _context;
        private readonly IProductFactory _factory;
        private readonly IProductDbFactory _dbFactory;

        public ProductRepository(SimpleShopDbContext context, IProductFactory factory, IProductDbFactory dbFactory)
        {
            _context = context;
            _factory = factory;
            _dbFactory = dbFactory;
        }

        public async Task AddAsync(Product product)
        {
            var productDb = _dbFactory.Create(product);
            
            _context.Add(productDb);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var products = await _context.Products.ToListAsync();

            return products.Select(_factory.Create);
        }
    }
}
