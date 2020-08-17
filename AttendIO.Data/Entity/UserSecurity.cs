using System;
using System.Collections.Generic;
using System.Text;

namespace AttendIO.Data.Entity
{
    public class UserSecurity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public byte[] SLT { get; set; }

        public User User { get; set; }
    }
}
