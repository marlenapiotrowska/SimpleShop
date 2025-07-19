using MediatR;
using SimpleShop.Application.ApplicationUser;
using SimpleShop.Domain.Repositories;

namespace SimpleShop.Application.Product.Commands.Delete
{
    internal class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductAccessValidator _accessValidator;
        private readonly IProductRepository _repository;

        public DeleteProductCommandHandler(IProductAccessValidator accessValidator, IProductRepository repository)
        {
            _accessValidator = accessValidator;
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            _accessValidator.Validate();

            await _repository.DeleteAsync(request.Id);

            return Unit.Value;
        }
    }
}
