using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foody.DataAccessLayer.Abstract;
using Foody.DataAccessLayer.Context;
using Foody.DataAccessLayer.Repsoitories;
using Foody.EntityLayer.Concrete;

namespace Foody.DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EfCategoryDal(FoodyContext context) : base(context)
        {

        }
        public List<Category> GetActiveCategories()
        {
            FoodyContext context = new FoodyContext();
            return context.Categories.Where(x => x.CategoryStatus == true).ToList();
        }
    }
}
