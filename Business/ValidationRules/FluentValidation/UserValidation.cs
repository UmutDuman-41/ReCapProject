using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidation:AbstractValidator<User>
    {
        public UserValidation() 
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.FirstName).MinimumLength(2);
            RuleFor(u => u.FirstName).MaximumLength(30);

            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.LastName).MinimumLength(3);
            RuleFor(u => u.LastName).MaximumLength(40);

            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Email).MinimumLength(3);
            RuleFor(u => u.Email).MaximumLength(40);
            RuleFor(u => u.Email).Must(ContainsComet);
            RuleFor(u => u.Email).Must(ContainsDotCom);

            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.Password).MinimumLength(4);
            RuleFor(u => u.Password).MaximumLength(8);
            RuleFor(u => u.Password).Must(ContainsSpecialChar).WithMessage(Messages.PassMustContainSpecialChar);
            RuleFor(u => u.Password).Must(ContainsBigLetter).WithMessage(Messages.PassMustContainBigLetter);
            RuleFor(u => u.Password).Must(ContainLetterAndDigit).WithMessage(Messages.PassMustContainLetterAndDigit);
        }

        private bool ContainsSpecialChar(string arg)
        {
            char[] privateChar = { '?', '@', '!', '#', '%', '+', '-', '_', '*', '_', '|' };

            foreach (var chara in privateChar)
            {
                if (arg.Contains(chara))
                {
                    return arg.Contains(chara);
                }
            }
            return false;
        }

        private bool ContainsDotCom(string arg)
        {
            return arg.Contains(".com");
        }

        private bool ContainsComet(string arg)
        {
            return arg.Contains("@");
        }
        private bool ContainsBigLetter(string arg)
        {
            return arg.Any(char.IsUpper);
        }
        private bool ContainLetterAndDigit(string arg)
        {
            bool containsLetter = arg.Any(char.IsLetter);
            bool containsDigit = arg.Any(char.IsDigit);
            return containsLetter && containsDigit;
        }
    }
}
