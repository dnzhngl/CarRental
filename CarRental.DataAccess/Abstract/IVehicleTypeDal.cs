using CarRental.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.DataAccess.Abstract
{
    public interface IVehicleTypeDal
    {
        List<VehicleType> GetAll();
        VehicleType GetById(int vehicleTypeId);
        void Add(VehicleType vehicle);
        void Update(VehicleType vehicle);
        void Delete(VehicleType vehicle);
    }
}
