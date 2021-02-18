using CarRental.Business.Abstract;
using CarRental.Business.Constants;
using CarRental.Business.ValidationRules.FluentValidation;
using CarRental.Core.Aspects.Autofac.Validation;
using CarRental.DataAccess.Abstract;
using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs;
using Core.Utilities.Results;
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

        [ValidationAspect(typeof(EmployeeValidator))]
        public IResult Add(Employee employee)
        {
            var result = _employeeDal.Any(e => e.IdentityNo == employee.IdentityNo);
            if (!result)
            {
                _employeeDal.Add(employee);
                return new SuccessResult(Messages.Employee.Add(employee.FirstName, employee.LastName));
            }
            return new ErrorResult(Messages.Employee.Exists(employee.FirstName, employee.LastName, employee.IdentityNo));
        }

        public IResult Delete(Employee employee)
        {
            var result = _employeeDal.Any(e => e.IdentityNo == employee.IdentityNo);
            if (result)
            {
                _employeeDal.Delete(employee);
                return new SuccessResult(Messages.Employee.Delete(employee.FirstName, employee.LastName));
            }
            return new ErrorResult(Messages.NotFound());
        }

        public IDataResult<List<Employee>> GetAll()
        {
            var result = _employeeDal.Count();
            if (result > 0)
            {
                return new SuccessDataResult<List<Employee>>(_employeeDal.GetAll());
            }
            return new ErrorDataResult<List<Employee>>(Messages.NotFound());
        }

        public IDataResult<Employee> GetById(int employeeId)
        {
            var result = _employeeDal.Get(e => e.Id == employeeId);
            if (result != null)
            {
                return new SuccessDataResult<Employee>(_employeeDal.Get(e => e.Id == employeeId));
            }
            return new ErrorDataResult<Employee>(Messages.NotFound());
        }

        public IDataResult<EmployeeDetailDto> GetEmployeeDetail(int employeeId)
        {
            var result = _employeeDal.Any(e => e.Id == employeeId);
            if (result)
            {
                return new SuccessDataResult<EmployeeDetailDto>(_employeeDal.GetEmployeeDetail(employeeId));
            }
            return new ErrorDataResult<EmployeeDetailDto>(Messages.NotFound());
        }
        
        [ValidationAspect(typeof(EmployeeValidator))]
        public IResult Update(Employee employee)
        {
            var result = _employeeDal.Any(e => e.IdentityNo == employee.IdentityNo);
            if (result)
            {
                _employeeDal.Update(employee);
                return new SuccessResult(Messages.Employee.Update(employee.FirstName, employee.LastName));
            }
            return new ErrorResult(Messages.NotFound());
        }
    }
}
