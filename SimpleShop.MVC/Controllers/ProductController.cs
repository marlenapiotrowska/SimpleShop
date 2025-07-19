using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleShop.Application.Product.Commands.Create;
using SimpleShop.Application.Product.Commands.Delete;
using SimpleShop.Application.Product.Commands.Edit;
using SimpleShop.Application.Product.Queries.GetAll;
using SimpleShop.Application.Product.Queries.GetById;
using SimpleShop.MVC.Extensions;
using SimpleShop.MVC.Factories;

namespace SimpleShop.MVC.Controllers
{
    [Route("Products/[action]")]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IEditProductCommandFactory _editFactory;
        private readonly IDeleteProductCommandFactory _deleteFactory;

        public ProductController(IMediator mediator, IEditProductCommandFactory editFactory, IDeleteProductCommandFactory deleteFactory)
        {
            _mediator = mediator;
            _editFactory = editFactory;
            _deleteFactory = deleteFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());
            return View(products);
        }

        public async Task<IActionResult> Edit(Guid productId)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(productId));
            var model = _editFactory.Create(product);
            return View(model);
        }

        public async Task<IActionResult> Delete(Guid productId)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(productId));
            var model = _deleteFactory.Create(product);
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Owner")]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);

            this.SetNotification("success", $"Created product: {command.Name}({command.Description})");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Owner")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(EditProductCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);

            this.SetNotification("success", $"Edited product: {command.Name}({command.Description})");
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Delete(DeleteProductCommand command)
        {
            await _mediator.Send(command);

            this.SetNotification("success", $"Deleted product: {command.Name}({command.Description})");
            return RedirectToAction(nameof(Index));
        }
    }
}
