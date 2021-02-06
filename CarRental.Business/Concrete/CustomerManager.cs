using CarRental.Business.Abstract;
using CarRental.DataAccess.Abstract;
using CarRental.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        public void Add(IndividualCustomer customer)
        {
            _customerDal.Add(customer);
        }

        public void Delete(IndividualCustomer customer)
        {
            _customerDal.Delete(customer);
        }

        public List<IndividualCustomer> GetAll()
        {
            return _customerDal.GetAll();
        }

        public IndividualCustomer GetById(int customerId)
        {
            return _customerDal.Get(c => c.Id == customerId);
        }

        public void Update(IndividualCustomer customer)
        {
            _customerDal.Update(customer);
        }
    }
}
