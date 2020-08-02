namespace BugTracker.API.Endpoints.Tests
{
	public class GetSampleAuthorizedResponse
	{
		public GetSampleAuthorizedResponse(string result)
		{
			Result = result;
		}

		public string Result { get; }
	}
}