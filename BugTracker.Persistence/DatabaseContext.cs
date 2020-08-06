namespace BugTracker.Persistence
{
	using BugTracker.Identity.Models;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore;

	public sealed class DatabaseContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
	{
		public DatabaseContext(DbContextOptions<DatabaseContext> options)
			: base(options)
		{
		}
	}
}