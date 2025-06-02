using Foody.BusinessLayer.Abstract;
using Foody.EntityLayer.Concrete;
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
        public IViewComponentResult Invoke()
        {
            var products = _productService.TGetProductsWithCategoryAndLast12Items();

            return View(products);
        }

    }
}
