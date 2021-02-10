using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Abstract
{
    public interface IEmployeeService
    {
        List<Employee> GetAll();
        Employee GetById(int employeeId);
        void Add(Employee employee);
        void Delete(Employee employee);
        void Update(Employee employee);

        EmployeeDetailDto GetEmployeeDetail(int employeeId);

    }
}
