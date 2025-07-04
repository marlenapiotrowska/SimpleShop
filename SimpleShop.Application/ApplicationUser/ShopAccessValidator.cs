using SimpleShop.Application.Exceptions;
using ShopEntity = SimpleShop.Domain.Entities.Shop;

namespace SimpleShop.Application.ApplicationUser
{
    public interface IShopAccessValidator
    {
        void Validate(ShopEntity shop);
    }

    internal class ShopAccessValidator : IShopAccessValidator
    {
        private readonly IUserContext _userContext;

        public ShopAccessValidator(IUserContext userContext)
        {
            _userContext = userContext;
        }

        public void Validate(ShopEntity shop)
        {
            var currentUser = _userContext.GetCurrentUser(false);

            if (shop.UserCreatedId != currentUser.Id)
            {
                throw new ShopNotEditableException(shop.Name, currentUser.Name);
            }
        }
    }
}
