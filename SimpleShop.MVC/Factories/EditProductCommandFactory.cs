using SimpleShop.Application.Features.Product;
using SimpleShop.Application.Features.Product.Edit;
using SimpleShop.MVC.Factories.Interfaces;

namespace SimpleShop.MVC.Factories;

internal class EditProductCommandFactory : IEditProductCommandFactory
{
    public EditProductRequest Create(ProductDto product)
    {
        return new()
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description
        };
    }
}
