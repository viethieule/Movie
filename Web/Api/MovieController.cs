using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

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

        [Route("{name}")]
        public FileResult Media(string name)
        {
            name = HttpUtility.HtmlDecode(name);
            string root = @"D:\Movies";
            string path = Directory.GetFiles(Path.Combine(root, name)).FirstOrDefault(p => Path.GetExtension(p) == ".mp4" || Path.GetExtension(p) == ".mkv");
            return PhysicalFile(path, "application/octet-stream", enableRangeProcessing: true);
        }

        [Route("{name}")]
        public IActionResult Subtitle(string name)
        {
            name = HttpUtility.HtmlDecode(name);
            string root = @"D:\Movies";
            string path = Directory.GetFiles(Path.Combine(root, name)).FirstOrDefault(p => Path.GetExtension(p) == ".vtt");
            if (string.IsNullOrEmpty(path))
            {
                return NotFound();
            }

            return PhysicalFile(path, "application/octet-stream");
        }
    }
}
