using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foody.DataAccessLayer.Abstract;
using Foody.DataAccessLayer.Context;
using Foody.DataAccessLayer.Repsoitories;
using Foody.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Foody.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        private readonly FoodyContext _context;
        public EfProductDal(FoodyContext context) : base(context)
        {
            _context = context;
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            return _context.Products
                .Include(x => x.Category)
                .Include(x => x.ProductImages.Where(x=>x.IsMain))
                .Where(x => x.CategoryId == categoryId)
                .ToList();
        }

        public List<Product> GetProductsWithCategory()
        {
            return  _context.Products
                .Include(x => x.ProductImages.Where(x=>x.IsMain))
                .Include(x => x.Category)
                .ToList();
        }
        public List<Product> GetProductsWithCategoryAndLast12Items()
        {
            return _context.Products
                  .Include(x => x.ProductImages.Where(x=>x.IsMain))
                  .Include(x => x.Category)
                  .OrderByDescending(x => x.ProductId)
                  .Take(12)
                  .ToList();
        }

        public List<Product> GetProductsWithCategoryAndImages(int id)
        {
            var products = _context.Products
            .Include(p => p.ProductImages.Where(x=>x.IsMain))
            .Include(p => p.Category)
            .Where(p => p.CategoryId == id).ToList();
            
            if (products == null)
            {
                throw new KeyNotFoundException($"Product with ID {id} not found.");
            }
            return  products; 
        }

       
    }

}
