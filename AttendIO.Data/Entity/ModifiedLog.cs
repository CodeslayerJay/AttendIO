using System;
using System.Collections.Generic;
using System.Text;

namespace AttendIO.Data.Entity
{
    public class ModifiedLog : EntityBase
    {
        public int TimeLogId { get; set; }
        public int ModifiedById { get; set; }

        public string PropertyChanged { get; set; }
        public string OriginalValue { get; set; }
        public string ChangedValue { get; set; }

        public bool Approved { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public TimeLog TimeLog { get; set; }
        public User ModifiedByUser { get; set; }

    }
}
