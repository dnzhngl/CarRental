
using CarRental.DataAccess.Abstract;
using CarRental.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRental.DataAccess.Concrete.InMemory
{
    public class InMemoryVehicleTypeDal : IVehicleTypeDal
    {
        List<VehicleType> _vehicleTypes;
        public InMemoryVehicleTypeDal()
        {
            _vehicleTypes = new List<VehicleType>
            {
                new VehicleType { Id = 1, Name= "Hatchback"},
                new VehicleType { Id = 2, Name= "Sedan"},
                new VehicleType { Id = 3, Name= "SUV"},
                new VehicleType { Id = 4, Name= "Pickup"},
                new VehicleType { Id = 5, Name= "Coupe"},
                new VehicleType { Id = 6, Name= "Minivan"},
                new VehicleType { Id = 6, Name= "Van"},
                new VehicleType { Id = 6, Name= "Mini Truck"},
            };
        }

        public void Add(VehicleType vehicleType)
        {
            _vehicleTypes.Add(vehicleType);
        }

        public void Delete(VehicleType vehicleType)
        {
            var vehicleToDelete = _vehicleTypes.SingleOrDefault(v => v.Id == vehicleType.Id);
            _vehicleTypes.Remove(vehicleToDelete);
        }

        public List<VehicleType> GetAll()
        {
            return _vehicleTypes;
        }

        public VehicleType GetById(int vehicleTypeId)
        {
            return _vehicleTypes.SingleOrDefault(v => v.Id == vehicleTypeId);
        }

        public void Update(VehicleType vehicleType)
        {
            var vehicleToUpdate = _vehicleTypes.SingleOrDefault(v => v.Id == vehicleType.Id);
            vehicleToUpdate.Name = vehicleType.Name;
        }
    }
}
