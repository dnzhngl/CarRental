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
    public class IndividualCustomerManager : IIndividualCustomerService
    {
        private readonly IIndividualCustomerDal _individualCustomerDal;
        public IndividualCustomerManager(IIndividualCustomerDal individualCustomerDal)
        {
            _individualCustomerDal = individualCustomerDal;
        }

        public IResult Add(IndividualCustomer customer)
        {
            var result = _individualCustomerDal.Any(c => c.IdentityNo == customer.IdentityNo);
            if (!result)
            {
                _individualCustomerDal.Add(customer);
                return new SuccessResult(Messages.IndividualCustomer.Add(customer.FirstName, customer.LastName));
            }
            return new ErrorResult(Messages.IndividualCustomer.Exists(customer.FirstName, customer.LastName));
        }

        public IResult Delete(IndividualCustomer customer)
        {
            var result = _individualCustomerDal.Any(c => c.Id == customer.Id);
            if (result)
            {
                _individualCustomerDal.Delete(customer);
                return new SuccessResult(Messages.IndividualCustomer.Delete(customer.FirstName, customer.LastName));
            }
            return new ErrorResult(Messages.NotFound());
        }

        public IDataResult<List<IndividualCustomer>> GetAll()
        {
            var result = _individualCustomerDal.Count();
            if (result > 0)
            {
                return new SuccessDataResult<List<IndividualCustomer>>(_individualCustomerDal.GetAll());
            }
            return new ErrorDataResult<List<IndividualCustomer>>(Messages.NotFound());
        }

        public IDataResult<IndividualCustomer> GetById(int customerId)
        {
            var result = _individualCustomerDal.Get(c => c.Id == customerId);
            if (result != null)
            {
                return new SuccessDataResult<IndividualCustomer>(result);
            }
            return new ErrorDataResult<IndividualCustomer>(Messages.NotFound());
        }

        public IResult Update(IndividualCustomer customer)
        {
            var result = _individualCustomerDal.Any(c => c.IdentityNo == customer.IdentityNo);
            if (result)
            {
                _individualCustomerDal.Update(customer);
                return new SuccessResult(Messages.IndividualCustomer.Update(customer.FirstName, customer.LastName));
            }
            return new ErrorResult(Messages.NotFound());
        }
    }
}
