using System;
using System.Collections.Generic;
using System.Text;

namespace AttendIO.Services.Models
{
    public class UserEditModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
    }
}
