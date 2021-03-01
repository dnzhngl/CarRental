using CarRental.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CarRental.Business.ValidationRules.FluentValidation
{
    public class IndividualCustomerValidator : AbstractValidator<IndividualCustomer>
    {
        public IndividualCustomerValidator()
        {
            RuleFor(i => i.IdentityNo).NotEmpty().Length(11);
            RuleFor(i => i.FirstName).NotEmpty().Length(2, 30).Must(ValidName);
            RuleFor(i => i.LastName).NotEmpty().Length(2, 30).Must(ValidName);
            RuleFor(i => i.DOB).NotEmpty().Must(BeAValidAge);
            RuleFor(i => i.Address).NotEmpty().Length(5, 150);
            RuleFor(i => i.PhoneNumber).NotEmpty().Length(10);
            RuleFor(i => i.Email).NotEmpty().Length(11, 30);
            RuleFor(i => i.PasswordHash).NotEmpty();
            RuleFor(i => i.JoinDate).NotEmpty().LessThanOrEqualTo(DateTime.Now);
        }

        private bool BeAValidAge(DateTime date)
        {
            int currentYear = DateTime.Now.Year;
            int dobYear = date.Year;
            if (dobYear < (currentYear -18) && dobYear > (currentYear - 80))
            {
                return true;
            }
            return false;
        }

        public bool ValidName(string name)
        {
            var regexItem = new Regex("^[a-zA-Z ÇçĞğİıÖöŞşÜü]*$");

            if (regexItem.IsMatch(name))
            {
                return true;
            }
            return false;
        }
    }
}
