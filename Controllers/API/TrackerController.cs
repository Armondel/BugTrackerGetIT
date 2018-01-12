using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BugTrackerGetIT.Data;
using BugTrackerGetIT.DTO;
using BugTrackerGetIT.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BugTrackerGetIT.Controllers.API
{
	//[Authorize]
    [Produces("application/json")]
    public class TrackerController : Controller
    {
	    private readonly ApplicationDbContext _context;

	    public TrackerController(ApplicationDbContext context)
	    {
		    _context = context;
	    }

		[AllowAnonymous]
		[Route("api/getbugs")]
	    public IActionResult GetBugs()
	    {
		    if (!User.Identity.IsAuthenticated)
			    return Json(new {message = "Access Denied"});

		    var bugs = _context.Bugs
			    .Include(b => b.User)
			    .Include(b => b.Criticality)
			    .Include(b => b.Status)
				.Include(b => b.Priority)
				.ToList()
			    .Select(Mapper.Map<Bug, BugDto>);

		    return Ok(bugs);
	    }
		[Route("api/getbug/{id}")]
		public IActionResult GetSingleBug(string id)
		{
			if (!User.Identity.IsAuthenticated)
				return Json(new { message = "Access Denied" });

			var bug = _context.Bugs
				.FirstOrDefault(b => b.Id == id);

			if (bug == null)
				return NotFound();

			return Ok(Mapper.Map<Bug, BugDto>(bug));

		}
	}
}