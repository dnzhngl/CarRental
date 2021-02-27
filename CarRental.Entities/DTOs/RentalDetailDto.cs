using CarRental.Core.Entities;
using CarRental.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Entities.DTOs
{
    public class RentalDetailDto : IDto
    {
        public int RentalId { get; set; }

        public string CustomerFullName { get; set; }

        //public int EmployeeId { get; set; }
        //public string EmployeeFirstName { get; set; }
        //public string EmployeeLastName { get; set; }
        public string LicensePlate { get; set; }
        public string BrandName { get; set; }
        public string Model { get; set; }

        public DateTime RentDate { get; set; }
        public Nullable<DateTime> ReturnDate { get; set; }
        public Nullable<double> TotalPrice { get; set; }
        public Nullable<float> Discount { get; set; }
    }
}
