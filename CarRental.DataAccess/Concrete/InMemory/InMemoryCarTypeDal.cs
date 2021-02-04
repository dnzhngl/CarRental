
using CarRental.DataAccess.Abstract;
using CarRental.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CarRental.DataAccess.Concrete.InMemory
{
    public class InMemoryCarTypeDal : ICarTypeDal
    {
        List<CarType> _CarTypes;
        public InMemoryCarTypeDal()
        {
            _CarTypes = new List<CarType>
            {
                new CarType { Id = 1, Name= "Hatchback"},
                new CarType { Id = 2, Name= "Sedan"},
                new CarType { Id = 3, Name= "SUV"},
                new CarType { Id = 4, Name= "Pickup"},
                new CarType { Id = 5, Name= "Coupe"},
                new CarType { Id = 6, Name= "Minivan"},
                new CarType { Id = 6, Name= "Van"},
                new CarType { Id = 6, Name= "Mini Truck"},
            };
        }

        public void Add(CarType CarType)
        {
            _CarTypes.Add(CarType);
        }

        public void Delete(CarType CarType)
        {
            var CarToDelete = _CarTypes.SingleOrDefault(v => v.Id == CarType.Id);
            _CarTypes.Remove(CarToDelete);
        }

        public CarType Get(Expression<Func<CarType, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarType> GetAll()
        {
            return _CarTypes;
        }

        public List<CarType> GetAll(Expression<Func<CarType, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public CarType GetById(int CarTypeId)
        {
            return _CarTypes.SingleOrDefault(v => v.Id == CarTypeId);
        }

        public void Update(CarType CarType)
        {
            var CarToUpdate = _CarTypes.SingleOrDefault(v => v.Id == CarType.Id);
            CarToUpdate.Name = CarType.Name;
        }
    }
}
