using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleShop.Application.Shop;
using SimpleShop.Application.Shop.Commands.Create;
using SimpleShop.Application.Shop.Commands.Delete;
using SimpleShop.Application.Shop.Commands.Edit;
using SimpleShop.Application.Shop.Queries.GetAll;
using SimpleShop.Application.Shop.Queries.GetById;
using SimpleShop.MVC.Extensions;
using SimpleShop.MVC.Factories.Interfaces;

namespace SimpleShop.MVC.Controllers
{
    [Route("Shops/[action]")]
    public class ShopController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IEditShopCommandFactory _editFactory;
        private readonly IDeleteShopCommandFactory _deleteFactory;

        public ShopController(IMediator mediator, IEditShopCommandFactory editFactory, IDeleteShopCommandFactory deleteFactory)
        {
            _mediator = mediator;
            _editFactory = editFactory;
            _deleteFactory = deleteFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var shops = await _mediator.Send(new GetAllShopsQuery());
            return View(shops);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Owner")]
        public async Task<IActionResult> Create(CreateShopCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);

            this.SetNotification("success", $"Created shop: {command.Name}({command.Description})");
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid shopId)
        {
            var (shop, redirect) = await TryGetShopOrRedirect(shopId);

            if (redirect != null)
            {
                return redirect;
            }

            var model = _editFactory.Create(shop);
            return View(model);
        }

        public async Task<IActionResult> Delete(Guid shopId)
        {
            var (shop, redirect) = await TryGetShopOrRedirect(shopId);

            if (redirect != null)
            {
                return redirect;
            }

            var model = _deleteFactory.Create(shop);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditShopCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);

            this.SetNotification("success", $"Edited shop: {command.Name}({command.Description})");
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteShopCommand command)
        {
            await _mediator.Send(command);

            this.SetNotification("success", $"Deleted shop: {command.Name}({command.Description})");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Owner")]
        public IActionResult Create()
        {
            return View();
        }

        private async Task<(ShopDto? Shop, IActionResult? Redirect)> TryGetShopOrRedirect(Guid shopId)
        {
            var shop = await _mediator.Send(new GetShopByIdQuery(shopId));

            if (!shop.IsEditable)
            {
                return (null, RedirectToAction("NoAccess", "Home", new { shopName = shop.Name }));
            }

            return (shop, null);
        }
    }
}
