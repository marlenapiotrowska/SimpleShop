using ErrorOr;
using SimpleShop.Application.Abstractions;
using SimpleShop.Application.ApplicationUser;
using SimpleShop.Application.Factories.Interfaces;
using SimpleShop.Application.Features.Shop.Edit;
using SimpleShop.Domain.Repositories;
using ShopProductEntity = SimpleShop.Domain.Entities.ShopProduct;

namespace SimpleShop.Application.Handlers.Shop
{
    public interface IEditShopHandler : IHandler
    {
        Task<ErrorOr<Success>> Handle(EditShopRequest request, CancellationToken cancellationToken);
    }

    internal class EditShopHandler(
        IShopAccessValidator accessValidator,
        IShopRepository shopRepository,
        IShopProductRepository shopProductsRepository,
        IShopProductFactory shopProductFactory) 
        : IEditShopHandler
    {
        public async Task<ErrorOr<Success>> Handle(EditShopRequest request, CancellationToken cancellationToken)
        {
            var shop = await shopRepository.GetByIdAsync(request.Id);
            accessValidator.Validate(shop);

            var productsAssigned = await shopProductsRepository.GetAssignedToShopAsync(request.Id);
            shop.AddAssignedProducts(productsAssigned);

            shop.EditName(request.Name);
            shop.EditDescription(request.Description);
            shop.UpdateAssignedProducts(GetProductsToUpdate(request, productsAssigned));
            shop.DeleteProducts(GetProductsIdsToDelete(request, productsAssigned));
            shop.AddAssignedProducts(GetProductsToAdd(request, productsAssigned));

            await shopRepository.UpdateAsync(shop);
            await shopRepository.SaveChangesAsync();

            return Result.Success;
        }

        private IEnumerable<ShopProductEntity> GetProductsToUpdate(EditShopRequest request, IEnumerable<ShopProductEntity> productsAssigned)
        {
            return request.AssignedShopProducts
                .Where(editedProduct => productsAssigned.Any(product => editedProduct.Id == product.Id && product.Price != editedProduct.Price))
                .Select(shopProductFactory.Create);
        }

        private IEnumerable<Guid> GetProductsIdsToDelete(EditShopRequest request, IEnumerable<ShopProductEntity> productsAssigned)
        {
            return productsAssigned
                .Where(assigned => !request.AssignedShopProducts.Any(product => product.Id == assigned.Id))
                .Select(sp => sp.Id);
        }

        private IEnumerable<ShopProductEntity> GetProductsToAdd(EditShopRequest request, IEnumerable<ShopProductEntity> productsAssigned)
        {
            return request.AssignedShopProducts
                .Where(assigned => !productsAssigned.Any(p => p.Id == assigned.Id))
                .Select(shopProductFactory.Create);
        }
    }
}
