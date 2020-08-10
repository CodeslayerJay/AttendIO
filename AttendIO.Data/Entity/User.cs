using AttendIO.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendIO.Data.Entity
{
    public class User : EntityBase, IUser
    {
        public User()
        {
            TimeLogs = new HashSet<TimeLog>();
            ModifiedLogs = new HashSet<ModifiedLog>();
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public bool IsActive { get; set; }

        public ICollection<TimeLog> TimeLogs { get; set; }
        public ICollection<ModifiedLog> ModifiedLogs { get; set; }
    }
}
