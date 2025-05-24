using Foody.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Foody.PresentationLayer.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
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
    }
}
