using System;
using System.Collections.Generic;
using System.Text;

namespace AttendIO.Domain.Entity
{
    public interface ITimeLog
    {
        public DateTime CreatedAt { get; set; }
        //public ILogType LogType { get; set; }
    }
}
