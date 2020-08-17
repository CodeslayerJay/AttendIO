using System;
using System.Collections.Generic;
using System.Text;

namespace AttendIO.Services.Models
{
    public class TimeLogEditModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string LogType { get; set; }
        public DateTime LogTime { get; set; } = DateTime.Now;
    }
}
