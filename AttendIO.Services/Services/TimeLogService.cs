using AttendIO.Data;
using AttendIO.Data.Entity;
using AttendIO.Services.Common;
using AttendIO.Services.Models;
using AttendIO.Services.ServiceActions;
using AttendIO.Services.Validators;
using AutoMapper;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendIO.Services.Services
{
    public class TimeLogService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public TimeLogService(AppDbContext appDbContext, IMapper mapper)
        {

            _dbContext = appDbContext;
            _mapper = mapper;
        }

        public IServiceResult<TimeLog> SaveLog(TimeLogEditModel model)
        {
            var action = new SaveLogAction(_dbContext, _mapper);
            return action.Execute(model);
        }


        public IServiceResult<TimeLog> GetLogs(string username)
        {
            var action = new GetLogsAction(_dbContext);
            return action.Execute(username);
        }
    }


}
