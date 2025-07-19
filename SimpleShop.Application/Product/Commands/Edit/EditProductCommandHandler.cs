using MediatR;
using SimpleShop.Domain.Repositories;

namespace SimpleShop.Application.Product.Commands.Edit
{
    internal class EditProductCommandHandler : IRequestHandler<EditProductCommand>
    {
        private readonly IProductRepository _repository;

        public EditProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id);

            product.UpdateName(request.Name);
            product.UpdateDescription(request.Description);

            await _repository.UpdateProductAsync(product);

            return Unit.Value;
        }
    }
}
