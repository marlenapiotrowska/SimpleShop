using SimpleShop.Application.Features.Shop.Create;

namespace SimpleShop.Application.Features.Shop.Edit;

public class EditShopRequest : CreateShopRequest
{
    public bool IsEditable { get; set; }
}
