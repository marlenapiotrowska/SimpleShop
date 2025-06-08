using MediatR;
using SimpleShop.Application.ApplicationUser;
using SimpleShop.Application.Factories.Interfaces;
using SimpleShop.Domain.Repositories;

namespace SimpleShop.Application.Shop.Commands.Create
{
    public class CreateShopCommandHandler : IRequestHandler<CreateShopCommand>
    {
        private readonly IShopFactory _factory;
        private readonly IShopRepository _repository;
        private readonly IUserContext _userContext;

        public CreateShopCommandHandler(IShopFactory factory, IShopRepository repository, IUserContext userContext)
        {
            _factory = factory;
            _repository = repository;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(CreateShopCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _userContext.GetCurrentUser();

            if (currentUser == null || !currentUser.IsInManagingRole)
            {
                return Unit.Value;
            }

            var shop = _factory.CreateNew(request, currentUser.Id);
            await _repository.AddAsync(shop);

            return Unit.Value;
        }
    }
}
