namespace BugTracker.API.Endpoints.Identity
{
	public class AuthenticateResponse
	{
		public AuthenticateResponse()
		{
			Result = false;
			Token = string.Empty;
			Username = string.Empty;
			IsLockedOut = false;
			IsNotAllowed = false;
			RequiresTwoFactor = false;
		}

		public bool Result { get; set; }
		public string Token { get; set; }
		public string Username { get; set; }
		public bool IsLockedOut { get; set; }
		public bool IsNotAllowed { get; set; }
		public bool RequiresTwoFactor { get; set; }
	}
}