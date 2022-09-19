using Microsoft.AspNetCore.Mvc;

namespace SuplementosShop.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
