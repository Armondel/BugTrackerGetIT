namespace API.Endpoints
{
	using Ardalis.ApiEndpoints;

	public class GetBugHistory : BaseEndpoint
	{
		/*
		 if (!User.Identity.IsAuthenticated)
			    return Json(new {message = "Access Denied"});

		    var bugHistory = _context.BugHistory
			    .Include(r => r.User)
				.Include(r => r.Status)
			    .Where(r => r.BugId == id)
			    .ToList()
			    .Select(Mapper.Map<BugHistory, BugHistoryDto>);

		    return Ok(bugHistory);
		 */
	}
}