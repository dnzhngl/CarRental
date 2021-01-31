using CarRental.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Entities.Concrete
{
    public class Employee : User, IEntity
    {
        public int DepartmantId { get; set; }
    }
}
