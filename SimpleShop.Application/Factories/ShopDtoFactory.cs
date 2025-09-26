using SimpleShop.Application.Factories.Interfaces;
using SimpleShop.Application.Features.Shop;
using SimpleShop.Application.Features.ShopProduct;
using ShopEntity = SimpleShop.Domain.Entities.Shop;
using ShopProductEntity = SimpleShop.Domain.Entities.ShopProduct;

namespace SimpleShop.Application.Factories
{
    internal class ShopDtoFactory : IShopDtoFactory
    {
        public ShopDto Create(ShopEntity shop, string currentUserId, IEnumerable<ShopProductEntity> availableProducts)
        {
            var isEditable = shop.UserCreatedId == currentUserId;

            return new ShopDto
            {
                Id = shop.Id,
                Name = shop.Name,
                Description = shop.Description,
                DateCreated = shop.DateCreated,
                IsEditable = isEditable,
                AssignedProducts = CreateShopProducts(shop.AssignedProducts),
                AvailableProducts = CreateShopProducts(availableProducts)
            };
        }

        private IEnumerable<ShopProductDto> CreateShopProducts(IEnumerable<ShopProductEntity> shopProducts)
        {
            if (shopProducts == null || !shopProducts.Any())
            {
                return [];
            }

            return shopProducts
                .Select(sp => new ShopProductDto
                {
                    Id = sp.Id,
                    ProductId = sp.ProductId,
                    ShopId = sp.ShopId,
                    Name = sp.Name,
                    Description = sp.Description,
                    Price = sp.Price,
                    IsSelected = false
                });
        }
    }
}
