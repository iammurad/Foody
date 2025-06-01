using Foody.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Foody.PresentationLayer.ViewComponents.DefaultViewComponents
{
    public class _DefaultProductSectionComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;
        public _DefaultProductSectionComponentPartial(IProductService productService)
        {
            _productService = productService;
        }
        public IViewComponentResult Invoke(int categoryId = 0)
        {
            var products = categoryId == 0
                ? _productService.TGetProductsWithCategoryAndLast12Items()
                : _productService.TGetProductsByCategory(categoryId);

            return View(products);
        }

    }
}
