using CarRental.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Entities.Concrete
{
    public class Vehicle : IEntity
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int VehicleTypeId { get; set; }
        public int ColorId { get; set; }

        public int Capacity { get; set; }
        public string ModelYear { get; set; }
        public double DailyPrice { get; set; }
        public string Description { get; set; }
        public int NumberOfCarsAvailable { get; set; }
    }
}
