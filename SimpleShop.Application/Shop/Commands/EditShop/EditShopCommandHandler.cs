using MediatR;
using SimpleShop.Application.ApplicationUser;
using SimpleShop.Application.Exceptions;
using SimpleShop.Domain.Repositories;

namespace SimpleShop.Application.Shop.Commands.EditShop
{
    internal class EditShopCommandHandler : IRequestHandler<EditShopCommand>
    {
        private readonly IUserContext _userContext;
        private readonly IShopRepository _shopRepository;
        private readonly IShopProductRepository _shopProductsRepository;

        public EditShopCommandHandler(IUserContext userContext, IShopRepository shopRepository, IShopProductRepository shopProductsRepository)
        {
            _userContext = userContext;
            _shopRepository = shopRepository;
            _shopProductsRepository = shopProductsRepository;
        }
        
        public async Task<Unit> Handle(EditShopCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _userContext.GetCurrentUser()
                ?? throw new UserNotFoundException();

            var shop = await _shopRepository.GetByIdAsync(request.Id);
            var productsAssigned = await _shopProductsRepository.GetAssignedToShopAsync(request.Id);

            shop.AddAssignedProducts(productsAssigned);

            if (shop.UserCreatedId != currentUser.Id)
            {
                throw new ShopNotEditableException(shop.Name, currentUser.Name);
            }

            shop.EditName(request.Name);
            shop.EditDescription(request.Description);

            await _shopRepository.UpdateAsync(shop);

            return Unit.Value;
        }
    }
}
