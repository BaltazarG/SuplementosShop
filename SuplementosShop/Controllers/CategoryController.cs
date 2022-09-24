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
        public IActionResult Index()
        {
            var categories = _categoryRepository.GetCategories();
            return View(categories);
        }

        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category newCat)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _categoryRepository.AddCategory(newCat);
            return RedirectToAction("Index");
        }

        public IActionResult EditCategory(int id)
        {
            if (id == 0 || id == null)
            {
                return NotFound("The id doesn't exist!");
            }
            else
            {
                var category = _categoryRepository.GetCategoryById(id);

                if (category == null)
                {
                    return NotFound("The category doesn't exist!");
                }

                return View(category);
            }
        }

        public IActionResult Edit(Category updatedCat)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.UpdateCategory(updatedCat);

                return RedirectToAction("Index");
            }

            return RedirectToAction("Error", "Home");
        }
        public IActionResult DeleteCategory(int id)
        {
            if (id == 0 || id == null)
            {
                return NotFound("The id doesn't exist!");
            }
            else
            {
                var cat = _categoryRepository.GetCategoryById(id);
                if (cat == null)
                {
                    return NotFound("The category doesn't exist!");
                }
                return View(cat);
            }

        }

        public IActionResult Delete(int id)
        {

            _categoryRepository.DeleteCategory(id);

            return RedirectToAction("Index");


        }
    }
}
