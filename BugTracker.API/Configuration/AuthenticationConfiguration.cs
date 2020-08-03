namespace BugTracker.API.Configuration
{
	using System.Text;
	using LanguageExt;
	using Microsoft.AspNetCore.Authentication.JwtBearer;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.IdentityModel.Tokens;

	public static class AuthenticationConfiguration
	{
		public static Unit Configure(IServiceCollection services, IConfiguration configuration)
		{
			var jwtConfig = configuration.GetSection("JwtConfig");
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
						options.SaveToken = true;
						options.TokenValidationParameters = new TokenValidationParameters
						{
							ValidIssuer = jwtConfig.GetValue<string>("issuer"),
							ValidAudience = jwtConfig.GetValue<string>("audience"),
							ValidateIssuer = true,
							ValidateAudience = true,
							ValidateLifetime = true,
							IssuerSigningKey =
								new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtConfig.GetValue<string>("secret"))),
							ValidateIssuerSigningKey = true,
						};
					});

			return Unit.Default;
		}
	}
}