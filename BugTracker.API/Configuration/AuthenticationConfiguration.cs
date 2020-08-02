namespace BugTracker.API.Configuration
{
	using System.Text;
	using BugTracker.Identity.Configuration;
	using LanguageExt;
	using Microsoft.AspNetCore.Authentication.JwtBearer;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.IdentityModel.Tokens;

	public static class AuthenticationConfiguration
	{
		public static Unit Configure(IServiceCollection services, IConfiguration configuration)
		{
			var secret = configuration.GetSection("JwtConfig").GetSection("secret").Value;
			services.AddAuthentication(x =>
					{
						x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
						x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
					})
					.AddJwtBearer(options =>
					{
#if DEBUG
						options.RequireHttpsMetadata = false;
#endif
						options.TokenValidationParameters = new TokenValidationParameters
						{
							ValidIssuer = AuthOptions.ISSUER,
							ValidAudience = AuthOptions.AUDIENCE,
							ValidateIssuer = true,
							ValidateAudience = true,
							ValidateLifetime = true,
							IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(secret),
							ValidateIssuerSigningKey = true,
						};
					});

			return Unit.Default;
		}
	}
}