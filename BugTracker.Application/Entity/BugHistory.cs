namespace BugTracker.Application.Entity
{
	using System;

	public class BugHistory
	{
		public string Id { get; set; }

		public Bug Bug { get; set; }

		public string BugId { get; set; }

		public DateTime DateChanged { get; set; }

		public string Description { get; set; }

		public Status Status { get; set; }

		public byte StatusId { get; set; }

		public User User { get; set; }

		public string UserId { get; set; }
	}
}