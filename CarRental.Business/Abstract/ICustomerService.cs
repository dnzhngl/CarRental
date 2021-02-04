using CarRental.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Abstract
{
    public interface ICustomerService
    {
        List<Customer> GetAll();
        Customer GetById(int customerId);
        void Add(Customer customer);
        void Delete(Customer customer);
        void Update(Customer customer);
    }
}
