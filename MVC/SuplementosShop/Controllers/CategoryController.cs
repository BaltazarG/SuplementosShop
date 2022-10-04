using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuplementosShop.Entities;
using SuplementosShop.Repositories.Interfaces;

namespace SuplementosShop.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ICategoryRepository categoryService, ILogger<CategoryController> logger)
        {
            _categoryRepository = categoryService;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            //traigo todas las categorias cargadas
            var categories = await _categoryRepository.GetCategories();
            return View(categories);
        }

        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(Category newCat)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            //agrego categoria
            await _categoryRepository.AddCategory(newCat);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> EditCategory(int id)
        {
            if (id == 0 || id == null)
            {
                return NotFound("The id doesn't exist!");
            }
            else
            {

                // traigo la categoria a actualizar
                var category = await _categoryRepository.GetCategoryById(id);

                if (category == null)
                {
                    return NotFound("The category doesn't exist!");
                }

                return View(category);
            }
        }

        public async Task<IActionResult> Edit(Category updatedCat)
        {
            if (ModelState.IsValid)
            {
                // actualizo la categoria
                await _categoryRepository.UpdateCategory(updatedCat);

                return RedirectToAction("Index");
            }

            return RedirectToAction("Error", "Home");
        }
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (id == 0 || id == null)
            {
                return NotFound("The id doesn't exist!");
            }
            else
            {
                // traigo la categoria a eliminar
                var cat = await _categoryRepository.GetCategoryById(id);
                if (cat == null)
                {
                    return NotFound("The category doesn't exist!");
                }
                return View(cat);
            }

        }

        public async Task<IActionResult> Delete(int id)
        {
            // elimino la categoria
            await _categoryRepository.DeleteCategory(id);

            return RedirectToAction("Index");


        }
    }
}
