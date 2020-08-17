using AttendIO.Data;
using AttendIO.Services.Common;
using AttendIO.Services.Models;
using AttendIO.Services.Validators;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AttendIO.Data.Entity;

namespace AttendIO.Services.ServiceActions
{
    internal class CreateLogTypeAction : ActionBase<LogTypeDTO>
    {
        private readonly IMapper _mapper;

        public CreateLogTypeAction(AppDbContext appDbContext, IMapper mapper) :base(appDbContext)
        {
            _mapper = mapper;
        }

        public IServiceResult<LogTypeDTO> Execute(LogTypeEditModel model)
        {

            var validator = new LogTypeEditValidator();
            var result = validator.Validate(model);

            if(result.IsValid == false)
            {
                MapErrorsToServiceResult(result.Errors);

                return ServiceResult;
            }

            var lastSequenceOrder = (from l in AppDbContext.LogTypes
                                     select l.Sequence).OrderByDescending(x => x).FirstOrDefault();

            var nextValidSequence = lastSequenceOrder + 1;

            if (model.Sequence != nextValidSequence)
                model.Sequence = nextValidSequence;

            var logType = _mapper.Map<LogType>(model);
            AppDbContext.LogTypes.Add(logType);
            AppDbContext.SaveChanges();

            ServiceResult.ResultData.Add(_mapper.Map<LogTypeDTO>(logType));

            return ServiceResult;
        }
    }
}
