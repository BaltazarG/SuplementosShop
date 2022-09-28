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
            //traigo el usuario loggeado
            var user = await _userManager.FindByNameAsync(model.UserId);
            var userId = user.Id;

            //traigo los items del carrito del usuario loggeado

            var items = await _cartRepository.GetItems(userId);
            var cartQuantity = 0;
            var totalPrice = 0;


            // calculo el precio total y la cantidad de items del carrito
            if (items != null)
            {
                foreach (var item in items)
                {
                    cartQuantity += item.Quantity;
                    totalPrice += (item.Product.Price * item.Quantity);
                }



                CartViewModel vmodel = new CartViewModel()
                {
                    CartItems = items,
                    CartQuantity = cartQuantity,
                    TotalPrice = totalPrice
                };

                return View(vmodel);
            }

            CartViewModel vmodel2 = new CartViewModel()
            {
                CartItems = new List<CartItem>(),
                CartQuantity = cartQuantity,
                TotalPrice = totalPrice
            };

            return View(vmodel2);




        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductCategoryViewModel model)
        {
            //traigo el usuario loggeado

            var user = await _userManager.FindByNameAsync(model.UserId);
            var userId = user.Id;


            // agrego el item al carrito del usuario
            await _cartRepository.AddItem(model.CurrentProductId, model.ProductQuantity, userId);

            return RedirectToAction("Index", "Market");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(CartViewModel model)
        {

            //elimino el item
            await _cartRepository.DeleteItem(model.CurrentCartItemId);

            return RedirectToAction("Index", "Market");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CartViewModel model)
        {
            // actualizo la cantidad del item
            await _cartRepository.UpdateItem(model.CurrentCartItemId, model.QuantityUpdated);


            return RedirectToAction("Index", "Market");
        }
    }
}
