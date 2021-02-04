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
        private readonly ICarTypeDal _CarTypeDal;
        public CarTypeManager(ICarTypeDal CarTypeDal)
        {
            _CarTypeDal = CarTypeDal;
        }

        public void Add(CarType CarType)
        {
            _CarTypeDal.Add(CarType);
        }

        public void Delete(CarType CarType)
        {
            _CarTypeDal.Delete(CarType);
        }

        public CarType GetById(int CarTypeId)
        {
            return _CarTypeDal.Get(vt => vt.Id == CarTypeId);
        }

        public List<CarType> GetAll()
        {
            return _CarTypeDal.GetAll();
        }

        public void Update(CarType CarType)
        {
            _CarTypeDal.Update(CarType);
        }
    }
}
