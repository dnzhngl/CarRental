using CarRental.Business.Abstract;
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
    public class CarImageManager : ICarImageService
    {
        private readonly ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfImageLimitExceeded(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImage.Add(isPlural: false));
        }

        public IResult Delete(CarImage carImage)
        {
            var result = _carImageDal.Any(c => c.Id == carImage.Id);
            if (result)
            {
                _carImageDal.Delete(carImage);
                return new SuccessResult(Messages.CarImage.Delete(isPlural: false));
            }
            return new ErrorResult(Messages.NotFound());
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            var result = _carImageDal.Any(c => c.CarId == carId);
            if (result)
            {
                return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
            }
            return new ErrorDataResult<List<CarImage>>(Messages.NotFound());
        }

        public IDataResult<CarImage> GetById(int id)
        {
            var result = _carImageDal.Any(c => c.Id == id);
            if (result)
            {
                return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == id));
            }
            return new ErrorDataResult<CarImage>(Messages.NotFound());
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfImageLimitExceeded(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImage.Update(isPlural: false));
        }


        // Business code blocks
        private IResult CheckIfImageLimitExceeded(int carId)
        {
            var numberOfImages = _carImageDal.Count(c => c.CarId == carId);
            if (numberOfImages >= 5)
            {
                return new ErrorResult(Messages.CarImage.NumberOfPhotografsHasReachedLimit(5));
            }
            return new SuccessResult();
        }

    }
}
