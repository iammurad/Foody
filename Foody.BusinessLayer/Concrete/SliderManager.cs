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
    public class SliderManager : ISliderService
    {
        private readonly ISliderDal _sliderDal;

        public SliderManager(ISliderDal sliderDal)
        {
            _sliderDal = sliderDal;
        }

        public void TDelete(int Id)
        {
            _sliderDal.Delete(Id);
        }

        public List<Slider> TGetAll()
        {
            return _sliderDal.GetAll(); 
        }

        public Slider TGetById(int id)
        {
            return _sliderDal.GetById(id);
        }

        public void TInsert(Slider entity)
        {
            _sliderDal.Insert(entity);
        }

        public void TUpdate(Slider entity)
        {
           _sliderDal.Update(entity);
        }
    }
}
