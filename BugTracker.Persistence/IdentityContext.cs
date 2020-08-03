namespace BugTracker.Persistence
{
	using BugTracker.Identity.Models;
	using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore;

	public sealed class IdentityContext : IdentityDbContext<ApplicationUser>
	{
		public IdentityContext(DbContextOptions<IdentityContext> options)
			: base(options)
		{
			Database.EnsureCreated();
		}
	}
}