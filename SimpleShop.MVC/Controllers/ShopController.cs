using Microsoft.AspNetCore.Mvc;

namespace SimpleShop.MVC.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
