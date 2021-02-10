using CarRental.Business.Abstract;
using CarRental.DataAccess.Abstract;
using CarRental.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Concrete
{
    public class RentalAgreementManager : IRentalAgreementService
    {
        private readonly IRentalAgreementDal _rentalAgreementDal;
        public RentalAgreementManager(IRentalAgreementDal rentalAgreementDal)
        {
            _rentalAgreementDal = rentalAgreementDal;
        }
        public void Add(RentalAgreement rentalAgreement)
        {
            _rentalAgreementDal.Add(rentalAgreement);
        }

        public void Delete(RentalAgreement rentalAgreement)
        {
            _rentalAgreementDal.Delete(rentalAgreement);
        }

        public List<RentalAgreement> GetAll()
        {
            return _rentalAgreementDal.GetAll();
        }

        public RentalAgreement GetById(int rentalAgreementId)
        {
            return _rentalAgreementDal.Get(r => r.Id == rentalAgreementId);
        }

        public void Update(RentalAgreement rentalAgreement)
        {
            _rentalAgreementDal.Update(rentalAgreement);
        }
    }
}
