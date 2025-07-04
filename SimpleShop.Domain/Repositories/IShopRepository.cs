using SimpleShop.Domain.Entities;

namespace SimpleShop.Domain.Repositories
{
    public interface IShopRepository
    {
        Task AddAsync(Shop shop);
        Task<IEnumerable<Shop>> GetAllAsync();
        Task<Shop> GetByIdAsync(Guid shopId);
        Task<Shop?> GetByNameAsync(string name, Guid? id = null);
        Task<Shop?> GetByDescriptionAsync(string description, Guid? id = null);
        Task UpdateAsync(Shop shop);
        Task DeleteAsync(Shop shop);
        Task SaveChangesAsync();
    }
}
