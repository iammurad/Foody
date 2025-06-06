using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foody.BusinessLayer.Abstract;
using Foody.DataAccessLayer.Abstract;
using Foody.EntityLayer.Concrete;

namespace Foody.BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> TGetProductsWithCategory()
        {
            return _productDal.GetProductsWithCategory();
        }

        public void TDelete(int Id)
        {
            _productDal.Delete(Id);
        }

        public List<Product> TGetAll()
        {
            return _productDal.GetAll();
        }

        public Product TGetById(int id)
        {
            return _productDal.GetById(id);
        }

        public void TInsert(Product entity)
        {
            _productDal.Insert(entity);
        }

        public void TUpdate(Product entity)
        {
            _productDal.Update(entity);
        }

        public List<Product> TGetProductsWithCategoryAndLast12Items()
        {
            return _productDal.GetProductsWithCategoryAndLast12Items();
        }

        public List<Product> TGetProductsByCategory(int categoryId)
        {
            return _productDal.GetProductsByCategory(categoryId);
        }

        public List<Product> TGetProductsWithCategoryAndImages(int id)
        {
            return _productDal.GetProductsWithCategoryAndImages(id);
        }
    }
}
