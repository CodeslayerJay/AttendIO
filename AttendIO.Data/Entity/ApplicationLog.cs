using System;
using System.Collections.Generic;
using System.Text;

namespace AttendIO.Data.Entity
{
    public class ApplicationLog : EntityBase
    {
        public string Level { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public string Comment { get; set; }
        public string CreatedAtLocation { get; set; }
    }
}
