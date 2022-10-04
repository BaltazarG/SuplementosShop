using API.Models;
using API.Models.ProductModels;
using API.Repositories.Interfaces;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Employee, Admin")]
        public async Task<IActionResult> Add(ProductToCreationDto newProd)
        {


            //agrego el nuevo producto
            var result = await _productService.AddProduct(newProd);

            if (result is false)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Oops something went wrong. Please try again later" });

            return NoContent();

        }

        [HttpPut]
        [Route("{productId}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Employee, Admin")]
        public async Task<IActionResult> Update(ProductToUpdateDto prodToUpdate, int productId)
        {
            if (prodToUpdate is null)
                return NotFound();

            //actualizo el producto
            var result = await _productService.UpdateProduct(prodToUpdate, productId);


            if (result is false)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Oops something went wrong. Please try again later" });

            return NoContent();


        }

        [HttpDelete]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Employee, Admin")]
        [Route("{productId}")]
        public async Task<IActionResult> Delete(int productId)
        {
            //elimino el producto
            var result = await _productService.DeleteProduct(productId);

            if (result is false)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Oops something went wrong. Please try again later" });

            return NoContent();
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Customer, Admin, Employer")]
        [HttpGet]
        [Route("{productId}")]
        public async Task<IActionResult> Get(int productId)
        {
            //elimino el producto
            var product = await _productService.GetProductById(productId);

            if (product is null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Oops something went wrong. Please try again later" });

            return Ok(product);
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Customer, Admin, Employer")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //elimino el producto
            var products = await _productService.GetProducts();

            if (products is null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Oops something went wrong. Please try again later" });

            return Ok(products);
        }
    }


}

