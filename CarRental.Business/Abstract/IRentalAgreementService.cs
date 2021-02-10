using CarRental.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Abstract
{
    public interface IRentalAgreementService
    {
        List<RentalAgreement> GetAll();
        RentalAgreement GetById(int rentalAgreementId);
        void Add(RentalAgreement rentalAgreement);
        void Delete(RentalAgreement rentalAgreement);
        void Update(RentalAgreement rentalAgreement);
    }
}
