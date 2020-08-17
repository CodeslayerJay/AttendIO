using AttendIO.Data;
using AttendIO.Domain.Entity;
using AttendIO.Services.Common;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AttendIO.Services.ServiceActions
{
    internal abstract class ActionBase<TEntity> where TEntity : class
    {
        protected readonly AppDbContext AppDbContext;
        protected ServiceResult<TEntity> ServiceResult;

        

        protected ActionBase(AppDbContext appDbContext)
        {
            AppDbContext = appDbContext;
            ServiceResult = new ServiceResult<TEntity>();
        }

        protected void MapErrorsToServiceResult(IList<ValidationFailure> errors)
        {
            if (errors != null && errors.Any())
            {
                foreach (var error in errors)
                {
                    ServiceResult.AddError(error.ErrorMessage);
                }
            }
        }
    }
}
