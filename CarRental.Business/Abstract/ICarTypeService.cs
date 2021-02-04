using CarRental.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Abstract
{
    public interface ICarTypeService
    {
        List<CarType> GetAll();
        CarType GetById(int CarTypeId);
        void Add(CarType CarType);
        void Delete(CarType CarType);
        void Update(CarType CarType);
    }
}
