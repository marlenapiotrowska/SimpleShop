using SimpleShop.Domain.Entities;

namespace SimpleShop.Domain.Repositories
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);
        Task<IEnumerable<Product>> GetAllAsync();
    }
}
