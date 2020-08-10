using AttendIO.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendIO.Data.Entity
{
    public class TimeLog : EntityBase, ITimeLog
    {
        public TimeLog()
        {
            ModifiedLogs = new HashSet<ModifiedLog>();
        }

        public int UserId { get; set; }
        public int LogTypeId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public LogType LogType { get; set; }

        
        public User User { get; set; }
        public ICollection<ModifiedLog> ModifiedLogs { get; set; }
        
    }
}
