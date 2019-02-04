using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using Backend.Service;

namespace Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService ;
        public UsersController(UserService userService) {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetUser() {

          //  var userList = _userService.GetUserList();

            //return Ok(userList);
            return Ok("vdfff");
        }

        //[HttpPost]
        // public IActionResult InsertUser(User user) {


        //     return Ok(user);
        // } 
    }
}