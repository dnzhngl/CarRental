using CarRental.Business.Abstract;
using CarRental.Business.Constants;
using CarRental.Business.ValidationRules.FluentValidation;
using CarRental.Core.Aspects.Autofac.Validation;
using CarRental.Core.CrossCuttingConcerns.Validation.FluentValidation;
using CarRental.DataAccess.Abstract;
using CarRental.Entities.Concrete;
using Core.Utilities.Results;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            var result = _brandDal.Any(b => b.Name == brand.Name);
            if (!result)
            {
                _brandDal.Add(brand);
                return new SuccessResult(Messages.Brand.Add(brand.Name));
            }
            return new ErrorResult(Messages.Brand.Exists(brand.Name));
        }

        public IResult Delete(Brand brand)
        {
            var result = _brandDal.Get(b => b.Id == brand.Id);
            if (result != null)
            {
                _brandDal.Delete(brand);
                return new SuccessResult(Messages.Brand.Delete(result.Name));
            }
            return new ErrorResult(Messages.Error());
        }

        public IDataResult<Brand> GetById(int brandId)
        {
            var result = _brandDal.Any(b => b.Id == brandId);
            if (result)
            {
                return new SuccessDataResult<Brand>(_brandDal.Get(b => b.Id == brandId));
            }
            return new ErrorDataResult<Brand>(Messages.NotFound());
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(Brand brand)
        {
            var result = _brandDal.Get(b => b.Id == brand.Id);
            if (result != null)
            {
                _brandDal.Update(brand);
                return new SuccessResult(Messages.Brand.Update(brand.Name));
            }
            return new ErrorResult(Messages.NotFound());
        }

        public IDataResult<Brand> GetByName(string brandName)
        {
            var result = _brandDal.Any(b => b.Name == brandName);
            if (result)
            {
                return new SuccessDataResult<Brand>(_brandDal.Get(b => b.Name == brandName));
            }
            return new ErrorDataResult<Brand>(Messages.NotFound());
        }
    }
}
