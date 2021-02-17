using CarRental.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Entities.Concrete
{
    public class Rental : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }

        public DateTime RentDate { get; set; }
        public Nullable<DateTime> ReturnDate { get; set; }
        public Nullable<double> TotalPrice { get; set; }
        public Nullable<float> Discount { get; set; }



        //public ICollection<Car> Cars { get; set; }
        //public ICollection<RentedCar> RentedCars { get; set; }

    }
}
