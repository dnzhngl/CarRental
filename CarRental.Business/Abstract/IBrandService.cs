using CarRental.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Abstract
{
    public interface IBrandService
    {
        List<Brand> GetAll();
        Brand GetById(int brandId);
        Brand GetByName(string brandName);
        void Add(Brand brand);
        void Delete(Brand brand);
        void Update(Brand brand);
    }
}
