using CarRental.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.ValidationRules.FluentValidation
{
    public class CarImageValidator : AbstractValidator<CarImage>
    {
        public CarImageValidator()
        {
            RuleFor(c => c.CarId).NotEmpty();
            RuleFor(c => c.ImagePath).NotEmpty().MaximumLength(500);
            RuleFor(c => c.Date).NotEmpty();
            RuleFor(c => c.Date.Date).Equals(DateTime.Now.Date);
        }
    }
}
