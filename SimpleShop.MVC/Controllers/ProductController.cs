using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleShop.Application.Features.Product.Create;
using SimpleShop.Application.Features.Product.Delete;
using SimpleShop.Application.Features.Product.Edit;
using SimpleShop.Application.Handlers.Product;
using SimpleShop.MVC.Extensions;
using SimpleShop.MVC.Factories.Interfaces;

namespace SimpleShop.MVC.Controllers
{
    [Route("Products/[action]")]
    public class ProductController : Controller
    {
        private readonly IEditProductCommandFactory _editFactory;
        private readonly IDeleteProductCommandFactory _deleteFactory;
        private readonly IGetProductByIdHandler _getByIdHandler;
        private readonly IGetAllProductsHandler _getAllHandler;
        private readonly ICreateProductHandler _createProductHandler;
        private readonly IEditProductHandler _editHandler;
        private readonly IDeleteProductHandler _deleteHandler;

        public ProductController(
            IEditProductCommandFactory editFactory,
            IDeleteProductCommandFactory deleteFactory,
            IGetProductByIdHandler getByIdHandler,
            IGetAllProductsHandler getAllHandler,
            ICreateProductHandler createHandler,
            IEditProductHandler editHandler,
            IDeleteProductHandler deleteHandler)
        {
            _editFactory = editFactory;
            _deleteFactory = deleteFactory;
            _getByIdHandler = getByIdHandler;
            _getAllHandler = getAllHandler;
            _createProductHandler = createHandler;
            _editHandler = editHandler;
            _deleteHandler = deleteHandler;
        }

        [HttpGet]
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var products = await _getAllHandler.Handle(cancellationToken);
            return View(products);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Owner")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(Guid productId, CancellationToken cancellationToken)
        {
            var product = await _getByIdHandler.Handle(productId, cancellationToken);
            var model = _editFactory.Create(product);
            return View(model);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Delete(Guid productId, CancellationToken cancellationToken)
        {
            var product = await _getByIdHandler.Handle(productId, cancellationToken);
            var model = _deleteFactory.Create(product);
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Owner")]
        public async Task<IActionResult> Create(CreateProductRequest command, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await _createProductHandler.Handle(command, cancellationToken);

            this.SetNotification("success", $"Created product: {command.Name}({command.Description})");
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(EditProductRequest request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            await _editHandler.Handle(request, cancellationToken);

            this.SetNotification("success", $"Edited product: {request.Name}({request.Description})");
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Delete(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            var result = _deleteHandler.Handle(request, cancellationToken);

            if (result.Exception != null)
            {
                this.SetNotification("error", result.Exception.Message);
                return RedirectToAction(nameof(Index));
            }

            this.SetNotification("success", $"Deleted product: {request.Name}({request.Description})");
            return RedirectToAction(nameof(Index));
        }
    }
}
