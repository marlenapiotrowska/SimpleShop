using MediatR;
using SimpleShop.Application.ApplicationUser;
using SimpleShop.Application.Exceptions;
using SimpleShop.Domain.Repositories;

namespace SimpleShop.Application.Shop.Commands.EditShop
{
    internal class EditShopCommandHandler : IRequestHandler<EditShopCommand>
    {
        private readonly IUserContext _userContext;
        private readonly IShopRepository _repository;

        public EditShopCommandHandler(IUserContext userContext, IShopRepository repository)
        {
            _userContext = userContext;
            _repository = repository;
        }
        
        public async Task<Unit> Handle(EditShopCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _userContext.GetCurrentUser()
                ?? throw new UserNotFoundException();

            var shop = await _repository.GetById(request.Id);

            if (shop.UserCreatedId != currentUser.Id)
            {
                throw new ShopNotEditableException(shop.Name, currentUser.Name);
            }

            shop.EditName(request.Name);
            shop.EditDescription(request.Description);

            await _repository.Update(shop);

            return Unit.Value;
        }
    }
}
