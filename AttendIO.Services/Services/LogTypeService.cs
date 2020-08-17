using AttendIO.Data;
using AttendIO.Services.Common;
using AttendIO.Services.Models;
using AttendIO.Services.ServiceActions;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendIO.Services.Services
{
    public class LogTypeService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public LogTypeService(AppDbContext appDbContext, IMapper mapper)
        {

            _dbContext = appDbContext;
            _mapper = mapper;
        }

        public IServiceResult<LogTypeDTO> CreateLogType(LogTypeEditModel model)
        {
            var action = new CreateLogTypeAction(_dbContext, _mapper);
            return action.Execute(model);
        }

        public IServiceResult<LogTypeDTO> UpdateLogType(LogTypeEditModel model)
        {
            var action = new UpdateLogTypeAction(_dbContext, _mapper);
            return action.Execute(model);
        }
    }
}
