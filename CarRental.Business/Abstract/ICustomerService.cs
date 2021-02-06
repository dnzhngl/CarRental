using CarRental.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Abstract
{
    public interface ICustomerService
    {
        List<IndividualCustomer> GetAll();
        IndividualCustomer GetById(int customerId);
        void Add(IndividualCustomer customer);
        void Delete(IndividualCustomer customer);
        void Update(IndividualCustomer customer);
    }
}
