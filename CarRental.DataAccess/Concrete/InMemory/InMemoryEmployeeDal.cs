using CarRental.DataAccess.Abstract;
using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CarRental.DataAccess.Concrete.InMemory
{
    public class InMemoryEmployeeDal : IEmployeeDal
    {
        List<Employee> _employees;
        public InMemoryEmployeeDal()
        {
            _employees = new List<Employee>
            {
                new Employee{ Id=1, DepartmantId=1, IdentityNo="12345678912",FirstName="Gümüş", LastName ="Zengin", Email="patron@carrental.com", PasswordHash="zengin" ,PhoneNumber="0555 555 55 5"},
                new Employee{ Id=1, DepartmantId=2, IdentityNo="12345678912",FirstName="Emek", LastName ="Emekçi", Email="emekci@carrental.com", PasswordHash="emek" ,PhoneNumber="0555 555 55 52"},
            };
        }
        #region Before Generic Repository Implementation
        //public List<Employee> GetAll()
        //{
        //    return _employees;
        //}

        //public List<Employee> GetAllByDepartment(int departmentId)
        //{
        //    return _employees.Where(e => e.DepartmantId == departmentId).ToList();
        //}

        //public Employee GetById(int employeeId)
        //{
        //    return _employees.SingleOrDefault(e => e.Id == employeeId);
        //} 
        #endregion
        public void Add(Employee employee)
        {
            _employees.Add(employee);
        }

        public void Delete(Employee employee)
        {
            var employeeToDelete = _employees.SingleOrDefault(e => e.Id == employee.Id);
            _employees.Remove(employeeToDelete);
        }

        public Employee Get(Expression<Func<Employee, bool>> filter)
        {
            var query = filter.Compile();
            return (Employee)_employees.SingleOrDefault(query.Invoke);
        }

        public List<Employee> GetAll(Expression<Func<Employee, bool>> filter = null)
        {
            if (filter == null)
            {
                return _employees;
            }
            else
            {
                var query = filter.Compile();
                return _employees.Where(query.Invoke).ToList();
            }
        }

        public EmployeeDetailDto GetEmployeeDetail(int employeeId)
        {
            throw new NotImplementedException();
        }

        public void Update(Employee employee)
        {
            var employeeToUpdate = _employees.SingleOrDefault(e => e.Id == employee.Id);
            employeeToUpdate.IdentityNo = employee.IdentityNo;
            employeeToUpdate.FirstName = employee.FirstName;
            employeeToUpdate.LastName = employee.LastName;
            employeeToUpdate.Email = employee.Email;
            employeeToUpdate.PasswordHash = employee.PasswordHash;
            employeeToUpdate.PhoneNumber = employee.PhoneNumber;
            employeeToUpdate.DepartmantId = employee.DepartmantId;
        }
    }
}
