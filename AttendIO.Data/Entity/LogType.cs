using AttendIO.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendIO.Data.Entity
{
    public class LogType : EntityBase, ILogType
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int Sequence { get; set; }
        public ICollection<TimeLog> TimeLogs { get; set; }
    }
}
