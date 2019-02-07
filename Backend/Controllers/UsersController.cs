using System;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Backend.Service;
using Backend.Models;

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
        public IActionResult UploadPhoto(IFormFile userFile, [FromForm] string text)
        {
            var filePath =  Path.Combine(Directory.GetCurrentDirectory(), "wwwroot",text);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                userFile.CopyTo(stream);
            }

            return Ok(filePath);
        }

       // [HttpPost("UploadPhotoAgain")]
        //public IActionResult UploadPhotoAgain(Test formData)
        //{
            // var myFiles = formData.Files;

            // foreach(var file in myFiles){

            //     var filePath =  Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", formData.Keys(""));

            //     using (var stream = new FileStream(filePath, FileMode.Create))
            //     {
            //         file.CopyTo(stream);
            //     }
            // }

           // return Ok(filePath);
       // }


        [HttpPost("TextUpload")]

        public  IActionResult TextPost()
        {

            // string myData;
            // Test parsedTest = new Test();

            // using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            // {
            //     myData =  reader.ReadToEnd(); 



                
                //MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(myData));
               // DataContractJsonSerializer ser = new DataContractJsonSerializer(parsedTest.GetType());
              //  parsedTest = (Test)ser.ReadObject(ms);
                //ms.Close();


           // }


            // //Test t = (Test)ser.ReadObject(ms);

           // return Ok(InputFormatterResult.Success(myData));
          // return Ok(test.text);

          return Ok(Request.Body)  ;
        }

    }
}