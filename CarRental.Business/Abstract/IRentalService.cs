﻿using CarRental.Entities.Concrete;
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
        IDataResult<Rental> GetByIdInclude(int rentalId);
        IResult Add(Rental rental);
        IResult AddWithChild(Rental rental);
        IResult Delete(Rental rental);
        IResult Update(Rental rental);
    }
}
