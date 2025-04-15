using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleShop.Application.Shop.Commands.Create;
using SimpleShop.Application.Shop.Queries.GetAllShops;
using SimpleShop.MVC.Extensions;

namespace SimpleShop.MVC.Controllers
{
    [Route("Shops/[action]")]
    public class ShopController : Controller
    {
        private readonly IMediator _mediator;

        public ShopController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var shops = await _mediator.Send(new GetAllShopsQuery());
            return View(shops);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateShopCommand command)
        {
            await _mediator.Send(command);

            this.SetNotification("success", $"Created shop: {command.Name}");

            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
