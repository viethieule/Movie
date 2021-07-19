using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index(string name)
        {
            ViewBag.Name = name;
            return View();
        }
    }
}
