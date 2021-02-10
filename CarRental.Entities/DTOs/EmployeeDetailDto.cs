using CarRental.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Entities.DTOs
{
    public class EmployeeDetailDto : IDto
    {
        public int Id { get; set; }
        public string IdentityNo { get; set; }
        public string FullName { get; set; }
        public DateTime DOB { get; set; }
        public char Gender { get; set; } 
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime JoinDate { get; set; }

    }
}
