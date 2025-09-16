using MediatR;
using SimpleShop.Application.ApplicationUser;
using SimpleShop.Application.Factories.Interfaces;
using SimpleShop.Domain.Repositories;

namespace SimpleShop.Application.Product.Commands.Create
{
    internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IUserContext _userContext;
        private readonly IProductRepository _repository;
        private readonly IProductFactory _factory;

        public CreateProductCommandHandler(IUserContext userContext, IProductRepository repository, IProductFactory factory)
        {
            _userContext = userContext;
            _repository = repository;
            _factory = factory;
        }

        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _userContext.GetCurrentUser(true);

            var product = _factory.CreateNew(request, currentUser.Id);
            await _repository.AddAsync(product);

            return Unit.Value;
        }
    }
}
