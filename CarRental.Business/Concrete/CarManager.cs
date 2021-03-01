using CarRental.Business.Abstract;
using CarRental.Business.BusinessAspect;
using CarRental.Business.Constants;
using CarRental.Business.ValidationRules.FluentValidation;
using CarRental.Core.Aspects.Autofac.Validation;
using CarRental.Core.Utilities.Business;
using CarRental.DataAccess.Abstract;
using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [SecuredOperation("Car.Add, Admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(CheckIfLicensePlateIsExists(car.LicensePlate));
            if (result != null)
            {
                return result;
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.Car.Add(car.Model, car.ModelYear));
        }

        [SecuredOperation("Car.Delete, Admin")]
        public IResult Delete(Car car)
        {
            IResult result = BusinessRules.Run(CheckIfExists(car.Id));
            if (result != null)
            {
                return new ErrorResult(Messages.Error());
            }
            _carDal.Delete(car);
            return new SuccessResult(Messages.Car.Delete(car.Model, car.ModelYear));
        }

        public IDataResult<Car> GetById(int carId)
        {
            var result = _carDal.Get(c => c.Id == carId);
            if (result != null)
            {
                return new SuccessDataResult<Car>(result);
            }
            return new ErrorDataResult<Car>(Messages.NotFound());
        }

        public IDataResult<List<Car>> GetAll()
        {
            var result = _carDal.Count();
            if (result > 0)
            {
                return new SuccessDataResult<List<Car>>(_carDal.GetAll());
            }
            return new ErrorDataResult<List<Car>>(Messages.NotFound());
        }


        [SecuredOperation("Car.Update, Admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            IResult result = BusinessRules.Run(CheckIfExists(car.Id), CheckIfLicensePlateIsExists(car.LicensePlate));

            if (result != null)
            {
                return result;
            }
            _carDal.Update(car);
            return new SuccessResult(Messages.Car.Update(car.Model, car.ModelYear));
        }

        public IDataResult<List<Car>> GetAllByCarTypeId(int carTypeId)
        {
            var result = _carDal.Any(c => c.CarTypeId == carTypeId);
            if (result)
            {
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(v => v.CarTypeId == carTypeId));
            }
            return new ErrorDataResult<List<Car>>(Messages.NotFound());
        }

        public IDataResult<List<Car>> GetAllByBrandId(int brandId)
        {
            var result = _carDal.Any(c => c.BrandId == brandId);
            if (result)
            {
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(v => v.BrandId == brandId));
            }
            return new ErrorDataResult<List<Car>>(Messages.NotFound());
        }

        public IDataResult<List<Car>> GetAllByColorId(int colorId)
        {
            var result = _carDal.Any(c => c.ColorId == colorId);
            if (result)
            {
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(v => v.ColorId == colorId));
            }
            return new ErrorDataResult<List<Car>>(Messages.NotFound());
        }

        public IDataResult<List<CarDetailDto>> GetAllCarsDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarsDetails());
        }

        public IDataResult<CarDetailDto> GetCarDetail(int carId)
        {
            var result = _carDal.GetCarDetail(carId);
            if (result != null)
            {
                return new SuccessDataResult<CarDetailDto>(result);
            }
            return new ErrorDataResult<CarDetailDto>(Messages.NotFound());
        }

        public IDataResult<List<CarDetailDto>> GetAllCarsDetailByBrandId(int brandId)
        {
            var result = _carDal.Any(c => c.BrandId == brandId);
            if (result)
            {
                return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllCarsDetailByBrandId(brandId));
            }
            return new ErrorDataResult<List<CarDetailDto>>(Messages.NotFound());
        }


        // Business code blocks
        private IResult CheckIfLicensePlateIsExists(string licensePlate)
        {
            var result = _carDal.Any(c => c.LicensePlate == licensePlate);
            if (result)
            {
                return new ErrorResult(Messages.Car.ExistsPlateNumber(licensePlate));
            }
            return new SuccessResult();
        }

        private IResult CheckIfExists(int id)
        {
            var result = _carDal.Any(c => c.Id == id);
            if (result)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.NotFound());
        }
    }
}
