using CarRental.Business.Abstract;
using CarRental.DataAccess.Abstract;
using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        private readonly IEmployeeDal _employeeDal;
        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }

        public void Add(Employee employee)
        {
            _employeeDal.Add(employee);
        }

        public void Delete(Employee employee)
        {
            _employeeDal.Delete(employee);
        }

        public List<Employee> GetAll()
        {
            return _employeeDal.GetAll();
        }

        public Employee GetById(int employeeId)
        {
            return _employeeDal.Get(e => e.Id == employeeId);
        }

        public EmployeeDetailDto GetEmployeeDetail(int employeeId)
        {
            return _employeeDal.GetEmployeeDetail(employeeId);
        }

        public void Update(Employee employee)
        {
            _employeeDal.Update(employee);
        }
    }
}
