using SimpleShop.Application.Features.Product;
using SimpleShop.Application.Features.Product.Delete;

namespace SimpleShop.MVC.Factories.Interfaces
{
    public interface IDeleteProductCommandFactory
    {
        DeleteProductRequest Create(ProductDto product);
    }
}
