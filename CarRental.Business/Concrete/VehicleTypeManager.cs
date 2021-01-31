using CarRental.Business.Abstract;
using CarRental.DataAccess.Abstract;
using CarRental.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Concrete
{
    public class VehicleTypeManager : IVehicleTypeService
    {
        private readonly IVehicleTypeDal _vehicleTypeDal;
        public VehicleTypeManager(IVehicleTypeDal vehicleTypeDal)
        {
            _vehicleTypeDal = vehicleTypeDal;
        }

        public void Add(VehicleType vehicleType)
        {
            _vehicleTypeDal.Add(vehicleType);
        }

        public void Delete(VehicleType vehicleType)
        {
            _vehicleTypeDal.Delete(vehicleType);
        }

        public VehicleType GetById(int vehicleTypeId)
        {
            return _vehicleTypeDal.GetById(vehicleTypeId);
        }

        public List<VehicleType> GetAll()
        {
            return _vehicleTypeDal.GetAll();
        }

        public void Update(VehicleType vehicleType)
        {
            _vehicleTypeDal.Update(vehicleType);
        }
    }
}
