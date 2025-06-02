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
                .Where(x => x.CategoryId == categoryId)
                .ToList();
        }

        public List<Product> GetProductsWithCategory()
        {
            var values = _context.Products.Include(x => x.Category).ToList();
            return values;
        }

        public List<Product> GetProductsWithCategoryAndLast12Items()
        {
          return  _context.Products
                .Include(x => x.ProductImages)
                .Include(x => x.Category)
                .OrderByDescending(x => x.ProductId)
                .Take(12)
                .ToList();
        }
    }
   
}
