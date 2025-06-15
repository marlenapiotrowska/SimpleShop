using MediatR;
using SimpleShop.Application.ApplicationUser;
using SimpleShop.Application.Exceptions;
using SimpleShop.Domain.Repositories;

namespace SimpleShop.Application.Shop.Commands.DeleteShop
{
    public class DeleteShopCommandHandler : IRequestHandler<DeleteShopCommand>
    {
        private readonly IShopRepository _repository;
        private readonly IUserContext _userContext;

        public DeleteShopCommandHandler(IShopRepository repository, IUserContext userContext)
        {
            _repository = repository;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(DeleteShopCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _userContext.GetCurrentUser()
                ?? throw new UserNotFoundException();

            var shop = await _repository.GetByIdAsync(request.Id);

            if (shop.UserCreatedId != currentUser.Id)
            {
                throw new ShopNotEditableException(shop.Name, currentUser.Name);
            }

            await _repository.DeleteAsync(shop);

            return Unit.Value;
        }
    }
}
