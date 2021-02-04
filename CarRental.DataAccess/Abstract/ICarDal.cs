using CarRental.DataAccess.Abstract.EntityRepository;
using CarRental.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
    }
}
