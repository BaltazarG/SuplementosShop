using API.Entities;
using API.Models;
using API.Models.CartModels;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "Customer")]
    [Route("api/cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public async Task<ActionResult<CartDto>> GetItems()
        {


            //traigo el usuario loggeado
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userIdClaim == null)
                return Forbid();

            //traigo los items del carrito del usuario loggeado

            var items = await _cartService.GetItems(userIdClaim);
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

                CartDto model = new()
                {
                    Items = items,
                    TotalQuantity = cartQuantity,
                    TotalAmount = totalPrice
                };

                return Ok(model);
            }


            return NotFound();


        }

        [HttpPost]
        [Route("newitem")]
        public async Task<IActionResult> Add(CartItemToCreationDto newItem)
        {
            //traigo el usuario loggeado

            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;


            // agrego el item al carrito del usuario
            var result = await _cartService.AddItem(newItem, userIdClaim);

            if (result is false)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Oops something went wrong. Please try again later" });

            return Ok(result);
        }

        [HttpDelete]
        [Route("cartItemId")]
        public async Task<IActionResult> Delete(int cartItemId)
        {

            var itemToUpdate = await _cartService.GetItem(cartItemId);

            if (itemToUpdate is null)
                return NotFound();

            //elimino el item
            var result = await _cartService.DeleteItem(cartItemId);

            if (result is false)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Oops something went wrong. Please try again later" });

            return NoContent();
        }

        [HttpPut]
        [Route("cartItemId")]
        public async Task<IActionResult> Edit(CartItemToUpdateDto itemUpdated, int itemId)
        {


            // actualizo la cantidad del item
            var itemToUpdate = await _cartService.GetItem(itemId);

            if (itemToUpdate is null)
                return NotFound();

            var result = await _cartService.UpdateItem(itemId, itemUpdated.Quantity);

            if (result is false)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Oops something went wrong. Please try again later" });

            return NoContent();

        }


    }
}
