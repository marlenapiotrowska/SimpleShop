using SimpleShop.Application.Product;
using SimpleShop.Application.Product.Commands.Edit;

namespace SimpleShop.MVC.Factories
{
    internal class EditProductCommandFactory : IEditProductCommandFactory
    {
        public EditProductCommand Create(ProductDto product)
        {
            return new EditProductCommand
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
            };
        }
    }
}
