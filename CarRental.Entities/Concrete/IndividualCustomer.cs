using CarRental.Entities.Abstract;
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
        public string PhoneNumber { get ; set ; }
        public string Email { get ; set ; }
        public string Password { get ; set ; }
    }
}
