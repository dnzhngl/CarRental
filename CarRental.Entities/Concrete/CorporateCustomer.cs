using CarRental.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Entities.Concrete
{
    public class CorporateCustomer : Customer, IEntity
    {
        public string CorporateName { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
    }
}
