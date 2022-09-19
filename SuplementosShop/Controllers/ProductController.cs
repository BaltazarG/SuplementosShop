using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuplementosShop.Entities;
using SuplementosShop.Models;
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
        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Employee, Admin")]
        public IActionResult Index()
        {

            ProductCategoryViewModel mymodel = new ProductCategoryViewModel();
            mymodel.Products = _productRepository.GetProducts();
            mymodel.Categories = _categoryRepository.GetCategories();

            return View(mymodel);
        }

        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Employee")]
        public IActionResult AddProduct()
        {
            SingleProductCategoryViewModel mymodel = new SingleProductCategoryViewModel();
            mymodel.Categories = _categoryRepository.GetCategories();

            return View(mymodel);
        }

        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Employee")]
        public IActionResult Add(SingleProductCategoryViewModel newProd)
        {


            var cat = _categoryRepository.GetCategoryById(newProd.Product.CategoryId);

            newProd.Product.Category = cat;

            _productRepository.AddProduct(newProd.Product);
            return RedirectToAction("Index");


        }

        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Employee")]
        public IActionResult EditProduct(int id)
        {
            if (id == 0 || id == null)
            {
                return NotFound("The id doesn't exist!");
            }
            else
            {

                SingleProductCategoryViewModel mymodel = new SingleProductCategoryViewModel();
                mymodel.Product = _productRepository.GetProductById(id);
                mymodel.Categories = _categoryRepository.GetCategories();

                if (mymodel.Product == null)
                {
                    return NotFound("The product doesn't exist!");
                }

                return View(mymodel);
            }
        }

        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Employee")]
        public IActionResult Edit(SingleProductCategoryViewModel prodToUpdate)
        {

            _productRepository.UpdateProduct(prodToUpdate.Product);

            return RedirectToAction("Index");


        }

        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Employee")]
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

        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Employee")]
        public IActionResult Delete(int id)
        {

            _productRepository.DeleteProduct(id);

            return RedirectToAction("Index");
        }
    }
}
