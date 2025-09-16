using SimpleShop.Domain.Entities;

namespace SimpleShop.Domain.Repositories
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteAsync(Guid id);

        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(Guid productId);
    }
}
