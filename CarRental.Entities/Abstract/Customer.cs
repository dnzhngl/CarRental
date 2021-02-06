using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Entities.Abstract
{
    public class Customer : IEntity, IUser
    {
        public int Id { get ; set ; }
        public DateTime JoinDate { get ; set ; }

        public int CustomerNo { get; set; }

    }
}
