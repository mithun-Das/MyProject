using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
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

        [HttpPost("UploadPhoto")]
        public IActionResult UploadPhoto(IFormFile file)
        {
           // return Ok(file);
            var filePath =  Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Cleaned IT Return 2018.docx");
            //var filePath = Path.GetTempFileName();

             using (var stream = new FileStream(filePath, FileMode.Create))
             {
                file.CopyTo(stream);
             }

            //string fileName = ContenDispositionHeaderValue.Parse

            return Ok(filePath);
        }

        [HttpPost("UploadPhotoAgain")]
        public IActionResult UploadPhotoAgain(IFormCollection formData)
        {
            var myFiles = formData.Files;

            foreach(var file in myFiles){

                var filePath =  Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", formData.Keys(""));

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }

            return Ok(filePath);
        }


        [HttpPost("TextUpload")]

        public IActionResult TextPost([FromBody] string text)
        {
            return Ok(text);
        }

    }
}