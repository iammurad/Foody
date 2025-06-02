using Foody.BusinessLayer.Abstract;
using Foody.DataAccessLayer.Abstract;
using Foody.DataAccessLayer.EntityFramework;
using Foody.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.BusinessLayer.Concrete
{
    public class ProductImageManager : IProductImageService
    {
    private readonly  IProductImageDal _productImageDal;

        public ProductImageManager(IProductImageDal productImageDal)
        {
            _productImageDal = productImageDal;
        }

        public void TDelete(int Id)
        {
            _productImageDal.Delete(Id);
        }

        public List<ProductImage> TGetAll()
        {
           return _productImageDal.GetAll();
        }

        public ProductImage TGetById(int id)
        {
           return _productImageDal.GetById(id);
        }

        public void TInsert(ProductImage entity)
        {
            _productImageDal.Insert(entity);
        }

        public void TUpdate(ProductImage entity)
        {
           _productImageDal.Update(entity);
        }
    }
}
