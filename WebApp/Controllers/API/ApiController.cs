namespace BugTrackerGetIT.WebApp.Controllers.API
{
	using System.Collections.Generic;
	using System.Linq;
	using AutoMapper;
	using BugTrackerGetIT.Core.Bug;
	using BugTrackerGetIT.Core.BugHistory;
	using BugTrackerGetIT.Core.User;
	using BugTrackerGetIT.WebApp.Data;
	using BugTrackerGetIT.WebApp.DTO;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.EntityFrameworkCore;

    [Authorize]
    [Produces("application/json")]
    public class ApiController : Controller
    {
	    private readonly ApplicationDbContext _context;
		private readonly IMapper _mapper;

	    public ApiController(ApplicationDbContext context, IMapper mapper)
	    {
		    _context = context;
			_mapper = mapper;
	    }

		[Route("api/getbugs")]
	    public IActionResult GetBugs()
	    {
		    if (!User.Identity.IsAuthenticated)
			    return Json(new {message = "Access Denied"});

		    var bugs = _mapper.Map<IEnumerable<Bug>, IEnumerable<BugDto>>(_context.Bugs
			    .Include(b => b.User)
				.ToList());

		    return Ok(bugs);
	    }

	    [Route("api/bughistory/{id}")]
	    public IActionResult GetHistory(string id)
	    {
		    if (!User.Identity.IsAuthenticated)
			    return Json(new {message = "Access Denied"});

		    var bugHistory = _mapper.Map<IEnumerable<BugHistory>, IEnumerable<BugHistoryDto>>(_context.BugHistory
				.Include(r => r.Status)
			    .Where(r => r.BugId == id)
			    .ToList());

		    return Ok(bugHistory);
	    }

	    [Route("api/getuserlist")]
	    public IActionResult GetUsers()
	    {
		    if (!User.Identity.IsAuthenticated)
			    return Json(new {message = "Access Denied"});

		    var userDtoList = _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(
				_context.Users
			    .ToList());

		    return Ok(userDtoList);
	    }


	}
}