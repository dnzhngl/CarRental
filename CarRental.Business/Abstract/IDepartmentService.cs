using CarRental.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Abstract
{
    public interface IDepartmentService
    {
        List<Department> GetAll();
        Department GetById(int departmentId);
        Department GetByName(string departmentName);
        void Add(Department department);
        void Delete(Department department);
        void Update(Department department);
    }
}
