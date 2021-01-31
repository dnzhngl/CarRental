using CarRental.Business.Abstract;
using CarRental.DataAccess.Abstract;
using CarRental.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Concrete
{
    public class VehicleManager : IVehicleService
    {
        private readonly IVehicleDal _vehicleDal;
        public VehicleManager(IVehicleDal vehicleDal)
        {
            _vehicleDal = vehicleDal;
        }

        public void Add(Vehicle vehicle)
        {
            _vehicleDal.Add(vehicle);
        }

        public void Delete(Vehicle vehicle)
        {
            _vehicleDal.Delete(vehicle);
        }

        public Vehicle GetById(int vehicleId)
        {
            return _vehicleDal.GetById(vehicleId);
        }

        public List<Vehicle> GetAll()
        {
            return _vehicleDal.GetAll();
        }

        public void Update(Vehicle vehicle)
        {
            _vehicleDal.Update(vehicle);
        }

        public List<Vehicle> GetAllByVehicleType(int vehicleTypeId)
        {
            return _vehicleDal.GetAllByVehicleType(vehicleTypeId);
        }

        public List<Vehicle> GetAllByBrand(int brandId)
        {
            return _vehicleDal.GetAllByBrand(brandId);
        }
    }
}
