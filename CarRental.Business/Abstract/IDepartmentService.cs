using CarRental.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Abstract
{
    public interface IDepartmentService
    {
        IDataResult<List<Department>> GetAll();
        IDataResult<Department> GetById(int departmentId);
        IDataResult<Department> GetByName(string departmentName);
        IResult Add(Department department);
        IResult Delete(Department department);
        IResult Update(Department department);
    }
}
