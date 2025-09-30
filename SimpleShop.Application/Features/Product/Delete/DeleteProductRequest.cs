using SimpleShop.Application.Features.Product.Create;

namespace SimpleShop.Application.Features.Product.Delete;

public class DeleteProductRequest : CreateProductRequest
{
    public Guid Id { get; set; }
}
