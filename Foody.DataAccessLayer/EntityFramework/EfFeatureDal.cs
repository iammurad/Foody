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
    public class EfFeatureDal : GenericRepository<Feature>, IFeatureDal
    {
        public EfFeatureDal(FoodyContext context) : base(context)
        {
        }

        public List<Feature> GetAllActiveFeatures()
        {
            var context = new FoodyContext();
            return context.Features.Where(x => x.Status==true).ToList();
        }
    }
    
}
