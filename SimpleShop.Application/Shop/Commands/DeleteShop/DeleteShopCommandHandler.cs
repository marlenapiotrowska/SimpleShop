using MediatR;
using SimpleShop.Application.ApplicationUser;
using SimpleShop.Domain.Repositories;

namespace SimpleShop.Application.Shop.Commands.DeleteShop
{
    public class DeleteShopCommandHandler : IRequestHandler<DeleteShopCommand>
    {
        private readonly IShopRepository _repository;
        private readonly IShopAccessValidator _accessValidator;

        public DeleteShopCommandHandler(IShopRepository repository, IShopAccessValidator accessValidator)
        {
            _repository = repository;
            _accessValidator = accessValidator;
        }

        public async Task<Unit> Handle(DeleteShopCommand request, CancellationToken cancellationToken)
        {
            var shop = await _repository.GetByIdAsync(request.Id);
            _accessValidator.Validate(shop);

            await _repository.DeleteAsync(shop);

            return Unit.Value;
        }
    }
}
