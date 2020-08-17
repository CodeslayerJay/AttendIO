using AttendIO.Data;
using AttendIO.Services.Common;
using AttendIO.Services.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AttendIO.Services.ServiceActions
{
    internal class GetUserAction : ActionBase<UserDTO>
    {
        private readonly IMapper _mapper;

        public GetUserAction(AppDbContext appDbContext, IMapper mapper) :base(appDbContext)
        {
            _mapper = mapper;
        }

        public IServiceResult<UserDTO> Execute(string username)
        {

            var user = AppDbContext.Users.Where(x => x.Username == username).FirstOrDefault();

            ServiceResult.ResultData.Add(_mapper.Map<UserDTO>(user));

            return ServiceResult;
        }
    }
}
