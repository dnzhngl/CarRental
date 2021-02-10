using CarRental.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Entities.Concrete
{
    public class RentalAgreement_Car
    {
        public int RentalAgreementId { get; set; }
        public RentalAgreement RentalAgreement { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int Quantity { get; set; }
    }
}
