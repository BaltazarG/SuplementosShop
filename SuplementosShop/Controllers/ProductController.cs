using Microsoft.AspNetCore.Mvc;
using SuplementosShop.Entities;
using SuplementosShop.Repositories.Interfaces;

namespace SuplementosShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            var products = _productRepository.GetProducts();

            return View(products);
        }

        public IActionResult AddProduct()
        {

            return View();
        }

        public IActionResult Add(Product newProd)
        {


            var cat = _categoryRepository.GetCategoryById(newProd.CategoryId);

            newProd.Category = cat;

            _productRepository.AddProduct(newProd);
            return RedirectToAction("Index");


        }

        public IActionResult EditProduct(int id)
        {
            if (id == 0 || id == null)
            {
                return NotFound("The id doesn't exist!");
            }
            else
            {
                var prod = _productRepository.GetProductById(id);

                if (prod == null)
                {
                    return NotFound("The product doesn't exist!");
                }

                return View(prod);
            }
        }

        public IActionResult Edit(Product updatedProd)
        {

            _productRepository.UpdateProduct(updatedProd);

            return RedirectToAction("Index");


        }

        public IActionResult DeleteProduct(int id)
        {
            if (id == 0 || id == null)
            {
                return NotFound("The id doesn't exist!");
            }
            else
            {
                var prod = _productRepository.GetProductById(id);
                if (prod == null)
                {
                    return NotFound("The product doesn't exist!");
                }
                return View(prod);
            }

        }

        public IActionResult Delete(int id)
        {

            _productRepository.DeleteProduct(id);

            return RedirectToAction("Index");

        }
    }
}
