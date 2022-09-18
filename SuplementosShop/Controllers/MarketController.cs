using Microsoft.AspNetCore.Mvc;
using SuplementosShop.Repositories.Interfaces;

namespace SuplementosShop.Controllers
{
    public class MarketController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public MarketController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            var products = _productRepository.GetProducts();

            return View(products);
        }
    }
}
