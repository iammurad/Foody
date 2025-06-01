using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foody.EntityLayer.Concrete;

namespace Foody.BusinessLayer.Abstract
{
    public interface ICategoryService : IGenericService<Category> 
    {
        List<Category> TGetActiveCategories();
        // This method is specific to the CategoryService and not part of the generic service interface.
        // It retrieves only the categories that are active (CategoryStatus == true).
        // The implementation will be in the concrete class that implements this interface.
    }
}
