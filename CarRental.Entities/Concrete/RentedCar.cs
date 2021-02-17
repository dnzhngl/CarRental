using CarRental.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Entities.Concrete
{
    public class RentedCar : IEntity
    {
        //public int RentalId { get; set; }
        //public int CarId { get; set; }
        public Rental Rental { get; set; }
        public Car Car { get; set; }

    }
}
