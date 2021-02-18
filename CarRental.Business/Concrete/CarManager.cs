using CarRental.Business.Abstract;
using CarRental.Business.Constants;
using CarRental.Business.ValidationRules.FluentValidation;
using CarRental.Core.Aspects.Autofac.Validation;
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

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            if (car.Model.Length < 2 & car.DailyPrice <= 0)
            {
                return new ErrorResult(Messages.Error());
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.Car.Add(car.Model, car.ModelYear));
        }

        public IResult Delete(Car car)
        {
            var result = _carDal.Get(c => c.Id == car.Id);
            if (result != null)
            {
                _carDal.Delete(car);
                return new SuccessResult(Messages.Car.Delete(result.Model, result.ModelYear));
            }
            return new ErrorResult(Messages.Error());
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
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            var result = _carDal.Get(c => c.Id == car.Id);
            if (result != null)
            {
                _carDal.Update(car);
                return new SuccessResult(Messages.Car.Update(result.Model, result.ModelYear));
            }
            return new ErrorResult(Messages.Error());
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

    }
}
