namespace BugTracker.API.Endpoints.Identity
{
	public class RegisterRequest
	{
		public string Email { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
	}
}