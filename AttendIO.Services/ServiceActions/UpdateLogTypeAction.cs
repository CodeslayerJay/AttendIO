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
    internal class UpdateLogTypeAction : ActionBase<LogTypeDTO>
    {
        private readonly IMapper _mapper;

        public UpdateLogTypeAction(AppDbContext appDbContext, IMapper mapper) : base(appDbContext)
        {
            _mapper = mapper;
        }

        public IServiceResult<LogTypeDTO> Execute(LogTypeEditModel model)
        {
            var validator = new LogTypeEditValidator();
            var result = validator.Validate(model);
            
            if (result.IsValid == false)
            {
                MapErrorsToServiceResult(result.Errors);

                return ServiceResult;
            }

            var logType = AppDbContext.LogTypes.Where(x => x.Id == model.Id).FirstOrDefault();

            if (logType == null)
            {
                ServiceResult.AddError("LogType is not found.");
                return ServiceResult;
            }

            var lastSequenceOrder = (from l in AppDbContext.LogTypes
                                     select l.Sequence).OrderByDescending(x => x).FirstOrDefault();

            if (model.Sequence > lastSequenceOrder || model.Sequence == 0)
            {
                ServiceResult.AddError($"Sequence must be between 1 and {lastSequenceOrder}");
                return ServiceResult;
            }

            logType.Sequence = model.Sequence;

            var logTypesToUpdateSequences = AppDbContext.LogTypes.Where(x => x.Sequence >= logType.Sequence && x.Id != logType.Id).ToList();

            var counter = logType.Sequence + 1;
            foreach(var lt in logTypesToUpdateSequences)
            {
                lt.Sequence = counter;
                counter++;
            }

            AppDbContext.SaveChanges();

            ServiceResult.ResultData.Add(_mapper.Map<LogTypeDTO>(logType));

            return ServiceResult;
        }
    }
}
