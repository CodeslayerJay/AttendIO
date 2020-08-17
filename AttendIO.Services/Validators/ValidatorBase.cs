using FluentValidation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace AttendIO.Services.Validators
{
    public abstract class ValidatorBase<T> : AbstractValidator<T> where T : class
    {
        protected virtual bool isValidCurrency(string currency)
        {
            var result = Decimal.TryParse(currency.ToString(), NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal value);

            if (result)
            {
                return (value > 0) ? true : false;
            }

            return result;
        }
        
    }
}
