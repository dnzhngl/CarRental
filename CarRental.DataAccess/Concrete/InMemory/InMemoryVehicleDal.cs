using CarRental.DataAccess.Abstract;
using CarRental.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRental.DataAccess.Concrete.InMemory
{
    public class InMemoryVehicleDal : IVehicleDal
    {
        List<Vehicle> _vehicles;
        public InMemoryVehicleDal()
        {
            _vehicles = new List<Vehicle>
            {
                new Vehicle {Id=1, BrandId=1, VehicleTypeId=2, ColorId=1, Capacity=4, ModelYear="2000", DailyPrice=100, Description="4 kişilik, mercedes marka, 2000 model, sedan araba"},
                new Vehicle {Id=2, BrandId=2, VehicleTypeId=1, ColorId=1, Capacity=4, ModelYear="2010", DailyPrice=110, Description="4 kişilik, Ford marka, 2010 model, hatchback araba"},
                new Vehicle {Id=3, BrandId=3, VehicleTypeId=1, ColorId=1, Capacity=4, ModelYear="1995", DailyPrice=70, Description="4 kişilik, Toyota marka, 1995 model, hatchback araba"},
                new Vehicle {Id=4, BrandId=4, VehicleTypeId=2, ColorId=1, Capacity=4, ModelYear="2012", DailyPrice=90, Description="4 kişilik, Opel marka, 2012 model, sedan araba"}
            };
        }
        public void Add(Vehicle vehicle)
        {
            _vehicles.Add(vehicle);
        }

        public void Delete(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetAll()
        {
            return _vehicles;
        }

        public List<Vehicle> GetAllByBrand(int brandId)
        {
            return _vehicles.Where(v => v.BrandId == brandId).ToList();
        }

        public List<Vehicle> GetAllByVehicleType(int vehicleTypeId)
        {
            return _vehicles.Where(v => v.VehicleTypeId == vehicleTypeId).ToList();
        }

        public Vehicle GetById(int vehicleId)
        {
            return _vehicles.SingleOrDefault(v => v.Id == vehicleId);
        }

        public void Update(Vehicle vehicle)
        {
            var vehicleToUpdate = _vehicles.SingleOrDefault(v => v.Id == vehicle.Id);
            vehicleToUpdate.BrandId = vehicle.BrandId;
            vehicleToUpdate.VehicleTypeId = vehicle.VehicleTypeId;
            vehicleToUpdate.ColorId = vehicle.ColorId;
            vehicleToUpdate.Capacity = vehicle.Capacity;
            vehicleToUpdate.ModelYear = vehicle.ModelYear;
            vehicleToUpdate.DailyPrice = vehicle.DailyPrice;
            vehicleToUpdate.Description = vehicle.Description;
        }
    }
}
