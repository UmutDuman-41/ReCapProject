﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator() 
        {
            RuleFor(c => c.CarName).NotEmpty();
            RuleFor(c => c.ModelYear).NotEmpty();

            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(350);

            RuleFor(c => c.BrandId).NotEmpty();
            RuleFor(c => c.BrandId).GreaterThan(0);

            RuleFor(c => c.ColorId).NotEmpty();
            RuleFor(c => c.ColorId).GreaterThan(0);

            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.Description).MinimumLength(2);
            RuleFor(c => c.Description).MaximumLength(50);
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.CarName).Must(NameControl).WithMessage("Araç isimlerinde sayı olamaz");

        }
        private bool NameControl(string arg)
        {
            foreach (char c in arg)
            {
                if (char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

    }
}
