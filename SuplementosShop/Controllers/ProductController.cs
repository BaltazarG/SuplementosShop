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
        public async Task<IActionResult> Index()
        {

            //traigo todos los productos y categorias

            ProductCategoryViewModel mymodel = new ProductCategoryViewModel();
            mymodel.Products = await _productRepository.GetProducts();
            mymodel.Categories = await _categoryRepository.GetCategories();

            return View(mymodel);
        }

        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Employee")]
        public async Task<IActionResult> AddProduct()
        {
            SingleProductCategoryViewModel mymodel = new SingleProductCategoryViewModel();

            //traigo las categorias para mostrar en un select
            mymodel.Categories = await _categoryRepository.GetCategories();

            return View(mymodel);
        }

        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Employee")]
        public async Task<IActionResult> Add(SingleProductCategoryViewModel newProd)
        {

            //traigo la categoria seleccionada
            var cat = await _categoryRepository.GetCategoryById(newProd.Product.CategoryId);

            newProd.Product.Category = cat;

            // agrego el nuevo producto
            await _productRepository.AddProduct(newProd.Product);

            return RedirectToAction("Index");


        }

        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Employee")]
        public async Task<IActionResult> EditProduct(int id)
        {
            if (id == 0 || id == null)
            {
                return NotFound("The id doesn't exist!");
            }
            else
            {

                SingleProductCategoryViewModel mymodel = new SingleProductCategoryViewModel();


                //traigo el producto a actualizar
                mymodel.Product = await _productRepository.GetProductById(id);

                mymodel.Categories = await _categoryRepository.GetCategories();

                if (mymodel.Product == null)
                {
                    return NotFound("The product doesn't exist!");
                }

                return View(mymodel);
            }
        }

        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Employee")]
        public async Task<IActionResult> Edit(SingleProductCategoryViewModel prodToUpdate)
        {
            //actualizo el producto
            await _productRepository.UpdateProduct(prodToUpdate.Product);

            return RedirectToAction("Index");


        }

        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Employee")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (id == 0 || id == null)
            {
                return NotFound("The id doesn't exist!");
            }
            else
            {

                //traigo el producto a eliminar
                var prod = await _productRepository.GetProductById(id);
                if (prod == null)
                {
                    return NotFound("The product doesn't exist!");
                }
                return View(prod);
            }

        }

        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Employee")]
        public async Task<IActionResult> Delete(int id)
        {
            // elimino el producto
            await _productRepository.DeleteProduct(id);

            return RedirectToAction("Index");
        }
    }
}
