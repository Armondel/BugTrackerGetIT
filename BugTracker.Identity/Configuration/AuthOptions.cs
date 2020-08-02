namespace BugTracker.Identity.Configuration
{
	using System.Text;
	using Microsoft.IdentityModel.Tokens;

	public class AuthOptions
	{
		public const string ISSUER = "MyAuthServer";      // издатель токена
		public const string AUDIENCE = "MyAuthClient";    // потребитель токена
		public const int LIFETIME = 1;                    // время жизни токена - 1 минута

		public static SymmetricSecurityKey GetSymmetricSecurityKey(string secret)
		{
			return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
		}
	}
}