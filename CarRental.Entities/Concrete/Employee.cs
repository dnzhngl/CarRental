using CarRental.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarRental.Entities.Concrete
{
    [Table("Employees")]
    public class Employee : User, IEntity
    {
        #region Before User Base class implementation
        //public int Id { get ; set ; }
        //public string Email { get; set; }
        //public DateTime JoinDate { get; set; } 
        #endregion
        public string IdentityNo { get ; set ; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get ; set ; }
        public char Gender { get; set; }    //  F : female, M : male
        public string PhoneNumber { get ; set ; }
        public string Address { get; set; }
        public string Position { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
