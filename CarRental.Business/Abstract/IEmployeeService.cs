using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Abstract
{
    public interface IEmployeeService
    {
        IDataResult<List<Employee>> GetAll();
        IDataResult<Employee> GetById(int employeeId);
        IResult Add(Employee employee, string password);
        IResult Delete(Employee employee);
        IResult Update(Employee employee);

        IDataResult<EmployeeDetailDto> GetEmployeeDetail(int employeeId);

    }
}
