using CarRental.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Entities.Concrete
{
    public class Color : IEntity
    {
        public int Id { get; set; }
        public int Name { get; set; }
    }
}