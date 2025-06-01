using Microsoft.AspNetCore.Mvc;

namespace Foody.PresentationLayer.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LoadProductsByCategory(int categoryId)
        {
            return ViewComponent("_DefaultProductSectionComponentPartial", new { categoryId=categoryId });
        }
    }
}
