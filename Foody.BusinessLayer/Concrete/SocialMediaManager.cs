﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foody.BusinessLayer.Abstract;
using Foody.DataAccessLayer.Abstract;
using Foody.EntityLayer.Concrete;

namespace Foody.BusinessLayer.Concrete
{
    public class SocialMediaManager : ISocialMediaService
    {

        private readonly ISocialMediaDal _socialMediaDal;

        public SocialMediaManager(ISocialMediaDal socialMediaDal)
        {
            _socialMediaDal = socialMediaDal;
        }

        public void TDelete(int Id)
        {
            _socialMediaDal.Delete(Id);
        }

        public List<SocialMedia> TGetAll()
        {
           return _socialMediaDal.GetAll();
        }

        public SocialMedia TGetById(int id)
        {
            return _socialMediaDal.GetById(id);
        }

        public void TInsert(SocialMedia entity)
        {
           _socialMediaDal.Insert(entity);
        }

        public void TUpdate(SocialMedia entity)
        {
           _socialMediaDal.Update(entity);
        }
    }
}
