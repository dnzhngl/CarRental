using CarRental.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CarRental.Business.ValidationRules.FluentValidation
{
    public class CorporateCustomerValidator : AbstractValidator<CorporateCustomer>
    {
        public CorporateCustomerValidator()
        {
            RuleFor(c => c.CompanyName).NotEmpty().Length(2,50).Must(ValidName);
            RuleFor(c => c.TaxNumber).NotEmpty().Length(10);
            RuleFor(c => c.Address).NotEmpty().Length(5, 150);
            RuleFor(c => c.PhoneNumber).NotEmpty().Length(9, 20);
            RuleFor(c => c.Email).NotEmpty().Length(11, 30);
            RuleFor(c => c.PasswordHash).NotEmpty().Length(5, 10);
            RuleFor(c => c.JoinDate).NotEmpty().LessThanOrEqualTo(DateTime.Now);
        }

        public static bool ValidName(string name)
        {
            var regexItem = new Regex("^[a-zA-Z0-9 ÇçĞğİıÖöŞşÜü]*$");

            if (regexItem.IsMatch(name))
            {
                return true;
            }
            return false;
        }
    }
}
