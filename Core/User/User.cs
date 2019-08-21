using Microsoft.AspNetCore.Identity;

namespace BugTrackerGetIT.Core.User
{
	public class User : IdentityUser
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Token { get; set; }
	}
}