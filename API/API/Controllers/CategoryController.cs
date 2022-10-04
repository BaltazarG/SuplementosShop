using API.Models;
using API.Models.CategoryModels;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService CategoryService)
        {
            _categoryService = CategoryService;
        }


        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<IActionResult> Add(CategoryToCreationDto newCat)
        {


            //agrego el nuevo Categoryo
            var result = await _categoryService.AddCategory(newCat);

            if (result is false)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Oops something went wrong. Please try again later" });

            return NoContent();

        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [Route("{CategoryId}")]
        public async Task<IActionResult> Update(CategoryToUpdateDto prodToUpdate, int CategoryId)
        {
            if (prodToUpdate is null)
                return NotFound();

            //actualizo el Category
            var result = await _categoryService.UpdateCategory(prodToUpdate, CategoryId);


            if (result is false)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Oops something went wrong. Please try again later" });

            return NoContent();


        }

        [HttpDelete]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [Route("{CategoryId}")]
        public async Task<IActionResult> Delete(int CategoryId)
        {
            //elimino el Categoryo
            var result = await _categoryService.DeleteCategory(CategoryId);

            if (result is false)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Oops something went wrong. Please try again later" });

            return NoContent();
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Employee, Admin, Customer")]
        [Route("{CategoryId}")]
        public async Task<IActionResult> Get(int CategoryId)
        {
            //elimino el Categoryo
            var Category = await _categoryService.GetCategoryById(CategoryId);

            if (Category is null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Oops something went wrong. Please try again later" });

            return Ok(Category);
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Employee, Admin, Customer")]
        public async Task<IActionResult> GetAll()
        {
            var Categories = await _categoryService.GetCategories();

            if (Categories is null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Oops something went wrong. Please try again later" });

            return Ok(Categories);
        }
    }


}

