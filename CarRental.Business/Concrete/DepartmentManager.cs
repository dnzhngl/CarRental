using CarRental.Business.Abstract;
using CarRental.Business.Constants;
using CarRental.DataAccess.Abstract;
using CarRental.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Concrete
{
    public class DepartmentManager : IDepartmentService
    {
        private readonly IDepartmentDal _departmentDal;
        public DepartmentManager(IDepartmentDal departmentDal)
        {
            _departmentDal = departmentDal;
        }

        public IResult Add(Department department)
        {
            var result = _departmentDal.Any(d => d.Name == department.Name);
            if (!result)
            {
                _departmentDal.Add(department);
                return new SuccessResult(Messages.Department.Add(department.Name));
            }
            return new ErrorResult(Messages.Department.Exists(department.Name));
        }

        public IResult Delete(Department department)
        {
            var result = _departmentDal.Any(d => d.Name == department.Name);
            if (result)
            {
                _departmentDal.Delete(department);
                return new SuccessResult(Messages.Department.Delete(department.Name));
            }
            return new ErrorResult(Messages.NotFound());
        }

        public IDataResult<List<Department>> GetAll()
        {
            var result = _departmentDal.Count();
            if (result > 0)
            {
                return new SuccessDataResult<List<Department>>(_departmentDal.GetAll());
            }
            return new ErrorDataResult<List<Department>>(Messages.NotFound());
        }

        public IDataResult<Department> GetById(int departmentId)
        {
            var result = _departmentDal.Any(d => d.Id == departmentId);
            if (result)
            {
                return new SuccessDataResult<Department>(_departmentDal.Get(d => d.Id == departmentId));
            }
            return new ErrorDataResult<Department>(Messages.NotFound());
        }

        public IDataResult<Department> GetByName(string departmentName)
        {
            var result = _departmentDal.Any(d => d.Name == departmentName);
            if (result)
            {
                return new SuccessDataResult<Department>(_departmentDal.Get(d => d.Name == departmentName));
            }
            return new ErrorDataResult<Department>(Messages.NotFound());
        }

        public IResult Update(Department department)
        {
            var result = _departmentDal.Any(d => d.Name == department.Name);
            if (result)
            {
                _departmentDal.Update(department);
                return new SuccessResult(Messages.Department.Update(department.Name));
            }
            return new ErrorResult(Messages.NotFound());
        }
    }
}
