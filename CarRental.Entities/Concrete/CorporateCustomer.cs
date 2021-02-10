using CarRental.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Entities.Concrete
{
    public class CorporateCustomer : Customer, IEntity
    {
        public string CompanyName { get; set; }
        public string TaxNumber { get; set; }
    }
}
