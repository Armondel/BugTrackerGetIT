namespace BugTracker.API.Endpoints.Tests
{
	public class GetSampleAnonymousResponse
	{
		public GetSampleAnonymousResponse(string result)
		{
			Result = result;
		}

		public string Result { get; }
	}
}