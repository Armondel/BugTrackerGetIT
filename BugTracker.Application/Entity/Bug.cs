namespace BugTracker.Application.Entity
{
	using System;

	public class Bug
	{
		public string Id { get; set; }

		public DateTime DateCreated { get; set; }

		public string Preview { get; set; }

		public string Description { get; set; }

		public User User { get; set; }

		public string UserId { get; set; }

		public Status Status { get; set; }

		public byte StatusId { get; set; }

		public Priority Priority { get; set; }

		public byte PriorityId { get; set; }

		public Criticality Criticality { get; set; }

		public byte CriticalityId { get; set; }
	}
}