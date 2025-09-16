using MediatR;
using SimpleShop.Application.ApplicationUser;
using SimpleShop.Domain.Repositories;

namespace SimpleShop.Application.Product.Commands.Edit
{
    internal class EditProductCommandHandler : IRequestHandler<EditProductCommand>
    {
        private readonly IProductAccessValidator _accessValidator;
        private readonly IProductRepository _repository;

        public EditProductCommandHandler(IProductAccessValidator accessValidator, IProductRepository repository)
        {
            _accessValidator = accessValidator;
            _repository = repository;
        }

        public async Task<Unit> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            _accessValidator.Validate();

            var product = await _repository.GetByIdAsync(request.Id);

            product.UpdateName(request.Name);
            product.UpdateDescription(request.Description);

            await _repository.UpdateProductAsync(product);

            return Unit.Value;
        }
    }
}
