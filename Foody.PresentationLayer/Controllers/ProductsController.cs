using System.Diagnostics.CodeAnalysis;
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

        public ProductsController(IProductService productService, ICategoryService categoryService,
            IProductImageService productImageService)
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
        public async Task<IActionResult> CreateProduct(Product product, IFormFile firstImage,
            List<IFormFile> productImages)
        {
            ModelState.Remove("Category");
            if (ModelState.IsValid)
            {
                _productService.TInsert(product);
                var imagesToSave = new List<(IFormFile File, bool IsFirstImage)>();

                if (firstImage != null && firstImage.Length > 0)
                    imagesToSave.Add((firstImage, true));

                if (productImages != null)
                    imagesToSave.AddRange(productImages.Where(f => f != null && f.Length > 0)
                        .Select(f => (f, false)));

                if (imagesToSave.Any())
                    await SaveProductImagesAsync(product.ProductId, imagesToSave);
                return RedirectToAction("ProductListWithCategories");
            }
            else
            {
                ViewBag.Categories = new SelectList(_categoryService.TGetAll(), "CategoryId", "CategoryName");
                return View(product);
            }
        }

        public IActionResult DeleteProduct(int id)
        {
            _productService.TDelete(id);
            return RedirectToAction("ProductListWithCategories");
        }

        [SuppressMessage("ReSharper.DPA", "DPA0011: High execution time of MVC action", MessageId = "time: 4053ms")]
        public IActionResult UpdateProduct(int id)
        {
            ViewBag.Categories = new SelectList(_categoryService.TGetAll(), "CategoryId", "CategoryName");
            var product = _productService.TGetById(id);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(Product product, IFormFile? firstImage,
            List<IFormFile>?  productImages)
        {
            ModelState.Remove("Category");
            if (ModelState.IsValid)
            {
                _productService.TUpdate(product);
                var imagesToSave = new List<(IFormFile File, bool IsFirstImage)>();

                if (firstImage != null && firstImage.Length > 0)
                    imagesToSave.Add((firstImage, true));

                if (productImages != null)
                    imagesToSave.AddRange(productImages.Where(f => f != null && f.Length > 0)
                        .Select(f => (f, false)));

                if (imagesToSave.Any())
                    await SaveProductImagesAsync(product.ProductId, imagesToSave);

                return RedirectToAction("ProductListWithCategories");
            }

            ViewBag.Categories = new SelectList(_categoryService.TGetAll(), "CategoryId", "CategoryName");
            return View(product);
        }

        private async Task SaveProductImagesAsync(int productId, List<(IFormFile File, bool IsFirstImage)> images)
        {
            var saveDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "webui", "img");
            Directory.CreateDirectory(saveDirectory);

            foreach (var (file, isFirstImage) in images)
            {
                var extension = Path.GetExtension(file.FileName);
                var uniqueName = Guid.NewGuid().ToString() + extension;
                var relativePath = "/webui/img/" + uniqueName;
                var savePath = Path.Combine(saveDirectory, uniqueName);

                using (var stream = new FileStream(savePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream).ConfigureAwait(false);
                }

                var productImage = new ProductImage
                {
                    ProductId = productId,
                    ImageUrl = relativePath,
                    IsMain = isFirstImage
                };

                _productImageService.TInsert(productImage);
            }
        }
    }
}