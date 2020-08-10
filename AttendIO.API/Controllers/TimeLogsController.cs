using AttendIO.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendIO.API.Controllers
{
    public class TimeLogsController : ApiControllerBase
    {
        private readonly AppDbContext _dbContext;

        public TimeLogsController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("GetLogs")]
        public IActionResult GetLogs()
        {
            try
            {
                var test = "This is a test";
                return Ok(test);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("LogTime")]
        public IActionResult LogTime([FromBody]LogTimeBindingModel param)
        {
            try
            {
                
                return CreatedAtAction(nameof(LogTime), param);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        public class LogTimeBindingModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public string LogType { get; set; }
            public DateTime LogTime { get; set; } = DateTime.Now;
        }
    }
}
