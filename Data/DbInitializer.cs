using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BugTrackerGetIT.Models;

namespace BugTrackerGetIT.Data
{
	public static class DbInitializer
	{
		public static void Initialize(ApplicationDbContext context)
		{
			// Checks if database exists and all migrations are applied, if not perform this.
			context.Database.Migrate();

			// Criticality
			if (context.Criticality.Any())
			{
				return;
			}

			var criticalities = new[]
			{
					new Criticality {Id = 1, CriticalityName = "Failure"},
					new Criticality {Id = 2, CriticalityName = "Critical"},
					new Criticality {Id = 3, CriticalityName = "Not Critical"},
					new Criticality {Id = 4, CriticalityName = "Change Request"}
				};

			foreach (var c in criticalities)
			{
				context.Criticality.Add(c);
			}

			// Priority
			var priorities = new[]
			{
					new Priority {Id = 1, PriorityName = "Very High"},
					new Priority {Id = 2, PriorityName = "High"},
					new Priority {Id = 3, PriorityName = "Normal"},
					new Priority {Id = 4, PriorityName = "Low"}
				};

			foreach (var p in priorities)
			{
				context.Priority.Add(p);
			}

			// Status
			var status = new[]
			{
					new Status {Id = 1, StatusName = "New"},
					new Status {Id = 2, StatusName = "Open"},
					new Status {Id = 3, StatusName = "Resolved"},
					new Status {Id = 4, StatusName = "Closed"}
				};

			foreach (var s in status)
			{
				context.Status.Add(s);
			}

			context.SaveChanges();
		}
	}

}
