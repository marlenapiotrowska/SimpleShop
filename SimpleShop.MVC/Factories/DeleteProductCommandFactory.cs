using SimpleShop.Application.Features.Product;
using SimpleShop.Application.Features.Product.Delete;
using SimpleShop.MVC.Factories.Interfaces;

namespace SimpleShop.MVC.Factories
{
    internal class DeleteProductCommandFactory : IDeleteProductCommandFactory
    {
        public DeleteProductRequest Create(ProductDto product)
        {
            return new DeleteProductRequest
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
            };
        }
    }
}
