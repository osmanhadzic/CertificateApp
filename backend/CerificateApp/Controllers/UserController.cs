using CerificateApp.Models.Request;
using CerificateApp.Services.Definition;
using DCCS.Web.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CerificateApp.Api.Controllers
{
    [Route("user/")]
    public class UserController : BaseController
    {
        private IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("")]
        public IActionResult GetAllUsers([FromQuery] UserRequestModel model)
        {
            var result = userService.GetAllUsers(model);
            return Convert(result);
        }

        [HttpGet("/userid/{id}")]
        public IActionResult GetUser([FromQuery] int Id)
        {
            var result = userService.GetUser(Id);
            return Convert(result);
        }

    }
}
