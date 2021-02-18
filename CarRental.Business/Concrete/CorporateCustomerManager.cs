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
    public class CorporateCustomerManager : ICorporateCustomerService
    {
        private readonly ICorporateCustomerDal _corporateCustomerDal;
        public CorporateCustomerManager(ICorporateCustomerDal corporateCustomerDal)
        {
            _corporateCustomerDal = corporateCustomerDal;
        }

        [ValidationAspect(typeof(CorporateCustomerValidator))]
        public IResult Add(CorporateCustomer customer)
        {
            var result = _corporateCustomerDal.Any(c => c.CompanyName == customer.CompanyName);
            if (!result)
            {
                _corporateCustomerDal.Add(customer);
                return new SuccessResult(Messages.CorporateCustomer.Add(customer.CompanyName));
            }
            return new ErrorResult(Messages.CorporateCustomer.Exists(customer.CompanyName));
        }

        public IResult Delete(CorporateCustomer customer)
        {
            var result = _corporateCustomerDal.Any(c => c.Id == customer.Id);
            if (result)
            {
                _corporateCustomerDal.Delete(customer);
                return new SuccessResult(Messages.CorporateCustomer.Delete(customer.CompanyName));
            }
            return new ErrorResult(Messages.NotFound());
        }

        public IDataResult<List<CorporateCustomer>> GetAll()
        {
            var result = _corporateCustomerDal.Count();
            if (result > 0)
            {
                return new SuccessDataResult<List<CorporateCustomer>>(_corporateCustomerDal.GetAll());
            }
            return new ErrorDataResult<List<CorporateCustomer>>(Messages.NotFound());
        }

        public IDataResult<CorporateCustomer> GetById(int customerId)
        {
            var result = _corporateCustomerDal.Get(c => c.Id == customerId);
            if (result != null)
            {
                return new SuccessDataResult<CorporateCustomer>(result);
            }
            return new ErrorDataResult<CorporateCustomer>(Messages.NotFound());
        }

        [ValidationAspect(typeof(CorporateCustomerValidator))]
        public IResult Update(CorporateCustomer customer)
        {
            var result = _corporateCustomerDal.Any(c => c.CompanyName == customer.CompanyName);
            if (result)
            {
                _corporateCustomerDal.Update(customer);
                return new SuccessResult(Messages.CorporateCustomer.Update(customer.CompanyName));
            }
            return new ErrorResult(Messages.NotFound());
        }
    }
}
