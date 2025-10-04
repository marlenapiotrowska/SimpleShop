using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleShop.Application.Features.Shop;
using SimpleShop.Application.Features.Shop.Create;
using SimpleShop.Application.Features.Shop.Delete;
using SimpleShop.Application.Features.Shop.Edit;
using SimpleShop.Application.Handlers.Shop;
using SimpleShop.MVC.Extensions;
using SimpleShop.MVC.Factories.Interfaces;

namespace SimpleShop.MVC.Controllers;

[Route("Shops/[action]")]
public class ShopController : Controller
{
    private readonly IEditShopCommandFactory _editFactory;
    private readonly IDeleteShopCommandFactory _deleteFactory;
    private readonly IGetAllShopsHandler _getAllHandler;
    private readonly IGetShopByIdHandler _getByIdHandler;
    private readonly ICreateShopHandler _createHandler;
    private readonly IEditShopHandler _editHandler;
    private readonly IDeleteShopHandler _deleteHandler;

    public ShopController(
        IEditShopCommandFactory editFactory, 
        IDeleteShopCommandFactory deleteFactory,
        IGetAllShopsHandler getAllHandler,
        IGetShopByIdHandler getByIdHandler,
        ICreateShopHandler createHandler,
        IEditShopHandler editHandler,
        IDeleteShopHandler deleteHandler)
    {
        _editFactory = editFactory;
        _deleteFactory = deleteFactory;
        _getAllHandler = getAllHandler;
        _getByIdHandler = getByIdHandler;
        _createHandler = createHandler;
        _editHandler = editHandler;
        _deleteHandler = deleteHandler;
    }

    [HttpGet]
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var shops = await _getAllHandler.HandleAsync(cancellationToken);
        return View(shops);
    }

    [HttpPost]
    [Authorize(Roles = "Admin, Owner")]
    public async Task<IActionResult> Create(CreateShopRequest request, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return View(request);
        }

        await _createHandler.HandleAsync(request, cancellationToken);

        this.SetNotification("success", $"Created shop: {request.Name}({request.Description})");
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(Guid shopId, CancellationToken cancellationToken)
    {
        var (shop, redirect) = await TryGetShopOrRedirect(shopId, cancellationToken);

        if (redirect != null)
        {
            return redirect;
        }

        var model = _editFactory.Create(shop);
        return View(model);
    }

    public async Task<IActionResult> Delete(Guid shopId, CancellationToken cancellationToken)
    {
        var (shop, redirect) = await TryGetShopOrRedirect(shopId, cancellationToken);

        if (redirect != null)
        {
            return redirect;
        }

        var model = _deleteFactory.Create(shop);
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditShopRequest request, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return View(request);
        }

        await _editHandler.HandleAsync(request, cancellationToken);

        this.SetNotification("success", $"Edited shop: {request.Name}({request.Description})");
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Delete(DeleteShopRequest request, CancellationToken cancellationToken)
    {
        await _deleteHandler.HandleAsync(request, cancellationToken);

        this.SetNotification("success", $"Deleted shop: {request.Name}({request.Description})");
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    [Authorize(Roles = "Admin, Owner")]
    public IActionResult Create()
    {
        return View();
    }

    private async Task<(ShopDto? Shop, IActionResult? Redirect)> TryGetShopOrRedirect(Guid shopId, CancellationToken cancellationToken)
    {
        var shop = await _getByIdHandler.HandleAsync(shopId, cancellationToken);

        if (!shop.IsEditable)
        {
            return (null, RedirectToAction("NoAccess", "Home", new { shopName = shop.Name }));
        }

        return (shop, null);
    }
}
