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
        private readonly IProductImageService _productImageService;

        public ProductsController(IProductService productService, ICategoryService categoryService, IProductImageService productImageService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _productImageService = productImageService;
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
        public async Task<IActionResult> CreateProduct(Product product, List<IFormFile> ProductImages)
        {
            ModelState.Remove("Category");
            if (ModelState.IsValid)
            {
               
                _productService.TInsert(product);
                int productId = product.ProductId; 

                foreach (var file in ProductImages)
                {
                    if (file != null && file.Length > 0)
                    {
                        // Create a unique filename
                        var extension = Path.GetExtension(file.FileName);
                        var uniqueName = Guid.NewGuid().ToString() + extension;
                        var savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/webui/img/", uniqueName);

                        // Ensure the upload folder exists
                        Directory.CreateDirectory(Path.GetDirectoryName(savePath));

                        // Save the file to disk
                        using (var stream = new FileStream(savePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        // 3. Create image entry in DB
                        var productImage = new ProductImage
                        {
                            ProductId = productId,
                            ImageUrl = "wwwroot/webui/img/" + uniqueName
                        };

                        _productImageService.TInsert(productImage);
                    }
                }

                return RedirectToAction("ProductListWithCategories");
            }
            ViewBag.Categories = new SelectList(_categoryService.TGetAll(), "CategoryId", "CategoryName");
            return View(product);
        }


        public IActionResult DeleteProduct(int id)
        {
            _productService.TDelete(id);
            return RedirectToAction("ProductListWithCategories");
        }
        public IActionResult UpdateProduct(int id)
        {
            ViewBag.Categories = new SelectList(_categoryService.TGetAll(), "CategoryId", "CategoryName");
            var product = _productService.TGetById(id);
            return View(product);
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            _productService.TUpdate(product);
            return RedirectToAction("ProductListWithCategories");
        }

    }
}
