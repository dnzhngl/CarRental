using CarRental.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Abstract
{
    public interface ICarTypeService
    {
        List<CarType> GetAll();
        CarType GetById(int carTypeId);
        CarType GetByName(string carTypeName);
        void Add(CarType carType);
        void Delete(CarType carType);
        void Update(CarType carType);
    }
}
