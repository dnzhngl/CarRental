using CarRental.DataAccess.Abstract;
using CarRental.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CarRental.DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _Cars;
        public InMemoryCarDal()
        {
            _Cars = new List<Car>
            {
                new Car {Id=1, BrandId=1, CarTypeId=2, ColorId=1, Capacity=4, Model="C 180", ModelYear="2000", DailyPrice=100, Description="4 kişilik, mercedes marka, 2000 model, sedan araba"},
                new Car {Id=2, BrandId=2, CarTypeId=1, ColorId=1, Capacity=4, Model="Fiesta", ModelYear="2010", DailyPrice=110, Description="4 kişilik, Ford marka, 2010 model, hatchback araba"},
                new Car {Id=3, BrandId=3, CarTypeId=1, ColorId=1, Capacity=4, Model="Auris", ModelYear="1995", DailyPrice=70, Description="4 kişilik, Toyota marka, 1995 model, hatchback araba"},
                new Car {Id=4, BrandId=4, CarTypeId=2, ColorId=1, Capacity=4, Model="Astra", ModelYear="2012", DailyPrice=90, Description="4 kişilik, Opel marka, 2012 model, sedan araba"}
            };
        }
        public void Add(Car car)
        {
            _Cars.Add(car);
        }

        public void Delete(Car car)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _Cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllByBrand(int brandId)
        {
            return _Cars.Where(v => v.BrandId == brandId).ToList();
        }

        public List<Car> GetAllByCarType(int carTypeId)
        {
            return _Cars.Where(v => v.CarTypeId == carTypeId).ToList();
        }

        public Car GetById(int carId)
        {
            return _Cars.SingleOrDefault(v => v.Id == carId);
        }

        public void Update(Car car)
        {
            var carToUpdate = _Cars.SingleOrDefault(v => v.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.CarTypeId = car.CarTypeId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.Capacity = car.Capacity;
            carToUpdate.Model = car.Model;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
