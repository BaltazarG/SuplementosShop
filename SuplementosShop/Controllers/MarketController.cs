using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuplementosShop.Models;
using SuplementosShop.Repositories.Interfaces;

namespace SuplementosShop.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Customer")]
    public class MarketController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public MarketController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<IActionResult> Index()
        {
            // en un view model meto todas las categorias y productos cargados para mostrarlos en las vistas

            ProductCategoryViewModel mymodel = new();
            mymodel.Products = await _productRepository.GetProducts();
            mymodel.Categories = await _categoryRepository.GetCategories();


            return View(mymodel);
        }
    }
}
