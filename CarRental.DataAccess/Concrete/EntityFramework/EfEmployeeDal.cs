using CarRental.Core.DataAccess.EntityFramework;
using CarRental.DataAccess.Abstract;
using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRental.DataAccess.Concrete.EntityFramework
{
    public class EfEmployeeDal : EfEntityRepositoryBase<Employee, CarRentalContext>, IEmployeeDal
    {
        public EmployeeDetailDto GetEmployeeDetail(int employeeId)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from e in context.Employees
                             join d in context.Departments on e.DepartmantId equals d.Id
                             join u in context.Users on e.Id equals u.Id
                             where e.Id == employeeId
                             select new EmployeeDetailDto
                             {
                                 Id = e.Id,
                                 IdentityNo = e.IdentityNo,
                                 FullName = $"{e.FirstName} {e.LastName}",
                                 DOB = e.DOB,
                                 Gender = e.Gender,
                                 PhoneNumber = e.PhoneNumber,
                                 Address = e.Address,
                                 Email = u.Email,
                                 PasswordHash = u.PasswordHash,
                                 Department = d.Name,
                                 JoinDate = u.JoinDate,
                                 Position = e.Position
                             };
                return result.FirstOrDefault();
            }
        }
    }
}
