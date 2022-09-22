using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SuplementosShop.Entities;
using SuplementosShop.Models;
using SuplementosShop.Repositories.Interfaces;
using System.Security.Claims;

namespace SuplementosShop.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartRepository _cartRepository;
        private readonly UserManager<IdentityUser> _userManager;



        public CartController(ICartRepository cartRepository, UserManager<IdentityUser> userManager)
        {
            _cartRepository = cartRepository;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index(ProductCategoryViewModel model)
        {
            //userId = "c5aa7f72-966c-4050-b415-6dda283a3da6";

            var user = await _userManager.FindByNameAsync(model.UserId);
            var userId = user.Id;


            var items = _cartRepository.GetItems(userId);

            if (items == null)
                return RedirectToAction("Index", "Market");

            return View(items);
        }

        [HttpPost]
        public IActionResult Add(ProductCategoryViewModel model)
        {


            _cartRepository.AddItem(model.CurrentProductId, model.ProductQuantity, model.UserId);

            return RedirectToAction("Index", "Market");
        }

    }
}
