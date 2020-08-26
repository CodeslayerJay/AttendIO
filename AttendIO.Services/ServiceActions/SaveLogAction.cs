using AttendIO.Data;
using AttendIO.Data.Entity;
using AttendIO.Services.Common;
using AttendIO.Services.Models;
using AttendIO.Services.Utils;
using AttendIO.Services.Validators;
using AutoMapper;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AttendIO.Services.ServiceActions
{
    internal class SaveLogAction : ActionBase<TimeLog>
    {
        private readonly IMapper _mapper;

        public SaveLogAction(AppDbContext appDbContext, IMapper mapper) :base(appDbContext)
        {
            _mapper = mapper;
        }

        public IServiceResult<TimeLog> Execute(TimeLogEditModel timeLogEditModel)
        {

            ValidateModel(timeLogEditModel);

            if (ServiceResult.IsSuccess == false) return ServiceResult;
            
            var user = AppDbContext.Users.Include("UserSecurity").Where(x => x.Username == timeLogEditModel.Username).FirstOrDefault();

            if(user != null && AppSecurity.VerifyPasswords(timeLogEditModel.Password, user.Password, user.UserSecurity.SLT))
            {
                var timeLog = _mapper.Map<TimeLog>(timeLogEditModel);
                timeLog.UserId = user.Id;

                var logType = (from t in AppDbContext.TimeLogs
                                join u in AppDbContext.Users on t.UserId equals u.Id
                                join lt in AppDbContext.LogTypes on t.LogTypeId equals lt.Id
                                from next in AppDbContext.LogTypes.Where(x => x.Sequence > lt.Sequence).OrderBy(x => x.Sequence).Take(1).DefaultIfEmpty()
                                from begin in AppDbContext.LogTypes.Where(x => x.Sequence == 1).Take(1).DefaultIfEmpty()
                                where u.Username == timeLogEditModel.Username
                                select new { t.CreatedAt, LogTypeId = next != null ? next.Id : begin.Id, Name = next != null ? next.Name : begin.Name })
                               .OrderByDescending(x => x.CreatedAt).FirstOrDefault();

                timeLog.LogTypeId = logType.LogTypeId;
                AppDbContext.TimeLogs.Add(timeLog);

                AppDbContext.SaveChanges();
                ServiceResult.StatusMessage = "Stamp saved as " + logType.Name;  
                ServiceResult.ResultData.Add(timeLog);
            } 
            else
            {
                ServiceResult.AddError("User or password doesn't not match.");
            }
            
            return ServiceResult;
        }

        private void ValidateModel(TimeLogEditModel timeLogEditModel)
        {
            var validator = new TimeLogEditValidator();
            var result = validator.Validate(timeLogEditModel);

            if (result.IsValid == false)
            {
                MapErrorsToServiceResult(result.Errors);
            }
        }


    }
}
