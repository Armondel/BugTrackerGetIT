namespace BugTracker.API.Endpoints
{
	using Ardalis.ApiEndpoints;

	public class GetAllBugs : BaseEndpoint
	{
		/*
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
		 */
	}
}