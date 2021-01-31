﻿using CarRental.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.DataAccess.Abstract
{
    public interface IBrandDal
    {
        List<Brand> GetAll();
        Brand GetById(int brandId);
        void Add(Brand brand);
        void Update(Brand brand);
        void Delete(Brand brand);
    }
}
