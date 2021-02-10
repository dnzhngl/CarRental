using CarRental.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Entities.Concrete
{
    public class IndividualCustomer : Customer, IEntity
    {
        public string IdentityNo { get ; set ; }
        public string FirstName { get ; set ; }
        public string LastName { get ; set ; }
        public DateTime DOB { get ; set ; }
    }
}
