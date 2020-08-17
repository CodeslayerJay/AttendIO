using System;
using System.Collections.Generic;
using System.Text;

namespace AttendIO.Services.Models
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
