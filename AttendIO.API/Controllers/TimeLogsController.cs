using AttendIO.Data;
using AttendIO.Services.Common;
using AttendIO.Services.Managers;
using AttendIO.Services.Models;
using AttendIO.Services.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendIO.API.Controllers
{
    public class TimeLogsController : ApiControllerBase
    {
        private readonly TimeLogServiceManager _manager;

        public TimeLogsController(TimeLogServiceManager manager)
        {
            _manager = manager;
            
        }

        [HttpGet]
        [Route("GetLogs/{username}")]
        public IActionResult GetLogs(string username)
        {
            try
            {
                return Ok(_manager.TimeLogService.GetLogs(username));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("SaveLog")]
        public IActionResult SaveLog([FromBody]TimeLogEditModel model)
        {
            try
            {
                return Ok(_manager.TimeLogService.SaveLog(model));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
