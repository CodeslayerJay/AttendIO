using AttendIO.Data;
using AttendIO.Data.Entity;
using AttendIO.Services.Common;
using AttendIO.Services.Models;
using AttendIO.Services.Utils;
using AttendIO.Services.Validators;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AttendIO.Services.ServiceActions
{
    internal class CreateUserAction : ActionBase<UserDTO>
    {
        private readonly IMapper _mapper;

        public CreateUserAction(AppDbContext appDbContext, IMapper mapper) :base(appDbContext)
        {
            _mapper = mapper;
        }

        public IServiceResult<UserDTO> Execute(UserEditModel userEditModel)
        {
            var validator = new UserEditValidator();
            var result = validator.Validate(userEditModel);

            if(result.IsValid == false)
            {
                MapErrorsToServiceResult(result.Errors);

                return ServiceResult;
            }

            var userExists = AppDbContext.Users
                .Where(x => x.Username == userEditModel.Username || x.EmailAddress == userEditModel.EmailAddress)
                .Any();

            if (userExists)
            {
                ServiceResult.AddError("User already exists with username and email address.");
                return ServiceResult;
            }

            var user = _mapper.Map<User>(userEditModel);
            user.IsActive = true;

            var hashResult = AppSecurity.HashPassword(userEditModel.Password);
            user.Password = hashResult.HashedPassword;

            AppDbContext.Users.Add(user);
            AppDbContext.SaveChanges();

            AppDbContext.UserSecurity.Add(new UserSecurity { UserId = user.Id, SLT = hashResult.SaltKey });
            AppDbContext.SaveChanges();

            
            ServiceResult.ResultData.Add(_mapper.Map<UserDTO>(user));

            return ServiceResult;
        }

    }
}
