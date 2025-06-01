using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foody.EntityLayer.Concrete;

namespace Foody.DataAccessLayer.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
        List<Product> GetProductsWithCategory();
        List<Product> GetProductsWithCategoryAndLast12Items();
    }
}
