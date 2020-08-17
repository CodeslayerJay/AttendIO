using AttendIO.Data;
using AttendIO.Data.Entity;
using AttendIO.Services.Common;
using AttendIO.Services.Models;
using AttendIO.Services.ServiceActions;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AttendIO.Services.Services
{
    public class UserService
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _dbContext;

        public UserService(AppDbContext appDbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = appDbContext;
        }

        public IServiceResult<UserDTO> CreateUser(UserEditModel userEditModel)
        {
            var action = new CreateUserAction(_dbContext, _mapper);
            return action.Execute(userEditModel);
        }

        public IServiceResult<UserDTO> GetUser(string username)
        {
            var action = new GetUserAction(_dbContext, _mapper);
            return action.Execute(username);
        }
    }
}
