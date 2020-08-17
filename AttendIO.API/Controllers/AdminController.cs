using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttendIO.Services.Managers;
using AttendIO.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttendIO.API.Controllers
{
    
    public class AdminController : ApiControllerBase
    {
        private readonly AdminServiceManager _adminManager;

        public AdminController(AdminServiceManager adminManager)
        {
            _adminManager = adminManager;
        }

        [HttpPost]
        [Route("SaveLogType")]
        public IActionResult SaveLogType([FromBody]LogTypeEditModel model)
        {
            try
            {
                return Ok(_adminManager.LogTypeService.CreateLogType(model));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("UpdateLogType")]
        public IActionResult UpdateLogType([FromBody]LogTypeEditModel model)
        {
            try
            {
                return Ok(_adminManager.LogTypeService.UpdateLogType(model));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}