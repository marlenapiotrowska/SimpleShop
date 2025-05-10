using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleShop.Application.Shop.Commands.Create;
using SimpleShop.Application.Shop.Commands.EditShop;
using SimpleShop.Application.Shop.Queries.GetAllShops;
using SimpleShop.Application.Shop.Queries.GetShopById;
using SimpleShop.MVC.Extensions;
using SimpleShop.MVC.Factories;

namespace SimpleShop.MVC.Controllers
{
    [Route("Shops/[action]")]
    public class ShopController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IEditShopCommandFactory _factory;

        public ShopController(IMediator mediator, IEditShopCommandFactory factory)
        {
            _mediator = mediator;
            _factory = factory;
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
            await _mediator.Send(command);

            this.SetNotification("success", $"Created shop: {command.Name}");

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid shopId)
        {
            var shopDto = await _mediator.Send(new GetShopByIdQuery(shopId));

            if (!shopDto.IsEditable)
            {
                return RedirectToAction("NoAccess", "Home", new { shopName = shopDto.Name });
            }

            var model = _factory.Create(shopDto);

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
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Owner")]
        public IActionResult Create()
        {
            return View();
        }
    }
}
