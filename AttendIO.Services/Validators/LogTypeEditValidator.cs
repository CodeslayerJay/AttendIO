using AttendIO.Services.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendIO.Services.Validators
{
    public class LogTypeEditValidator : ValidatorBase<LogTypeEditModel>
    {
        public LogTypeEditValidator()
        {
            RuleFor(x => x.Code).Cascade(CascadeMode.Stop).NotEmpty();
            RuleFor(x => x.Name).Cascade(CascadeMode.Stop).NotEmpty();
        }
    }
}
