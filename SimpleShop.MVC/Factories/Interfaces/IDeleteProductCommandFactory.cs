using SimpleShop.Application.Product;
using SimpleShop.Application.Product.Commands.Delete;

namespace SimpleShop.MVC.Factories.Interfaces
{
    public interface IDeleteProductCommandFactory
    {
        DeleteProductCommand Create(ProductDto product);
    }
}
