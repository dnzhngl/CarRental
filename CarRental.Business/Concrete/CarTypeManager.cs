using CarRental.Business.Abstract;
using CarRental.DataAccess.Abstract;
using CarRental.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Concrete
{
    public class CarTypeManager : ICarTypeService
    {
        private readonly ICarTypeDal _carTypeDal;
        public CarTypeManager(ICarTypeDal carTypeDal)
        {
            _carTypeDal = carTypeDal;
        }

        public void Add(CarType carType)
        {
            _carTypeDal.Add(carType);
        }

        public void Delete(CarType carType)
        {
            _carTypeDal.Delete(carType);
        }

        public CarType GetById(int carTypeId)
        {
            return _carTypeDal.Get(vt => vt.Id == carTypeId);
        }

        public List<CarType> GetAll()
        {
            return _carTypeDal.GetAll();
        }

        public void Update(CarType carType)
        {
            _carTypeDal.Update(carType);
        }

        public CarType GetByName(string carTypeName)
        {
            return _carTypeDal.Get(c => c.Name == carTypeName);
        }
    }
}
