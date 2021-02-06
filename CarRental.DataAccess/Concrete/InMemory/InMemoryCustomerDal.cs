﻿using CarRental.DataAccess.Abstract;
using CarRental.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CarRental.DataAccess.Concrete.InMemory
{
    public class InMemoryCustomerDal : ICustomerDal
    {
        List<IndividualCustomer> _customers;
        public InMemoryCustomerDal()
        {
            _customers = new List<IndividualCustomer>
            {
                new IndividualCustomer { Id=1, FirstName="Sevim", LastName="Sevimli", IdentityNo="12345678910" ,Email="sevimSevimli@hotmail.com", Password="sevimli", PhoneNumber="0555 555 55 55", JoinDate= new DateTime(01/01/2020)},
                new IndividualCustomer { Id=2, FirstName="Ateş", LastName="Soba", IdentityNo="12345678911" ,Email="atesSoba@hotmail.com", Password="atesS", PhoneNumber="0555 555 55 54", JoinDate= new DateTime(07/12/2020)}
            };
        }
        public void Add(IndividualCustomer customer)
        {
            _customers.Add(customer);
        }

        public void Delete(IndividualCustomer customer)
        {
            var customerToDelete = _customers.SingleOrDefault(c => c.Id == customer.Id);
            _customers.Remove(customerToDelete);
        }

        public IndividualCustomer Get(Expression<Func<IndividualCustomer, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<IndividualCustomer> GetAll()
        {
            return _customers;
        }

        public List<IndividualCustomer> GetAll(Expression<Func<IndividualCustomer, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public IndividualCustomer GetById(int customerId)
        {
            return _customers.SingleOrDefault(c => c.Id == customerId);
        }

        public void Update(IndividualCustomer customer)
        {
            var customerToUpdate = _customers.SingleOrDefault(c => c.Id == customer.Id);
            customerToUpdate.FirstName = customer.FirstName;
            customerToUpdate.LastName = customer.LastName;
            customerToUpdate.IdentityNo = customer.IdentityNo;
            customerToUpdate.Email = customer.Email;
            customerToUpdate.Password = customer.Password;
            customerToUpdate.PhoneNumber = customer.PhoneNumber;
        }
    }
}
