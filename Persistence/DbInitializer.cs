using Microsoft.EntityFrameworkCore;

namespace BugTrackerGetIT.Persistence
{
    public static class DbInitializer
	{
		public static void Initialize(ApplicationDbContext context)
		{
			// Checks if database exists and all migrations are applied, if not perform this.
			context.Database.Migrate();

			context.SaveChanges();
		}
	}

}
