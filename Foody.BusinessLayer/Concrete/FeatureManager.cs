using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foody.BusinessLayer.Abstract;
using Foody.EntityLayer.Concrete;
using Foody.DataAccessLayer.Abstract;

namespace Foody.BusinessLayer.Concrete
{
    public class FeatureManager : IFeatureService
    {

       private readonly IFeatureDal _featureDal;
        public FeatureManager(IFeatureDal featureDal)
        {
            _featureDal = featureDal;
        }

        public List<Feature> TGetAllActiveFeatures()
        {
           return _featureDal.GetAllActiveFeatures();
        }

        public void TDelete(int Id)
        {
           _featureDal.Delete(Id);
        }

        public List<Feature> TGetAll()
        {
            return _featureDal.GetAll();
        }

        public Feature TGetById(int id)
        {
            return _featureDal.GetById(id);
        }

        public void TInsert(Feature entity)
        {
            _featureDal.Insert(entity);
        }

        public void TUpdate(Feature entity)
        {
            _featureDal.Update(entity);
        }
    }
}
