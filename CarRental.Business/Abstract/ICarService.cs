using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        Car GetById(int CarId);
        string Add(Car Car);
        void Delete(Car Car);
        void Update(Car Car);
        List<Car> GetAllByCarTypeId(int CarTypeId);
        List<Car> GetAllByBrandId(int brandId);
        List<Car> GetAllByColorId(int colorId);
        List<CarDetailDto> GetAllCarsDetails();
        CarDetailDto GetCarDetail(int carId);
    }
}
