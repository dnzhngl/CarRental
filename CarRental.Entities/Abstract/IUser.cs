using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Entities.Abstract
{
    public interface IUser
    {
        public int Id { get; set; }
        public DateTime JoinDate { get; set; }
    }
}
