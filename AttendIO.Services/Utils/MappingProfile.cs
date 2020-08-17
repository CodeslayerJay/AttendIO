using AttendIO.Data.Entity;
using AttendIO.Services.Models;
using AttendIO.Services.Services;
using AutoMapper;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendIO.Services.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TimeLogEditModel, TimeLog>();

            CreateMap<UserEditModel, User>();
            CreateMap<User, UserDTO>();

            CreateMap<LogTypeEditModel, LogType>();
            CreateMap<LogType, LogTypeDTO>();
        }
    }
}
