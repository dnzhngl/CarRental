﻿using CarRental.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Entities.Concrete
{
    public class CarType : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
