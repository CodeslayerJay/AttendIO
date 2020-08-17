using AttendIO.Data;
using AttendIO.Data.Entity;
using AttendIO.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AttendIO.Services.ServiceActions
{
    internal class GetLogsAction : ActionBase<TimeLog>
    {
        
        public GetLogsAction(AppDbContext appDbContext) : base(appDbContext)
        { }
        
        public IServiceResult<TimeLog> Execute(string username)
        {

            if (String.IsNullOrEmpty(username))
            {
                ServiceResult.AddError("You must provide a valid username.");
                return ServiceResult;
            }

            var user = AppDbContext.Users.Where(x => x.Username == username).FirstOrDefault();

            if(user != null)
            {
                ServiceResult.ResultData.AddRange(AppDbContext.TimeLogs.Where(x => x.UserId == user.Id).ToList());
            }

            return ServiceResult;
        }
    }
}
