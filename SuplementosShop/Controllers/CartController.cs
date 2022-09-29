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



        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public async Task<IActionResult> Index()
        {


            //traigo el usuario loggeado
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            //traigo los items del carrito del usuario loggeado

            var items = await _cartRepository.GetItems(userIdClaim);
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



                CartViewModel vmodel = new()
                {
                    CartItems = items,
                    CartQuantity = cartQuantity,
                    TotalPrice = totalPrice
                };

                return View(vmodel);
            }

            CartViewModel vmodel2 = new()
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

            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;



            // agrego el item al carrito del usuario
            await _cartRepository.AddItem(model.CurrentProductId, model.ProductQuantity, userIdClaim);

            return RedirectToAction("Index", "Market");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(CartViewModel model)
        {

            //elimino el item
            await _cartRepository.DeleteItem(model.CurrentCartItemId);

            return RedirectToAction("Index", "Cart");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CartViewModel model)
        {
            // actualizo la cantidad del item
            await _cartRepository.UpdateItem(model.CurrentCartItemId, model.QuantityUpdated);


            return RedirectToAction("Index", "Cart");
        }
    }
}
