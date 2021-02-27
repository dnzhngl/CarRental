using CarRental.Core.DataAccess;
using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.DataAccess.Abstract
{
    public interface IRentalDal : IEntityRepository<Rental>
    {
        List<RentalDetailDto> GetAllRentalsDetails();
        RentalDetailDto GetRentalDetails(int rentalId);
        List<RentalDetailDto> GetAllNotReturnedRentalsDetails();
    }
}
