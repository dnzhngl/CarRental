using CarRental.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.ValidationRules.FluentValidation
{
    public class IndividualCustomerValidator : AbstractValidator<IndividualCustomer>
    {
        public IndividualCustomerValidator()
        {
            RuleFor(i => i.IdentityNo).NotEmpty().Length(11);
            RuleFor(i => i.FirstName).NotEmpty().MinimumLength(3);
            RuleFor(i => i.LastName).NotEmpty().MinimumLength(3);
            RuleFor(i => i.DOB).NotEmpty();
            RuleFor(i => i.Address).NotEmpty().Length(5, 150);
            RuleFor(i => i.PhoneNumber).NotEmpty().Length(10);
            RuleFor(i => i.Email).NotEmpty().Length(11, 30);
            RuleFor(i => i.PasswordHash).NotEmpty().Length(5, 12);
            RuleFor(i => i.JoinDate).NotEmpty();
        }
    }
}
