using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BugTrackerGetIT.Controllers
{
    public class TrackerController : Controller
    {
		[Route("/tracker/all")]
        public IActionResult Index()
        {
            return View();
        }
    }
}