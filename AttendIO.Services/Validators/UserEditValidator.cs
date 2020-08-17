using AttendIO.Services.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendIO.Services.Validators
{
    public class UserEditValidator : ValidatorBase<UserEditModel>
    {
        public UserEditValidator()
        {
            RuleFor(x => x.EmailAddress).Cascade(CascadeMode.Stop).NotEmpty();
            RuleFor(x => x.Username).Cascade(CascadeMode.Stop).NotEmpty().MaximumLength(20);
            RuleFor(x => x.Password).Cascade(CascadeMode.Stop).NotEmpty().MinimumLength(6).MaximumLength(30);
            RuleFor(x => x.PasswordConfirmation).Cascade(CascadeMode.Stop).NotEmpty().Matches(x => x.Password).MaximumLength(30);
            RuleFor(x => x.FirstName).Cascade(CascadeMode.Stop).NotEmpty().MinimumLength(1).MaximumLength(30);
            RuleFor(x => x.LastName).Cascade(CascadeMode.Stop).NotEmpty().MinimumLength(1).MaximumLength(30);
        }
    }
}
