using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetById(int rentalId);
        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IResult Update(Rental rental);

        IDataResult<RentalDetailDto> GetRentalDetails(int rentalId);
        IDataResult<List<RentalDetailDto>> GetAllRentalsDetails();
        IDataResult<List<RentalDetailDto>> GetAllNotReturnedRentalsDetails();
    }
}
