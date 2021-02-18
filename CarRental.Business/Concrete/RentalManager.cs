using CarRental.Business.Abstract;
using CarRental.Business.Constants;
using CarRental.Business.ValidationRules.FluentValidation;
using CarRental.Core.Aspects.Autofac.Validation;
using CarRental.DataAccess.Abstract;
using CarRental.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private readonly IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var result = _rentalDal.Any(r => r.CarId == rental.CarId && r.ReturnDate == null);
            if (!result)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.Rental.Add());
            }
            return new ErrorResult(Messages.Error());
        }

        public IResult Delete(Rental rental)
        {
            var result = _rentalDal.Get(a => a.Id == rental.Id);
            if (result != null)
            {
                _rentalDal.Delete(rental);
                return new SuccessResult(Messages.Rental.Delete());
            }
            return new ErrorResult(Messages.NotFound());
        }

        public IDataResult<List<Rental>> GetAll()
        {
            var result = _rentalDal.Count();
            if (result > 0)
            {
                return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
            }
            return new ErrorDataResult<List<Rental>>(Messages.NotFound());
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            var result = _rentalDal.Get(a => a.Id == rentalId);
            if (result != null)
            {
                return new SuccessDataResult<Rental>(result);
            }
            return new ErrorDataResult<Rental>(Messages.NotFound());
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            var result = _rentalDal.Get(a => a.Id == rental.Id);
            if (result != null)
            {
                _rentalDal.Update(rental);
                return new SuccessResult(Messages.Rental.Update());
            }
            return new ErrorResult(Messages.NotFound());
        }
    }
}
