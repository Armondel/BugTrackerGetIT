namespace BugTracker.API.Configuration
{
	using System;
	using BugTracker.Persistence;
	using LanguageExt;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.Extensions.DependencyInjection;

	public static class IdentityConfiguration
	{
		public static Unit Configure(IServiceCollection services)
		{
			services.AddIdentity<IdentityUser, IdentityRole>()
					.AddEntityFrameworkStores<IdentityContext>();
			
			services.Configure<IdentityOptions>(options =>
			{
				// Password settings.
				options.Password.RequireDigit = true;
				options.Password.RequireLowercase = true;
				options.Password.RequireUppercase = true;
				options.Password.RequiredLength = 6;

				// Lockout settings.
				options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
				options.Lockout.MaxFailedAccessAttempts = 3;
				options.Lockout.AllowedForNewUsers = true;

				// User settings.
				options.User.AllowedUserNameCharacters =
					"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
				options.User.RequireUniqueEmail = false;
			});
			
			return Unit.Default;
		}
	}
}