using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendIO.Services.Utils
{
    public static class TokenConfig
    {
        public const string ValidIssuer = "AttendIO";
        public const string ValidAudience = "AttendIO_User";
        public static TimeSpan SkewTime = TimeSpan.Zero;
        public static DateTime Expires = DateTime.Now.AddMinutes(DefaultTokenTimeout);
        public const int DefaultTokenTimeout = 20;

        private static byte[] _key = Encoding.UTF8.GetBytes("rlyaKithdrYVl6Z80ODU350md");


        public static SymmetricSecurityKey GetKey()
        {
            var key = new SymmetricSecurityKey(_key);
            return key;
        }
    }
}
