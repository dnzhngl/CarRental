using CarRental.Core.Entities;
using CarRental.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarRental.Entities.Concrete
{
    [Table("Customers")]
    public class Customer : User, IEntity
    {
        #region Before User base class implementation
        //public int Id { get ; set ; }
        //public string Email { get; set; }
        //public string Password { get; set; }
        //public DateTime JoinDate { get ; set ; } 
        #endregion
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
