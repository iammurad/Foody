using Foody.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Foody.PresentationLayer.ViewComponents.DefaultViewComponents
{
    public class _DefaultCategorySectionComponentPartial : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _DefaultCategorySectionComponentPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryService.TGetActiveCategories();
            return View(categories);
        }
    }
}
