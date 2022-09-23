using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuplementosShop.Models;
using SuplementosShop.Repositories.Interfaces;
using System.Dynamic;

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

        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
        public IActionResult Index()
        {

            ProductCategoryViewModel mymodel = new ProductCategoryViewModel();
            mymodel.Products = _productRepository.GetProducts();
            mymodel.Categories = _categoryRepository.GetCategories();


            return View(mymodel);
        }
    }
}
