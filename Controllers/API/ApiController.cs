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
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace BugTrackerGetIT.Controllers.API
{
	[Authorize]
    [Produces("application/json")]
    public class ApiController : Controller
    {
	    private readonly ApplicationDbContext _context;

	    public ApiController(ApplicationDbContext context)
	    {
		    _context = context;
	    }

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

	    [Route("api/bughistory/{id}")]
	    public IActionResult GetHistory(string id)
	    {
		    if (!User.Identity.IsAuthenticated)
			    return Json(new {message = "Access Denied"});

		    var bugHistory = _context.BugHistory
			    .Include(r => r.User)
				.Include(r => r.Status)
			    .Where(r => r.BugId == id)
			    .ToList()
			    .Select(Mapper.Map<BugHistory, BugHistoryDto>);

		    return Ok(bugHistory);
	    }

	    [Route("api/getuserlist")]
	    public IActionResult GetUsers()
	    {
		    if (!User.Identity.IsAuthenticated)
			    return Json(new {message = "Access Denied"});

		    var userDtoList = _context.Users
			    .ToList()
			    .Select(Mapper.Map<ApplicationUser, UserDto>);

		    return Ok(userDtoList);
	    }


	}
}