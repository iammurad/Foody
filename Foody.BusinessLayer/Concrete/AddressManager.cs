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
    public class AddressManager : IAddressService
    {

        private readonly IAddressDal _addressDal;

        public AddressManager(IAddressDal addressDal)
        {
            _addressDal = addressDal;
        }

        public void TDelete(int Id)
        {
            _addressDal.Delete(Id);
        }

        public List<Address> TGetAll()
        {
          return _addressDal.GetAll();
        }

        public Address TGetById(int id)
        {
           return _addressDal.GetById(id);
        }

        public void TInsert(Address entity)
        {
           _addressDal.Insert(entity);
        }

        public void TUpdate(Address entity)
        {
            _addressDal.Update(entity);
        }
    }
}
