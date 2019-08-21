using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BugTrackerGetIT.WebApp.Models;

namespace BugTrackerGetIT.WebApp.Controllers
{
    public class HomeController : Controller
    {
		
        public IActionResult Index()
        {
            return View();
        }
    }
}
