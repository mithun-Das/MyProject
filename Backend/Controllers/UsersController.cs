using System;
using System.Threading.Tasks;
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
        public async Task<IActionResult> GetUser() {

            var userList =  await _userService.GetUserList();

            return Ok(userList);
        }

        //[HttpPost]
        // public IActionResult InsertUser(User user) {


        //     return Ok(user);
        // } 
    }
}