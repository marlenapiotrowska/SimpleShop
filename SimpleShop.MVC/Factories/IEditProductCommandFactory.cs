using SimpleShop.Application.Product;
using SimpleShop.Application.Product.Commands.Edit;

namespace SimpleShop.MVC.Factories
{
    public interface IEditProductCommandFactory
    {
        EditProductCommand Create(ProductDto product);
    }
}
