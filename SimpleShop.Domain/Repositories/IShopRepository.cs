using SimpleShop.Domain.Entities;

namespace SimpleShop.Domain.Repositories
{
    public interface IShopRepository
    {
        Task AddAsync(Shop shop);
        Task<IEnumerable<Shop>> GetAll();
        Task<Shop> GetById(Guid shopId);

        Task Update(Shop shop);
    }
}
