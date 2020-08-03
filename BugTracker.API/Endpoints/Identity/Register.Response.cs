namespace BugTracker.API.Endpoints.Identity
{
	public class RegisterResponse
	{
		public RegisterResponse(bool isSucceeded)
		{
			IsSucceeded = isSucceeded;
		}

		public bool IsSucceeded { get; }
	}
}