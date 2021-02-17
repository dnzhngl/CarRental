using CarRental.Business.Abstract;
using CarRental.Business.Constants;
using CarRental.DataAccess.Abstract;
using CarRental.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Concrete
{
    public class RentalCarManager : IRentalCarService
    {
        private readonly IRentalCarDal _rentalCarDal;
        public RentalCarManager(IRentalCarDal rentalCarDal)
        {
            _rentalCarDal = rentalCarDal;
        }
        //public IResult Add(Entities.Concrete.RentedCar rentalCar)
        //{
        //    var result = _rentalCarDal.Any(r => r.CarId == rentalCar.CarId && r.Rental.ReturnDate == null);
        //    if (result)
        //    {
        //        return new ErrorResult(Messages.RentalCar.Exists(rentalCar.Car.Model, rentalCar.Car.ModelYear));
        //    }
        //    _rentalCarDal.Add(rentalCar);
        //    return new SuccessResult(Messages.RentalCar.Add());
        //}

        //public IResult Delete(Entities.Concrete.RentedCar rentalCar)
        //{
        //    var result = _rentalCarDal.Any(r => r.RentalId == rentalCar.RentalId && r.CarId == rentalCar.CarId);
        //    if (result)
        //    {
        //        _rentalCarDal.Delete(rentalCar);
        //        return new SuccessResult(Messages.RentalCar.Delete());
        //    }
        //    return new ErrorResult(Messages.NotFound());

        //}

        //public IDataResult<List<Entities.Concrete.RentedCar>> GetAll()
        //{
        //    var result = _rentalCarDal.Count();
        //    if (result > 0)
        //    {
        //        return new SuccessDataResult<List<Entities.Concrete.RentedCar>>(_rentalCarDal.GetAll());
        //    }
        //    return new ErrorDataResult<List<Entities.Concrete.RentedCar>>(Messages.NotFound());
        //}

        //public IDataResult<List<Entities.Concrete.RentedCar>> GetAllByRentalId(int rentalId)
        //{
        //    var result = _rentalCarDal.Any(r => r.RentalId == rentalId);
        //    if (result)
        //    {
        //        return new SuccessDataResult<List<Entities.Concrete.RentedCar>>(_rentalCarDal.GetAll(r => r.RentalId == rentalId));
        //    }
        //    return new ErrorDataResult<List<Entities.Concrete.RentedCar>>(Messages.NotFound());
        //}
        //public IDataResult<List<Entities.Concrete.RentedCar>> GetAllByCarId(int carId)
        //{
        //    var result = _rentalCarDal.Any(r => r.CarId == carId);
        //    if (result)
        //    {
        //        return new SuccessDataResult<List<Entities.Concrete.RentedCar>>(_rentalCarDal.GetAll(r => r.CarId == carId));
        //    }
        //    return new ErrorDataResult<List<Entities.Concrete.RentedCar>>(Messages.NotFound());
        //}
        //public IResult Update(Entities.Concrete.RentedCar rentalCar)
        //{
        //    var result = _rentalCarDal.Get(r => r.CarId == rentalCar.CarId && r.RentalId == rentalCar.RentalId);
        //    if (result != null)
        //    {
        //        _rentalCarDal.Update(rentalCar);
        //        return new SuccessResult(Messages.RentalCar.Update());
        //    }
        //    return new ErrorResult(Messages.NotFound());

        //}
    }
}
