namespace BugTrackerGetIT.Core.BugHistory
{
    using System;
    using Bug;
    using BugTrackerGetIT.Core.Abstraction;

    public class BugHistory : DomainModel
    {
        public Bug Bug { get; set; }

        public string BugId { get; set; }

        public DateTimeOffset DateChanged { get; set; }

        public string Description { get; set; }

	    public Status Status { get; set; }

	    public byte StatusId { get; set; }

        public string UserId { get; set; }
    }
}