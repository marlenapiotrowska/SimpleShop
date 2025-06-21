using SimpleShop.Domain.Entities;

namespace SimpleShop.Domain.Repositories
{
    public interface IShopRepository
    {
        Task AddAsync(Shop shop);
        Task<IEnumerable<Shop>> GetAllAsync();
        Task<Shop> GetByIdAsync(Guid shopId);
        Task<Shop?> GetByNameAsync(string name);
        Task<Shop?> GetByDescriptionAsync(string description);
        Task UpdateAsync(Shop shop);
        Task DeleteAsync(Shop shop);
    }
}
