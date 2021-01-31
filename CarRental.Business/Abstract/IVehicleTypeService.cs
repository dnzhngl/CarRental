using CarRental.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Abstract
{
    public interface IVehicleTypeService
    {
        List<VehicleType> GetAll();
        VehicleType GetById(int vehicleTypeId);
        void Add(VehicleType vehicleType);
        void Delete(VehicleType vehicleType);
        void Update(VehicleType vehicleType);
    }
}
