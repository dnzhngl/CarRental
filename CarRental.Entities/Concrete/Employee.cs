using CarRental.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Entities.Concrete
{
    public class Employee : IEntity, IUser
    {
        public int Id { get ; set ; }
        public string IdentityNo { get ; set ; }
        public string FirstName { get ; set ; }
        public string LastName { get ; set ; }
        public DateTime DOB { get ; set ; }
        public string PhoneNumber { get ; set ; }
        public string Email { get ; set ; }
        public string Password { get ; set ; }
        public DateTime JoinDate { get; set; }
        public string Position { get; set; }

        public int DepartmantId { get; set; }
        public Department Department { get; set; }
    }
}
