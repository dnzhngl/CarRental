using CarRental.Core.DataAccess;
using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.DataAccess.Abstract
{
    public interface IEmployeeDal : IEntityRepository<Employee>
    {
        EmployeeDetailDto GetEmployeeDetail(int employeeId);
    }
}
