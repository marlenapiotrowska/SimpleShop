using SimpleShop.Application.Features.Product.Create;

namespace SimpleShop.Application.Features.Product.Edit;

public class EditProductRequest : CreateProductRequest
{
    public Guid Id { get; set; }
}
