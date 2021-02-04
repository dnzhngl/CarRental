﻿using CarRental.DataAccess.Abstract;
using CarRental.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CarRental.DataAccess.Concrete.InMemory
{
    public class InMemoryRentalAgreementDal : IRentalAgreementDal
    {
        List<RentalAgreement> _rentalAgreements;
        public InMemoryRentalAgreementDal()
        {
            _rentalAgreements = new List<RentalAgreement>();
        }

        public void Add(RentalAgreement rentalAgreement)
        {
            _rentalAgreements.Add(rentalAgreement);
        }

        public void Delete(RentalAgreement rentalAgreement)
        {
            var agreementToDelete = _rentalAgreements.SingleOrDefault(a => a.Id == rentalAgreement.Id);
            _rentalAgreements.Remove(agreementToDelete);
        }

        public RentalAgreement Get(Expression<Func<RentalAgreement, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<RentalAgreement> GetAll()
        {
            return _rentalAgreements;
        }

        public List<RentalAgreement> GetAll(Expression<Func<RentalAgreement, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<RentalAgreement> GetAllByCustomer(int customerId)
        {
            return _rentalAgreements.Where(a => a.CustomerId == customerId).ToList();
        }

        public List<RentalAgreement> GetAllByEmployee(int employeeId)
        {
            return _rentalAgreements.Where(a => a.EmployeeId == employeeId).ToList();
        }

        public RentalAgreement GetById(int rentalAgreementId)
        {
            return _rentalAgreements.SingleOrDefault(a => a.Id == rentalAgreementId);
        }

        public void Update(RentalAgreement rentalAgreement)
        {
            var agreementToUpdate = _rentalAgreements.SingleOrDefault(a => a.Id == rentalAgreement.Id);
            agreementToUpdate.CustomerId = rentalAgreement.CustomerId;
            agreementToUpdate.EmployeeId = rentalAgreement.EmployeeId;
            agreementToUpdate.CarId = rentalAgreement.CarId;
            agreementToUpdate.StartDate = rentalAgreement.StartDate;
            agreementToUpdate.EndDate = rentalAgreement.EndDate;
            agreementToUpdate.TotalPrice = rentalAgreement.TotalPrice;
            agreementToUpdate.Discount = rentalAgreement.Discount;
        }
    }
}
