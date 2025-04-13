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

        public CreateShopCommandHandler(IShopFactory factory, IShopRepository repository)
        {
            _factory = factory;
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateShopCommand request, CancellationToken cancellationToken)
        {
            var shop = _factory.CreateNew(request);
            await _repository.AddAsync(shop);

            return Unit.Value;
        }
    }
}
