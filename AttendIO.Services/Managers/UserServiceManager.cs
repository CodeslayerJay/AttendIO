using AttendIO.Data;
using AttendIO.Services.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendIO.Services.Managers
{
    public class UserServiceManager
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        
        public UserService UserService { get; }

        public UserServiceManager(AppDbContext appDbContext, IMapper mapper)
        {
            _dbContext = appDbContext;
            _mapper = mapper;
            
            UserService = new UserService(_dbContext, _mapper);
        }
    }
}
