using CarRental.Business.Abstract;
using CarRental.DataAccess.Abstract;
using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;
        public CarManager(ICarDal CarDal)
        {
            _carDal = CarDal;
        }

        public string Add(Car Car)
        {
            if (Car.Model.Length > 2 & Car.DailyPrice > 0)
            {
                _carDal.Add(Car);
                return $"{Car.Model} model araba sistme başarıyla eklenmiştir.";
            }
            return "Model adı 2 karakterden küçük olamaz. Günlük kiralama fiyatı 0'dan büyük olmalıdır.";
        }

        public void Delete(Car Car)
        {
            _carDal.Delete(Car);
        }

        public Car GetById(int CarId)
        {
            return _carDal.Get(v => v.Id == CarId);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public void Update(Car Car)
        {
            _carDal.Update(Car);
        }

        public List<Car> GetAllByCarTypeId(int CarTypeId)
        {
            return _carDal.GetAll(v => v.CarTypeId == CarTypeId);
        }

        public List<Car> GetAllByBrandId(int brandId)
        {
            return _carDal.GetAll(v => v.BrandId == brandId);
        }

        public List<Car> GetAllByColorId(int colorId)
        {
            return _carDal.GetAll(v => v.ColorId == colorId);
        }

        public List<CarDetailDto> GetAllCarsDetails()
        {
            return _carDal.GetCarsDetails();
        }

        public CarDetailDto GetCarDetail(int carId)
        {
            return _carDal.GetCarDetail(carId);
        }
    }
}
