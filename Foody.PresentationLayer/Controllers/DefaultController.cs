using Foody.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Foody.PresentationLayer.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IProductService _productService;

        public DefaultController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult LoadProductsByCategory(int categoryId)
        //{
        //    return ViewComponent("_DefaultProductSectionComponentPartial", new { categoryId=categoryId });
        //}

        public IActionResult LoadProductsByCategory(int categoryId)
        {
            var products = categoryId == 0
                ? _productService.TGetProductsWithCategoryAndLast12Items()
                : _productService.TGetProductsByCategory(categoryId);

                return PartialView("_ProductItemsPartial", products); 
        }
    }
}
