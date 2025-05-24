using Foody.BusinessLayer.Abstract;
using Foody.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Foody.PresentationLayer.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductsController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult ProductList()
        {
            var products = _productService.TGetAll();
            return View(products);
        }
        public IActionResult ProductListWithCategories()
        {
            var products = _productService.TGetProductsWithCategory();
            return View(products);
        }

        public IActionResult ProductDetails(int id)
        {
            var product = _productService.TGetById(id);
            return View(product);
        }
        [HttpGet]
        public IActionResult CreateProduct()
        {
            ViewBag.Categories = new SelectList(_categoryService.TGetAll(), "CategoryId", "CategoryName"); 
            return View();
        }
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            _productService.TInsert(product);
            return RedirectToAction("ProductListWithCategories");
        }
        public IActionResult DeleteProducts(int id)
        {
            _productService.TDelete(id);
            return RedirectToAction("ProductListWithCategories");
        }
        public IActionResult ProductUpdate(int id)
        {
            var product = _productService.TGetById(id);
            return View(product);
        }
        [HttpPost]  
        public IActionResult ProductUpdate(Product product)
        {
            _productService.TUpdate(product);
            return RedirectToAction("ProductListWithCategories");
        }

    }
}
