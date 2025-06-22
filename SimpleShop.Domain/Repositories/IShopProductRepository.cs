using SimpleShop.Domain.Entities;

namespace SimpleShop.Domain.Repositories
{
    public interface IShopProductRepository
    {
        Task<IEnumerable<ShopProduct>> GetAssignedToShopAsync(Guid shopId);
        Task<IEnumerable<ShopProduct>> GetNotAssignedToShopAsync(Guid shopId);
    }
}
