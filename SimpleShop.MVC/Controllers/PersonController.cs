using Microsoft.AspNetCore.Mvc;

namespace SimpleShop.MVC.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
