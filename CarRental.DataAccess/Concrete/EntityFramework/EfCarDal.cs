using CarRental.Core.DataAccess.EntityFramework;
using CarRental.DataAccess.Abstract;
using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CarRental.DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public CarDetailDto GetCarDetail(int carId)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Cars
                             join ct in context.CarTypes on c.CarTypeId equals ct.Id
                             join b in context.Brands on c.BrandId equals b.Id
                             join cl in context.Colors on c.ColorId equals cl.Id
                             where c.Id == carId
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 Brand = b.Name,
                                 Color = cl.Name,
                                 CarType = ct.Name,
                                 Model = c.Model,
                                 ModelYear = c.ModelYear,
                                 Capacity = c.Capacity,
                                 DailyPrice = c.DailyPrice,
                                 QuantityInStock = c.QuantityInStock,
                                 Description = c.Description
                             };
                return result.FirstOrDefault();
            }
        }

        public List<CarDetailDto> GetCarsDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Cars
                             join ct in context.CarTypes on c.CarTypeId equals ct.Id
                             join b in context.Brands on c.BrandId equals b.Id
                             join cl in context.Colors on c.ColorId equals cl.Id
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 Brand = b.Name,
                                 Color = cl.Name,
                                 CarType = ct.Name,
                                 Model = c.Model,
                                 ModelYear = c.ModelYear,
                                 Capacity = c.Capacity,
                                 DailyPrice = c.DailyPrice,
                                 QuantityInStock = c.QuantityInStock,
                                 Description = c.Description
                             };
                return result.ToList();
            }
        }
    }
}
