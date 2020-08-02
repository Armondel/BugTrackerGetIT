namespace BugTracker.Identity.UseCases.GetUserToken
{
	using BugTracker.SharedKernel.Abstract;

	public class GetUserToken : IQuery<string>
	{
		public GetUserToken(string userName)
		{
			UserName = userName;
		}

		public string UserName { get; }
	}
}