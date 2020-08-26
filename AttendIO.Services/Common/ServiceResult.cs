using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AttendIO.Services.Common
{
    public class ServiceResult<TEntity> : IServiceResult<TEntity> where TEntity : class
    {
        public ServiceResult()
        {
            ServiceErrors = new HashSet<string>();
            ResultData = new List<TEntity>();
        }

        public ICollection<string> ServiceErrors { get; }

        public List<TEntity> ResultData { get; set; }
        
        public string StatusMessage { get; set; }
        public bool IsSuccess => ServiceErrors.Any() == false;

        public void AddError(string message)
        {
            if (String.IsNullOrEmpty(message) == false)
            {
                ServiceErrors.Add(message);
            }
        }
    }
}
