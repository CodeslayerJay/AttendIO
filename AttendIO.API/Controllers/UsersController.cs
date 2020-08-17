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
    
    public class UsersController : ApiControllerBase
    {
        private readonly UserServiceManager _manager;

        public UsersController(UserServiceManager manager)
        {
            _manager = manager;

        }

        [HttpPost]
        [Route("CreateUser")]
        public IActionResult CreateUser([FromBody]UserEditModel model)
        {
            try
            {
                return Ok(_manager.UserService.CreateUser(model));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetUser/{username}")]
        public IActionResult GetUser(string username)
        {
            try
            {
                return Ok(_manager.UserService.GetUser(username));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}