namespace BugTracker.API.Endpoints
{
	using Ardalis.ApiEndpoints;

	public class GetUsers : BaseEndpoint
	{
		/*
		 * if (!User.Identity.IsAuthenticated)
			    return Json(new {message = "Access Denied"});

		    var userDtoList = _context.Users
			    .ToList()
			    .Select(Mapper.Map<ApplicationUser, UserDto>);

		    return Ok(userDtoList);
		 */
	}
}