using AttendIO.Data.Entity;
using AttendIO.Services.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendIO.Services.Validators
{
    public class TimeLogEditValidator : ValidatorBase<TimeLogEditModel>
    {
        public TimeLogEditValidator()
        {
            RuleFor(x => x.Username).Cascade(CascadeMode.Stop).NotEmpty();
            RuleFor(x => x.Password).Cascade(CascadeMode.Stop).NotEmpty();
        }
    }
}
