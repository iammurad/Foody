﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foody.EntityLayer.Concrete;

namespace Foody.DataAccessLayer.Abstract
{
    public interface ICategoryDal:IGenericDal<Category>
    {
        List<Category> GetActiveCategories();
    }
}
