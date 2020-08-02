namespace BugTracker.API.Endpoints.Identity
{
	using LanguageExt;
	using static LanguageExt.Prelude;

	public class AuthenticateRequest
	{
		private Option<string> _username;
		private Option<string> _password;

		public string Username
		{
			get => _username.Match(s1 => s1, () => string.Empty);
			set => _username = Some(value);
		}

		public string Password
		{
			get => _password.Match(s1 => s1, () => string.Empty);
			set => _password = Some(value);
		}

		public bool RequestIsValid() =>
			_username.IsSome && _password.IsSome;
	}
}