using CarRental.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Entities.Concrete
{
    public class Customer : User, IEntity
    {
        public int NumberOfRental { get; set; }
        public DateTime JoinDate { get; set; }
    }
}
