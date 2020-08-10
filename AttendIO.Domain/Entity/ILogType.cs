using System;
using System.Collections.Generic;
using System.Text;

namespace AttendIO.Domain.Entity
{
    public interface ILogType
    {
        public string Name { get; set; }
        public string Code { get; set; }

        //public ICollection<ITimeLog> TimeLogs { get; set; }
    }
}
