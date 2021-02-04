using CarRental.Business.Abstract;
using CarRental.DataAccess.Abstract;
using CarRental.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _CarDal;
        public CarManager(ICarDal CarDal)
        {
            _CarDal = CarDal;
        }

        public string Add(Car Car)
        {
            if (Car.Model.Length > 2 & Car.DailyPrice > 0)
            {
                _CarDal.Add(Car);
                return $"{Car.Model} model araba sistme başarıyla eklenmiştir.";
            }
            return "Model adı 2 karakterden küçük olamaz. Günlük kiralama fiyatı 0'dan büyük olmalıdır.";
        }

        public void Delete(Car Car)
        {
            _CarDal.Delete(Car);
        }

        public Car GetById(int CarId)
        {
            return _CarDal.Get(v => v.Id == CarId);
        }

        public List<Car> GetAll()
        {
            return _CarDal.GetAll();
        }

        public void Update(Car Car)
        {
            _CarDal.Update(Car);
        }

        public List<Car> GetAllByCarTypeId(int CarTypeId)
        {
            return _CarDal.GetAll(v => v.CarTypeId == CarTypeId);
        }

        public List<Car> GetAllByBrandId(int brandId)
        {
            return _CarDal.GetAll(v => v.BrandId == brandId);
        }

        public List<Car> GetAllByColorId(int colorId)
        {
            return _CarDal.GetAll(v => v.ColorId == colorId);
        }
    }
}
