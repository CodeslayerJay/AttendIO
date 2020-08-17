using AttendIO.Data;
using AttendIO.Services.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendIO.Services.Managers
{
    public class AdminServiceManager
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public TimeLogService TimeLogService { get; }
        public UserService UserService { get; }
        public LogTypeService LogTypeService { get; }


        public AdminServiceManager(AppDbContext appDbContext, IMapper mapper)
        {
            _dbContext = appDbContext;
            _mapper = mapper;
            TimeLogService = new TimeLogService(_dbContext, _mapper);
            UserService = new UserService(_dbContext, _mapper);
            LogTypeService = new LogTypeService(_dbContext, _mapper);
        }
    }
}
