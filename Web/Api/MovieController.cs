using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        public IActionResult List()
        {
            string root = @"D:\Movies";
            string[] movies = Directory.GetDirectories(root).Select(p => new DirectoryInfo(p).Name).ToArray();

            return Ok(movies);
        }
    }
}
