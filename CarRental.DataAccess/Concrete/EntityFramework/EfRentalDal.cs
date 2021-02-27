using CarRental.Core.DataAccess.EntityFramework;
using CarRental.DataAccess.Abstract;
using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRental.DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalContext>, IRentalDal
    {
        public List<RentalDetailDto> GetAllRentalsDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from r in context.Rentals
                             join car in context.Cars on r.CarId equals car.Id
                             join customer in context.IndividualCustomers on r.CustomerId equals customer.Id
                             join b in context.Brands on car.BrandId equals b.Id
                             select new RentalDetailDto
                             {
                                 RentalId = r.Id,
                                 CustomerFullName = $"{customer.FirstName} {customer.LastName}",

                                 LicensePlate = car.LicensePlate,
                                 BrandName = b.Name,
                                 Model = car.Model,

                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 Discount = r.Discount,
                                 TotalPrice = r.TotalPrice
                             };
                return result.ToList();

            }
        }

        public RentalDetailDto GetRentalDetails(int rentalId)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from r in context.Rentals
                             join car in context.Cars on r.CarId equals car.Id
                             join customer in context.IndividualCustomers on r.CustomerId equals customer.Id
                             join b in context.Brands on car.BrandId equals b.Id
                             where r.Id == rentalId
                             select new RentalDetailDto
                             {
                                 RentalId = r.Id,
                                 CustomerFullName = $"{customer.FirstName} {customer.LastName}",

                                 LicensePlate = car.LicensePlate,
                                 BrandName = b.Name,
                                 Model = car.Model,

                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 Discount = r.Discount,
                                 TotalPrice = r.TotalPrice
                             };
                return result.SingleOrDefault();
            }
        }

        public List<RentalDetailDto> GetAllNotReturnedRentalsDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from r in context.Rentals
                             join car in context.Cars on r.CarId equals car.Id
                             join customer in context.IndividualCustomers on r.CustomerId equals customer.Id
                             join b in context.Brands on car.BrandId equals b.Id
                             where r.ReturnDate == null
                             select new RentalDetailDto
                             {
                                 RentalId = r.Id,
                                 CustomerFullName = $"{customer.FirstName} {customer.LastName}",

                                 LicensePlate = car.LicensePlate,
                                 BrandName = b.Name,
                                 Model = car.Model,

                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 Discount = r.Discount,
                                 TotalPrice = r.TotalPrice
                             };
                return result.ToList();

            }
        }
    }
}
