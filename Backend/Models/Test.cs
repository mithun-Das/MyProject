using System;
using Microsoft.AspNetCore.Http;

namespace Backend.Models
{
    public class Test
    {
        public string text { get; set; }
        public IFormFile file { get; set; }
    }
}