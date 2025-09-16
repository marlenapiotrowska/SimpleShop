using SimpleShop.Application.Product;
using SimpleShop.Application.Product.Commands.Delete;
using SimpleShop.MVC.Factories.Interfaces;

namespace SimpleShop.MVC.Factories
{
    internal class DeleteProductCommandFactory : IDeleteProductCommandFactory
    {
        public DeleteProductCommand Create(ProductDto product)
        {
            return new DeleteProductCommand
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
            };
        }
    }
}
