using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator:AbstractValidator<Color>
    {
        public ColorValidator() 
        {
            RuleFor(c => c.ColorName).NotEmpty();
            RuleFor(c => c.ColorName).Must(IsLetterOrDigit).WithMessage("Renk adında özel karakter olamaz.");
        }
        private bool IsLetterOrDigit(string arg)
        {
            foreach (char c in arg)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
