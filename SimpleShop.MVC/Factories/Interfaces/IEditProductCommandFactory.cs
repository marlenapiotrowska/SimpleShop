using SimpleShop.Application.Features.Product;
using SimpleShop.Application.Features.Product.Edit;

namespace SimpleShop.MVC.Factories.Interfaces
{
    public interface IEditProductCommandFactory
    {
        EditProductRequest Create(ProductDto product);
    }
}
