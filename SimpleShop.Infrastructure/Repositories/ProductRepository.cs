using Microsoft.EntityFrameworkCore;
using SimpleShop.Domain.Entities;
using SimpleShop.Domain.Repositories;
using SimpleShop.Infrastructure.Exceptions;
using SimpleShop.Infrastructure.Factories.Interfaces;
using ProductDb = SimpleShop.Infrastructure.Models.Product;

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

        public async Task UpdateProductAsync(Product product)
        {
            var productDb = await GetByIdBase(product.Id);

            productDb.Name = product.Name;
            productDb.Description = product.Description;
         
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var product = await GetByIdBase(id);

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var products = await _context.Products.ToListAsync();

            return products.Select(_factory.Create);
        }

        public async Task<Product> GetByIdAsync(Guid productId)
        {
            var product = await GetByIdBase(productId);

            return _factory.Create(product);
        }

        private async Task<ProductDb> GetByIdBase(Guid productId)
        {
            return await _context.Products.SingleOrDefaultAsync(p => p.Id == productId)
                ?? throw new EntityNotFoundException($"There is no product with id {productId}");
        }
    }
}
