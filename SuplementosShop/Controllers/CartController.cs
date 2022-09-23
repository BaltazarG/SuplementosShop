using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SuplementosShop.Entities;
using SuplementosShop.Models;
using SuplementosShop.Repositories.Interfaces;
using System.Security.Claims;

namespace SuplementosShop.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Customer")]
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

            var user = await _userManager.FindByNameAsync(model.UserId);
            var userId = user.Id;


            var items = _cartRepository.GetItems(userId);
            var cartQuantity = 0;
            var totalPrice = 0;

            foreach (var item in items)
            {
                cartQuantity += item.Quantity;
                totalPrice += (item.Product.Price * item.Quantity);
            }

            if (items == null)
                return RedirectToAction("Index", "Market");

            CartViewModel vmodel = new CartViewModel()
            {
                CartItems = items,
                CartQuantity = cartQuantity,
                TotalPrice = totalPrice
            };

            return View(vmodel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductCategoryViewModel model)
        {

            var user = await _userManager.FindByNameAsync(model.UserId);
            var userId = user.Id;

            _cartRepository.AddItem(model.CurrentProductId, model.ProductQuantity, userId);

            return RedirectToAction("Index", "Market");
        }


        [HttpPost]
        public IActionResult Delete(CartViewModel model)
        {


            _cartRepository.DeleteItem(model.CurrentCartItemId);

            return RedirectToAction("Index", "Market");
        }

        [HttpPost]
        public IActionResult Edit(CartViewModel model)
        {

            _cartRepository.UpdateItem(model.CurrentCartItemId, model.QuantityUpdated);

            return RedirectToAction("Index", "Market");
        }
    }
}
