using MediatR;
using SimpleShop.Application.ApplicationUser;
using SimpleShop.Application.Exceptions;
using SimpleShop.Application.Factories.Interfaces;
using SimpleShop.Domain.Repositories;

namespace SimpleShop.Application.Shop.Commands.EditShop
{
    internal class EditShopCommandHandler : IRequestHandler<EditShopCommand>
    {
        private readonly IUserContext _userContext;
        private readonly IShopRepository _shopRepository;
        private readonly IShopProductRepository _shopProductsRepository;
        private readonly IShopProductFactory _shopProductFactory;

        public EditShopCommandHandler(
            IUserContext userContext, 
            IShopRepository shopRepository, 
            IShopProductRepository shopProductsRepository,
            IShopProductFactory shopProductFactory)
        {
            _userContext = userContext;
            _shopRepository = shopRepository;
            _shopProductsRepository = shopProductsRepository;
            _shopProductFactory = shopProductFactory;
        }
        
        public async Task<Unit> Handle(EditShopCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _userContext.GetCurrentUser()
                ?? throw new UserNotFoundException();

            var shop = await _shopRepository.GetByIdAsync(request.Id);
            
            if (shop.UserCreatedId != currentUser.Id)
            {
                throw new ShopNotEditableException(shop.Name, currentUser.Name);
            }

            var productsAssigned = await _shopProductsRepository.GetAssignedToShopAsync(request.Id);
            shop.AddAssignedProducts(productsAssigned);

            shop.EditName(request.Name);
            shop.EditDescription(request.Description);

            var productsToDelete = productsAssigned
                .Where(sp => !request.AssignedShopProducts.Select(p => p.Id).Contains(sp.Id));

            shop.DeleteProducts(productsToDelete);

            var productsToAdd = request.AvailableShopProducts
                .Where(p => p.IsSelected)
                .Select(_shopProductFactory.Create);

            shop.AddAssignedProducts(productsToAdd);

            await _shopRepository.UpdateAsync(shop);
            await _shopRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
