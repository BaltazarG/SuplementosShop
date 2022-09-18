using Microsoft.AspNetCore.Mvc;

namespace SuplementosShop.Controllers
{
    public class Customer : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
