using CarRental.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.ValidationRules.FluentValidation
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(e => e.IdentityNo).NotEmpty().Length(11);
            RuleFor(e => e.FirstName).NotEmpty().Length(2,30);
            RuleFor(e => e.LastName).NotEmpty().Length(2,30);
            RuleFor(e => e.Gender).NotEmpty();
            RuleFor(e => e.DOB).NotEmpty();
            RuleFor(e => e.Address).NotEmpty().Length(5, 150);
            RuleFor(e => e.PhoneNumber).NotEmpty().Length(10);
            RuleFor(e => e.Email).NotEmpty().Length(11, 30);
            RuleFor(e => e.PasswordHash).NotEmpty().Length(5, 12);
            RuleFor(e => e.JoinDate).NotEmpty();
            RuleFor(e => e.DepartmentId).NotEmpty();
            RuleFor(e => e.Position).NotEmpty();
        }
    }
}
