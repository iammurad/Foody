using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foody.EntityLayer.Concrete;

namespace Foody.BusinessLayer.Abstract
{
    public interface IProductService:IGenericService<Product>
    {
        List<Product> TGetProductsWithCategory();
        List<Product> TGetProductsWithCategoryAndLast12Items();
        List<Product> TGetProductsByCategory(int categoryId);
        List<Product> TGetProductsWithCategoryAndImages(int id);
    }
}
