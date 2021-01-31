using CarRental.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.DataAccess.Abstract
{
    public interface IVehicleDal
    {
        List<Vehicle> GetAll();
        Vehicle GetById(int vehicleId);
        void Add(Vehicle vehicle);
        void Update(Vehicle vehicle);
        void Delete(Vehicle vehicle);

        List<Vehicle> GetAllByVehicleType(int vehicleTypeId);
        List<Vehicle> GetAllByBrand(int brandId);
    }
}
