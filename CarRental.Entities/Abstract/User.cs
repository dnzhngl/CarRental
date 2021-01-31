using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Entities.Abstract
{
    public abstract class User : IEntity
    {
        public int Id { get; set; }
        public string IdentityNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
