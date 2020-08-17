using FluentValidation.Results;
using System.Collections.Generic;

namespace AttendIO.Services.Common
{
    public interface IServiceResult<TEntity> where TEntity : class
    {
        bool IsSuccess { get; }
        ICollection<string> ServiceErrors { get; }
        
        //TEntity Entity { get; set; }

        List<TEntity> ResultData { get; set; }
        void AddError(string message);
    }
}