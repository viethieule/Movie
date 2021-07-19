using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("api/getmedia/{name}")]
        public FileResult GetMedia(string name)
        {
            name = HttpUtility.HtmlDecode(name);
            string root = @"D:\Movies";
            string path = Directory.GetFiles(Path.Combine(root, name)).FirstOrDefault(p => Path.GetExtension(p) == ".mp4");
            return PhysicalFile(path, "application/octet-stream", enableRangeProcessing: true);
        }

        [Route("api/getsub/{name}")]
        public IActionResult GetSub(string name)
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
